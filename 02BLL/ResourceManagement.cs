﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _00Common;
using _01DAL;

namespace _02BLL
{
    public class ResourceManagement
    {
        private static ResourceManagement _instance = null;
        public static ResourceManagement Instance
        {
            get
            {
                if(null == _instance)
                {
                    _instance = new ResourceManagement();
                }
                return _instance;
            }
        }
        private ResourceManagement()
        {
            this.State = eState.stoped;
        }
        enum eState { stoped,init,running,suspend}
        public eState State
        {
            get;
            private set;
        }
        public Map iMap
        {
            get;
            private set;
        }
        public LineList iLineList
        {
            get;
            private set;
        }
        public StationList iStationList
        {
            get;
            private set;
        }
        public BusList iBusList
        {
            get;
            private set;
        }
        public PassengerList iPassengerList
        {
            get;
            private set;
        }
        public bool Init()
        {
            bool res = false;

            //init map
            iMap = Map.Instance;
            //init line
            iLineList = LineList.Instance;
            //init station
            iStationList = StationList.Instance;
            //init bus
            iBusList = BusList.Instance;
            //init passenger
            iPassengerList = PassengerList.Instance;


            return res;
        }
        public bool Start()
        {
            return true;
        }

        public bool Suspend()
        {
            return true;
        }
        public bool Continue()
        {
            return true;
        }
        public bool Stop()
        {
            return true;
        }
    }
}