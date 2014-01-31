using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;

namespace _01DAL
{
    public class Line
    {
        public List<Node> NodeList
        {
            get;
            private set;
        }
        public List<Station> StationList
        {
            get;
            private set;
        }
        public List<Bus> BusList
        {
            get;
            private set;
        }
        public int Length
        {
            get;
            private set;
        }
        public Line(int[] arr)
        {
            if (null != arr && 0 == arr.Length % 2 && arr.Length > 2)
            {
                NodeList = new List<Node>();
                Length = 0;
                for (var i = 0; i < arr.Length; i += 2)
                {
                    NodeList.Add(new Node(arr[i], arr[i + 1]));
                    if (0 != i)
                    {
                        if (arr[i] == arr[i - 2])
                        {
                            Length += System.Math.Abs(arr[i + 1] - arr[i - 1]);
                        }
                        else if (arr[i + 1] == arr[i - 1])
                        {
                            Length += System.Math.Abs(arr[i] - arr[i - 2]);
                        }
                        else
                        {
                            //未定义
                        }
                    }
                }

                //初始化车站



                //初始化车辆


            }
            else
            {
                //error
            }
        }


    }

    public class LineList
    {
        private static LineList _instance = null;
        public static LineList Instance
        {
            get
            {
                if(null == _instance)
                {
                    _instance = new LineList();
                }
                return _instance;
            }
        }
        public LineList()
        {
            count = Config.GetInt("Line");
        }
        public int count
        {
            get;
            private set;
        }
        public Node GetStationNode()
        {
            return null;
        }
    }
}
