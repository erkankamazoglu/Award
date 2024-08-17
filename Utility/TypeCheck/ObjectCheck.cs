using Utility.TypeConverter;

namespace Utility.TypeCheck
{
    public static class ObjectCheck
    { 
        public static bool IsNullOrEmpty(this object? value)
        {
            if(value == null)
                return true;

            return string.IsNullOrEmpty(value.ToSafeString());
        } 
    }
}
