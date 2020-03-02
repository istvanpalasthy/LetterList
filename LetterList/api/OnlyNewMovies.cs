using System;
using System.Collections.Generic;
using System.Text;

namespace LetterList
{
    class OnlyNewMovies : MovieConsumer
    {
        Movies film = new Movies();
        public OnlyNewMovies(string question) : base(question)
        {
        }

        public override string SuggestMovie(List<Movies> MovieList)
        {
            return MovieList[2].Name;
        }
    }
}
