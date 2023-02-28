using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LightTraveller.Helpers;

public static class EnumExtensions
{
    public static TAttrib? GetAttribute<TAttrib>(this Enum e) where TAttrib : Attribute
    {
        return e.GetType().GetMember(e.ToString()).First().GetCustomAttribute<TAttrib>();
    }

    public static string? GetDisplayName(this Enum e)
    {
        return e.GetAttribute<DisplayAttribute>()?.Name;
    }
}
