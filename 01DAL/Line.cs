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
        public Node[] NodeArr
        {
            get;
            private set;
        }
        public Station[] StationArr
        {
            get;
            set;
        }
        public double Length
        {
            get;
            private set;
        }
        public Line(int number, int[] arr)
        {
            Init(number, arr);
        }

        private void Init(int number, int[] arr)
        {
            this.Number = number;
            NodeArr = new Node[arr.Length / 2];
            Length = 0;
            for (var i = 0; i < arr.Length; i += 2)
            {
                NodeArr[i / 2] = new Node(arr[i], arr[i + 1]);
                if (i/2 != 0)
                {
                    Length += Node.Distance(NodeArr[i/2], NodeArr[i/2 - 1]);
                }
            }

        }

        internal void SetStationNode()
        {
            int stationCount = StationArr.Length;
            int nodeCount = NodeArr.Length;
            double lineLength = Length;

            StationArr[0].StationNode = new Node(NodeArr[0]);
            StationArr[StationArr.Length - 1].StationNode = new Node(NodeArr[NodeArr.Length - 1]);

            List<Node> crossNodeList = LineManagenment.Instance.GetCrossNodeList(this);

            int lastStationCount = stationCount - 2;
            int segment = (int)this.Length / (lastStationCount - crossNodeList.Count + 1);
            int lineNode = 0;
            int crossNodeCount = 0;
            int stationNodeCount = 1;
            if (NodeArr.Length == 2)
            {
                for (; lastStationCount > 0; lastStationCount--)
                {
                    if (NodeArr[0].X == NodeArr[1].X)
                    {
                        lineNode = (lineNode == 0) ? NodeArr[0].Y : lineNode;
                        lineNode += segment;
                        if (lineNode == crossNodeList[crossNodeCount].Y)
                        {
                            throw new Exception();
                        }
                        while (lineNode > crossNodeList[crossNodeCount].Y)
                        {
                            StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                        }
                        StationArr[stationNodeCount++].StationNode = new Node(NodeArr[0].X, lineNode);

                    }
                    else if (NodeArr[0].Y == NodeArr[1].Y)
                    {
                        lineNode = (lineNode == 0) ? NodeArr[0].X : lineNode;
                        lineNode += segment;
                        if (lineNode == crossNodeList[crossNodeCount].X)
                        {
                            throw new Exception();
                        }
                        while (lineNode > crossNodeList[crossNodeCount].X)
                        {
                            StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                        }
                        StationArr[stationNodeCount++].StationNode = new Node(NodeArr[0].Y, lineNode);

                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            else if (NodeArr.Length == 3)
            {
                int flag = 0;
                for (; lastStationCount > 0; lastStationCount--)
                {
                    if (NodeArr[0].X == NodeArr[1].X)
                    {
                        lineNode = (lineNode == 0) ? NodeArr[0].Y : lineNode;
                        lineNode += segment;
                        if (lineNode <= NodeArr[1].Y)
                        {
                            if (lineNode == crossNodeList[crossNodeCount].Y)
                            {
                                throw new Exception();
                            }
                            while (lineNode > crossNodeList[crossNodeCount].Y)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            StationArr[stationNodeCount++].StationNode = new Node(NodeArr[0].X, lineNode);

                        }
                        else
                        {
                            while (NodeArr[1].Y > crossNodeList[crossNodeCount].Y)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            if (flag == 0)
                            {
                                flag = 1;
                                lineNode = NodeArr[1].X + (lineNode - NodeArr[1].Y);
                            }
                            if (lineNode == crossNodeList[crossNodeCount].X)
                            {
                                throw new Exception();
                            }
                            while (lineNode > crossNodeList[crossNodeCount].X)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            StationArr[stationNodeCount++].StationNode = new Node(NodeArr[1].Y, lineNode);

                        }

                    }
                    else if (NodeArr[0].Y == NodeArr[1].Y)
                    {
                        lineNode = (lineNode == 0) ? NodeArr[0].X : lineNode;
                        lineNode += segment;
                        if (lineNode <= NodeArr[1].X)
                        {
                            if (lineNode == crossNodeList[crossNodeCount].X)
                            {
                                throw new Exception();
                            }
                            while (lineNode > crossNodeList[crossNodeCount].X)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            StationArr[stationNodeCount++].StationNode = new Node(NodeArr[0].Y, lineNode);
                        }
                        else
                        {
                            while (NodeArr[1].X > crossNodeList[crossNodeCount].X)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            if (flag == 0)
                            {
                                flag = 1;
                                lineNode = NodeArr[1].Y + (lineNode - NodeArr[1].X);
                            }
                            if (lineNode == crossNodeList[crossNodeCount].Y)
                            {
                                throw new Exception();
                            }
                            while (lineNode > crossNodeList[crossNodeCount].Y)
                            {
                                StationArr[stationNodeCount++].StationNode = new Node(crossNodeList[crossNodeCount++]);
                            }
                            StationArr[stationNodeCount++].StationNode = new Node(NodeArr[1].X, lineNode);

                        }

                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    public class LineManagenment
    {
        private static LineManagenment _instance = null;
        public static LineManagenment Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new LineManagenment();
                }
                return _instance;
            }
        }
        private LineManagenment()
        {
            Init();
        }

        private void Init()
        {

            LineCount = Config.LineCount;
            LineArr = new Line[LineCount];
            for (int i = 0; i < LineCount; i++)
            {
                LineArr[i] = new Line(i + 1, Config.LineNode(i + 1));
            }

        }
        public int LineCount
        {
            get;
            private set;
        }
        public Line[] LineArr
        {
            get;
            private set;
        }


        internal List<Node> GetCrossNodeList(Line line)
        {
            List<Node> nodeList = new List<Node>();
            foreach (Line item in this.LineArr)
            {
                if (!item.Equals(line))
                {
                    for (int i = 0; i < item.NodeArr.Length - 1; i++)
                    {
                        for (int j = 0; j < line.NodeArr.Length - 1; j++)
                        {
                            Node node = GetCrossNode(item.NodeArr[i], item.NodeArr[i + 1], line.NodeArr[j], line.NodeArr[j + 1]);
                            if (node != null)
                            {
                                nodeList.Add(node);
                            }

                        }

                    }
                }
            }

            return nodeList;
        }

        private Node GetCrossNode(Node node1, Node node2, Node node3, Node node4)
        {
            Node node = null;
            int x, y;
            if (node1.X == node2.X && node3.Y == node4.Y)
            {
                x = node1.X;
                y = node3.Y;
                if (x >= System.Math.Min(node3.X, node4.X)
                  && x <= System.Math.Max(node3.X, node4.Y)
                  && y >= System.Math.Min(node1.Y, node2.Y)
                  && y <= System.Math.Max(node1.Y, node2.Y))
                {
                    node = new Node(x, y);
                }
            }
            else if (node3.X == node4.X && node1.Y == node2.Y)
            {
                x = node3.X;
                y = node1.Y;
                if (x >= System.Math.Min(node1.X, node2.X)
                  && x <= System.Math.Max(node1.X, node2.Y)
                  && y >= System.Math.Min(node3.Y, node4.Y)
                  && y <= System.Math.Max(node3.Y, node4.Y))
                {
                    node = new Node(x, y);
                }
            }
            return node;
        }
    }
}
