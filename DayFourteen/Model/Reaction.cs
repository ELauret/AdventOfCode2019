using System;
using System.Collections.Generic;
using System.Text;

namespace DayFourteen.Model
{
    public class Reaction
    {
        private static string REACTION_PATTERN = @"(?<Reactants>(?|\d+ [A-Z]+,?\s?)+) => (?<Product>\d+ [A-Z]+)";
        public List<Chemical> Reactants { get; }
        public Chemical Product { get; set; }

        public Reaction()
        {
            Reactants = new List<Chemical>();
        }
    }
}
