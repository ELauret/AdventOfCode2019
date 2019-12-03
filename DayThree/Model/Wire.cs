using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayThree.Model
{
    public class Wire
    {
        public List<Point> Path { get; }

        public Wire()
        {
            Path = new List<Point>
            {
                new Point(0, 0)
            };
        }

        public Wire(MatchCollection sections) : this()
        {
            if (sections == null) throw new ArgumentNullException(nameof(sections));

            foreach (Match sectionString in sections)
            {
                AddSection(new Section(sectionString.Value));
            }
        }

        public Wire(string sections) : this(Regex.Matches(sections, @"[URDL]\d+")) { }

        public void AddSection(Section section)
        {
            if (section == null) throw new ArgumentNullException(nameof(section));

            var sectionOrigin = Path.Last();

            for (int i = 0; i < section.Length; i++)
            {
                var p = new Point(sectionOrigin);

                switch (section.Direction)
                {
                    case Direction.Up:
                        p.Y += i + 1;
                        break;
                    case Direction.Right:
                        p.X += i + 1;
                        break;
                    case Direction.Down:
                        p.Y -= i + 1;
                        break;
                    default:
                        p.X -= i + 1;
                        break;
                }

                if (p.StepsToReachPoint == 0)
                {
                    p.StepsToReachPoint = sectionOrigin.StepsToReachPoint + i + 1;
                    Path.Add(p);
                }
            }
        }

        public List<Point> GetListOfIntersectionsWith(Wire other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            var intersectionPoints = Path.Intersect(other.Path).ToList();
            return intersectionPoints;
        }
    }
}