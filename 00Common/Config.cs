using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _00Common
{
    public static class Config
    {
        private static string GetString(string key, string defaultValue = null)
        {
            string value = defaultValue;
            if (null != key && null != ConfigurationManager.AppSettings[key])
            {
                value = ConfigurationManager.AppSettings[key];
            }
            return value;
        }
        private static int GetInt(string key, string defaultValue = null)
        {
            return Convert.ToInt32(GetString(key, defaultValue));
        }
        private static string[] GetStringArray(string key, int n = 0, string defaultValue = null)
        {
            string[] stringArray = null;
            string value = GetString(key, defaultValue);
            if (null != value)
            {
                stringArray = value.Split(new Char[] { ' ', ',', '.', ':', ';', '\t' });

                if (0 != n && n != stringArray.Length)
                {
                    string[] arr = new string[n];
                    if (n > stringArray.Length)
                    {
                        stringArray.CopyTo(arr, 0);
                        for (int i = stringArray.Length; i < n; i++)
                        {
                            arr[i] = stringArray[stringArray.Length - 1];
                        }
                    }
                    else if (n < stringArray.Length)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            arr[i] = stringArray[i];
                        }
                    }
                    stringArray = arr;
                }
            }
            return stringArray;
        }
        private static int[] GetIntArray(string key, int n = 0, string defaultValue = null)
        {
            string[] stringArray = GetStringArray(key, n, defaultValue);
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(stringArray[i]);
            }
            return intArray;
        }

        public static int FleetCount
        {
            get { return GetInt("FleetCount"); }
        }
        public static int[] BusCount
        {
            get { return GetIntArray("BusCount"); }
        }
        public static int BusSeatCount
        {
            get { return GetInt("BusSeatCount"); }
        }
        public static int BusLength
        {
            get { return GetInt("BusLength"); }
        }
        public static int[] BusSpeedRange
        {
            get { return GetIntArray("BusSpeedRange"); }
        }
        public static int PassengerCount
        {
            get { return GetInt("PassengerCount"); }
        }
        public static int LineCount
        {
            get { return GetInt("LineCount"); }
        }
        public static int[] StationCount
        {
            get { return GetIntArray("StationCount"); }
        }
        public static int[] Map
        {
            get { return GetIntArray("Map"); }
        }
        public static int[] LineNode(int lineNumber)
        {
            return GetIntArray("L_"+lineNumber.ToString());
        }
    }
}
