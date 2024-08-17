namespace Utility.TypeConverter
{
    public static class BooleanConverter
    {
        public static bool ToSafeBool(this object? obj)
        {
            if (obj == null)
                return false;

            string st = obj.ToSafeString();

            if (string.IsNullOrEmpty(st))
                return false;

            st = st.ToLower();

            if (st == "1" || st == "evet" || st == "yes" || st == "true" || st == "on" || st == "on,0")
                return true;

            return false;
        }
    }
}
