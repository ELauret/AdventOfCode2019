using DayFive.Model;
using System.Collections.Generic;

namespace DaySeven.Model
{
    public class Amplifier
    {
        public int PhaseSetting { get; set; }
        public int InputSignale { get; set; }
        public int Output { get; private set; }
        public IntcodeComputer Engine { get; private set; }

        public Amplifier(IEnumerable<int> program)
        {
            Engine = new IntcodeComputer(program);
        }

        public void Reset()
        {
            Engine.Reset();
        }

        public ProgramStatus Run(IEnumerable<long> input, ref long output)
        {
            return Engine.RunProgram(input, ref output);
        }
    }
}
