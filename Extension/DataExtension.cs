using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace APIArchitecture.Extension
{
    public static class DataExtension
    {

        public static string FormatDateTime(this string Format)
        {
            return DateTime.Now.ToString(Format);
        }

        public static DateTime ToDateTime(this object dateTime)
        {
            if (dateTime != DBNull.Value)
            {
                DateTime t = Convert.ToDateTime(dateTime);
                return t;
            }
            else
                return Convert.ToDateTime("MM/dd/yyyy HH:mm".FormatDateTime());
        }

        public static DateTime ToDate(this object dateTime)
        {
            if (dateTime != DBNull.Value)
            {
                DateTime t = Convert.ToDateTime(dateTime);
                return t;
                //return Convert.ToDateTime(((DateTime)dateTime).ToString("yyyy-MM-dd HH:mm:ss"));
                //ddd;
            }
            else
                return Convert.ToDateTime("MM/dd/yyyy".FormatDateTime());
        }
        public static Int16 Int16(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToInt16(value);
            else
                return 0;
        }

        public static Int32 Int32(this object value)
        {
            if (value!=null && value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToInt32(value);
            else
                return 0;
        }

        public static Int64 Int64(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToInt64(value);
            else
                return 0;
        }

        public static UInt16 UInt16(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToUInt16(value);
            else
                return 0;
        }

        public static UInt32 UInt32(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToUInt32(value);
            else
                return 0;
        }

        public static UInt64 UInt64(this object value)
        {
            if (value != DBNull.Value)
                return Convert.ToUInt64(value);
            else
                return 0;
        }

        

        public static float ToFloat(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return (float)value;
            else
                return 0;
        }

        public static Decimal ToDecimal(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToDecimal(value);
            else
                return 0;
        }

        public static Double ToDouble(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
            {
                //return Math.Round(Convert.ToDouble(value), 2);
                return Convert.ToDouble(value);
            }
            else
                return 0;
        }

        public static Byte ToSbyte(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToByte(value);
            else
                return 0;

        }

        public static bool ToBool(this object value)
        {
            if (value != DBNull.Value && value.ToString().Trim() != "")
                return Convert.ToBoolean(value);
            else
                return false;

        }



        
        public static bool IsNumeric(this object text)
        {
            return double.TryParse(text.ToString(), out double _);
        }

        

    }
}