using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace FinalProject
{
    public class Affirmation
    {
        public string AffirmationText { get; set; }
        public string Category { get; set; }
        public int ID { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
