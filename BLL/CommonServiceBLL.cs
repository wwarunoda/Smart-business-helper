using PizzaBox_Receipt_Management.DML;
using PizzaBox_Receipt_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox_Receipt_Management.BLL
{
    public class CommonServiceBLL : IDisposable
    {
        public decimal GetDiscountedPrice(decimal Price, decimal Percentage)
        {
            decimal remainingPercentage = 100 - Percentage;
            decimal finalPrice = Price * remainingPercentage * Convert.ToDecimal(0.01); 
            decimal a=  RoundUp(finalPrice, 2);
            return a;
        }

        public static decimal RoundUp(decimal input, int places)
        {
            decimal multiplier = Convert.ToDecimal(Math.Pow(10, Convert.ToDouble(places)));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
        public CommonDataResponse GetMasterData()
        {
            using (CommonServiceDAL masterDal = new CommonServiceDAL())
            {
                return masterDal.GetMasterData();
            }
        }

        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
