using Microsoft.AspNetCore.Components;

namespace Creatives.Layout.MainContainer;

public partial class MainContainer
{
  [Parameter] public required RenderFragment Body { get; set; }
  [Parameter] public required string TitlePage { get; set; }
  [Parameter] public bool AddDrawer { get; set; } = true;
}
