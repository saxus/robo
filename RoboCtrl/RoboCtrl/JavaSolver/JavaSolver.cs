using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboCtrl.Model;

namespace RoboCtrl.JavaSolver
{
    class JavaSolver
    {
        public IEnumerable<Move> Solve(string map, Robot robot)
        {
            var res = RunSolver(map);

            var lowercase = res.ToLower();
            List<Move> movements = new List<Move>();
            foreach (char character in lowercase)
            {
                switch (character)
                {
                    case 'u':
                        if (robot.Heading == 0 || robot.Heading == 360)
                        {
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 90)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 180)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 270)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                        }
                        break;
                    case 'd':
                        if (robot.Heading == 0 || robot.Heading == 360)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 90)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 180)
                        {
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 270)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }
                        break;
                    case 'l':
                        if (robot.Heading == 0 || robot.Heading == 360)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 90)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 180)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 270)
                        {
                            movements.Add(Move.Forward);
                        }
                        break;
                    case 'r':
                        if (robot.Heading == 0 || robot.Heading == 360)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 90)
                        {
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 180)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                        }

                        if (robot.Heading == 270)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                        }
                        break;
                }
            }

            return movements;
        }


        private string RunSolver(string map)
        {
            return "";
        }
    }
}
