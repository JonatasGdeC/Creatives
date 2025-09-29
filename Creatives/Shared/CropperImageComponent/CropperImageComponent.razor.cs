using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Creatives.Shared.CropperImageComponent;

public partial class CropperImageComponent
{
  [Parameter] public required string Image { get; set; }
  [Parameter] public EventCallback<string> OnCropComplete { get; set; }

  private string? _croppedImage = string.Empty;

  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      await JsRuntime.InvokeVoidAsync(identifier: "cropperInterop.initializeCropper", args: "imageToCrop");
    }
  }

  public async Task CropImageAsync()
  {
    _croppedImage = await JsRuntime.InvokeAsync<string>(identifier: "cropperInterop.getCroppedImageBase64");
    await OnCropComplete.InvokeAsync(arg: _croppedImage);
    StateHasChanged();
  }

  public async ValueTask DisposeAsync()
  {
    await JsRuntime.InvokeVoidAsync(identifier: "cropperInterop.destroyCropper");
  }
}
