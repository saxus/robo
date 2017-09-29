using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboCtrl.Model;

namespace RoboCtrl
{
    public class SolutionExecuter
    {
        private readonly HttpClient client;

        public SolutionExecuter(string url)
        {
            client = new HttpClient { BaseAddress = new Uri(url) };
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
                    Console.Clear();
                    wareHouse.Dump();
                    Thread.Sleep(1000);
                }
                else
                {
                    throw new Exception("ERROR");
                }
            }


            

        }
    }
}
