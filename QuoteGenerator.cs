using System;
using System.Net.Http;
using FinalProject.Models;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Cryptography;

namespace FinalProject
{
    public class QuoteGenerator
    {
        public static string ProgrammingQuote()
        {
            var client = new HttpClient();
            var apiURL = "https://programming-quotes-api.herokuapp.com/Quotes?count=200";

            var apiResponse = client.GetStringAsync(apiURL).Result;
            int r = RandomNumberGenerator.GetInt32(200);
            var author = JArray.Parse(apiResponse)[r]["author"].ToString();
            var line = JArray.Parse(apiResponse)[r]["en"].ToString();
            
            var quote = $"\"{ line}\" - By { author }";
            return quote;
        }
    }
}
