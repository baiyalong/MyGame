using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using _00Common;
using _01DAL;
using _02BLL;
using log4net;
using System.Threading;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ConsoleApplication
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
    (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            //int i = 0;
            //while (true)
            //{
            //    Console.WriteLine("tick-----"+i++.ToString());
            //    Thread.Sleep(1000);
            //}
            ResourceManagement.Instance.Init();


            Console.Read();
        }
    }
}
