using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboCtrl.Model;
using RoboCtrl.JavaSolver;

namespace RoboCtrl.Algorithms
{
    class Calculator
    {

        public List<Move> Solve(WarehouseState warehouse)
        {
            var res = new List<Move>();


            while (true)
            {
                var newW = new WarehouseState(warehouse.json);
                bool first = true;
                int a=0;
                int b=0;
                for (int i = 0; i < newW.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newW.matrix.GetLength(1); j++)
                    {
                        if (newW.matrix[i, j] is Crate)
                        {
                            if (first && (warehouse.matrix[i, j] is Crate))
                            {
                                a = i;
                                b = j;
                                first = false;
                            }
                            else
                            {
                                if (warehouse.matrix[i, j] is Crate)
                                {
                                    newW.matrix[i, j] = new Obstacle();
                                }
                                else
                                {
                                    newW.matrix[i, j] = null;
                                }
                            }
                        }
                    }
                }

                if (first)
                {
                    break;
                }

                var solver = new JavaSolver.JavaSolver();

                var r = solver.Solve(newW.GenerateString(),warehouse.Robot);
                Console.WriteLine(r.solverString);
                res.AddRange(r.moves);
                res.Add(Move.Forward);

                warehouse.matrix[a, b] = null; 
            }



            return res;
        }

    }
}
