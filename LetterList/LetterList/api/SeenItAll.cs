using System;
using System.Collections.Generic;
using System.Text;

namespace LetterList
{
    class SeenItAll : MovieConsumer
    {
        Movies film = new Movies();
        public SeenItAll(string question) : base(question)
        {
        }

        public override string SuggestMovie(List<Movies> MovieList)
        {
            return MovieList[1].Name;
        }
    }
}
