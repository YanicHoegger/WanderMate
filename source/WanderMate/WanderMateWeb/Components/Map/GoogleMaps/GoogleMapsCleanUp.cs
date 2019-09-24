using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Utilities;
using WanderMateWeb.Components.Helpers;

namespace WanderMateWeb.Components.Map.GoogleMaps
{
    public class GoogleMapsCleanUp : DisposableBase, IHostedService
    {
        private readonly WwwRootUploader _wwwRootUploader;

        public GoogleMapsCleanUp(WwwRootUploader wwwRootUploader)
        {
            _wwwRootUploader = wwwRootUploader;
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                _wwwRootUploader.DeleteFile(FileNames.GoogleMapsInterop);
            }

            base.Dispose(disposing);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Nothing to do
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //Nothing to do
            return Task.CompletedTask;
        }
    }
}
