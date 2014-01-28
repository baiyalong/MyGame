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

        public List<Line> LineList
        {
            get;
            private set;
        }

        public void Init()
        {
            int[] value = ConfigManager.GetIntArray("Map");
            this.Length = value[0];
            this.Width = value[1];

            //初始化路线
            int line = ConfigManager.GetInt("Line");
            LineList = new List<Line>();
            for (var i = 1; i <= line; i++)
            {
                LineList.Add(new Line(ConfigManager.GetIntArray("L_"+i.ToString())));
            }
        }
    }
}
