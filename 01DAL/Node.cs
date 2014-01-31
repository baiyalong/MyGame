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
        private int _x;
        private int _y;
        private int _x_max;
        private int _y_max;

        public int x
        {
            get { return _x; }
            set { _x = (value >= 0 && value <= _x_max) ? value : 0; }
        }
        public int y
        {
            get { return _y; }
            set { _y = (value >= 0 && value <= _y_max) ? value : 0; }
        }
        public Node(int x = 0, int y = 0)
        {
            getConfig();

            this.x = x;
            this.y = y;
        }

        private void getConfig()
        {
            int[] max = Config.GetIntArray("Map");
            _x_max = max[0];
            _y_max = max[1];
        }
        public Node(Node node)
        {
            getConfig();
            this.x = node.x;
            this.y = node.y;

        }
    }
}
