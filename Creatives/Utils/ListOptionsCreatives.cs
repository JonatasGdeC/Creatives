using Creatives.Models;
using MudBlazor;

namespace Creatives.Utils;

public static class ListOptionsCreatives
{
  public static readonly List<OptionCreativeDto> ListOptions = new()
  {
    new()
    {
      Title = "Assinatura de e-mail",
      Icon = Icons.Material.Filled.Email,
      Url = "/assinatura-email"
    }
  };
}
