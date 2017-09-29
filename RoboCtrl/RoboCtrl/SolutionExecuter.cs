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
                Thread.Sleep(500);

                HttpResponseMessage result = null;
                switch (movement)
                {
                    case Move.Forward:
                        result = await client.PostAsync("/robot/forward", null);
                        break;
                    case Move.Left:
                        result = await client.PostAsync("/robot/turn/left", null);
                        break;
                    case Move.Right:
                        result = await client.PostAsync("/robot/turn/right", null);
                        break;
                }

                if (result != null)
                {
                    var resultContent = await result.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<WarehouseJson>(resultContent);

                    Warehouse wareHouse = new Warehouse(json);
                    wareHouse.Dump();
                }
                else
                {
                    throw new Exception("ERROR");
                }
            }


            

        }
    }
}
