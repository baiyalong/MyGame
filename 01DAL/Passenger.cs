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
        public int Number
        {
            get;
            private set;
        }
        public enum eState
        {
            OnWait,
            OnBus
        }
        public eState State
        {
            get;
            set;
        }
        public Station StartStation
        {
            get;
            private set;
        }
        public Station TerminalStation
        {
            get;
            private set;
        }
        public Bus OnTheGoBus
        {
            get;
            set;
        }
        public int SeatNumber
        {
            get;
            set;
        }
        public Station StandByStation
        {
            get;
            set;
        }
        public Node PassengerNode
        {
            get;
            set;
        }
        public Passenger(int i)
        {
            this.Number = i;
            this.State = eState.OnWait;
            this.StartStation = StationManagenment.Instance.GetRandomStation();
            this.TerminalStation = StationManagenment.Instance.GetRandomStation();
            this.OnTheGoBus = null;
            this.SeatNumber = 0;
            this.StandByStation = this.StartStation;
            if (this.StandByStation!=null&&this.StandByStation.StationNode != null)
                this.PassengerNode = new Node(this.StandByStation.StationNode);
        }

    }

    public class PassengerManagement
    {
        public int PassengerCount
        {
            get;
            private set;
        }
        public Passenger[] PassengerArr
        {
            get;
            private set;
        }

        private static PassengerManagement _instance = null;
        public static PassengerManagement Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new PassengerManagement();
                }
                return _instance;
            }
        }

        private PassengerManagement()
        {
            this.PassengerCount = Config.PassengerCount;
            this.PassengerArr = new Passenger[this.PassengerCount];
            for (var i = 0; i < PassengerCount; i++)
            {
                PassengerArr[i] = new Passenger(i + 1);
            }
        }

    }
}
