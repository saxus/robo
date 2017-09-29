﻿using System;
using System.Collections.Generic;
using Mono.Options;
using RoboCtrl.Algorithms;
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

            connectionString = "http://warehouse.nexogen.io/wh/d26a8954-feb9-4e75-aebd-a1caf20a807c";

            SolutionExecuter executer = new SolutionExecuter(connectionString);

            // executer.ResetProblem().Wait();

            var initialWarehouse = executer.GetInitialState().Result;

            var whs = new WarehouseState(initialWarehouse.json);
            whs.matrix = initialWarehouse.matrix;
            whs.Robot = initialWarehouse.Robot;
            whs.h = initialWarehouse.h;
            whs.w = initialWarehouse.w;

            whs.Dump();

            Console.ReadLine();

            // var calculator = new Calculator();
            // var solution = calculator.Solve(initialWarehouse);
            //             
            // executer.ProcessMovements(solution).Wait();                        
        }
    }
}
