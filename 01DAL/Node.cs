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
        public int x
        {
            get;
            set;
        }
        public int y
        {
            get;
            set;
        }
        public Node(int x = 0, int y = 0)
        {
            try
            {
                if (x < 0 || x > Map.Instance.Length || y < 0 || y > Map.Instance.Width)
                {
                    throw new Exception();
                }
                this.x = x;
                this.y = y;

            }
            catch (Exception ex)
            {

            }
        }
        public Node(Node node)
        {
            this.x = node.x;
            this.y = node.y;

        }
    }
}
