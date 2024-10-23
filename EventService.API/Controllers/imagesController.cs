using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using EventService.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeakerService.Api.model;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;

namespace SpeakerService.Api.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // public class imagesController : ControllerBase
    // {
    //     private readonly ApplicationDbContext _dbContext;
    //     private readonly BlobServiceClient _blobServiceClient;
    //     private const string ContainerName = "mmc";
    //     private readonly BlobContainerClient _containerClient;
    //     public string key = "O/jPRRQCyjEoHfQekkMsvb888JdEFrgT8yDZOdw22PODddDNw6HIYEiGBIn7dUX795/UetM44VBL+AStPIE06g==";
    //     public imagesController(ApplicationDbContext EventDBContext, BlobServiceClient blobServiceClient)
    //     {
    //         _dbContext = EventDBContext;
    //         _blobServiceClient = blobServiceClient;
    //         _containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
    //         _containerClient.CreateIfNotExists();
    //         
    //     }
    //
    //     [HttpPost("/uploadeventimages")]
    //     public async Task<IActionResult> Uploadevent(Images image)
    //     {
    //         var events = await _dbContext.Events.FindAsync(image.EventId);
    //         if (events == null)
    //         {
    //             throw new InvalidOperationException("event not found");
    //         }
    //         string uniqueFileName = $"detailImage_{image.EventId}_{image.File.FileName}";
    //         var blobClient = _containerClient.GetBlobClient(uniqueFileName);
    //         await blobClient.UploadAsync(image.File.OpenReadStream(), true);
    //         //Ok("File uploaded successfully.");
    //         var Data = GetFileUrls("detailImage_"+image.EventId);
    //         events.ImagePath = Data;
    //         _dbContext.SaveChanges();
    //         return Ok(Data);
    //     }
    //
    //     [HttpPost("/uploadsliderimage")]
    //     public async Task<IActionResult> UploadSliderImage(Images image)
    //     {
    //         var events = await _dbContext.Events.FindAsync(image.EventId);
    //         if (events == null)
    //         {
    //             throw new InvalidOperationException("event not found");
    //         }
    //         string uniqueFileName = $"sliderImage_{image.EventId}_{image.File.FileName}";
    //         var blobClient = _containerClient.GetBlobClient(uniqueFileName);
    //         await blobClient.UploadAsync(image.File.OpenReadStream(), true);
    //         //Ok("File uploaded successfully.");
    //         var Data = GetFileUrls("sliderImage_"+ image.EventId);
    //         events.ImageSliderlPath = Data;
    //         _dbContext.SaveChanges();
    //         return Ok(Data);
    //     }
    //
    //     [HttpPost("/uploadimageforlistevent")]
    //     public async Task<IActionResult> UploadImageForListEvent(Images image)
    //     {
    //         var events = await _dbContext.Events.FindAsync(image.EventId);
    //         if (events == null)
    //         {
    //             throw new InvalidOperationException("event not found");
    //         }
    //         string uniqueFileName = $"listImages_{image.EventId}_{image.File.FileName}";
    //         var blobClient = _containerClient.GetBlobClient(uniqueFileName);
    //         await blobClient.UploadAsync(image.File.OpenReadStream(), true);
    //         //Ok("File uploaded successfully.");
    //         var Data = GetFileUrls($"listImages_{image.EventId}");
    //         events.ImageListEventPath = Data;
    //         _dbContext.SaveChanges();
    //         return Ok(Data);
    //     }
    //
    //
    //
    //     [HttpGet("count")]
    //     public int CountFilesInContainer()
    //     {
    //         var blobs = _containerClient.GetBlobs();
    //         int fileCount = blobs.Count();
    //
    //         return fileCount;
    //     }
    //
    //     [HttpGet("names")]
    //     public IEnumerable<string> GetFileNamesInContainer()
    //     {
    //         var blobs = _containerClient.GetBlobs();
    //
    //         var fileNames = new List<string>();
    //         foreach (var blobItem in blobs)
    //         {
    //             fileNames.Add(blobItem.Name);
    //         }
    //
    //         return fileNames;
    //     }
    //
    //     [HttpGet("url")]
    //     public string GetFileUrl(string fileName)
    //     {
    //         fileName = "ConnaissancesIntelligenceArtificielle.png";
    //         try
    //         {
    //             BlobClient blobClient = _containerClient.GetBlobClient(fileName);
    //
    //             BlobSasBuilder sasBuilder = new BlobSasBuilder()
    //             {
    //                 BlobContainerName = _containerClient.Name,
    //                 BlobName = blobClient.Name,
    //                 Resource = "b",
    //                 StartsOn = DateTimeOffset.UtcNow,
    //                 ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
    //             };
    //
    //             sasBuilder.SetPermissions(BlobSasPermissions.Read);
    //             StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(_containerClient.AccountName, key);
    //
    //             string sasToken = sasBuilder.ToSasQueryParameters(sharedKeyCredential).ToString();
    //             Uri blobUrlWithSas = new Uri(blobClient.Uri, $"{fileName}?{sasToken}");
    //
    //             return blobUrlWithSas.ToString();
    //         }
    //         catch (RequestFailedException ex)
    //         {
    //             Console.WriteLine($"Error: {ex.ErrorCode} - {ex.Message}");
    //             return null;
    //         }
    //     }
    //
    //     [HttpGet("{fileId}")]
    //     public string GetFileUrls([FromRoute]string fileId)
    //     {
    //         try
    //         {
    //             List<string> urls = new List<string>();
    //
    //             foreach (BlobItem blobItem in _containerClient.GetBlobs(prefix: fileId.ToString()))
    //             {
    //                 string fileName = blobItem.Name;
    //                 BlobClient blobClient = _containerClient.GetBlobClient(fileName);
    //                 BlobSasBuilder sasBuilder = new BlobSasBuilder()
    //                 {
    //                     BlobContainerName = _containerClient.Name,
    //                     BlobName = blobClient.Name,
    //                     Resource = "b",
    //                     StartsOn = DateTimeOffset.UtcNow,
    //                     ExpiresOn = DateTimeOffset.UtcNow.AddYears(10)
    //                 };
    //                 sasBuilder.SetPermissions(BlobSasPermissions.Read);
    //                 StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(_containerClient.AccountName, key);
    //                 string sasToken = sasBuilder.ToSasQueryParameters(sharedKeyCredential).ToString();
    //                 Uri blobUrlWithSas = new Uri(blobClient.Uri, $"{fileName}?{sasToken}");
    //                 urls.Add(blobUrlWithSas.ToString());
    //             }
    //             if (urls.Count() == 0)
    //             {
    //                 return "NaN";
    //             }
    //             else
    //             {
    //                 return urls[0];
    //             }
    //         }
    //         catch (RequestFailedException ex)
    //         {
    //             Console.WriteLine($"Error: {ex.ErrorCode} - {ex.Message}");
    //             return null;
    //         }
    //     }
    //
    //     [HttpDelete("{fileId}")]
    //     public IActionResult DeleteBlobsById(string fileId)
    //     {
    //         try
    //         {
    //             foreach (BlobItem blobItem in _containerClient.GetBlobs(prefix: fileId))
    //             {
    //                 _containerClient.DeleteBlobIfExists(blobItem.Name);
    //             }
    //
    //             return Ok($"Blobs with ID {fileId} deleted successfully.");
    //         }
    //         catch (RequestFailedException ex)
    //         {
    //             Console.WriteLine($"Error: {ex.ErrorCode} - {ex.Message}");
    //             return StatusCode(500, "An error occurred while deleting blobs.");
    //         }
    //     }
    //
    //
    //     [HttpGet]
    //     public string GetHAHA() 
    //     {
    //         return "HAHAHA";
    //     }
    // }
}
