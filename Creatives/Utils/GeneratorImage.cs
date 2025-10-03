using Microsoft.JSInterop;

namespace Creatives.Utils;

public class GeneratorImage
{
  private readonly IJSRuntime _jsRuntime;
  private readonly GeneratorImageModel _model;

  public GeneratorImage(IJSRuntime jsRuntime, GeneratorImageModel model)
  {
    _jsRuntime = jsRuntime;
    _model = model;
  }

  public async Task Execute()
  {
    await _jsRuntime.InvokeVoidAsync(identifier: "htmlToImage.download", _model.IdComponent, _model.TitleImage, HandleImageExtension(extension: _model.ImageExtension));
  }

  public enum ImageExtension
  {
    Png,
    Jpeg,
    Webp
  }

  private string HandleImageExtension(ImageExtension extension) => extension switch
  {
    ImageExtension.Png  => "image/png",
    ImageExtension.Jpeg => "image/jpeg",
    ImageExtension.Webp => "image/webp",
    _                   => throw new NotImplementedException()
  };

  public class GeneratorImageModel
  {
    public required string IdComponent { get; init; }
    public required string TitleImage { get; init; }
    public required ImageExtension ImageExtension { get; init; }
  }
}
