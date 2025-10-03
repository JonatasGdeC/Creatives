using Creatives.Enums;
using Creatives.Models;
using Creatives.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Creatives.Screens.EmailSignatureScreen.Components.EmailSignatureForm;

public partial class EmailSignatureForm
{
  [Parameter] public EventCallback<EmailSignatureModel> EmailSignatureModelChanged { get; set; }
  [Parameter] public required EmailSignatureModel EmailSignatureModel { get; set; }

  private GeneratorImage.ImageExtension _imageExtension = GeneratorImage.ImageExtension.Png;

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

  private async Task Generate()
  {
    GeneratorImage generatorImage = new(jsRuntime: JsRuntime, model: new GeneratorImage.GeneratorImageModel
    {
      IdComponent = "signature-card",
      TitleImage = "assinatura",
      ImageExtension = _imageExtension
    });

    await generatorImage.Execute();
  }
}
