using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Flexio.Azure.Storage.Configuration;
using Microsoft.Extensions.Options;

namespace Flexio.Azure.Storage.Services;

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageService(IOptions<AzureStorageSettings> settings)
    {
        _blobServiceClient = new BlobServiceClient(settings.Value.ConnectionString);
    }

    public BlobStorageService(string connectionString)
    {
        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public List<BlobContainerItem> GetAllContainers() =>
        _blobServiceClient.GetBlobContainers().ToList();

    public async Task CreateContainer(string containerName) =>
        await _blobServiceClient.CreateBlobContainerAsync(containerName, PublicAccessType.Blob);

    public async Task DeleteContainer(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        await containerClient.DeleteAsync();
    }

    public async Task<string> Upload(string containerName, Stream file, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        if (!await containerClient.ExistsAsync())
        {
            await CreateContainer(containerName);
        }

        var blobClient = containerClient.GetBlobClient(fileName);

        ResetStreamPosition(file);

        await blobClient.UploadAsync(file, true);

        return blobClient.Uri.ToString();
    }

    public async Task Delete(string containerName, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(blobName);

        await blobClient.DeleteAsync(DeleteSnapshotsOption.IncludeSnapshots);
    }

    public async Task<Response<BlobDownloadResult>> Download(string containerName, string blobName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(blobName);

        return await blobClient.DownloadContentAsync();
    }

    public static void ResetStreamPosition(Stream stream) => stream.Position = 0;

    public BlobContainerClient GetBlobContainer(string containerName) =>
        _blobServiceClient.GetBlobContainerClient(containerName);
}