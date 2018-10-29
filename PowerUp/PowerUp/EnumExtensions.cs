using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PowerUp
{
    /// <summary>
    ///     Class for Enum method extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Convert a Sting to an enum value of type <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="str">String to be parsed</param>
        /// <param name="ignoreCase">Ignore string character case.</param>
        /// <exception cref="ArgumentNullException">The attribute str is null or empty.</exception>
        /// <exception cref="ArgumentException">The attribute str cannot be parsed.</exception>
        /// <returns>An enum value.</returns>
        public static T ToEnum<T>(this string str, bool ignoreCase=true) where T : Enum
        {
            if(string.IsNullOrEmpty(str))
                throw new ArgumentNullException("The string is null.");
            if(Enum.TryParse(typeof(T), str, ignoreCase, out var res))
                return (T)res;
            throw new ArgumentException($"{str} does not belong to {typeof(T)}. Valid values: {Enum.GetValues(typeof(T))}");
        }

        /// <summary>
        ///     Gets DescriptionAttribute of one enum value
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="enumValue">Enum value from which to get the DescriptionAttribute</param>
        /// <exception cref="ArgumentException">The enum value does not have a DescriptionAttribute.</exception>
        /// <returns>The DescriptionAttribute of the value.</returns>
        public static string GetDescription<T>(this T enumValue) where T : Enum
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute) attrs[0]).Description;
                }
            }

            throw new ArgumentException("Enum value must have a DescriptionAttribute",
                nameof(enumValue));
        }
    }
}