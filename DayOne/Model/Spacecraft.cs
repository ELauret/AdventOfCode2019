using System.Collections.Generic;
using System.Linq;

namespace DayOne.Model
{
    public class Spacecraft
    {
        public List<Module> Modules { get; set; }
        public int RequiredFuel { get { return Modules.Sum(m => m.RequiredFuel); } }

        public Spacecraft()
        {
            Modules = new List<Module>();
        }
    }
}
