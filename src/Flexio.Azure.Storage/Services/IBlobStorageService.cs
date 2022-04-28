using Azure;
using Azure.Storage.Blobs.Models;

namespace Flexio.Azure.Storage.Services;

public interface IBlobStorageService
{
    public Task CreateContainer(string containerName);
    public Task DeleteContainer(string containerName);
    public Task Upload(string containerName, Stream file, string fileName);
    public Task Delete(string containerName, string blobName);
    public Task<Response<BlobDownloadResult>> Download(string containerName, string blobName);
}