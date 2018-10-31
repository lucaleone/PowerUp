using System;

namespace PowerUp
{
    /// <summary>
    ///     Class for String method extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Return true if the string content is an integer.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#isinteger" />
        /// <returns>True if the string content is an integer.</returns>
        public static bool IsInteger(this string s) =>
            int.TryParse(s, out _);

        /// <summary>
        ///     Removes from a string the content of the parameter string
        /// </summary>
        /// <param name="remove">Remove this string.</param>
        /// <returns>A string with the desired content removed.</returns>
        public static string Remove(this string s, string remove) =>
            s.Replace(remove, string.Empty);

        /// <summary>
        ///     Convert a Sting to an enum value of type <see cref="T" />
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#toenum" />
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="str">String to be parsed</param>
        /// <param name="ignoreCase">Ignore string character case.</param>
        /// <exception cref="ArgumentNullException">The attribute str is null or empty.</exception>
        /// <exception cref="ArgumentException">The attribute str cannot be parsed.</exception>
        /// <returns>An enum value.</returns>
        public static T ToEnum<T>(this string str, bool ignoreCase = true) where T : Enum
        {
            if (string.IsNullOrEmpty(str))
                throw new ArgumentNullException("The string is null.");
            if (Enum.TryParse(typeof(T), str, ignoreCase, out var res))
                return (T) res;
            throw new ArgumentException(
                $"{str} does not belong to {typeof(T)}. Valid values: {Enum.GetValues(typeof(T))}");
        }

        /// <summary>
        ///     Replaces one or more format items in a string with the string representation of a specified object.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#format" />
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The object to format.</param>
        /// <exception cref="System.ArgumentNullException">The format is null</exception>
        /// <exception cref="System.FormatException">
        ///     The format item in format is invalid. -or- The index of a format item is not zero.
        /// </exception>
        /// <returns>A copy of format in which any format items are replaced by the string representation of arg0</returns>
        public static string Format(this string format, object arg0) =>
            string.Format(format, arg0);

        /// <summary>
        ///     Replaces the format items in a string with the string representation of two specified objects.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#format" />
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <exception cref="System.ArgumentNullException">The format is null</exception>
        /// <exception cref="System.FormatException">
        ///     The format item in format is invalid. -or- The index of a format item is not zero.
        /// </exception>
        /// <returns>A copy of format in which format items are replaced by the string representations of arg0 and arg1.</returns>
        public static string Format(this string format, object arg0, object arg1) =>
            string.Format(format, arg0, arg1);

        /// <summary>
        ///     Replaces the format items in a string with the string representation of three specified objects.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#format" />
        /// <param name="format">A composite format string.</param>
        /// <param name="arg0">The first object to format.</param>
        /// <param name="arg1">The second object to format.</param>
        /// <param name="arg2">The third object to format.</param>
        /// <exception cref="System.ArgumentNullException">The format is null</exception>
        /// <exception cref="System.FormatException">
        ///     The format item in format is invalid. -or- The index of a format item is not zero.
        /// </exception>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the string representations of arg0, arg1, and
        ///     arg2.
        /// </returns>
        public static string Format(this string format, object arg0, object arg1, object arg2) =>
            string.Format(format, arg0, arg1, arg2);

        /// <summary>
        ///     Replaces the format item in a specified string with the string representation of a corresponding object in a
        ///     specified array.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#format" />
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <exception cref="System.ArgumentNullException">The format is null</exception>
        /// <exception cref="System.FormatException">
        ///     The format item in format is invalid. -or- The index of a format item is not zero.
        /// </exception>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the string representation of the corresponding
        ///     objects in args.
        /// </returns>
        public static string Format(this string format, params object[] args) =>
            string.Format(format, args);
    }
}