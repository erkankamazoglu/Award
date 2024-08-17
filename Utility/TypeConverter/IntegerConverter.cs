namespace Utility.TypeConverter
{
    public static class IntegerConverter
    {

        public static int ToSafeInt32(this object? value)
        {
            return value.ToSafeInt32(int.MaxValue);
        }

        public static int ToSafeInt32(this object? value, int defaultValue)
        {
            int number;
            if (value == null || value.ToString() == "")
            {
                return defaultValue;
            }

            bool result = int.TryParse(value.ToString(), out number);
            if (result)
            {
                return number;
            }

            return defaultValue;
        }
    }
}
