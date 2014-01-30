using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01DAL
{
    public class Station
    {
        public Node node
        {
            get;
            set;
        }
        public Station()
        {

        }
    }
    public class StationList
    {
        private static StationList _instance = null;
        public static StationList instance
        {
            get
            {
                if(null == _instance)
                {
                    _instance = new StationList();
                }
                return _instance;
            }
        }
        private StationList()
        {

        }
        public List<Station> list
        {
            get;
            private set;
        }
        public int GetRandomStationNumber()
        {
            return 0;
        }
    }
}
