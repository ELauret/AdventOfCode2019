using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTwelve.Model
{
    public class JupiterSystem
    {
        public List<JupiterMoon> Moons { get; }
        public int TotalEnergy { get { return Moons.Sum(m => m.TotalEnergy); } }

        public JupiterSystem()
        {
            Moons = new List<JupiterMoon>();
        }

        public JupiterSystem(IEnumerable<string> moons) : this()
        {
            if (moons == null) throw new ArgumentNullException(nameof(moons));

            foreach (var moon in moons)
            {
                Moons.Add(new JupiterMoon(moon));
            }
        }

        public int UpdateSystem(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                UpdateMoonsVelocities();

                foreach (var moon in Moons)
                {
                    moon.UpdatePosition();
                }
            }

            return TotalEnergy;
        }

        public void UpdateMoonsVelocities()
        {
            var moonsQueue = new Queue<JupiterMoon>(Moons);

            while (moonsQueue.Count > 1)
            {
                var firstMoon = moonsQueue.Dequeue();

                foreach (var secondMoon in moonsQueue)
                {
                    ApplyGravity(firstMoon, secondMoon);
                }
            }
        }

        public static void ApplyGravity(JupiterMoon firstMoon, JupiterMoon secondMoon)
        {
            if (firstMoon == null || secondMoon == null) throw new ArgumentNullException("One of the two moon suplies is null.");

            if (firstMoon.Position.X < secondMoon.Position.X)
            {
                firstMoon.Velocity.X++;
                secondMoon.Velocity.X--;
            }
            else if (firstMoon.Position.X > secondMoon.Position.X)
            {
                firstMoon.Velocity.X--;
                secondMoon.Velocity.X++;
            }

            if (firstMoon.Position.Y < secondMoon.Position.Y)
            {
                firstMoon.Velocity.Y++;
                secondMoon.Velocity.Y--;
            }
            else if (firstMoon.Position.Y > secondMoon.Position.Y)
            {
                firstMoon.Velocity.Y--;
                secondMoon.Velocity.Y++;
            }

            if (firstMoon.Position.Z < secondMoon.Position.Z)
            {
                firstMoon.Velocity.Z++;
                secondMoon.Velocity.Z--;
            }
            else if (firstMoon.Position.Z > secondMoon.Position.Z)
            {
                firstMoon.Velocity.Z--;
                secondMoon.Velocity.Z++;
            }
        }
    }
}
