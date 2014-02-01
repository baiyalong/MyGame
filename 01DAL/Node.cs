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
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public Node(int x = 0, int y = 0)
        {
            try
            {
                if (x < 0 || x > Map.Instance.X || y < 0 || y > Map.Instance.Y)
                {
                    throw new Exception();
                }
                this.X = x;
                this.Y = y;

            }
            catch (Exception ex)
            {

            }
        }
        public Node(Node node)
        {
            this.X = node.X;
            this.Y = node.Y;

        }
        public static double Distance(Node node1, Node node2)
        {
            return System.Math.Sqrt(System.Math.Pow(node1.X - node2.X, 2) + System.Math.Pow(node1.Y - node2.Y, 2));
        }
    }
}
