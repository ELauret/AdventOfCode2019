using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTwo.Model
{
    public class IntcodeProgram
    {
        public List<int> Code{ get; set; }

        public IntcodeProgram(IEnumerable<int> code)
        {
            Code = code.ToList();
        }

        public void Run()
        {
            var position = 0;

            while (Code[position] != 99)
            {
                if (Code[position] == 1)
                {
                    Code[Code[position + 3]] = Code[Code[position + 1]] + Code[Code[position + 2]];
                }
                else if (Code[position] == 2)
                {
                    Code[Code[position + 3]] = Code[Code[position + 1]] * Code[Code[position + 2]];
                }

                position += 4;
            }
        }

        public void FixCode(int position, int value)
        {
            Code[position] = value;
        }
    }
}
