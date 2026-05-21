namespace Shopping.Helpers
{
    public static class BlobUrlHelper
    {
        public static string GetBlobUrl(string container, Guid imageId)
        {
            if (imageId == Guid.Empty)
            {
                return string.Empty;
            }

            string? publicBaseUrl = Environment.GetEnvironmentVariable("Blob__PublicBaseUrl")
                ?? Environment.GetEnvironmentVariable("Blob:PublicBaseUrl");

            if (!string.IsNullOrWhiteSpace(publicBaseUrl))
            {
                return $"{publicBaseUrl.TrimEnd('/')}/{container}/{imageId}";
            }

            return $"https://shoppingzulu.blob.core.windows.net/{container}/{imageId}";
        }
    }
}
