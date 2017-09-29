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

            // TODO: Conversion

            return new Move[0];
        }


        private string RunSolver(string map)
        {
            return "";
        }
    }
}
