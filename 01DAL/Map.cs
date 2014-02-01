using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Map
    {
        private Map()
        {
            Init();
        }
        private static Map _instance = null;

        public static Map Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new Map();
                }
                return _instance;
            }
        }
        public int X
        {
            get;
            private set;
        }
        public int Y
        {
            get;
            private set;
        }

        private void Init()
        {
            int[] value = Config.Map;
            this.X = value[0];
            this.Y = value[1];
        }
    }
}
