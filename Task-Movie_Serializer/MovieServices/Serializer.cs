using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Movie_Serializer.Models;

namespace Task_Movie_Serializer.MovieServices
{
    class Serializer
    {
        //Path where the account.json is stored
        private static string filePath = ConfigurationManager.AppSettings["MyPath"].ToString();

        //Deserialization
        public static Movies[] DeserializeMovies()
        {

            if (File.Exists(filePath))
            {
                string moiviesData = File.ReadAllText(filePath);

                return JsonSerializer.Deserialize<Movies[]>(moiviesData);
            }
            return new Movies[5];
        }

        //Serialization
        public static void SerializeMovies(Movies[] movies)
        {

            string jsonData = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
