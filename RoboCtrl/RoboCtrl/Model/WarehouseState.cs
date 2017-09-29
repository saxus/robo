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
                Add(it);
            }

            foreach (var it in json.Crates)
            {
                Add(it);
            }

            // XXX
            matrix[json.Exit.Location.Y, json.Exit.Location.X] = json.Exit;

            Robot = new Robot();
            Robot.StepCompleted = json.Robot.StepCompleted;
            Robot.TurnCompleted = json.Robot.TurnCompleted;
            Robot.ValueCreated = json.Robot.ValueCreated;
        }

        private void Add(Place it)
        {
            if (it.Location.Y >= 0 &&
                it.Location.X >= 0 &&
                it.Location.Y < h &&
                it.Location.Y < w)
            {
                matrix[it.Location.Y, it.Location.X] = it;
            }
        }

        public void Dump()
        {
            Console.WriteLine("Robot value created:" + Robot.ValueCreated);
            Console.WriteLine("Robot step completed:" + Robot.StepCompleted);
            Console.WriteLine("Robot turn completed:" + Robot.TurnCompleted);

            
            Console.WriteLine(GenerateString());

            Console.SetCursorPosition(1 + json.Robot.Location.X, 1 + json.Robot.Location.Y + 5);


        }


        public string GenerateString()
        {
            var res = (h + 2) + "\n" + (w + 2) + "\n";

            res += new string('#', w + 2) + "\n";

            for (int i = 0; i < h; i++)
            {
                res += "#";

                for (int j = 0; j < w; j++)
                {

                    var p = matrix[i, j];
                    if (p == null)
                    {
                        res += " ";
                    }
                    else
                    {
                        if (p is Exit &&
                            p.Location.X == json.Robot.Location.X &&
                            p.Location.Y == json.Robot.Location.Y)
                        {
                            res += "+";
                        }
                        else
                        {
                            res += p.ToString();
                        }
                    }
                }
                res += "#\n";
            }

            for (int x = 0; x < w + 2; x++)
            {
                res += "#";
            }

            return res;
        }
    }
}
