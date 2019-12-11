using DayFive.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DaySeven.Model
{
    public class AmplifyingStack
    {
        public List<Amplifier> Amplifiers { get; }

        public AmplifyingStack(int count, IEnumerable<int> program)
        {
            Amplifiers = new List<Amplifier>();

            for (int i = 0; i < count; i++)
            {
                Amplifiers.Add(new Amplifier(program));
            }
        }

        public long Run(long input, IEnumerable<int> phaseSettingSequence, bool looping)
        {
            if (looping) return RunLooping(input, phaseSettingSequence);
            else return RunDirect(input, phaseSettingSequence);
        }

        public long RunDirect(long input, IEnumerable<int> phaseSettingSequence)
        {
            if (phaseSettingSequence.Count() != Amplifiers.Count)
                throw new ArgumentException($"Phase setting sequence is invalid");

            var output = long.MinValue;

            for (int i = 0; i < Amplifiers.Count; i++)
            {
                _ = Amplifiers[i].Run(new long[] { phaseSettingSequence.ElementAt(i), input });
                input = output = Amplifiers[i].Output;
            }

            return output;
        }

        public long RunLooping(long input, IEnumerable<int> phaseSettingSequence)
        {
            if (phaseSettingSequence.Count() != Amplifiers.Count)
                throw new ArgumentException($"Phase setting sequence is invalid");

            var queue = new Queue<Amplifier>(Amplifiers);
            var output = long.MinValue;
            var amplifierId = 0;

            var phaseSettings = phaseSettingSequence.ToArray();

            while (queue.Any())
            {
                var programInput = WriteProgramInput(amplifierId, input, phaseSettings);

                var amplifier = queue.Dequeue();
                var status = amplifier.Run(programInput);
                input = output = amplifier.Output;

                amplifierId = (amplifierId + 1) % 5;

                if (status == ProgramStatus.WaitingForInput) queue.Enqueue(amplifier);
            }

            return output;
        }

        public IEnumerable<long> WriteProgramInput(int ampliId, long input, int[] phaseSettings)
        {
            if (phaseSettings[ampliId] >= 0)
            {
                var phaseSetting = phaseSettings[ampliId];
                phaseSettings[ampliId] = int.MinValue;

                return new long[] { phaseSetting, input };
            }
            else return new long[] { input };
        }

        public (long output, IEnumerable<int> phaseSettings) Optimize(int input, bool looping)
        {
            var configurations = new List<(long output, IEnumerable<int> phaseSettings)>();
            var phaseSettingRange = GetPhaseSettingRange(looping);

            for (int i = phaseSettingRange[0]; i < phaseSettingRange[1]; i++)
            {
                for (int j = phaseSettingRange[0]; j < phaseSettingRange[1]; j++)
                {
                    for (int k = phaseSettingRange[0]; k < phaseSettingRange[1]; k++)
                    {
                        for (int l = phaseSettingRange[0]; l < phaseSettingRange[1]; l++)
                        {
                            for (int m = phaseSettingRange[0]; m < phaseSettingRange[1]; m++)
                            {
                                var phaseSettings = new int[] { i, j, k, l, m };

                                if (phaseSettings.Distinct().Count() == phaseSettings.Length)
                                {
                                    Reset();
                                    var output = Run(input, phaseSettings, looping);

                                    configurations.Add((output, phaseSettings));
                                }
                            }
                        }
                    }
                }
            }

            var bestOutput = configurations.OrderByDescending(c => c.output).First();

            return bestOutput;
        }

        private static int[] GetPhaseSettingRange(bool looping)
        {
            var range = new int[2];

            if (looping)
            {
                range[0] = 5;
                range[1] = 10;
            }
            else
            {
                range[0] = 0;
                range[1] = 5;
            }

            return range;
        }

        public void Reset()
        {
            foreach (var amplifier in Amplifiers)
            {
                amplifier.Reset();
            }
        }
    }
}
