using System.Collections.Generic;
using System.Linq;

namespace DayTwo.Model
{
    public class IntcodeComputer
    {
        public List<int> Memory { get; set; }

        public IntcodeComputer(IEnumerable<int> program)
        {
            Memory = program.ToList();
        }

        public void RunProgram()
        {
            var instructionPointer = 0;

            while (Memory[instructionPointer] != 99)
            {
                if (Memory[instructionPointer] == 1)
                {
                    Memory[Memory[instructionPointer + 3]] = Memory[Memory[instructionPointer + 1]] + Memory[Memory[instructionPointer + 2]];
                }
                else if (Memory[instructionPointer] == 2)
                {
                    Memory[Memory[instructionPointer + 3]] = Memory[Memory[instructionPointer + 1]] * Memory[Memory[instructionPointer + 2]];
                }

                instructionPointer += 4;
            }
        }

        public void FixInputMemory(int position, int value)
        {
            Memory[position] = value;
        }

        public void Reset()
        {
            Memory = new List<int>();
        }
    }
}
