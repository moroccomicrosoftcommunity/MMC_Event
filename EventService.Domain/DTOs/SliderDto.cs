namespace EventServices.Domain.DTOs;

public record SliderDto(
    Guid Id,
    string Title,
    string Description,
    string ImagePath,
    bool IsDisabled,
    string MoreText,
    string MoreLink
    );