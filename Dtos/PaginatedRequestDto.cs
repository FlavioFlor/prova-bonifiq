using System.Text.Json.Serialization;

namespace ProvaPub.Dtos;

public sealed record PaginatedRequestDto
{
    public string Filter { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
    [JsonIgnore]
    public int? SkipPage => (Page - 1) * Limit;
}