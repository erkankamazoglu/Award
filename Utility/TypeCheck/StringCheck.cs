using Utility.TypeConverter;

namespace Utility.TypeCheck
{
    public static class StringCheck
    {
        public static bool IsNullOrEmpty(this string? str)
        {
            return string.IsNullOrEmpty(str);
        } 
    }
}
