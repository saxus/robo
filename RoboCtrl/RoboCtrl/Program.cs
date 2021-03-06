﻿using System;
using System.Collections.Generic;
using System.IO;
using Mono.Options;
using Newtonsoft.Json;
using RoboCtrl.Algorithms;
using RoboCtrl.Model;

namespace RoboCtrl
{
    class Program
    {
        private static string connectionString;

        static void Main(string[] args)
        {
            string warehouseId = "";

            var options = new OptionSet
            {
                { "conn=", "Connection string", n => { connectionString = n.ToString(); } },
                { "id=", "Warehouse ID", n => { warehouseId = n;  } }
            };

            options.Parse(args);

            if (string.IsNullOrWhiteSpace(warehouseId))
            {
                Console.WriteLine("NINCS ID!");
                return;
            }

            Console.WriteLine($"Warehouse ID: {warehouseId}");

            // connectionString = "http://warehouse.nexogen.io/wh/d26a8954-feb9-4e75-aebd-a1caf20a807c";
            connectionString = "http://warehouse.nexogen.io/wh/a9c11152-2b17-4c67-98cb-cd5838a4f21b";


            connectionString = "http://warehouse.nexogen.io/wh/14c7af82-cd34-4d53-b61f-ffc8c8c30ae5";

            SolutionExecuter executer = new SolutionExecuter(connectionString);
             
            executer.ResetProblem().Wait();
             
            var initialWarehouse = executer.GetInitialState().Result;

            // var whs = JsonConvert.DeserializeObject<WarehouseStateJson>(File.ReadAllText("wh2.json"));
            // var initialWarehouse = new WarehouseState(whs);

            var calculator = new Calculator();
            var solution = calculator.Solve(initialWarehouse);

            executer.ProcessMovements(solution).Wait();
        }
    }
}
