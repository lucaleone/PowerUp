using System;

namespace PowerUp
{
    public static class GenericExtensions
    {
        /// <summary>
        ///     Throws System.ArgumentNullException if the given argument is null.
        /// </summary>
        /// <param name="varName">The name of the variable to test</param>
        /// <exception cref="ArgumentNullException">The value is null.</exception>
        public static void ThrowIfNull<T>(this T obj, string varName) where T : class
        {
            if (obj.IsNull())
                throw new ArgumentNullException(varName);
        }

        /// <summary>
        ///     Verify that the object is null.
        /// </summary>
        /// <param name="obj">Object to verify</param>
        /// <returns>True if the object is null.</returns>
        public static bool IsNull<T>(this T obj) where T : class =>
            obj == null;


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

    public enum BetweenOptions
    {
        Exclusive,
        Inclusive
    }
}