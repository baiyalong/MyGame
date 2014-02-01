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

        public static int[] BusCount
        {
            get
            {
                int[] busCount = null;
                try
                {
                    busCount = GetIntArray("BusCount");
                    if (busCount.Length != LineCount)
                    {
                        throw new Exception();
                    }
                    foreach (var item in busCount)
                    {
                        if (item <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception ex) { }
                return busCount;
            }
        }
        public static int BusSeatCount
        {
            get
            {
                int value = 0;
                try
                {
                    value = GetInt("BusSeatCount");
                    if (value <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return value;
            }
        }
        public static int BusLength
        {
            get
            {
                int value = 0;
                try
                {
                    value = GetInt("BusLength");
                    if (value <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return value;
            }
        }
        public static int[] BusSpeedRange
        {
            get
            {
                int[] value = null;
                try
                {
                    value = GetIntArray("BusSpeedRange");
                    if (value.Length != 2)
                    {
                        throw new Exception();
                    }
                    foreach (var item in value)
                    {
                        if (item <= 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return value;
            }
        }
        public static int PassengerCount
        {
            get
            {
                int value = 0;
                try
                {
                    value = GetInt("PassengerCount");
                    if (value <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return value;
            }
        }
        public static int LineCount
        {
            get
            {
                int lineCount = 0;
                try
                {
                    lineCount = GetInt("LineCount");
                    if (lineCount <= 0 || lineCount > 100)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {

                }
                return lineCount;

            }
        }
        public static int[] StationCount
        {
            get
            {
                int[] value = null;
                try
                {
                    value = GetIntArray("StationCount");
                    if (value.Length != LineCount)
                    {
                        throw new Exception();
                    }
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] < 2)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return value;
            }
        }
        public static int[] Map
        {
            get
            {
                int[] map = null;
                try
                {
                    map = GetIntArray("Map");
                    if (map.Length != 2 || map[0] <= 0 || map[1] <= 0)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {
                }
                return map;
            }
        }
        public static int[] LineNode(int lineNumber)
        {
            int[] arr = null;
            try
            {
                arr = GetIntArray("L_" + lineNumber.ToString());
                if (null == arr || 0 != arr.Length % 2 || arr.Length < 4)
                {
                    throw new Exception();
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if ((0 == i % 2 && (arr[i] < 0 || arr[i] > Map[0])) || (0 != i % 2) && (arr[i] < 0 || arr[i] > Map[1]))
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return arr;
        }
    }
}
