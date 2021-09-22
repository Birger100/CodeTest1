using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;

namespace SWAPI
{
    class Program
    {
        static MemoryCache cache;
        static void Main(string[] args)
        {
            //init cache 
            cache = new MemoryCache(new MemoryCacheOptions());

            var list = new List<int>() { 1,5,8,6,200,5,3 };
            foreach (var item in list)
            {
                Console.WriteLine($"id {item} name : {GetNameFromAPI(item)}"); 
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }


        private static string GetNameFromAPI(int id)
        {


            var cacheResult = (string)cache.Get(id);
            if (cacheResult != null)
                return cacheResult + "(Cache)";

            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"people/{id}", DataFormat.Json);

            var response = client.Get(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Id not found or other error";
            }else
            {
                var name = JsonConvert.DeserializeObject<SwapiPerson>(response.Content).name;
                cache.Set(id, name);
                return name;
            }
        }
    }
}
