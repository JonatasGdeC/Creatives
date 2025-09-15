using Creatives.Models;
using Creatives.Utils;

namespace Creatives.Screens.HomeScreen.Main;

public partial class HomeScreen
{
  private static List<OptionCreativeDto> ListLinks => ListOptionsCreatives.ListOptions;

  private void NavigateTo(string url) => NavigationManager.NavigateTo(uri: url);
}
