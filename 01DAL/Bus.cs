using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Bus
    {
        public int Number
        {
            get;
            private set;
        }
        private static int _seatCount = Config.BusSeatCount;
        private static int _length = Config.BusLength;
        private static int _speed_max = System.Math.Max(Config.BusSpeedRange[0], Config.BusSpeedRange[1]);
        private static int _speed_min = System.Math.Min(Config.BusSpeedRange[0], Config.BusSpeedRange[1]);
        public static int SeatCount { get { return _seatCount; } }
        public static int Length { get { return _length; } }
        public static int SpeedMax { get { return _speed_max; } }
        public static int SpeedMin { get { return _speed_min; } }
        public Line Line
        {
            get;
            private set;
        }
        public Passenger[] SeatArr
        {
            get;
            set;
        }
        public Node BusNode
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public enum eDirection
        {
            Forward,
            Reverse
        }
        public eDirection Direction
        {
            get;
            set;
        }
        public Bus(Line line, int number)
        {
            Line = line;
            Number = number;
            SeatArr = new Passenger[SeatCount];
            Speed = 0;
            if (Line.StationArr[0].StationNode != null)
                BusNode = new Node(Line.StationArr[0].StationNode);
            this.Direction = eDirection.Forward;
        }

    }


    public class BusManagement
    {
        private static BusManagement _instance = null;
        public static BusManagement Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new BusManagement();
                }
                return _instance;
            }
        }
        private BusManagement()
        {
            Init();
        }
        public int BusCount
        {
            get;
            private set;
        }
        public Bus[] BusArr
        {
            get;
            private set;
        }
        private void Init()
        {
            int[] value = Config.BusCount;
            this.BusCount = value.Sum();
            this.BusArr = new Bus[this.BusCount];

            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < value[i]; j++)
                {
                    this.BusArr[count++] = new Bus(LineManagenment.Instance.LineArr[i], count);
                }
            }
        }
    }
}