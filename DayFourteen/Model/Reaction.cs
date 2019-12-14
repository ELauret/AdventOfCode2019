using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayFourteen.Model
{
    public class Reaction
    {
        public const string REACTION_PATTERN = @"(?<Reactants>(\d+ [A-Z]+,?\s?)+) => (?<Product>\d+ [A-Z]+)";

        public List<Chemical> Reactants { get; }
        public Chemical Product { get; set; }

        public Reaction(string reaction)
        {
            var reactionMatch = Regex.Match(reaction, REACTION_PATTERN);

            if (!reactionMatch.Success)
                throw new ArgumentException("Formating of the reaction is invalid.", nameof(reaction));

            Product = new Chemical(reactionMatch.Groups["Product"].Value);

            Reactants = new List<Chemical>();
            var reactants = reactionMatch.Groups["Reactants"].Value.Split(", ");
            foreach (var reactant in reactants)
            {
                Reactants.Add(new Chemical(reactant));
            }
        }
    }
}
