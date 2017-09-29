using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCtrl.Model
{
    class Warehouse
    {
        public readonly Place[,] places;
        public readonly int width;
        public readonly int heigth;

        public Warehouse(int w, int h)
        {
            this.width = w;
            this.heigth = h;

            Warehouse = new Place[w, h];
        }
    }
}
