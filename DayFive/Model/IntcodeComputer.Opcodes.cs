using System;

namespace DayFive.Model
{
    public partial class IntcodeComputer
    {
        private void OpcodeOne_AddTwoNumbers(InstructionCode instruction)
        {
            var value = ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter)
                        + ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter);

            WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, value);

            InstructionPointer += 4;
        }

        private void OpcodeTwo_MultiplyTwoNumbers(InstructionCode instruction)
        {
            var value = ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter)
                        * ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter);

            WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, value);

            InstructionPointer += 4;
        }

        private void OpcodeThree_ReadInput(InstructionCode instruction)
        {
            WriteToMemoryAt(InstructionPointer + 1, instruction.FirstParameter, Input.Dequeue());

            InstructionPointer += 2;
        }

        private long OpcodeFour_ReturnOutput(InstructionCode instruction)
        {
            var output = ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter);

            InstructionPointer += 2;

            return output;
        }

        private void OpcodeFive_JumpIfTrue(InstructionCode instruction)
        {
            if (ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter) != 0)
                InstructionPointer = CheckPointer(ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter));
            else
                InstructionPointer += 3;
        }

        private void OpcodeSix_JumpIfFalse(InstructionCode instruction)
        {
            if (ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter) == 0)
                InstructionPointer = CheckPointer(ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter));
            else
                InstructionPointer += 3;
        }

        private void OpcodeSeven_LessThan(InstructionCode instruction)
        {
            if (ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter)
                < ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter))
                WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, 1);
            else
                WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, 0);

            InstructionPointer += 4;
        }

        private void OpcodeHeigth_AreEqual(InstructionCode instruction)
        {
            if (ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter)
               == ReadMemoryAtForMode(InstructionPointer + 2, instruction.SecondParameter))
                WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, 1);
            else
                WriteToMemoryAt(InstructionPointer + 3, instruction.ThirdParameter, 0);

            InstructionPointer += 4;
        }

        private void OpcodeNine_UpdateRelativeBase(InstructionCode instruction)
        {
            RelativeBase += CheckPointer(ReadMemoryAtForMode(InstructionPointer + 1, instruction.FirstParameter));

            InstructionPointer += 2;
        }

        private long ReadMemoryAtForMode(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return ReadMemoryAt(CheckPointer(Memory[pointer]));
            else if (mode == ParameterMode.Relative) return ReadMemoryAt(RelativeBase + CheckPointer(Memory[pointer]));
            else return ReadMemoryAt(pointer);
        }

        private int GetMemoryLocationForMode(int pointer, ParameterMode mode)
        {
            if (mode == ParameterMode.Position) return CheckPointer(Memory[pointer]);
            else if (mode == ParameterMode.Relative) return RelativeBase + CheckPointer(Memory[pointer]);
            else throw new ArgumentException("Immediate mode is invalid for writing to the memory.");
        }

        private int CheckPointer(long pointer)
        {
            return CheckMemoryValueIsInt(pointer);
        }

        private void WriteToMemoryAt(int pointer, ParameterMode mode, long value)
        {
            pointer = GetMemoryLocationForMode(pointer, mode);

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
