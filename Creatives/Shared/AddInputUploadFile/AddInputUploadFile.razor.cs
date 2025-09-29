using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Creatives.Shared.AddInputUploadFile;

public partial class AddInputUploadFile
{
  [Parameter] public required RenderFragment Body { get; set; }
  [Parameter] public EventCallback<IBrowserFile> UploadFile { get; set; }
  [Parameter] public string Accept { get; set; } = ".png";
  [Parameter] public bool MultipleFiles { get; set; }
  [Parameter] public string Padding { get; set; } = "16px 32px";
  [Parameter] public string BorderRadius { get; set; } = "5px";

  private string _dragClass = string.Empty;

  private void SetDragClass() => _dragClass = "--active";
  private void ClearDragClass() => _dragClass = string.Empty;

  private async Task HandleUploadFile(InputFileChangeEventArgs args)
  {

    if (MultipleFiles)
    {
      foreach (IBrowserFile file in args.GetMultipleFiles(maximumFileCount: 100))
      {
        await UploadFile.InvokeAsync(arg: file);
        StateHasChanged();
      }
    }
    else
    {
      await UploadFile.InvokeAsync(arg: args.File);
    }
  }

  private string StyleInputPhoto()
  {
    string padding = $"padding: {Padding};";
    string borderRadius = $"border-radius: {BorderRadius};";

    return $"{padding}{borderRadius}";
  }
}
