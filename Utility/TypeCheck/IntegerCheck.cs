using Utility.TypeConverter;

namespace Utility.TypeCheck
{
    public static class IntegerCheck
    {
        public static bool IsInt(this object value)
        {
            if (value.IsNullOrEmpty())
                return false;

            bool result = Int32.TryParse(value.ToSafeString(), out _);

            return result;
        }

        public static bool IsMaxIntValue(this int value)
        {
            return value == int.MaxValue;
        }

        public static bool IsMinIntValue(this int value)
        {
            return value == int.MinValue;
        }
    }
}
