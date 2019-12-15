using FourLeggedHead.Model;
using System.Collections.Generic;
using System.Linq;

namespace DaySeven.Model
{
    public class Amplifier
    {
        public int PhaseSetting { get; set; }
        public int InputSignale { get; set; }
        public long Output { get; private set; }
        public IntcodeComputer Engine { get; private set; }

        public Amplifier(IEnumerable<int> program)
        {
            Engine = new IntcodeComputer(program);
        }

        public void Reset()
        {
            Engine.Reset();
        }

        public ProgramStatus Run(IEnumerable<long> input)
        {
            var programStatus = Engine.RunProgram(input);
            Output = Engine.Output.Last();
            return programStatus;
        }
    }
}
