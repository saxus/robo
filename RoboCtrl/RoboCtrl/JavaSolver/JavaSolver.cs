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
