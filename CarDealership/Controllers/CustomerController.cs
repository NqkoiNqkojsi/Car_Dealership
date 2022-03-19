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
        private static CarDealershipContext customerContext = null;

      
        public static int sessionID { get; set; }

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
        /// <param name="email">potential email</param>
        /// <returns>true or false</returns>
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
        /// Checks Password Validity
        /// </summary>
        /// <param name="password">potential password</param>
        /// <returns>true or false</returns>
        public static bool IsValidPassword(string password)
        {
            try
            {
                const int MIN_LENGTH = 8;
                const int MAX_LENGTH = 15;

                if (password == null) return false;

                bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
                bool hasLetter = false;
                bool hasDecimalDigit = false;

                if (meetsLengthRequirements)
                {
                    foreach (char c in password)
                    {
                        if (char.IsLetter(c)) hasLetter = true;
                        else if (char.IsDigit(c)) hasDecimalDigit = true;
                    }
                }

                bool isValid = meetsLengthRequirements
                            && hasLetter
                            && hasDecimalDigit
                            ;
                return isValid;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Make a date from a string with 
        /// </summary>
        /// <param name="date">format=dd.M.yyy :"23.10.2003"</param>
        /// <returns>DateTime with only moth and year</returns>
        public static DateTime MakeBirthDate(string date)
        {
            try
            {
                string[] dateArray = date.Split('.');//split the month and year
                DateTime dateTime = new DateTime();//empty DateTime =1.1.0001
                dateTime = dateTime.AddDays(Convert.ToInt32(dateArray[0]) - 1);//add the days without the first
                dateTime = dateTime.AddMonths(Convert.ToInt32(dateArray[1]) - 1);//add the months without the first
                dateTime = dateTime.AddYears(Convert.ToInt32(dateArray[2]) - 1);//add the years without the first
                return dateTime;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Unable to parse '{0}'", date);
                return DateTime.MinValue;//at error return min value
            }
        }

        /// <summary>
        /// Registers a customer
        /// </summary>
        public static void CreateCustomer(string name, string birthDate, string password, string phoneNum, string email)
        {
            bool CustomerExists = Customer.customers.Any(c => c.name == name && c.Email == email);
            Customer customer = new Customer(name, CustomerController.MakeBirthDate(birthDate), password, phoneNum, email);
            sessionID = customer.id;
            if (!CustomerExists)
            {
                Customer.customers.Add(customer);
                using (customerContext = new CarDealershipContext())
                {
                    customerContext.customers.Add(customer);
                    customerContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Redo Password
        /// </summary>
        public static void UpdatePassword(int id, string oldPass, string newPass)
        {
            if (sessionID != 0)
            {
                if (Customer.customers.Where(x => x.id == id).FirstOrDefault().Password == HashString(oldPass))
                {
                    try
                    {
                        Customer.customers.Where(x => x.id == id).FirstOrDefault().Password = newPass;

                        using (customerContext = new CarDealershipContext())
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
            Console.WriteLine("Log in to update your password");
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
            else Console.WriteLine("Log in to send emails");
        }

        /// <summary>
        /// Adds a car to your wishlist/favorite cars
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="car"></param>
        public static void AddToFavorite(Car car)
        {
            if (sessionID != null)
            {
                Customer customer = Customer.customers.Where(c=>c.id==sessionID).FirstOrDefault();
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
            else Console.WriteLine("Log in to perform this operation");
        }

        /// <summary>
        /// Sends you an email to recover your password
        /// </summary>
        /// <param name="email"></param>
        public static void ForgottenPasswords(string email)
        {
            bool trueMail = Customer.customers.Any(c => c.Email == email);
            if (trueMail)
            {
                string newPass = RandomPassword();
                Customer.customers.Where(c => c.Email == email).FirstOrDefault().Password = newPass;
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
        /// <returns>a response message</returns>
        public static int CreateOffer(string brand, string model, double price, string manufDateStr, double horsePower, double kmDriven, double engineVolume, string info)
        {
            if (sessionID != 0)
            {
                try
                {
                    CarBrand carBrand;
                    if (CarBrand.IsNew(brand, model))
                    {
                        carBrand = new CarBrand(brand, model);
                    }
                    else
                    {
                        carBrand = CarBrand.carBrands.Where(c => c.brand == brand && c.model == model).FirstOrDefault();
                    }
                    Car car = new Car(carBrand, price, manufDateStr, horsePower, kmDriven, engineVolume, info);
                    Customer customer = Customer.customers.Where(c => c.id == sessionID).FirstOrDefault();
                    car.owner = customer;
  
                    Customer.customers.Where(c => c.id == sessionID).FirstOrDefault().publicOffers.Add(car);

                  
                    return car.id;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            return 0;
        }
        /// <summary>
        /// Method to log in a customer
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>response message</returns>
        public static string Login(string email, string password)
        {
            if (IsValidEmail(email))
            {
                if(Customer.customers.Any(c => c.Email == email))
                {
                    Customer customer = Customer.customers.First(c => c.Email == email);
                    if(customer.Password == HashString(password))
                    {
                        sessionID = customer.id;
                        return "Success";
                    }
                    return "Wrong password";
                }
                return "no profile";
            }
            else Console.WriteLine("Invalid email or password");
            return ("Invalid email or password");
        } 

        public static void RemoveOffer(int id)
        {
            if (sessionID != 0)
            {
                Customer customer = Customer.customers.Where(c => c.id == sessionID).FirstOrDefault();
                Car car = Car.approvedCars.Where(c => c.id == id).FirstOrDefault();
                customer.publicOffers.Remove(car);
                foreach (Customer cus in Customer.customers)
                {
                    if(cus.favoritedCars.Contains(car)) cus.favoritedCars.Remove(car);
                }
            }
            else Console.WriteLine("Log in to remove offers.");
        }

    }
}
