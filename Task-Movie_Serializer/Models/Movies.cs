using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Movie_Serializer.Models
{
    internal class Movies
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public int MovieYear { get; set; }

        public Movies(int movieId, string movieName, string movieGenre, int movieYear)
        {
            MovieId = movieId;
            MovieName = movieName;
            MovieGenre = movieGenre;
            MovieYear = movieYear;
        }

        public string DisplayMovie()
        {
            return $"Movie ID : {MovieId} \n" +
                $"Movie Name : {MovieName} \n" +
                $"Movie Genre : {MovieGenre} \n" +
                $"Movie Year : {MovieYear} \n";
        }
    }
}
