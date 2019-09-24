using System.IO;
using System.Reflection;

namespace Utilities
{
    public static class ResourceHelper
    {
        public static Stream GetEmbeddedResource(string resourceName)
        {
            return GetEmbeddedResource(resourceName, Assembly.GetCallingAssembly());
        }

        public static Stream GetEmbeddedResource(string resourceName, Assembly assembly)
        {
            resourceName.CheckNotNull(nameof(resourceName));
            resourceName.CheckNotNull(nameof(assembly));

            var formattedResourceName = FormatResourceName(assembly, resourceName);

            return assembly.GetManifestResourceStream(formattedResourceName);
        }

        private static string FormatResourceName(Assembly assembly, string resourceName)
        {
            return assembly.GetName().Name + "." + resourceName.Replace(" ", "_")
                .Replace("\\", ".")
                .Replace("/", ".");
        }
    }
}
