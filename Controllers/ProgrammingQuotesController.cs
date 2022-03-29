using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProgrammingQuotesController : Controller
    {

       public IActionResult Index()
        {
            return View();
        }

        public string GetQuote()
        {
            var quote = QuoteGenerator.ProgrammingQuote();
            return quote;
        }
    }
}

