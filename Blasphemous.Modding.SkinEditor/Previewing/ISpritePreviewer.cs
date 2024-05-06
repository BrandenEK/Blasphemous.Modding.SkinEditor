
namespace Blasphemous.Modding.SkinEditor.Previewing;

public interface ISpritePreviewer
{
    void ChangePreview(Bitmap preview);

    void UpdatePreview(int pixel, Color color);

    IEnumerable<byte> GetPixelsInPreview();
}
