using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboCtrl.Model;

namespace RoboCtrl
{
    class SolutionExecuter
    {
        private readonly HttpClient client;

        public SolutionExecuter(string url)
        {
            client = new HttpClient { BaseAddress = new Uri(url) };
        }

        public async Task ResetProblem()
        {
            await client.PostAsync(client.BaseAddress + "/reset", null);
        }

        public async Task<WarehouseState> GetInitialState()
        {
            var result = await client.GetAsync(client.BaseAddress);
            var resultContent = await result.Content.ReadAsStringAsync();
            WarehouseStateJson json = JsonConvert.DeserializeObject<WarehouseStateJson>(resultContent);
            WarehouseState warehouse = new WarehouseState(json);
            return warehouse;
        }

        public async Task ProcessMovements(IEnumerable<Move> movements)
        {
            foreach (var movement in movements)
            {
                HttpResponseMessage result = null;
                switch (movement)
                {
                    case Move.Forward:
                        result = await client.PostAsync(client.BaseAddress + "/robot/forward", null);
                        break;
                    case Move.Left:
                        result = await client.PostAsync(client.BaseAddress + "/robot/turn/left", null);
                        break;
                    case Move.Right:
                        result = await client.PostAsync(client.BaseAddress + "/robot/turn/right", null);
                        break;
                }

                if (result != null)
                {
                    var resultContent = await result.Content.ReadAsStringAsync();
                    WarehouseJson json = JsonConvert.DeserializeObject<WarehouseJson>(resultContent);

                    WarehouseState wareHouse = new WarehouseState(json.WarehouseState);
                    // onsole.SetCursorPosition(0, 0);
                    Console.Clear();
                    wareHouse.Dump();
                    Thread.Sleep(100);
                }
                else
                {
                    throw new Exception("ERROR");
                }
            }


            

        }
    }
}
