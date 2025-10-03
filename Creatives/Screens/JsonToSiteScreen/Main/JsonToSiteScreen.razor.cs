using System.Text.Json;
using System.Text.RegularExpressions;
using Creatives.Enums;
using Creatives.Utils;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Creatives.Screens.JsonToSiteScreen.Main;

public partial class JsonToSiteScreen
{
  private string _text = string.Empty;
  private string _jsonText = string.Empty;

  private async Task HandleUploadFile(IBrowserFile file)
  {
    UploadFile uploadFile = new(fileType: FileType.Pdf);
    byte[] fileBytes = await uploadFile.ReadBytes(file: file);
    _text = await JsRuntime.InvokeAsync<string>(identifier: "pdfInterop.extractText", fileBytes);

    ParseAndShowJson(pdfText: _text);
  }

  private void ParseAndShowJson(string pdfText)
  {
    object parsedObject = ParsePdfTextToJson(text: pdfText);
    _jsonText = JsonSerializer.Serialize(value: parsedObject, options: new JsonSerializerOptions
    {
      WriteIndented = true
    });
  }


  private object ParsePdfTextToJson(string text)
  {
    string? GetValue(string label)
    {
      Match match = Regex.Match(input: text,
        pattern: $@"\d*\.*\s*{Regex.Escape(str: label)}\s*\.?\s*(.+)",
        options: RegexOptions.IgnoreCase);

      return match.Success ? match.Groups[groupnum: 1].Value.Trim() : null;
    }

    return new
    {
      DataRegistro = GetValue(label: "Data de registro"),
    };
  }
}
