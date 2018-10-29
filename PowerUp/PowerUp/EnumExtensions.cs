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

        public static string GetDescription<T>(this T enumerationValue) where T : Enum
        {
            var type = typeof(T);
            var memberInfo = type.GetMember(enumerationValue.ToString());
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
                nameof(enumerationValue));
        }
    }
}