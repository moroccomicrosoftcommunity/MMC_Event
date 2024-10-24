using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
        Task<bool> DeleteAsync(string filePath);
    }
}
