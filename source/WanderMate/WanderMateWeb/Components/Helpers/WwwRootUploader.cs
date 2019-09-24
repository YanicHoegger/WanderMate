using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Utilities;

namespace WanderMateWeb.Components.Helpers
{
    public class WwwRootUploader
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WwwRootUploader(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Uploads file into wwwroot
        /// </summary>
        /// <param name="copyFromPath">
        /// Absolute path of file to copy
        /// </param>
        /// <param name="copyToPath">
        /// Relative path of file in wwwroot
        /// </param>
        /// <returns></returns>
        public async Task<bool> UploadFile(string copyFromPath, string copyToPath)
        {
            if (!string.IsNullOrWhiteSpace(copyFromPath))
            {
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, copyToPath);
                using (var readingStream = ResourceHelper.GetEmbeddedResource(copyFromPath))
                using (var writingStream = new FileStream(filePath, FileMode.Create))
                {
                    await StreamCopier.CopyStream(readingStream, writingStream);
                }
                return true;
            }
            return false;
        }

        public void DeleteFile(string path)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, path);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
