using System;
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
                if (null == _instance)
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
        public enum eState { stoped, init, running, suspend }
        public eState State
        {
            get;
            set;
        }
        public Map iMap
        {
            get;
            private set;
        }
        public LineManagenment iLineList
        {
            get;
            private set;
        }
        public StationManagenment iStationList
        {
            get;
            private set;
        }
        public BusManagement iBusList
        {
            get;
            private set;
        }
        public PassengerManagement iPassengerList
        {
            get;
            private set;
        }
        public void Init()
        {
            try
            {
                //init map
                iMap = Map.Instance;
                //init line
                iLineList = LineManagenment.Instance;
                //init station
                iStationList = StationManagenment.Instance;
                //init bus
                iBusList = BusManagement.Instance;
                //init passenger
                iPassengerList = PassengerManagement.Instance;
            }
            catch (Exception)
            {

                throw;
            }

            this.State = eState.init;

        }
        public void Start()
        {
            this.State = eState.running;
            try
            {
                while (true)
                {
                    
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Suspend()
        {
            throw new NotImplementedException();
        }
        public void Continue()
        {
            throw new NotImplementedException();

        }
        public void Stop()
        {
            throw new NotImplementedException();

        }
    }
}
