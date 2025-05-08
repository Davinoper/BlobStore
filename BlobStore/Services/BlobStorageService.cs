using Azure.Storage.Blobs;


namespace BlobStore.Services;

public class BlobStorageService
{
    private readonly BlobContainerClient _containerClient;

    public BlobStorageService(IConfiguration config)
    {
        var connectionString = config["StorageConnection:connectionString"];
        var containerName = config["StorageConnection:container"];
        _containerClient = new BlobContainerClient(connectionString, containerName);
        _containerClient.CreateIfNotExists(); 
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        var blobClient = _containerClient.GetBlobClient(file.FileName);

        using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, overwrite: true);

        return blobClient.Uri.ToString();
    }
}
