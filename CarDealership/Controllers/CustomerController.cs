using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using CarDealership.Models;
using CarDealership.Data;
using Microsoft.Data.SqlClient;

namespace CarDealership.Controllers
{
    public class CustomerController
    {
        private static CustomerContext customerContext = null;
      
        public static List<Customer> customers = new List<Customer>();
      
        public static string sessionID = null;

        public static List<Customer> customers = new List<Customer>();
        public static string sessionId;
        /// <summary>
        /// Safe Password Hashing w/ SHA512
        /// </summary>
        public static string HashString(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Random Number between 2 Endpoints
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Returns random jumble of letters with specified size and upper/lowercase
        /// </summary>
        /// <param name="size"></param>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        /// <summary>
        /// Makes a random password out of numbers and letters
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        /// <summary>
        /// Checks Email Validity
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Registers a customer
        /// </summary>
        public static void CreateCustomer(string name, DateTime birthDate, string password, string phoneNum, string email)
        {
            bool CustomerExists = customers.Any(c => c.name == name && c.email == email);
            Customer customer = new Customer(name, birthDate, password, phoneNum, email);
            if (!CustomerExists)
            {
                customers.Add(customer);
                using (customerContext = new CustomerContext())
                {
                    customerContext.customers.Add(customer);
                    customerContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Redo Password
        /// </summary>
        public static void UpdatePassword(string id, string oldPass, string newPass)
        {
            if (sessionID != null)
            {
                if (customers.Where(x => x.id == id).FirstOrDefault().Password == HashString(oldPass))
                {
                    try
                    {
                        customers.Where(x => x.id == id).FirstOrDefault().Password = newPass;

                        using (customerContext = new CustomerContext())
                        {
                            if (oldPass != null)
                            {
                                customerContext.Entry(oldPass).CurrentValues.SetValues(newPass);
                                customerContext.SaveChanges();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Username or password is incorrect");
                    }
                }
            }
        }

        /// <summary>
        /// Sends an email/offer about a car
        /// </summary>
        public static void SendEmail(string receiver, string subject, string message)
        {
            if (sessionID != null)
            {
                if (IsValidEmail(receiver))
                {
                    var sender = new MailAddress("cardealeritcareer@gmail.com");
                    var recipient = new MailAddress($"{receiver}");
                    const string fromPassword = "ugtjyktoeiphmvsv";
                    string subj = subject;
                    string body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(sender.Address, fromPassword)
                    };
                    using (var mail = new MailMessage(sender, recipient)
                    {
                        Subject = subj,
                        Body = body
                    })
                    {
                        smtp.Send(mail);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a car to your wishlist/favorite cars
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="car"></param>
        public static void AddToFavorite(Customer customer, Car car)
        {
            customer.favoritedCars.Add(car);

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Database = cardealership; Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into relaionFavourite (customerId,carId)" +
                                                "values (" + customer.id + ", " + car.id + ")";

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var carId = car.id;
                                    var customerId = customer.id;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                Console.WriteLine($"Exception: {eSql.Message}");
            }
        }

        /// <summary>
        /// Sends you an email to recover your password
        /// </summary>
        /// <param name="email"></param>
        public static void ForgottenPasswords(string email)
        {
            bool trueMail = customers.Any(c => c.email == email);
            if (trueMail)
            {
                string newPass = RandomPassword();
                CustomerController.customers.Where(c => c.email == email).FirstOrDefault().Password = newPass;
                SendEmail(email, "Password Recovery", $"Your new password is {newPass}, log in to your account and update it to whatever you want.");
            }
        }

        /// <summary>
        /// Creates an offer for a car
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="price"></param>
        /// <param name="manufDateStr"></param>
        /// <param name="horsePower"></param>
        /// <param name="kmDriven"></param>
        /// <param name="engineVolume"></param>
        /// <param name="info"></param>
        public static string CreateOffer(string brand, string model, double price, string manufDateStr, double horsePower, double kmDriven, double engineVolume, string info)
        {
            CarBrand carBrand = CarBrand.carBrands.Where(c => c.brand == brand && c.model == model).FirstOrDefault();
            Car car = new Car(carBrand, price, manufDateStr, horsePower, kmDriven,  engineVolume, info);
            Customer customer = customers.Where(c => c.name == name).FirstOrDefault();
            customer.publicOffers.Add(car);
            if (sessionID != null)
            {
                try
                {
                    CarBrand carBrand;
                    if (CarBrand.IsNew(brand, model))
                    {
                        carBrand = new CarBrand(brand, model, true);
                    }
                    else
                    {
                        carBrand = CarBrand.carBrands.Where(c => c.brand == brand && c.model == model).FirstOrDefault();
                    }
                    Car car = new Car(carBrand, price, manufDateStr, horsePower, kmDriven, engineVolume, info);
                    Customer customer = customers.Where(c => c.id == sessionID).FirstOrDefault();
                    car.owner = customer;
                    customer.publicOffers.Add(car);
                    return "Made an offer";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "Not logged in!";
        }

        public static string Login(string email, string password)
        {
            if (IsValidEmail(email))
            {
                sessionID = CustomerController.customers.Where(c => c.email == email && c.Password == HashString(password)).FirstOrDefault().id;
                return CustomerController.customers.Where(c => c.email == email && c.Password == HashString(password)).FirstOrDefault().id;
            }
            else Console.WriteLine("Invalid email or password");
            return ("Invalid email or password");
        }
    }
}
