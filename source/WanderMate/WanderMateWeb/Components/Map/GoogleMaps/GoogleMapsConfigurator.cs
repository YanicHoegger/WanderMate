using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using WanderMateWeb.Components.Helpers;

namespace WanderMateWeb.Components.Map.GoogleMaps
{
    public static class GoogleMapsConfigurator
    {
        public static void AddGoogleMaps(this IServiceCollection services, IWebHostEnvironment webHostEnvironment)
        {
            var wwwRootUploader = new WwwRootUploader(webHostEnvironment);
            _ = wwwRootUploader.UploadFile(Path.Combine("Components/Map/GoogleMaps", FileNames.GoogleMapsInterop), FileNames.GoogleMapsInterop).Result;

            services.AddSingleton(wwwRootUploader);
            services.AddScoped<IMap, GoogleMaps>();
            services.AddHostedService<GoogleMapsCleanUp>();
        }
    }
}
