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

        private int ProcessParameter(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return Memory[Memory[pointer]];
            else return Memory[pointer];
        }

        private void OpcodeOne(InstructionCode instruction)
        {
            Memory[Memory[InstructionPointer + 3]] =
                ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                + ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);

            InstructionPointer += 4;
        }

        private void OpcodeTwo(InstructionCode instruction)
        {
            Memory[Memory[InstructionPointer + 3]] =
                ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                * ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);

            InstructionPointer += 4;
        }

        private void OpcodeThree()
        {
            Memory[Memory[InstructionPointer + 1]] = Input.Dequeue();

            InstructionPointer += 2;
        }

        private int OpcodeFour(InstructionCode instruction)
        {
            var output = ProcessParameter(InstructionPointer + 1, instruction.FirstParameter);

            InstructionPointer += 2;

            return output;
        }

        private void OpcodeFive(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter) != 0)
                InstructionPointer = ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);
            else
                InstructionPointer += 3;
        }

        private void OpcodeSix(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter) == 0)
                InstructionPointer = ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);
            else
                InstructionPointer += 3;
        }

        private void OpcodeSeven(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                < ProcessParameter(InstructionPointer + 2, instruction.SecondParameter))
                Memory[Memory[InstructionPointer + 3]] = 1;
            else
                Memory[Memory[InstructionPointer + 3]] = 0;

            InstructionPointer += 4;
        }

        private void OpcodeHeigth(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
               == ProcessParameter(InstructionPointer + 2, instruction.SecondParameter))
                Memory[Memory[InstructionPointer + 3]] = 1;
            else
                Memory[Memory[InstructionPointer + 3]] = 0;

            InstructionPointer += 4;
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
