using EventServices.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EventServices.Application.Services
{
    public class FileService : IFileService
    {
        private IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            try
            {
                string directoryPath = Path.Combine(_env.WebRootPath, "Files");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(directoryPath, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return $"/Resources/{fileName}";
            }
            catch (Exception ex)
            {
                return "FailedToUploadFile";
            }
        }
        public async Task<bool> DeleteAsync(string filePath)
        {
            try
            {
                // Remove leading slash and "Resources" part to match the physical file path
                if (filePath.StartsWith("/Resources"))
                {
                    filePath = filePath.Substring("/Resources".Length).TrimStart('/');
                }

                // Combine the path to point to the actual file location in the "wwwroot/Files" directory
                string fullPath = Path.Combine(_env.WebRootPath, "Files", filePath);

                // Check if the file exists and delete it
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                else
                {
                    // File doesn't exist
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed, such as logging
                return false;
            }
        }
    }
}
