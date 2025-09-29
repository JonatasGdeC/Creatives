using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Creatives.Shared.InputPhoto;

public partial class InputPhoto
{
  [Parameter] public string? Value { get; set; }
  [Parameter] public EventCallback<string> ValueChanged { get; set; }
  private IBrowserFile? _file;
  private string _dragClass = string.Empty;
  private string? _base64Image;

  private async Task UploadFile(InputFileChangeEventArgs args)
  {
    _file = args.File;

    if (_file != null)
    {
      byte[] buffer = new byte[_file.Size];
      await _file.OpenReadStream().ReadExactlyAsync(buffer: buffer);
      string base64Image = $"data:{_file.ContentType};base64,{Convert.ToBase64String(inArray: buffer)}";

      if (!string.IsNullOrEmpty(value: base64Image))
      {
        DialogParameters parameters = new(){ [parameterName: "Image"] = base64Image };
        IDialogReference dialog = await DialogService.ShowAsync<DialogAddPhoto.DialogAddPhoto>(title: string.Empty, parameters: parameters);
        DialogResult? result = await dialog.Result;

        if (result != null && !result.Canceled && result.Data is string cropped)
        {
          _base64Image = cropped;
          await ValueChanged.InvokeAsync(arg: _base64Image);
        }
      }
    }
  }

  private void SetDragClass() => _dragClass = "--active";
  private void ClearDragClass() => _dragClass = string.Empty;
}
