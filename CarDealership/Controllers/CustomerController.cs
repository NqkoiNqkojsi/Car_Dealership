using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.Security.Cryptography;
using System.Net.Mail;

namespace CarDealership.Controllers
{
    public class CustomerController
    {
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
        /// Checks Email Validity
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        static List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Registers a customer
        /// </summary>
        public static void CreateCustomer(string name, DateTime birthDate, string password, string phoneNum, string email)
        {
            Customer customer = new Customer(name, birthDate, password, phoneNum, email);
            customers.Add(customer);
        }

        /// <summary>
        /// Redo Password
        /// </summary>
        public static void UpdatePassword(string id, string oldPass, string newPass)
        {
            if (customers.Where(x => x.id == id).FirstOrDefault().Password == HashString(oldPass))
            {
                try
                {
                    customers.Where(x => x.id == id).FirstOrDefault().Password = newPass;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Username or password is incorrect");
                }
            }
        }

        /// <summary>
        /// Sends an email/offer about a car
        /// </summary>
        public static void SendEmail(string receiver, string subject, string message)
        {

            string sender = "CarDealer@gmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(sender);
            mail.To.Add(receiver);
            mail.Subject = subject;
            mail.Body = message;

            Smtp.Port = 587;
            Smtp.UseDefaultCredentials = true;

            try
            {
                Smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to send message: {0}",
                    ex.ToString());
            }
        }


    }
}
