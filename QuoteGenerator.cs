using System;
using System.Net.Http;
using FinalProject.Models;
using Newtonsoft.Json.Linq;

namespace FinalProject
{
    public class QuoteGenerator
    {
        public static string ProgrammingQuote()
        {
            var client = new HttpClient();
            var apiURL = "https://programming-quotes-api.herokuapp.com/Quotes?count=1"; 
            
            var apiResponse = client.GetStringAsync(apiURL).Result;
            return apiResponse;
            //var apiQuote = JObject.Parse(apiResponse).GetValue("quote").ToString();
         
           
            
        }

       
        
    }
}
