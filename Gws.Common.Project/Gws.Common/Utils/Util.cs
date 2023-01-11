using System.Net;

namespace Gws.Common.Utils
{
    #nullable disable
    public class Util
    {
        #region Null처리 함수

        public static object DbNull(object src)
        {
            object retVal = DBNull.Value;
            if (src != null)
            {
                retVal = src;
            }

            return retVal;
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static int IsNull(object src, int defValue)
        {
            try
            {
                if (src == null || src.Equals("") || src == (object)DBNull.Value) return defValue;

                return Convert.ToInt32(src);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static int? IsNull(object src, int? defValue)
        {
            try
            {
                if (src == null || src.Equals("") || src == (object)DBNull.Value) return defValue;
                return Convert.ToInt32(src);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static long IsNull(object src, long defValue)
        {
            try
            {
                if (src == null || src.Equals("") || src == (object)DBNull.Value) return defValue;
                return Convert.ToInt64(src);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static double IsNull(object src, double defValue)
        {
            try
            {
                if (src == null || src.Equals("") || src == (object)DBNull.Value) return defValue;
                return Convert.ToDouble(src);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        // public static bool IsValidJson(string jsonString)
        // {
        //     try
        //     {
        //         var asToken = JToken.Parse(jsonString);
        //         return asToken.Type == JTokenType.Object || asToken.Type == JTokenType.Array;
        //     }
        //     catch (Exception)  // Typically a JsonReaderException exception if you want to specify.
        //     {
        //         return false;
        //     }
        // }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static decimal IsNull(object src, decimal defValue)
        {
            try
            {
                if (src == null || src.Equals("") || src == (object)DBNull.Value) return defValue;
                return Convert.ToDecimal(src);
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static string IsNull(object src, string defValue)
        {
            try
            {
                if (src == null || src == (object)DBNull.Value) return defValue;
                return src.ToString();
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        public static string IsNullOrEmpty(string src, string defValue)
        {
            try
            {
                if (string.IsNullOrEmpty(src) == true) return defValue;
                return src.ToString();
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        public static string IsNullOrEmpty(string src)
        {
            try
            {
                if (string.IsNullOrEmpty(src) == true) return string.Empty;
                return src.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static bool IsNull(object src, bool defValue)
        {
            bool retVal = defValue;
            try
            {
                if (src == null || src == (object)DBNull.Value) return defValue;

                if (src.GetType() == typeof(string))
                {
                    string strCheck = src.ToString().Trim().ToLower();

                    if (strCheck == "true" || strCheck == "false")
                        retVal = bool.Parse(strCheck);
                    else if (strCheck == "1")
                        retVal = true;
                    else if (strCheck == "0")
                        retVal = false;
                    else
                        retVal = defValue;

                }
                else if (src.GetType() == typeof(int))
                {
                    int val = Convert.ToInt32(src);
                    retVal = (val == 0) ? false : true;
                }
                else
                {
                    retVal = Convert.ToBoolean(src);
                }
            }
            catch (Exception)
            {
                retVal = defValue;
            }

            return retVal;

            //try
            //{
            //    if (src == null || src == (object)DBNull.Value) return defValue;

            //    try
            //    {
            //        bool val = Convert.ToBoolean(src);
            //        return val;
            //    }
            //    catch (Exception)
            //    {
            //        // Boolean변환시 에러가 발생하면 숫자형식으로도 체크
            //        int val = Convert.ToInt32(src);
            //        return (val == 0) ? false : true;
            //    }
            //}
            //catch (Exception)
            //{
            //    return defValue;
            //}
        }

        /// <summary>
        /// Null처리 함수
        /// </summary>
        /// <param name="src"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public static DateTime IsNull(object src, DateTime defValue)
        {
            try
            {
                if (src == null || src == (object)DBNull.Value) return defValue;
                return DateTime.Parse(src.ToString());

            }
            catch (Exception)
            {
                return defValue;
            }
        }

        // public static DateTime ToDateTime(string src, string format)
        // {

        //     DateTime? dt = ToDateTime(src, format, false);
        //     return dt.GetValueOrDefault();

        //     //DateTime dt;
        //     //string value = src.Substring(0, format.Length);
        //     //DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out dt);

        //     //return dt;
        // }
        public static DateTime ToDateTime(string src, string format, IFormatProvider provider)
        {

            DateTime? dt = ToDateTime(src, format, false, provider);
            return dt.GetValueOrDefault();

            //DateTime dt;
            //string value = src.Substring(0, format.Length);
            //DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out dt);

            //return dt;
        }

        public static DateTime? ToDateTime(string src, string format, bool isNullable, IFormatProvider provider)
        {
            DateTime? dtRetVal = null;
            DateTime dt;
            if (string.IsNullOrEmpty(src) == false)
            {
                if (src.Length >= format.Length)
                {
                    string value = src.Substring(0, format.Length);
                    DateTime.TryParseExact(value, format, provider, System.Globalization.DateTimeStyles.None, out dt);

                    if (isNullable == true && dt.Equals(DateTime.MinValue) == true)
                    {
                        dtRetVal = null;
                    }
                    else
                    {
                        dtRetVal = dt;
                    }
                }
                else
                {
                    format = format.Substring(0, src.Length);
                    DateTime.TryParseExact(src, format, provider, System.Globalization.DateTimeStyles.None, out dt);

                    if (isNullable == true && dt.Equals(DateTime.MinValue) == true)
                    {
                        dtRetVal = null;
                    }
                    else
                    {
                        dtRetVal = dt;
                    }
                }
            }
            return dtRetVal;
        }


        public static string ConvertDateTimeToString(DateTime src)
        {
            string defValue = null;

            try
            {
                if (src == null || src == DateTime.MinValue) return defValue;
                return src.ToString();
            }
            catch (Exception)
            {
                return defValue;
            }
        }

        public static DateTime UnixTimestampToDateTime(double unixTimestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimestamp).ToLocalTime();
            return dtDateTime;
        }

        public static bool CheckIpAddress(string ipString, string cidrAddress)
        {
            bool retVal = false;
            string addressPart = null;
            int cidrPart = 32;

            if (IsValidateIPv4(ipString) == false)
            {
                return false;
            }

            if (string.IsNullOrEmpty(cidrAddress) == false)
            {
                string[] parseCidrAddress = cidrAddress.Split('/');

                if (parseCidrAddress != null)
                {
                    switch (parseCidrAddress.Length)
                    {
                        case 1:
                            addressPart = parseCidrAddress[0];
                            cidrPart = 32;
                            break;
                        case 2:
                            addressPart = parseCidrAddress[0];
                            cidrPart = Convert.ToInt32(parseCidrAddress[1]);
                            break;
                        default: break;
                    }

                    if (IsValidateIPv4(addressPart) == false)
                    {
                        return false;
                    }
                }
            }

            uint[] cidrAddressRange = GetIpv4Range(addressPart, cidrPart);
            uint uintIp = IPv4ToUInt(ipString);

            if (uintIp >= cidrAddressRange[0] && uintIp <= cidrAddressRange[1])
            {
                retVal = true;
            }

            return retVal;

        }

        public static uint IPv4ToUInt(string ip)
        {
            IPAddress ipAddress = IPAddress.Parse(ip);

            byte[] bytes = ipAddress.GetAddressBytes();

            return (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
        }
         public static uint[] GetIpv4Range(string ip, int cidr)
        {
            uint uintSubnet = (uint)(0xffffffff << (32 - cidr));
            uint uintIP = IPv4ToUInt(ip);

            uint startIP = uintIP & uintSubnet;
            uint endIP = startIP | (0xffffffff & ~uintSubnet);

            return new uint[] { startIP, endIP };
        }

         public static bool IsValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }
        #endregion
    }

    
}