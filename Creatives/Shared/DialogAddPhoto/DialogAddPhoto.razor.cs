using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Creatives.Shared.DialogAddPhoto;

public partial class DialogAddPhoto
{
  [CascadingParameter] public required IMudDialogInstance MudDialog { get; set; }
  [Parameter] public required string Image { get; set; }

  private CropperImageComponent.CropperImageComponent? _cropRef;

  private void HandleCroppedImage(string image) => Image = image;

  private async Task Confirm()
  {
    if (_cropRef is not null)
    {
      await _cropRef.CropImageAsync();
    }

    MudDialog.Close(dialogResult: DialogResult.Ok(result: Image));
  }

  private void Cancel() => MudDialog.Cancel();
}
