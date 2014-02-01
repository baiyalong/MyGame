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
        public Node StationNode
        {
            get;
            internal set;
        }
        public int Number
        {
            get;
            private set;
        }
        public int LineNumber
        {
            get;
            private set;
        }
        public Station(int number, int lineNumber, Node node)
        {
            this.Number = number;
            this.LineNumber = lineNumber;
            this.StationNode = node;
        }
    }
    public class StationManagenment
    {
        private static StationManagenment _instance = null;
        public static StationManagenment Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new StationManagenment();
                }
                return _instance;
            }
        }
        private StationManagenment()
        {
            Init();

        }

        private void Init()
        {
            int[] value = Config.StationCount;
            StationCount = value.Sum();
            StationArr = new Station[StationCount];

            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                LineManagenment.Instance.LineArr[i].StationArr = new Station[value[i]];
                for (int j = 0; j < value[i]; j++)
                {
                    Station station = new Station(count, i + 1, null);
                    StationArr[count] = station;
                    LineManagenment.Instance.LineArr[i].StationArr[j] = station;
                }
                LineManagenment.Instance.LineArr[i].SetStationNode();
            }

        }
        public Station[] StationArr
        {
            get;
            private set;
        }
        public int StationCount
        {
            get;
            private set;
        }
        public Station GetRandomStation()
        {
            int rand = (new Random()).Next(0, this.StationArr.Length);
            return this.StationArr[rand];
        }
    }
}
