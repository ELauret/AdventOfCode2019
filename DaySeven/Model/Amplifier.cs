using DayFive.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

        public int Run(int phaseSetting, int inputSignal)
        {
            Output = Engine.RunProgram(new int[] { phaseSetting, inputSignal });
            return Output;
        }
    }
}
