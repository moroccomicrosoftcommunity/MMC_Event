using EventServices.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EventServices.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<FileService> _logger;

        public FileService(IWebHostEnvironment env, ILogger<FileService> logger)
        {
            _env = env;
            _logger = logger;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            try
            {
                if (_env.WebRootPath == null)
                {
                    _logger.LogError("WebRootPath is null. Ensure that WebRootPath is correctly configured.");
                    return "FailedToUploadFile";
                }

                string directoryPath = Path.Combine(_env.WebRootPath, "Files");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    _logger.LogInformation("Created directory at {DirectoryPath}", directoryPath);
                }

                string fileExtension = Path.GetExtension(file.FileName);
                string fileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(directoryPath, fileName);

                _logger.LogInformation("Starting file upload for {FileName} to {FilePath}", file.FileName, filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                _logger.LogInformation("File {FileName} uploaded successfully to {FilePath}", fileName, filePath);
                return $"/Resources/{fileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to upload file {FileName}", file.FileName);
                return "FailedToUploadFile";
            }
        }

        public async Task<bool> DeleteAsync(string filePath)
        {
            try
            {
                if (_env.WebRootPath == null)
                {
                    _logger.LogError("WebRootPath is null. Ensure that WebRootPath is correctly configured.");
                    return false;
                }

                if (filePath.StartsWith("/Resources"))
                {
                    filePath = filePath.Substring("/Resources".Length).TrimStart('/');
                }

                string fullPath = Path.Combine(_env.WebRootPath, "Files", filePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    _logger.LogInformation("File {FilePath} deleted successfully", fullPath);
                    return true;
                }
                else
                {
                    _logger.LogWarning("File {FilePath} not found for deletion", fullPath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete file {FilePath}", filePath);
                return false;
            }
        }

    }
}
