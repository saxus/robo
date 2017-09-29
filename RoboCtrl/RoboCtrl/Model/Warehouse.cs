using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCtrl.Model
{
    class Warehouse
    {
        public Place[,] matrix;
        public WarehouseJson json;
        public int w;
        public int h;


        public Warehouse(WarehouseJson json)
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
            matrix[json.Robot.Location.X, json.Robot.Location.Y] = json.Robot;
            matrix[json.Exit.Location.X, json.Exit.Location.Y] = json.Exit;
        }


        public void Dump()
        {
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

        }
    }
}
