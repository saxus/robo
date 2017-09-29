using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCtrl.Model
{
    class WarehouseState
    {
        public Place[,] matrix;
        public WarehouseStateJson json;
        public int w;
        public int h;
        public Robot Robot { get; set; }


        public WarehouseState(WarehouseStateJson json)
        {
            this.json = json;

            w = json.Size.Width;
            h = json.Size.Height;
            matrix = new Place[w, h];

            foreach (var it in json.Obstacles)
            {
                matrix[it.Location.X, it.Location.Y] = it;
            }

            foreach (var it in json.Crates)
            {
                matrix[it.Location.X, it.Location.Y] = it;
            }

            // XXX
            matrix[json.Exit.Location.X, json.Exit.Location.Y] = json.Exit;

            Robot = new Robot();
            Robot.StepCompleted = json.Robot.StepCompleted;
            Robot.TurnCompleted = json.Robot.TurnCompleted;
            Robot.ValueCreated = json.Robot.ValueCreated;
        }


        public void Dump()
        {
            Console.WriteLine("Robot value created:" + Robot.ValueCreated);
            Console.WriteLine("Robot step completed:" + Robot.StepCompleted);
            Console.WriteLine("Robot turn completed:" + Robot.TurnCompleted);

            Console.WriteLine("+" + new string('-', w) + "+");


            for (int x = 0; x < w; x++)
            {

                Console.Write("|");

                for (int y = 0; y < h; y++)
                {
                    var v = matrix[x, y]?.ToString();
                    if (v == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(".");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(v);
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new string('-', w) + "+");

            Console.SetCursorPosition(1 + json.Robot.Location.Y, 1 + json.Robot.Location.X);


        }
    }
}
