using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Node
    {
        private int x;
        private int y;
        private int x_max;
        private int y_max;

        public int X
        {
            get { return x; }
            set { x = (value >= 0 && value <= x_max) ? value : 0; }
        }
        public int Y
        {
            get { return y; }
            set { y = (value >= 0 && value <= y_max) ? value : 0; }
        }
        public Node(int x = 0, int y = 0)
        {
            int[] max = ConfigManager.GetIntArray("Map");
            x_max = max[0];
            y_max = max[1];

            this.X = x;
            this.Y = y;
        }
    }
}
