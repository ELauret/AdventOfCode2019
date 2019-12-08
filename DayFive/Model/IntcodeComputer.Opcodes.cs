using System;
using System.Collections.Generic;
using System.Text;

namespace DayFive.Model
{
    public partial class IntcodeComputer
    {
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

        private int ProcessParameter(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return Memory[Memory[pointer]];
            else return Memory[pointer];
        }
    }
}
