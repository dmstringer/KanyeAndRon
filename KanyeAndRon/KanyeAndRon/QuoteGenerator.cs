using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KanyeAndRon
{
    public class QuoteGenerator
    {
        static HttpClient client = new HttpClient();
        public static void KanyeQuote()
        {
            var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;
            // The response has a name/value pair where the quote is called 'quote'
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Kanye: {kanyeQuote}");
        }

        public static void RonQuote()
        {
            var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            // The return is different, the ron api returns a single element array with the quote in it,
            // We need to take out the array brackets in the array
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Ron: {ronQuote}");
        }
    }
}
