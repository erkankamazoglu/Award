namespace Utility.TypeConverter
{
    public static class DatetimeConverter
    {
        public static DateTime ToSafeDateTime(this object value)
        {
            return ToSafeDateTime(value, DateTime.MaxValue);
        }
        public static DateTime ToSafeDateTime(this object value, DateTime defaultValue)
        {
            DateTime result;
            if (value == null)
            {
                return defaultValue;
            }

            bool boolRes = DateTime.TryParse(value.ToString(), out result);
            if (boolRes)
            {
                return result;
            }

            return defaultValue;

        }
    }
}
