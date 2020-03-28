﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(args[0]);

            if (response.IsSuccessStatusCode) //2xx
            {
                var html = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-zA-Z0-9]+@[a-z.]+");
                var matches = regex.Matches(html);
                foreach(var i in matches)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Koniec!");
        }
    }
}
