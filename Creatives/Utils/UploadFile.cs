using Creatives.Enums;
using Microsoft.AspNetCore.Components.Forms;

namespace Creatives.Utils;

public class UploadFile
{
  private readonly FileType _fileType;

  public UploadFile(FileType fileType)
  {
    _fileType = fileType;
  }

  public async Task<byte[]> ReadBytes(IBrowserFile file)
  {
    Stream stream = file.OpenReadStream(maxAllowedSize: HandleSizeFileInMegabytesByTypeFile() * 1024 * 1024);
    using MemoryStream ms = new();
    await stream.CopyToAsync(destination: ms);
    return ms.ToArray();
  }

  public async Task<string> Preview(IBrowserFile file)
  {
    byte[] bytes = await ReadBytes(file: file);
    return $"data:{file.ContentType};base64,{Convert.ToBase64String(inArray: bytes)}";
  }

  private int HandleSizeFileInMegabytesByTypeFile() => _fileType switch
  {
    FileType.Image => 50,
    FileType.Video => 500,
    FileType.Pdf   => 100,
    _              => throw new ArgumentOutOfRangeException()
  };
}
