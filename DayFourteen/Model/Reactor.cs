using System;
using System.Collections.Generic;
using System.Text;

namespace DayFourteen.Model
{
    public class Reactor
    {
        public List<Reaction> Reactions { get; }

        public Reactor()
        {
            Reactions = new List<Reaction>();
        }
    }
}
