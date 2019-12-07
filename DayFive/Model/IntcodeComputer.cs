using System;
using DayFive.Model;
using System.Collections.Generic;
using System.Linq;

namespace DayFive.Model
{
    public class IntcodeComputer
    {
        public IEnumerable<int> Program { get; }
        public List<int> Memory { get; set; }

        public IntcodeComputer(IEnumerable<int> program)
        {
            Program = program;
            Memory = new List<int>(program);
        }

        public int RunProgram(IEnumerable<int> input)
        {
            if (!input.Any()) throw new ArgumentException($"Input musy have at least one element!");

            var instructionPointer = 0;
            var instructionCode = new InstructionCode(Memory[instructionPointer]);
            int output = int.MinValue;

            while (instructionCode.Opcode != 99)
            {
                switch (instructionCode.Opcode)
                {
                    case 1:
                        OpcodeOne(ref instructionPointer, instructionCode);
                        break;
                    case 2:
                        OpcodeTwo(ref instructionPointer, instructionCode);
                        break;
                    case 3:
                        OpcodeThree(ref instructionPointer, ref input);
                        break;
                    case 4:
                        output = OpcodeFour(ref instructionPointer, instructionCode);
                        break;
                    case 5:
                        OpcodeFive(ref instructionPointer, instructionCode);
                        break;
                    case 6:
                        OpcodeSix(ref instructionPointer, instructionCode);
                        break;
                    case 7:
                        OpcodeSeven(ref instructionPointer, instructionCode);
                        break;
                    case 8:
                        OpcodeHeigth(ref instructionPointer, instructionCode);
                        break;
                    default:
                        break;
                }

                instructionCode = new InstructionCode(Memory[instructionPointer]);
            }

            return output;
        }

        private int ProcessParameter(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return Memory[Memory[pointer]];
            else return Memory[pointer];
        }

        private void OpcodeOne(ref int pointer, InstructionCode instruction)
        {
            Memory[Memory[pointer + 3]] =
                ProcessParameter(pointer + 1, instruction.FirstParameter)
                + ProcessParameter(pointer + 2, instruction.SecondParameter);

            pointer += 4;
        }

        private void OpcodeTwo(ref int pointer, InstructionCode instruction)
        {
            Memory[Memory[pointer + 3]] =
                ProcessParameter(pointer + 1, instruction.FirstParameter)
                * ProcessParameter(pointer + 2, instruction.SecondParameter);

            pointer += 4;
        }

        private void OpcodeThree(ref int pointer, ref IEnumerable<int> input)
        {
            Memory[Memory[pointer + 1]] = input.ElementAt(0);

            var count = input.Count();
            if (count > 1) input = input.TakeLast(count - 1);

            pointer += 2;
        }

        private int OpcodeFour(ref int pointer, InstructionCode instruction)
        {
            var output = ProcessParameter(pointer + 1, instruction.FirstParameter);

            pointer += 2;

            return output;
        }

        private void OpcodeFive(ref int pointer, InstructionCode instruction)
        {
            if (ProcessParameter(pointer + 1, instruction.FirstParameter) != 0)
                pointer = ProcessParameter(pointer + 2, instruction.SecondParameter);
            else
                pointer += 3;
        }

        private void OpcodeSix(ref int pointer, InstructionCode instruction)
        {
            if (ProcessParameter(pointer + 1, instruction.FirstParameter) == 0)
                pointer = ProcessParameter(pointer + 2, instruction.SecondParameter);
            else
                pointer += 3;
        }

        private void OpcodeSeven(ref int pointer, InstructionCode instruction)
        {
            if (ProcessParameter(pointer + 1, instruction.FirstParameter)
                < ProcessParameter(pointer + 2, instruction.SecondParameter))
                Memory[Memory[pointer + 3]] = 1;
            else
                Memory[Memory[pointer + 3]] = 0;

            pointer += 4;
        }

        private void OpcodeHeigth(ref int pointer, InstructionCode instruction)
        {
            if (ProcessParameter(pointer + 1, instruction.FirstParameter)
               == ProcessParameter(pointer + 2, instruction.SecondParameter))
                Memory[Memory[pointer + 3]] = 1;
            else
                Memory[Memory[pointer + 3]] = 0;

            pointer += 4;
        }

        public void FixInputMemory(int position, int value)
        {
            Memory[position] = value;
        }

        public void Reset()
        {
            Memory = new List<int>(Program);
        }

        public override string ToString()
        {
            return string.Join("\t", Memory);
        }
    }
}
