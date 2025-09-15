using Creatives.Models;

namespace Creatives.Screens.EmailSignatureScreen.Main;

public partial class EmailSignatureScreen
{
  private EmailSignatureModel _emailSignatureModel = new();
  private string _keyImage = Guid.NewGuid().ToString();

  private void HandleUpdateForm(EmailSignatureModel emailSignatureModel)
  {
    _emailSignatureModel = emailSignatureModel;
    _keyImage = Guid.NewGuid().ToString();
    StateHasChanged();
  }
}
