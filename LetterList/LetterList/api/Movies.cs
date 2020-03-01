using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LetterList
{
    class Movies
    {
        public string Name { get; private set; }
        public string Director { get; private set; }
        public int Releaseyear { get; private set; }
        public List<Movies> MovieList = new List<Movies>();
        public string fileName;

        public Movies()
        {

        }

        public Movies(string filename)
        {
            this.fileName = filename;
            LoadCSV(filename);
        }


        public Movies(string name, string director, int releaseyear)
        {
            this.Name = name;
            this.Director = director;
            this.Releaseyear = releaseyear;

        }

        public void LoadCSV(string filename = "movies.csv")
        {
           StreamReader sr = new StreamReader (filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] split = line.Split(",");
                string name = split[0];
                string director = split[1];
                int releaseyear = int.Parse(split[2]);

                Movies movies = new Movies(name, director, releaseyear);
                MovieList.Add(movies);
            }
            sr.Close();
        }

        public void MakeCustomList(string name, string director, int releaseyear, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, true))
                {
                    file.WriteLine(name + "," + director + "," + releaseyear);
                }
            }
            catch (Exception)
            {

                throw new FileNotFoundException("The file you was referring is not viable");
            }

        }

        public int GetNumberOfMovies()
        {
            return MovieList.Count;
        }

        public void AddMovies(string name, string director, int releaseyear)
        {
            Movies usermovie = new Movies(name, director, releaseyear);
            MovieList.Add(usermovie);
        }

        public void RemoveMovies(string deletename)
        {
            for (int i = 0; i < MovieList.Count; i++)
            {
                if (MovieList[i].Name == deletename)
                {
                    MovieList.Remove(MovieList[i]);
                }
                else
                {
                    throw new WrongInputException();
                }

            }
            ListMovies();

        }
        public override string ToString()
        {
            return $"Name: {this.Name}\tDirector: {this.Director}\tReleaseyear: {this.Releaseyear}{Environment.NewLine}";
        }

        public void ListMovies()
        {
            foreach (var item in MovieList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void UpdateMovie(string updatename, string newname)
        {
            for (int i = 0; i < MovieList.Count; i++)
            {
                if (MovieList[i].Name.Contains(updatename))
                {
                    MovieList[i].Name = newname;
                    break;
                }
                else
                {
                    throw new WrongInputException();
                }

            }
            ListMovies();
        }

        public int GetMovieCount()
        {
            return MovieList.Count;
        }

        public void MoviePrinter(int GetMovieCount)
        {
            Console.WriteLine(GetMovieCount);
        }

        public void MakeCustomList(string listname)
        {
            listname = Console.ReadLine();

        }
    }
}
