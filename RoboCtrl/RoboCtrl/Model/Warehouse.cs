using System;

namespace RoboCtrl.Model
{
    class Warehouse
    {
        public Place[,] matrix;
        public WarehouseStateJson json;
        public int w;
        public int h;
        public Robot Robot { get; set; }
        
        
        public Warehouse(WarehouseStateJson json)
        {
            this.json = json;

            w = json.Size.Width;
            h = json.Size.Height;
            matrix = new Place[w, h];

            foreach (var it in json.Obstacles)
            {
                if (it.Location.Y > w - 1 || it.Location.X > h - 1)
                {

                }
                else
                {
                    matrix[it.Location.Y, it.Location.X] = it;
                }
            }

            foreach (var it in json.Crates)
            {
                matrix[it.Location.Y, it.Location.X] = it;
            }

            // XXX
            matrix[json.Exit.Location.Y, json.Exit.Location.X] = json.Exit;

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

            Console.WriteLine("#" + new string('#', w) + "#");


                for (int y = 0; y < h; y++)
                
            {

                Console.Write("#");

                for (int x = 0; x < w; x++)
                {
                    var v = matrix[y, x]?.ToString();
                    if (v == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(v);
                    }
                }
                Console.WriteLine("#");
            }
            Console.WriteLine("#" + new string('#', w) + "#");

            Console.SetCursorPosition(1 + json.Robot.Location.Y, 1 + json.Robot.Location.X);


        }


        public string GenerateString()
        {
            var res = (h+2) + "\n" + (w + 2)  + "\n";

            for (int x = 0; x < w+2; x++)
            {
                //if (json.Exit.Location.X == 0 && json.Exit.Location.Y == x)
                //{
                //    res += ".";
                //}
                //else
                //{
                    res += "#";
                //}
            }

            res += "\n";

            for (int i = 0; i < h; i++)                
            {

                //if (json.Exit.Location.X == x && json.Exit.Location.Y == 0)
                //{
                //    res += ".";
                //}
                //else
                //{
                    res += "#";
                //}
                for (int j = 0; j < w; j++)
                {

                    var p = matrix[i, j];
                    if (p == null)
                    {
                        res += " ";
                    }
                    else
                    {
                        if (p is Exit && p.Location.X == json.Robot.Location.X &&
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
