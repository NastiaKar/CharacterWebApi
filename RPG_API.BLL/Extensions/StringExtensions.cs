using RPG_API.Models.Enums;

namespace RPG_API.BLL.Extensions;

public static class StringExtensions
{
    public static RpgClass ConvertToRpgClass(this string source)
    {
        bool parsed = Enum.TryParse(source, out RpgClass rpgClass);
        if (!parsed)
            throw new Exception("RpgClass not detected.");
        return rpgClass;
    }
}