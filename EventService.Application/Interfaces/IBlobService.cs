using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadAsync(Guid fileId, IFormFile file);
        string DeleteAsync(string fileId);
        string GetFileUrl(Guid fileId);
    }
}
