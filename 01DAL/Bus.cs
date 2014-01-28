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
        public Line Line
        {
            get;
            private set;
        }
        public int Length
        {
            get;
            private set;
        }
        public SpeedRange Speed
        {
            get;
            private set;
        }
        public List<int> Seat
        {
            get;
            set;
        }
        public Bus(Line line)
        {
            Line = line;
            Length = ConfigManager.GetInt("BusLength");
            int[] value = ConfigManager.GetIntArray("BusSpeed");
            Speed = new SpeedRange(value[0], value[1]);
            int seatCount = ConfigManager.GetInt("BusSeat");
            for (var i = 0; i < seatCount; i++)
            {
                Seat.Add(0);
            }
        }
        
    }
}


public class SpeedRange
{
    public int Max
    {
        get;
        private set;
    }
    public int Min
    {
        get;
        private set;
    }
    public SpeedRange(int a, int b)
    {
        Max = System.Math.Max(a, b);
        Min = System.Math.Min(a, b);
    }

}