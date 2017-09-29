using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboCtrl.Model;

namespace RoboCtrl.JavaSolver
{
    class SolverResult
    {
        public IEnumerable<Move> moves { get; set; }
        public string solverString { get; set; }

    }

    class JavaSolver
    {
        public SolverResult Solve(string map, Robot robot)
        {
            var res = RunSolver(map);

            var lowercase = res.ToLower();
            List<Move> movements = new List<Move>();

            var heading = robot.Heading;

            foreach (char character in lowercase)
            {
                switch (character)
                {
                    case 'u':
                        if (heading == 0 || heading == 360)
                        {
                            movements.Add(Move.Forward);

                        }

                        else if (heading == 90)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                        }

                        else if (heading == 180)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                            heading = Left(heading);
                        }

                        else if (heading == 270)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                            heading = Right(heading);
                        }
                        break;
                    case 'd':
                        if (heading == 0 || heading == 360)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                            heading = Left(heading);
                        }

                        else if (heading == 90)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                            heading = Right(heading);
                        }

                        else if (heading == 180)
                        {
                            movements.Add(Move.Forward);
                        }

                        else if (heading == 270)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                        }
                        break;
                    case 'l':
                        if (heading == 0 || heading == 360)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                        }

                        else if (heading == 90)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                            heading = Left(heading);
                        }

                        else if (heading == 180)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                            heading = Right(heading);
                        }

                        else if (heading == 270)
                        {
                            movements.Add(Move.Forward);
                        }
                        break;
                    case 'r':
                        if (heading == 0 || heading == 360)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                            heading = Right(heading);
                        }

                        else if (heading == 90)
                        {
                            movements.Add(Move.Forward);
                        }

                        else if (heading == 180)
                        {
                            movements.Add(Move.Left);
                            movements.Add(Move.Forward);
                            heading = Left(heading);
                        }

                        else if (heading == 270)
                        {
                            movements.Add(Move.Right);
                            movements.Add(Move.Right);
                            movements.Add(Move.Forward);
                            heading = Right(heading);
                            heading = Right(heading);
                        }
                        break;
                }
            }

            var resu = new SolverResult()
            {
                moves = movements,
                solverString = res,
            };
            return resu;
        }

        private int Left(int heading)
        {
            switch (heading)
            {
                case 0: return 270;
                case 90: return 0;
                case 180: return 90;
                case 270: return 180;
                default: throw new Exception();
            }
        }

        private int Right(int heading)
        {
            switch (heading)
            {
                case 0: return 90;
                case 90: return 180;
                case 180: return 270;
                case 270: return 0;
                default: throw new Exception();
            }
        }

        private string RunSolver(string map)
        {
            var path = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "JavaSolver", "bin");

            File.WriteAllText(Path.Combine(path, "input2.txt"), map);

            var psi = new ProcessStartInfo()
            {
                FileName = @"C:\Program Files\Java\jre1.8.0_144\bin\java",
                Arguments = "A",
                WorkingDirectory = Path.Combine(Path.GetDirectoryName(GetType().Assembly.Location), "JavaSolver", "bin"),
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var p = Process.Start(psi);
            string output = p.StandardOutput.ReadToEnd();
            var l = output.Split('\n')[3].Trim();
            return l.Replace(" ", "");
        }
    }


    /*
     * 
     * 
     *  Process p = new Process();
 // Redirect the output stream of the child process.
 p.StartInfo.UseShellExecute = false;
 p.StartInfo.RedirectStandardOutput = true;
 p.StartInfo.FileName = "YOURBATCHFILE.bat";
 p.Start();
 // Do not wait for the child process to exit before
 // reading to the end of its redirected stream.
 // p.WaitForExit();
 // Read the output stream first and then wait.
 string output = p.StandardOutput.ReadToEnd();
 p.WaitForExit();

    */
}
