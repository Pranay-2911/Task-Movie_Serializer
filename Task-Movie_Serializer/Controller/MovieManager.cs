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

       
        public MovieManager()
        {
            movies = Serializer.DeserializeMovies();
            movieSize = CheckMoviesCount(movies);
        }


        public void ToSerialization()
        {
            Serializer.SerializeMovies(movies);
        }
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


        public  int GetMovieSize()
        {
            return movieSize;
        }

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

        public void AddMovies(int moviesId, string movieName, string movieGenre, int movieYear)
        {
            movies[movieSize] = new Movies(moviesId, movieName, movieGenre, movieYear);
            movieSize++;
        }

        public void ClearMovie()
        {
            movies = new Movies[5];
            movieSize = 0;
            Serializer.SerializeMovies(movies);
        }

        
    }
    
}
