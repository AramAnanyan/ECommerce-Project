using System.ComponentModel;
using System.Reflection;

namespace ECommerce.Domain.Helpers;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());

        if (field == null)
            return value.ToString();

        var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(
            field,
            typeof(DescriptionAttribute)
        );

        return attribute?.Description ?? value.ToString();
    }
}
