using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCtrl.Model
{
    class Size
    {
        public int Width {get;set;}
        public int Height { get; set; }
    }

    class WarehouseJson
    {
        public WarehouseStateJson WarehouseState { get; set; }
    }

    class WarehouseStateJson
    {
        public Size Size { get; set; }        
        public List<Crate> Crates { get; set; }
        public Robot Robot { get; set; }
        public Exit Exit { get; set; }
        public List<Obstacle> Obstacles { get; set; }

        // public Warehouse(int w, int h)
        // {
        //     this.width = w;
        //     this.heigth = h;
        //
        //     places = new Place[w, h];
        // }
    }
}
