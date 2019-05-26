
using System.IO;
using Microsoft.Extensions.Configuration;

namespace MovieDatabase.Common.Helpers
{
    public static class AppSettingsHelper
    {
        private static IConfigurationRoot ConfigurationRoot()
        {
            var builder = new ConfigurationBuilder();
            var path = $@"{Directory.GetCurrentDirectory()}\appsettings.json";
            builder.AddJsonFile(path);

            var root = builder.Build();
            return root;
        }
        public static string ConnectionString
        {
            get
            {
                var result = ConfigurationRoot().GetSection("ConnectionString").GetSection("MovieDatabaseDb").Value;
                return result;
            }
        }
    }
}