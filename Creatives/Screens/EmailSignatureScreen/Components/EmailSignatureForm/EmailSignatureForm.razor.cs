using Creatives.Enums;
using Creatives.Models;
using Creatives.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Creatives.Screens.EmailSignatureScreen.Components.EmailSignatureForm;

public partial class EmailSignatureForm
{
  [Parameter] public EventCallback<EmailSignatureModel> EmailSignatureModelChanged { get; set; }
  [Parameter] public required EmailSignatureModel EmailSignatureModel { get; set; }

  private async Task HandleUploadFile(IBrowserFile file)
  {
    UploadFile uploadFile = new(fileType: FileType.Image);
    string imagePreview = await uploadFile.Preview(file: file);
    EmailSignatureModel.Photo = imagePreview;
    await UpdateForm();
  }

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
