using Utility.TypeCheck;

namespace Utility.TypeConverter
{
    public static class StringConverter
    { 
        public static string ToSafeString(this object? value, string defaultValue = "")
        {
            string result;
            if (value == null) 
                return defaultValue; 

            try
            {
                result = value.ToString();
            }
            catch
            {
                result = defaultValue;
            }

            return result;
        } 

        public static string ToConcat(this List<string>? list, string seperator = ",")
        {
            if (list != null && list.Any())
                return string.Join(seperator, list.Where(i => !i.IsNullOrEmpty()));

            return "";
        }

        public static string TurkishCharactersToLatin(this string str)
        {
            char[] oldValue = { 'ö', 'Ö', 'ü', 'Ü', 'ç', 'Ç', 'ı', 'İ', 'Ğ', 'ğ', 'Ş', 'ş' };
            char[] newValue = { 'o', 'O', 'u', 'U', 'c', 'C', 'i', 'I', 'G', 'g', 'S', 's' };
            for (int i = 0; i < oldValue.Length; i++)
            {
                str = str.Replace(oldValue[i], newValue[i]);
            } 

            return str;
        }

        public static string ToThousand(this decimal value)
        {
            if (value == null)
                return "0,00";

            string res = value.ToString("N");
            return res;
        }
    }
}
