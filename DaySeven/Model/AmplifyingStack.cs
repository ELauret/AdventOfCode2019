using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public int Run(int input, IEnumerable<int> phaseSettingSequence)
        {
            if (phaseSettingSequence.Count() != Amplifiers.Count)
                throw new ArgumentException($"Phase setting sequence is invalid");

            for (int i = 0; i < Amplifiers.Count; i++)
            {
                input = Amplifiers[i].Run(new int[] { phaseSettingSequence.ElementAt(i), input });
            }

            return input;
        }

        public (int output,IEnumerable<int> phaseSettings) Optimize(int input)
        {
            var outputs = new Dictionary<int, IEnumerable<int>>();
            var maxPhaseSetting = 5;

            for (int i = 0; i < maxPhaseSetting; i++)
            {
                for (int j = 0; j < maxPhaseSetting; j++)
                {
                    for (int k = 0; k < maxPhaseSetting; k++)
                    {
                        for (int l = 0; l < maxPhaseSetting; l++)
                        {
                            for (int m = 0; m < maxPhaseSetting; m++)
                            {
                                var phaseSettings = new int[] { i, j, k, l, m };

                                if (phaseSettings.Distinct().Count() == phaseSettings.Length)
                                {
                                    var output = Run(input, phaseSettings);

                                    Console.WriteLine($"Output: {output}\t" + string.Join("\t",phaseSettings));

                                    outputs.Add(output, phaseSettings);

                                }
                            }
                        }
                    }
                }
            }

            var bestOutput = outputs.OrderByDescending(o => o.Key).First();

            return (output: bestOutput.Key, phaseSettings: bestOutput.Value);
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
