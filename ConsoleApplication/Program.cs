using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _00Common;
using _01DAL;
using log4net;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Map m = Map.Instance;
            Node c = new Node();

            Console.WriteLine(c.ToString());
            

            Console.Read();
        }
    }
}
