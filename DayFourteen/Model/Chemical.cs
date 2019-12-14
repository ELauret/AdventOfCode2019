using System;
using System.Text.RegularExpressions;

namespace DayFourteen.Model
{
    public class Chemical
    {
        public static string CHEMICAL_PATTERN = @"(?<Quantity>\d+) (?<Type>[A-Z]+)";

        public string Type { get; set; }
        public int Quantity { get; set; }

        public Chemical(string chemical)
        {
            var match = Regex.Match(chemical, CHEMICAL_PATTERN);

            if (!match.Success)
                throw new ArgumentException("Formating of the chemical is invalid.", nameof(chemical));

            Quantity = int.Parse(match.Groups["Quantity"].Value);
            Type = match.Groups["Type"].Value;
        }
    }
}
