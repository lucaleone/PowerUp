using System;

namespace PowerUp
{
    /// <summary>
    ///     Class for Generic method extensions
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        ///     Throws System.ArgumentNullException if the given argument is null.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/new/master?readme=1#throwifnull" />
        /// <param name="obj">Object to verify</param>
        /// <param name="varName">The name of the variable to test</param>
        /// <exception cref="ArgumentNullException">The value is null.</exception>
        public static void ThrowIfNull<T>(this T obj, string varName) where T : class
        {
            if (obj.IsNull())
                throw new ArgumentNullException(varName);
        }

        /// <summary>
        ///     Verify that a object is null.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/new/master?readme=1#isnull-and-isnotnull" />
        /// <param name="obj">Object to verify</param>
        /// <returns>True if the object is null.</returns>
        public static bool IsNull<T>(this T obj) where T : class =>
            obj == null;

        /// <summary>
        ///     Verify that a nullable object is null.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/new/master?readme=1#isnull-and-isnotnull" />
        /// <param name="obj">Object to verify</param>
        /// <returns>True if the object is null.</returns>
        public static bool IsNull<T>(this T? obj) where T : struct =>
            !obj.HasValue;

        /// <summary>
        ///     Verify that a object is not null.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/new/master?readme=1#isnull-and-isnotnull" />
        /// <param name="obj">Object to verify</param>
        /// <returns>True if the object is not null.</returns>
        public static bool IsNotNull<T>(this T obj) where T : class =>
            obj != null;

        /// <summary>
        ///     Verify that a nullable object is not null.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/new/master?readme=1#isnull-and-isnotnull" />
        /// <param name="obj">Object to verify</param>
        /// <returns>True if the nullable object is not null.</returns>
        public static bool IsNotNull<T>(this T? obj) where T : struct =>
            obj.HasValue;

        /// <summary>
        ///     Verify that the object value is between the lower and upper bound.
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#between" />
        /// <typeparam name="T">IComparable object</typeparam>
        /// <param name="obj"></param>
        /// <param name="lower">Upper bound.</param>
        /// <param name="upper">Lower bound.</param>
        /// <param name="option">Exclusive or inclusive between option.</param>
        /// <returns>True is the object value in included between the lower and upper bound.</returns>
        public static bool Between<T>(this T obj,
                                      T lower,
                                      T upper,
                                      BetweenOptions option = BetweenOptions.Exclusive)
            where T : IComparable<T>
        {
            if (option == BetweenOptions.Exclusive)
                return obj.CompareTo(lower) > 0 && obj.CompareTo(upper) < 0;
            return obj.CompareTo(lower) >= 0 && obj.CompareTo(upper) <= 0;
        }
    }

    /// <summary>
    ///     Exclusive or inclusive between option
    /// </summary>
    public enum BetweenOptions
    {
        Exclusive,
        Inclusive
    }
}