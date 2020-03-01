using cmd;
using System;
using System.Collections.Generic;

namespace LetterList
{
    class Program
    {

        static void Main(string[] args)
        {

            Movies movies = new Movies("movies.csv");
            Menu menuke = new Menu(movies);
            menuke.StartMenu();


            

            
        }
    }
}
