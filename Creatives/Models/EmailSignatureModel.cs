namespace Creatives.Models;

public class EmailSignatureModel
{
  public string Name { get; set; } = string.Empty;
  public string? PhoneNumber { get; set; }
  public bool AddPhoneNumber { get; set; } = true;
  public string? Email { get; set; }
  public bool AddEmail { get; set; } = true;
}
