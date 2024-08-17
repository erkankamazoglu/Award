namespace Utility.TypeConverter
{
    public static class DecimalConverter
    {
        public static decimal ToSafeDecimal(this object? value)
        {
            return ToSafeDecimal(value, int.MaxValue);
        }

        public static decimal ToSafeDecimal(this object? value, decimal defaultValue)
        {
            decimal number;
            if (value == null || value.ToString() == "")
            {
                return defaultValue;
            }

            bool result = Decimal.TryParse(value.ToString(), out number);
            if (result)
            {
                return number;
            }

            return defaultValue;
        } 
    }
}
