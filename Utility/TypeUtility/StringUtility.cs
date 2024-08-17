using Utility.TypeCheck;
using Utility.TypeConverter;

namespace Utility.TypeUtility
{
    public static class StringUtility
    {
        public static string MakeFirstLetterUpper(this string str, bool baglaclariVeOzelIsimleriDahilEt = false)
        {
            if (!baglaclariVeOzelIsimleriDahilEt && IsSpecialName(str))
            {
                return str;
            }
            if (!str.ToSafeString().Trim().IsNullOrEmpty())
            {
                return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            }
            return "";
        }

        private static bool IsSpecialName(string str)
        {
            string[] specialName =
            {
                "ve", "veya", "de", "da", "ki", "ile", "ise", "ama"
            };

            return specialName.Contains(str);
        }
    }
}
