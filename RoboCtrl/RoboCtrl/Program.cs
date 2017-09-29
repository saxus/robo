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

            SolutionExecuter executer = new SolutionExecuter(connectionString);
            executer.ResetProblem().Wait();
            var initialWarehouse = executer.GetInitialState();            
            List<Move> moves = new List<Move>{Move.Right, Move.Forward, Move.Forward, Move.Forward, Move.Forward};
            executer.ProcessMovements(moves).Wait();
        }
    }
}
