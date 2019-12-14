using System;
using System.Text.RegularExpressions;

namespace DayThree.Model
{
    public class Section
    {
        public Direction Direction { get; set; }
        public int Length { get; set; }

        public Section(string sectionString)
        {
            var match = Regex.Match(sectionString, @"(?<Direction>[URDL])(?<Length>\d+)");

            if (match == null)
            {
                Direction = Direction.Up;
                Length = 0;
            }

            try
            {
                Direction = GetDirection(match.Groups["Direction"].Value);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            Length = int.Parse(match.Groups["Length"].Value);
        }

        private Direction GetDirection(string direction)
        {
            if (!Regex.IsMatch(direction, @"[URDL]")) throw new ArgumentException($"{nameof(direction)} is invalid.");

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            return direction switch
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            {
                "U" => Direction.Up,
                "R" => Direction.Right,
                "D" => Direction.Down,
                "L" => Direction.Left,
            };
        }
    }
}
