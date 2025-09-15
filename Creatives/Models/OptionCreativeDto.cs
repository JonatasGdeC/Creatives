namespace Creatives.Models;

public record OptionCreativeDto
{
  public required string Title { get; init; }
  public required string Icon { get; init; }
  public required string Url { get; init; }
}
