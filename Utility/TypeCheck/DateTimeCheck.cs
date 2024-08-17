using Utility.TypeConverter;

namespace Utility.TypeCheck
{
    public static class DateTimeCheck
    {
        
        public static bool IsDateTime(this object? value)
        {
            if (value == null)
                return true;
            if (value.ToSafeString() == "")
                return true;

            return DateTime.TryParse(value.ToSafeString(), out _); 
        }

        public static bool IsTimeSpan(object? value)
        {
            if (value == null)
                return true;
            if (value.ToSafeString() == "")
                return true;

            if (TimeSpan.TryParse(value.ToSafeString(), out _))
            {
                return true;
            }
            return false;
        }
    }
}
