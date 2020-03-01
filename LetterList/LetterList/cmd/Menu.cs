using LetterList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cmd
{
    public class Menu
    {

        Movies movie;
        internal Menu(Movies movieka)
        {
            movie = movieka;
        }
        private void showMenu(string[] menupoints)
        {
            Console.WriteLine("Letter List!");
            Console.WriteLine();
            foreach (string point in menupoints)
            {
                Console.WriteLine(point);
            }
        }
        string[] menupoints = new string[]
            {
                "(1) List Movies",
                "(2) Add a Movie",
                "(3) Remove a Movie",
                "(4) Change a Movie",
                "(5) Reccomend me a movie",
                "(6) Save current movie list",
                "(0) End Program"
            };
        private bool intinput;

        public void StartMenu()
        {
            while (true)
            {
                showMenu(menupoints);
                Console.WriteLine();
                Console.Write("Type in your choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        { 
                            movie.ListMovies();
                            break;
                        }
                    case "2":
                        {
                            intinput = true;
                            try
                            {
                                Console.WriteLine("Please enter the name of the movie: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Please enter the director of the movie: ");
                                string director = Console.ReadLine();
                                Console.WriteLine("Please enter the release date of the movie: ");
                                int releaseyear = int.Parse(Console.ReadLine());
                                movie.AddMovies(name, director, releaseyear);
                            }
                            catch (Exception WrongInputException)
                            {
                                Console.WriteLine("Wrong input");
                            }
                            break;
                        }
                    case "3":
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the movie you wish to delete: ");
                                string deletename = Console.ReadLine();
                                movie.RemoveMovies(deletename);
                                
                            }
                            catch (WrongInputException)
                            {
                                Console.WriteLine("There is no data with that movie");
                            }
                            break;
                        }
                    case "4":
                        {
                            try
                            {
                                Console.WriteLine("Enter the name of the movie you wish to update: ");
                                string updatename = Console.ReadLine();
                                Console.WriteLine("Enter the new name of the movie: ");
                                string newname = Console.ReadLine();
                                movie.UpdateMovie(updatename,newname);
                            }
                            catch (WrongInputException)
                            {
                                Console.WriteLine("There is no data with that name.") ;
                            }
                            break;
                        }
                    case "5":
                        {
                            try
                            {
                                Console.WriteLine("You will see three statement, if you feelany of them suits you, just type yes, and the magic will work it's way into your heart!");
                                Movies movie = new Movies();
                                movie.LoadCSV("movies.csv");
                                List<MovieConsumer> allMovieConsumers = new List<MovieConsumer> {
                                 new OldMovieConsumer("Bezzeg Kádár idejében! Még a kenyér is dolgozott."),
                                 new SeenItAll("Kizárólag Kinóban utazok."),
                                 new OnlyNewMovies("2018? Az már vagy 6 éve volt."),
                                 };
                                Console.WriteLine(allMovieConsumers[0].Question);
                                allMovieConsumers[0].Answer = bool.Parse(Console.ReadLine());

                                if (allMovieConsumers[0].Answer.Equals(true))
                                {
                                    Console.WriteLine(allMovieConsumers[0].SuggestMovie(movie.MovieList));
                                }
                                else if (allMovieConsumers[0].Answer.Equals(false))
                                {

                                    Console.WriteLine(allMovieConsumers[1].Question);
                                    allMovieConsumers[1].Answer = bool.Parse(Console.ReadLine());
                                    if (allMovieConsumers[1].Answer.Equals(true) || allMovieConsumers[1].Answer.Equals("yes"))
                                    {
                                        Console.WriteLine(allMovieConsumers[1].SuggestMovie(movie.MovieList));
                                    }
                                    else if (allMovieConsumers[1].Answer.Equals(false))
                                    {

                                        Console.WriteLine(allMovieConsumers[2].Question);
                                        allMovieConsumers[2].Answer = bool.Parse(Console.ReadLine());
                                        if (allMovieConsumers[2].Answer.Equals(true))
                                        {
                                            Console.WriteLine(allMovieConsumers[2].SuggestMovie(movie.MovieList));
                                        }
                                        else
                                        {
                                            Console.WriteLine("You should read a book.");
                                        }
                                    }
                                }
                               
                            }
                            catch (WrongInputException)
                            {
                                Console.WriteLine("Wrong Input");
                            } 
                            break;
                        }
                    case "6":
                        {
                            string name = Console.ReadLine();
                            string director = Console.ReadLine();
                            int releaseyear = int.Parse(Console.ReadLine());
                            movie.MakeCustomList(name, director, releaseyear, "customlist.csv");
                                break;
                        }
                        
                }
            }
        }
    }
}
