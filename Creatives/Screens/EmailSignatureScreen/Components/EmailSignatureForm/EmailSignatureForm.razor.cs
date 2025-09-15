using Creatives.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Creatives.Screens.EmailSignatureScreen.Components.EmailSignatureForm;

public partial class EmailSignatureForm
{
  [Parameter] public EventCallback<EmailSignatureModel> EmailSignatureModelChanged { get; set; }
  [Parameter] public required EmailSignatureModel EmailSignatureModel { get; set; }

  private async Task UpdateForm()
  {
    await EmailSignatureModelChanged.InvokeAsync(arg: EmailSignatureModel);
    StateHasChanged();
  }

  public async Task Generate()
  {
    await JsRuntime.InvokeVoidAsync(identifier: "htmlToImage.download", "signature-card", "assinatura.png");
  }
}
