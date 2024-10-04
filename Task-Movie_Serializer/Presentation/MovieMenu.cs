using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Movie_Serializer.Controller;
using Task_Movie_Serializer.Models;

namespace Task_Movie_Serializer.Presentation
{
    internal class MovieMenu
    {
        static MovieManager manager = new MovieManager(); //creating a static object of manager class
        public static void GetMovieMenu()
        {
            
            Console.WriteLine("============= Welcome To Movies App =============");
            Console.WriteLine();

            bool check = true;


            //TO perform a operations
            while (check)
            {
                Console.WriteLine("============== Operation ==============");
                Console.WriteLine($"1. Display Movies \n" +
                    $"2. Add Movies \n" +
                    $"3. Clear All \n" +
                    $"4. Exit \n");

                int choice = int.Parse(Console.ReadLine());
                Switches(choice, ref check);

            }

            static void Switches(int choice, ref bool check)
            {
                switch (choice)
                {
                    case 1:
                        DisplayMovie();

                        break;
                    case 2:
                        CheckMovieList();
                        break;
                    case 3:
                        ClearMovie();
                        break;
                    case 4:
                        Serializer(ref check);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }


            //display movies by taking a obj of manager
            static void DisplayMovie()
            {
                if (manager.GetMovieSize() == 0)
                {
                    Console.WriteLine("NO Movies Found!... Pls Enter the Movie");
                }
                else
                {

                    manager.PrintDetails();
                }
            }

            
            //check that wheather to add a movies list is full or not
            static void CheckMovieList()
            {
                if (manager.GetMovieSize() < 5)
                {
                    AddMovies();
                }
                else
                {

                    Console.WriteLine("Your Movie list is full");
                    Console.WriteLine();
                }
            }
            //Adding movies by Taking obj of manager
            static void AddMovies()
            {
                Console.WriteLine("Enter the Movie ID");
                int moviesId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Movie Name");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter the Movie Genre");
                string movieGenre = Console.ReadLine();
                Console.WriteLine("Enter the Movie Year");
                int movieYear = int.Parse(Console.ReadLine());

               manager.AddMovies(moviesId, movieName, movieGenre, movieYear);

                manager.ToSerialization();
                Console.WriteLine("Movie Added Succesfully");

            }


            //Clearing all movies by taking object og manager
            static void ClearMovie()
            {
               manager.ClearMovie();
                Console.WriteLine("All Movies Cleared.");
            }


            //Serializer
            static void Serializer(ref bool check)
            {
                manager.ToSerialization();
                check = false;
                Console.WriteLine("Saved Succesfully");
            }
        }
    }
}
