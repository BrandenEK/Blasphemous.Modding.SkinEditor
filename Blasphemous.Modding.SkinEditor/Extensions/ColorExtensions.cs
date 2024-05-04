
namespace Blasphemous.Modding.SkinEditor.Extensions;

public static class ColorExtensions
{
    public static Color GetTextColor(this Color c)
    {
        return c.R * 2 + c.G * 7 + c.B < 500 ? Color.White : Color.Black;
    }
}
