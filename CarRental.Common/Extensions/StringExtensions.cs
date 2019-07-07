using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string someString)
        {
            return string.IsNullOrEmpty(someString);
        }
        public static bool IsNullOrWhiteSpace(this string someString)
        {
            return string.IsNullOrWhiteSpace(someString);
        }
        public static bool IsNotNullOrEmpty(this string someString)
        {
            return !string.IsNullOrEmpty(someString);
        }
        public static bool IsNotNullOrWhiteSpace(this string someString)
        {
            return !string.IsNullOrWhiteSpace(someString);
        }
        
        public static string ToBase64(this string someString)
        {
            var bytes = Encoding.UTF8.GetBytes(someString);
            return Convert.ToBase64String(bytes);
        }
    }
}