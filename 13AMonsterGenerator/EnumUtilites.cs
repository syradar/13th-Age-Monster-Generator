using System;
using System.ComponentModel;
using System.Linq;

namespace _13AMonsterGenerator
{
    internal class EnumUtilites
    {
        public static string StringValueOf(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static object EnumValueOf(string value, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (var name in names.Where(name => StringValueOf((Enum) Enum.Parse(enumType, name)).Equals(value)))
            {
                return Enum.Parse(enumType, name);
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }
}