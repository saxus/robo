using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboCtrl.Model;

namespace RoboCtrl
{
    class Program
    {
        static Warehouse warehouse;

        static void Main(string[] args)
        {
            var str = File.ReadAllText("wh2.json");
            var data = JsonConvert.DeserializeObject<WarehouseJson>(str);

            warehouse = new Warehouse(data);



            warehouse.Dump();
            // TODO: live beolvasás
        }
    }
}
