using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Flexio.Business.Users;

public static class FileUtils
{
    public static async Task<Stream> ToMemoryStream(IFormFile file)
    {
        var stream = new MemoryStream();

        if (file is null || file.ContentType is null || file.Length == 0)
        {
            return stream;
        }

        await file.CopyToAsync(stream);
        return stream;
    }
}