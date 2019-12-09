using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayFive.Model
{
    public partial class IntcodeComputer
    {
        private void OpcodeOne_AddTwoNumbers(InstructionCode instruction)
        {
            var value = ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                        + ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);

            WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), value);

            InstructionPointer += 4;
        }

        private void OpcodeTwo_MultiplyTwoNumbers(InstructionCode instruction)
        {
            var value = ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                        * ProcessParameter(InstructionPointer + 2, instruction.SecondParameter);

            WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), value);

            InstructionPointer += 4;
        }

        private void OpcodeThree_ReadInput(InstructionCode instruction)
        {
            if (instruction.FirstParameter == ParameterMode.Position)
            {
                WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 1]), Input.Dequeue());
            }
            else if (instruction.FirstParameter == ParameterMode.Relative)
            {
                WriteToMemoryAt(RelativeBase + CheckPointer(Memory[InstructionPointer + 1]), Input.Dequeue());
            }

            InstructionPointer += 2;
        }

        private long OpcodeFour_ReturnOutput(InstructionCode instruction)
        {
            var output = ProcessParameter(InstructionPointer + 1, instruction.FirstParameter);

            InstructionPointer += 2;

            return output;
        }

        private void OpcodeFive_JumpIfTrue(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter) != 0)
                InstructionPointer = CheckPointer(ProcessParameter(InstructionPointer + 2, instruction.SecondParameter));
            else
                InstructionPointer += 3;
        }

        private void OpcodeSix_JumpIfFalse(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter) == 0)
                InstructionPointer = CheckPointer(ProcessParameter(InstructionPointer + 2, instruction.SecondParameter));
            else
                InstructionPointer += 3;
        }

        private void OpcodeSeven_LessThan(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
                < ProcessParameter(InstructionPointer + 2, instruction.SecondParameter))
                WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), 1);
            else
                WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), 0);

            InstructionPointer += 4;
        }

        private void OpcodeHeigth_AreEqual(InstructionCode instruction)
        {
            if (ProcessParameter(InstructionPointer + 1, instruction.FirstParameter)
               == ProcessParameter(InstructionPointer + 2, instruction.SecondParameter))
                WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), 1);
            else
                WriteToMemoryAt(CheckPointer(Memory[InstructionPointer + 3]), 0);

            InstructionPointer += 4;
        }

        private void OpcodeNine_UpdateRelativeBase(InstructionCode instruction)
        {
            RelativeBase += CheckPointer(ProcessParameter(InstructionPointer + 1,instruction.FirstParameter));

            InstructionPointer += 2;
        }

        private long ProcessParameter(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return ReadMemoryAt(CheckPointer(Memory[pointer]));
            else if (mode == ParameterMode.Relative) return ReadMemoryAt(RelativeBase + CheckPointer(Memory[pointer]));
            else return ReadMemoryAt(pointer);
        }

        private int CheckPointer(long pointer)
        {
            return CheckMemoryValueIsInt(pointer);
        }

        private void WriteToMemoryAt(int pointer, long value)
        {
            var memorySize = Memory.Count;

            if (pointer >= memorySize)
            {
                for (int i = 0; i < pointer + 1 - memorySize; i++)
                {
                    Memory.Add(0);
                }
            }

            Memory[pointer] = value;
        }

        private long ReadMemoryAt(int pointer)
        {
            var memorySize = Memory.Count;

            if (pointer >= memorySize)
            {
                for (int i = 0; i < pointer + 1 - memorySize; i++)
                {
                    Memory.Add(0);
                }
            }

            return Memory[pointer];
        }
    }
}
