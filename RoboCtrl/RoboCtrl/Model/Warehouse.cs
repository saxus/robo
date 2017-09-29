using System;

namespace RoboCtrl.Model
{
    /*class Warehouse
    {
        public Place[,] matrix;
        public WarehouseStateJson json;
        public int w;
        public int h;
        public Robot Robot { get; set; }
        
        
        public Warehouse(WarehouseStateJson json)
        {
            this.json = json;

            w = json.Size.Width;
            h = json.Size.Height;
            matrix = new Place[w, h];

            foreach (var it in json.Obstacles)
            {
                if (it.Location.Y > w - 1 || it.Location.X > h - 1)
                {

                }
                else
                {
                    matrix[it.Location.Y, it.Location.X] = it;
                }
            }

            foreach (var it in json.Crates)
            {
                matrix[it.Location.Y, it.Location.X] = it;
            }

            // XXX
            matrix[json.Exit.Location.Y, json.Exit.Location.X] = json.Exit;

            Robot = new Robot();
            Robot.StepCompleted = json.Robot.StepCompleted;
            Robot.TurnCompleted = json.Robot.TurnCompleted;
            Robot.ValueCreated = json.Robot.ValueCreated;
        }
        

        
    }*/
}
