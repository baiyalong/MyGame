using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Passenger
    {
        public int number
        {
            get;
            private set;
        }
        public enum State
        {
            OnWait,
            OnBus
        }
        public State state
        {
            get;
            set;
        }
        public int startStationNumber
        {
            get;
            private set;
        }
        public int terminalStationNumber
        {
            get;
            private set;
        }
        public int busNumber
        {
            get;
            set;
        }
        public int seatNumber
        {
            get;
            set;
        }
        public int stationNumber
        {
            get;
            set;
        }
        public Node node
        {
            get;
            set;
        }
        public Passenger(int i)
        {
            number = i;
            state = State.OnWait;
            startStationNumber = StationList.Instance.GetRandomStationNumber();
            terminalStationNumber = StationList.Instance.GetRandomStationNumber();
            busNumber = 0;
            seatNumber = 0;
            stationNumber = startStationNumber;
            node = new Node(StationList.Instance.stationList[startStationNumber].node);
        }

    }

    public class PassengerList
    {
        public int count
        {
            get;
            private set;
        }
        public List<Passenger> list
        {
            get;
            private set;
        }

        private static PassengerList _instance = null;
        public static PassengerList Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new PassengerList();
                }
                return _instance;
            }
        }

        private PassengerList()
        {
            count = Config.GetInt("Passenger");
            list = new List<Passenger>(count);
            for (var i = 0; i < count; i++)
            {
                list[i] = new Passenger(i + 1);
            }
        }

    }
}
