
namespace BlasphemousSkinEditor
{
    public static class Extensions
    {
        public static string FormatId(this string str) => str.ToUpper().Replace(' ', '_');

        public static bool IsNullOrEmpty(this string str) => str == null || str == string.Empty;
    }
}
