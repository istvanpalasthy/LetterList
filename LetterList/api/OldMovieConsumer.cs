using System;
using System.Collections.Generic;
using System.Text;
using LetterList;

namespace LetterList
{
    class OldMovieConsumer : MovieConsumer
    {
        Movies film = new Movies();
        public OldMovieConsumer(string question) : base(question)
        {
        }


        public override string SuggestMovie(List<Movies> listofmovies)
        {
            return "You should probably see " + listofmovies[0].Name;
        }

    }
}
