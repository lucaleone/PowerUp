﻿using System;
using System.ComponentModel;

namespace PowerUp
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("Argument must be of Enum type",
                    nameof(enumerationValue));
            }

            // Tries to find a DescriptionAttribute for a potential friendly name for the enum
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    // Pull out the description value
                    return ((DescriptionAttribute) attrs[0]).Description;
                }
            }

            // If we have no description attribute throw ArgumentException
            throw new ArgumentException("Enum value must have a DescriptionAttribute",
                nameof(enumerationValue));
        }
    }
}