namespace ApplicationCore.Contracts.Services
{
    public interface IBlobService
    {
        Task<Uri> UploadFileBlobAsync(Stream content, string contentType, string fileName);
        Task<bool> CheckIfBlobExistsAsync(string blobName);
        string ContainerName { get; set; }
    }
}