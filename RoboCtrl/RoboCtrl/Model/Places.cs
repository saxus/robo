using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCtrl.Model
{
    class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Place
    {
        public Location Location { get; set; }
    }

    class Obstacle : Place
    {
        public override string ToString() => "#";
    }

    class Crate : Place
    {
        public int Value { get; set; }

        public override string ToString() => "$";
    }

    class Robot: Place
    {
        public Location Location { get; set; }

        public Guid Id { get; set; }

        public int Heading { get; set; }
        public int ValueCreated { get; set; }
        public int StepCompleted { get; set; }
        public int TurnCompleted { get; set; }
        public int State { get; set; }
        public int TurningTime { get; set; }
        public int MovingTime { get; set; }

        public override string ToString()
        {
            switch (Heading)
            {
                case 0: return "@";
                case 1: return "@";
                case 2: return "@";
                case 3: return "@";
                default: throw new Exception("heading szar");
            }
        }
    }

    class Exit : Place
    {
        public Guid RobotId { get; set; }
        public override string ToString() => ".";

    }
}
