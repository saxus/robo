using System;
using System.Collections.Generic;
using Mono.Options;
using RoboCtrl.Model;

namespace RoboCtrl
{
    class Program
    {
        private static string connectionString;

        static void Main(string[] args)
        {
            var options = new OptionSet
            {
                { "conn=", "Connection string", n => { connectionString = n.ToString(); } }
            };

            options.Parse(args);

            var f = @"52
52
####################################################
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#          #                   #                   #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
.                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                                                  #
#                    #                   #         #
#                    #                   #         #
#                    #  $                #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                    #                   #         #
#                                                  #
#                                                  #
#                                         @        #
#                                                  #
####################################################";

            var s = new JavaSolver.JavaSolver();
            var res = s.Solve(f, null);

            foreach (var r in res)
                Console.WriteLine(r);


            //var str = File.ReadAllText("wh.json");
            //var data = JsonConvert.DeserializeObject<WarehouseJson>(str);

            //warehouse = new Warehouse(data);

            //warehouse.Dump();
            // TODO: live beolvasás
            // Solution betöltés:
            

// SolutionExecuter executer = new SolutionExecuter(connectionString);
//             List<Move> moves = new List<Move>{Move.Right, Move.Forward, Move.Forward, Move.Forward, Move.Forward};
//             executer.ProcessMovements(moves).Wait();
        }
    }
}
