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
            Wait,
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
        public int BusNumber
        {
            get;
            set;
        }
        public int SeatNumber
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
            state = State.Wait;
            startStationNumber = StationList.instance.GetRandomStationNumber();
            terminalStationNumber = StationList.instance.GetRandomStationNumber();
            BusNumber = 0;
            SeatNumber = 0;
            node = new Node(StationList.instance.list[startStationNumber].node);
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
        public static PassengerList instance
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
            count = ConfigManager.GetInt("Passenger");
            list = new List<Passenger>(count);
            for (var i = 0; i < count; i++)
            {
                list[i] = new Passenger(i + 1);
            }
        }

    }
}
