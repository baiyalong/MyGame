using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Station
    {
        public Node node
        {
            get;
            set;
        }
        public int number
        {
            get;
            private set;
        }
        public int lineNumber
        {
            get;
            private set;
        }
        public Station(int number, int lineNumber)
        {
            this.number = number;
            this.lineNumber = lineNumber;
            this.node = new Node(LineList.Instance.GetStationNode());
        }
    }
    public class StationList
    {
        private static StationList _instance = null;
        public static StationList Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new StationList();
                }
                return _instance;
            }
        }
        private StationList()
        {
            int[] value = Config.GetIntArray("Station");
            count = 0;
            list = new List<Station>();

            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < value[j]; j++)
                {
                    list.Add(new Station(++count,i+1));
                }
            }

        }
        public List<Station> list
        {
            get;
            private set;
        }
        public int count
        {
            get;
            private set;
        }
        public int GetRandomStationNumber()
        {
            return (new Random()).Next(1,count+1);
        }
    }
}
