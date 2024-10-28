namespace SpeakerService.Api.model;

public record DevEvent( 
    Guid Id,    
    IFormFile? ImageDetailEventFile,
    IFormFile? ImageListEventFile);