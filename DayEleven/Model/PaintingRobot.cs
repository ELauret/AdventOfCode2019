using DayFive.Model;
using System;
using System.Collections.Generic;

namespace DayEleven.Model
{
    public class PaintingRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public RobotOrientation Orientation { get; set; }
        public IntcodeComputer Brain { get; set; }

        public PaintingRobot(IEnumerable<long> program)
        {
            Orientation = RobotOrientation.North;
            Brain = new IntcodeComputer(program);
        }

        public void PaintHull(Hull hull, PaintColor startingColor)
        {
            var status = Brain.RunProgram(new long[] { (long)startingColor }); ;

            while (status == ProgramStatus.WaitingForInput)
            {
                var color = (PaintColor)Enum.ToObject(typeof(PaintColor), Brain.Output.Dequeue());
                var direction = (RobotDirection)Enum.ToObject(typeof(RobotDirection), Brain.Output.Dequeue());

                PaintPanel(hull, color);
                Move(direction);

                color = hull.GetPanel(X, Y)?.Color ?? PaintColor.Black;
                status = Brain.RunProgram(new long[] { (long)color });
            }
        }

        public void PaintPanel(Hull hull, PaintColor color)
        {
            var panel = hull.GetPanel(X, Y) ?? hull.AddPanel(X, Y);
            panel.Color = color;
        }

        public void Move(RobotDirection direction)
        {
            switch (Orientation)
            {
                case RobotOrientation.North:
                    if (direction == RobotDirection.TurnLeft)
                    {
                        X--;
                        Orientation = RobotOrientation.West;
                    }
                    else
                    {
                        X++;
                        Orientation = RobotOrientation.East;
                    }
                    break;
                case RobotOrientation.East:
                    if (direction == RobotDirection.TurnLeft)
                    {
                        Y++;
                        Orientation = RobotOrientation.North;
                    }
                    else
                    {
                        Y--;
                        Orientation = RobotOrientation.South;
                    }
                    break;
                case RobotOrientation.South:
                    if (direction == RobotDirection.TurnLeft)
                    {
                        X++;
                        Orientation = RobotOrientation.East;
                    }
                    else
                    {
                        X--;
                        Orientation = RobotOrientation.West;
                    }
                    break;
                case RobotOrientation.West:
                    if (direction == RobotDirection.TurnLeft)
                    {
                        Y--;
                        Orientation = RobotOrientation.South;
                    }
                    else
                    {
                        Y++;
                        Orientation = RobotOrientation.North;
                    }
                    break;
                default:
                    throw new NotSupportedException("There can only be four orientations for the robot.");
            }
        }
    }
}
