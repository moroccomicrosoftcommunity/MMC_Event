namespace EventServices.Domain.DTOs
{

    public record EventGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId, 
        Guid ProgramId,
        ProgramOnlyGetDTO Program,
        ICollection<SessionGetDTO>   Sessions,
        Guid ThemeId

    );

    public record EventOnlyGetDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ProgramId,
        Guid ThemeId

    );

    public record EventPostDTO
    (
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );

    public record EventPutDTO
    (
        Guid Id,
        string Title,
        string? Address,
        string? Description,
        string? ImageDetailEventPath,
        string? ImageListEventPath,
        DateTime? StartDate,
        DateTime? EndDate,
        Guid CityId,
        Guid ThemeId,
        Guid? ProgramId
    );
}
