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
        /// <returns>True if the string content is an integer.</returns>
        public static bool IsInteger(this string s) =>
            int.TryParse(s, out _);

        /// <summary>
        ///     Replaces one or more format items in a string with the string representation of a specified object.
        /// </summary>
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