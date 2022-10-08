using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Validations
    {
        public static void CheckValue<T>(T value, string paramName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Used to validate that a string is non-null, non-empty, and non-whitespace.
        /// Throws InputArgumentNullException or InputArgumentException on failure.
        /// </summary>
        /// <param name="s">The string to check.</param>
        /// <param name="paramName">The name of the parameter being tested.</param>
        public static void CheckNonWhiteSpace(string s, string paramName)
        {
            if (s == null)
            {
                throw new ArgumentNullException(paramName);
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Checks that the value of the specified parameter is not null.
        /// </summary>
        /// <typeparam name="T">The type of parameter to check.</typeparam>
        /// <param name="val">The value of the parameter.</param>
        /// <param name="paramName">The name of the parameter.</param>
        public static void CheckIsNotNull<T>(T val, string paramName)
        {
            if (ReferenceEquals(val, null))
                throw new ArgumentNullException(paramName);
        }

    }
}
