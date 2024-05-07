
namespace Blasphemous.Modding.SkinEditor.Extensions;

public static class StringExtensions
{
    public static bool HasInvalidCharacter(this string str)
    {
        foreach (char c in str)
        {
            if (SPECIAL_CHARACTERS.Contains(c))
                return true;
        }

        return false;
    }

    private const string SPECIAL_CHARACTERS = "<>:\"/\\|?*";
}
