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

    class Obstacle: Place
    {

    }

    class Crate: Place
    {
        public int Value { get; set; }
    }

    class Robot
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

    }

    class Exit: Place
    {
        public Guid RobotId { get; set; }
    }
}
