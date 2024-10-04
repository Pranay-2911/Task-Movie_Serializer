using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task_Movie_Serializer.Models;
using Task_Movie_Serializer.MovieServices;

namespace Task_Movie_Serializer.Controller
{
    internal class MovieManager
    {

       static Movies[] movies;
        static int movieSize;

       
        public MovieManager()  //Constructo with Deserializer
        {
            movies = Serializer.DeserializeMovies();
            movieSize = CheckMoviesCount(movies);
        }


        public void ToSerialization() //serializer
        {
            Serializer.SerializeMovies(movies);
        }


        //Check and return the amount of moives present in the array
        public static int CheckMoviesCount(Movies[] movies)
        {
            int count = 0;

            foreach (Movies movie in movies)
            {
                if (movie != null)
                {
                    count++;
                }
            }
            return count;
        }


        //Returning the movieSize which is Movies availble in a array
        public  int GetMovieSize()
        {
            return movieSize;
        }


        //Printing the movies
        public  void PrintDetails()
        {
            for (int i = 0; i < movies.Length; i++)
            {
                if (movies[i] != null)
                {
                    Console.WriteLine(movies[i].DisplayMovie());
                }
            }
        }


        //Adding the movies
        public void AddMovies(int moviesId, string movieName, string movieGenre, int movieYear)
        {
            movies[movieSize] = new Movies(moviesId, movieName, movieGenre, movieYear);
            movieSize++;
        }


        //Claering the movies
        public void ClearMovie()
        {
            movies = new Movies[5];
            movieSize = 0;
            Serializer.SerializeMovies(movies);
        }

        
    }
    
}
