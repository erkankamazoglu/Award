using Microsoft.Extensions.Configuration; 

namespace Utility.ConfigurationFile
{
    public static class ConfigurationFileHelper
    {
        private static IConfigurationRoot GetIConfigurationRoot()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            IConfigurationRoot root = configurationBuilder.Build();
            return root;
        }

        private static object? GetAppSetting(string key)
        {
            string? res = GetIConfigurationRoot().GetSection("AppSettings").GetSection(key).Value;
            return res;
        }

        private static string? GetConnectionString(string key)
        {
            string? res = GetIConfigurationRoot().GetSection("ConnectionStrings").GetSection(key).Value;
            return res;
        }

        public static string GetDefaultConnectionString()
        {
            return GetConnectionString("DefaultConnection")!;
        } 
    }
}
