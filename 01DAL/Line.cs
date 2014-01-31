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
        public int Number
        {
            get;
            private set;
        }
        public List<Node> NodeList
        {
            get;
            private set;
        }
        public int Length
        {
            get;
            private set;
        }
        public Line(int number, int[] arr)
        {
            try
            {
                if (null == arr || number <= 0 || 0 != arr.Length % 2 || arr.Length < 4)
                {
                    throw new Exception();
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if ((0 == i % 2 && (arr[i] < 0 || arr[i] > Map.Instance.Length)) || (0 != i % 2) && (arr[i] < 0 || arr[i] > Map.Instance.Width))
                    {
                        throw new Exception();
                    }
                }
                this.Number = number;
                Init(arr);
            }
            catch (Exception ex)
            {

            }
        }

        private void Init(int[] arr)
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
                        throw new Exception();
                    }
                }
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
                if (null == _instance)
                {
                    _instance = new LineList();
                }
                return _instance;
            }
        }
        private LineList()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                Count = Config.LineCount;
                if (Count <= 0)
                {
                    throw new Exception();
                }

                lineList = new List<Line>(Count);
                for (int i = 1; i <= Count; i++)
                {
                    lineList[i] = new Line(i, Config.LineNode(i));
                }

            }
            catch (Exception ex)
            {
            }

        }
        public int Count
        {
            get;
            private set;
        }
        public List<Line> lineList
        {
            get;
            private set;
        }
        public Line GetLine(int number)
        {
            Line line = null;
            foreach(Line i in lineList)
            {
                if (number == i.Number)
                {
                    line = i;
                }
            }
            return line;
        }
    }
}
