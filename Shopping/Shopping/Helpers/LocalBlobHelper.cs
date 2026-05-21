namespace Shopping.Helpers
{
    public class LocalBlobHelper : IBlobHelper
    {
        private readonly string _rootPath;

        public LocalBlobHelper(IWebHostEnvironment environment)
        {
            _rootPath = Path.Combine(environment.WebRootPath, "blob");
            Directory.CreateDirectory(_rootPath);
        }

        public Task DeleteBlobAsync(Guid id, string containerName)
        {
            string path = GetFilePath(containerName, id);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            return Task.CompletedTask;
        }

        public async Task<Guid> UploadBlobAsync(IFormFile file, string containerName)
        {
            await using Stream stream = file.OpenReadStream();
            return await UploadBlobAsync(stream, containerName);
        }

        public async Task<Guid> UploadBlobAsync(byte[] file, string containerName)
        {
            await using MemoryStream stream = new(file);
            return await UploadBlobAsync(stream, containerName);
        }

        public async Task<Guid> UploadBlobAsync(string image, string containerName)
        {
            await using FileStream stream = File.OpenRead(image);
            return await UploadBlobAsync(stream, containerName);
        }

        private async Task<Guid> UploadBlobAsync(Stream stream, string containerName)
        {
            Guid name = Guid.NewGuid();
            string directory = Path.Combine(_rootPath, containerName);
            Directory.CreateDirectory(directory);

            string path = GetFilePath(containerName, name);
            await using FileStream fileStream = File.Create(path);
            await stream.CopyToAsync(fileStream);
            return name;
        }

        private string GetFilePath(string containerName, Guid id) =>
            Path.Combine(_rootPath, containerName, id.ToString());
    }
}
