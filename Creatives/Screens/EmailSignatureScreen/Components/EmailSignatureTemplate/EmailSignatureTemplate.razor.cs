using Creatives.Models;
using Microsoft.AspNetCore.Components;

namespace Creatives.Screens.EmailSignatureScreen.Components.EmailSignatureTemplate;

public partial class EmailSignatureTemplate
{
  [Parameter] public required EmailSignatureModel EmailSignatureModel { get; set; }
}
