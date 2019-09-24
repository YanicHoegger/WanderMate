using System.IO;
using System.Threading.Tasks;

namespace Utilities
{
    public static class StreamCopier
    {
        private const int _bufferSize = 4096;

        public static async Task CopyStream(Stream source, Stream destination)
        {
            source.CheckNotNull(nameof(source));
            destination.CheckNotNull(nameof(destination));

            var buffer = new byte[_bufferSize];
            int len;
            while ((len = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                await destination.WriteAsync(buffer, 0, len);
            }
        }
    }
}
