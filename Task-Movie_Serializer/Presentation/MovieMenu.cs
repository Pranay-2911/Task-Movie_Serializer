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
        static MovieManager manager = new MovieManager();
        public static void GetMovieMenu()
        {
            
            Console.WriteLine("============= Welcome To Movies App =============");
            Console.WriteLine();

            bool check = true;

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
                        AddMovie();
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
            static void AddMovie()
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

            static void ClearMovie()
            {
               manager.ClearMovie();
                Console.WriteLine("All Movies Cleared.");
            }

            static void Serializer(ref bool check)
            {
                manager.ToSerialization();
                check = false;
                Console.WriteLine("Saved Succesfully");
            }
        }
    }
}
