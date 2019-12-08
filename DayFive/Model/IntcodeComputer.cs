using System;
using System.Collections.Generic;
using System.Linq;

namespace DayFive.Model
{
    public partial class IntcodeComputer
    {
        public IEnumerable<int> Program { get; }
        public List<int> Memory { get; set; }

        public Queue<int> Input { get; set; }
        public int InstructionPointer { get; set; }

        public IntcodeComputer(IEnumerable<int> program)
        {
            Program = program;
            Reset();
        }

        public ProgramStatus RunProgram(IEnumerable<int> input, ref int output)
        {
            if (!input.Any()) throw new ArgumentException($"Input must have at least one element!");

            var instructionCode = new InstructionCode(Memory[InstructionPointer]);

            foreach (var entry in input)
            {
                Input.Enqueue(entry);
            }

            while (instructionCode.Opcode != 99)
            {
                switch (instructionCode.Opcode)
                {
                    case 1:
                        OpcodeOne(instructionCode);
                        break;
                    case 2:
                        OpcodeTwo(instructionCode);
                        break;
                    case 3:
                        if (!Input.Any()) return ProgramStatus.WaitingForInput;
                        OpcodeThree();
                        break;
                    case 4:
                        output = OpcodeFour(instructionCode);
                        break;
                    case 5:
                        OpcodeFive(instructionCode);
                        break;
                    case 6:
                        OpcodeSix(instructionCode);
                        break;
                    case 7:
                        OpcodeSeven(instructionCode);
                        break;
                    case 8:
                        OpcodeHeigth(instructionCode);
                        break;
                    default:
                        break;
                }

                instructionCode = new InstructionCode(Memory[InstructionPointer]);
            }

            return ProgramStatus.Terminated;
        }

        public void FixInputMemory(int position, int value)
        {
            Memory[position] = value;
        }

        public void Reset()
        {
            Memory = new List<int>(Program);
            Input = new Queue<int>();
            InstructionPointer = 0;
        }

        public override string ToString()
        {
            return string.Join("\t", Memory);
        }
    }
}
