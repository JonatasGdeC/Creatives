using Creatives.Models;
using Creatives.Utils;
using Microsoft.AspNetCore.Components;

namespace Creatives.Layout.NavMenu;

public partial class NavMenu
{
  [Parameter] public required string TitlePage { get; set; }
  [Parameter] public bool AddDrawer { get; set; } = true;

  private bool _isDrawerOpen = true;
  private void ToggleDrawer() => _isDrawerOpen = !_isDrawerOpen;

  private static List<OptionCreativeDto> ListLinks => ListOptionsCreatives.ListOptions;
}
