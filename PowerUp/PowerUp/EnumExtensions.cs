using System;
using System.ComponentModel;

namespace PowerUp
{
    /// <summary>
    ///     Class for Enum method extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     Gets DescriptionAttribute of one enum value
        /// </summary>
        /// <see cref="https://github.com/lucaleone/PowerUp/blob/master/README.md#getdescription" />
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