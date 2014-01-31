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
            //this.node = new Node(LineList.Instance.GetStationNode());
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
            Init();

        }

        private void Init()
        {
            try
            {
                int[] value = Config.StationCount;
                if (value.Length != Config.LineCount)
                {
                    throw new Exception();
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < 2 || value[i] > LineList.Instance.lineList[i].Length / Bus.length)
                    {
                        throw new Exception();
                    }
                }
                Count = 0;
                stationList = new List<Station>();

                for (int i = 1; i <= value.Length; i++)
                {
                    for (int j = 0; j < value[j]; j++)
                    {
                        stationList.Add(new Station(++Count, i));
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        public List<Station> stationList
        {
            get;
            private set;
        }
        public int Count
        {
            get;
            private set;
        }
        //public int GetRandomStationNumber()
        //{
        //    return (new Random()).Next(1, Count + 1);
        //}
    }
}
