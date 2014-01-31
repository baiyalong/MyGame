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
        private static Map instance = null;

        public static Map Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new Map();
                }
                return instance;
            }
        }
        public int Length
        {
            get;
            private set;
        }
        public int Width
        {
            get;
            private set;
        }

        private void Init()
        {
            try
            {
                int[] value = Config.Map;
                if (value[0] <= 0 || value[1] <= 0)
                {
                    throw new Exception();
                }

                this.Length = value[0];
                this.Width = value[1];
            }
            catch (Exception ex)
            {

            }
        }
    }
}
