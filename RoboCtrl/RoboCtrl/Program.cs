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
            var str = File.ReadAllText("wh.json");
            var data = JsonConvert.DeserializeObject<Warehouse>(str);

            ÍConsole.WriteLine(data);
            // TODO: live beolvasás
        }
    }
}
