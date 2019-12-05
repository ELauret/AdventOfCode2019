using DayFive.Model;
using System.Collections.Generic;
using System.Linq;

namespace DayFive.Model
{
    public class IntcodeComputer
    {
        public List<int> Memory { get; set; }

        public IntcodeComputer(IEnumerable<int> program)
        {
            Memory = program.ToList();
        }

        public void RunProgram(int input)
        {
            var instructionPointer = 0;
            var instructionCode = new InstructionCode(Memory[instructionPointer]);

            while (instructionCode.Opcode != 99)
            {
                switch (instructionCode.Opcode)
                {
                    case 1:
                        OpcodeOne(ref instructionPointer,
                            instructionCode.FirstParameter, instructionCode.SecondParameter);
                        break;
                    case 2:
                        OpcodeTwo(ref instructionPointer,
                            instructionCode.FirstParameter, instructionCode.SecondParameter);
                        break;
                    case 3:
                        OpcodeThree(ref instructionPointer, input);
                        break;
                    case 4:
                        System.Console.WriteLine(OpcodeFour(ref instructionPointer, instructionCode.FirstParameter));
                        break;
                    default:
                        break;
                }

                instructionCode = new InstructionCode(Memory[instructionPointer]);
            }
        }

        private int ProcessParameter(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return Memory[Memory[pointer]];
            else return Memory[pointer];
        }

        private void OpcodeOne(ref int pointer,
            ParameterMode firstParameterMode, ParameterMode secondParameterMode)
        {
            Memory[Memory[pointer + 3]] =
                ProcessParameter(pointer + 1, firstParameterMode)
                + ProcessParameter(pointer + 2, secondParameterMode);

            pointer += 4;
        }

        private void OpcodeTwo(ref int pointer,
            ParameterMode firstParameterMode, ParameterMode secondParameterMode)
        {
            Memory[Memory[pointer + 3]] =
                ProcessParameter(pointer + 1, firstParameterMode)
                * ProcessParameter(pointer + 2, secondParameterMode);

            pointer += 4;
        }

        private void OpcodeThree(ref int pointer, int input)
        {
            Memory[Memory[pointer + 1]] = input;

            pointer += 2;
        }

        private int OpcodeFour(ref int pointer, ParameterMode firstParameterMode)
        {
            var output = ProcessParameter(pointer + 1, firstParameterMode);

            pointer += 2;

            return output;
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
