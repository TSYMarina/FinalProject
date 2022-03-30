using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinalProject.Models
{
    public class ProgrammingQuotes
    {
        [JsonPropertyName("QuoteText")]
        public string Quote { get; set; }
        public string Author { get; set; }
       
    }
}
