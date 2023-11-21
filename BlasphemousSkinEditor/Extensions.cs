using System.Drawing;

namespace BlasphemousSkinEditor
{
    public static class Extensions
    {
        public static string FormatId(this string str) => str.ToUpper().Replace(' ', '_');

        public static bool IsNullOrEmpty(this string str) => str == null || str == string.Empty;

        public static string ToHTML(this Color color)
        {
            return "#" +
                color.R.ToString("X2") +
                color.G.ToString("X2") +
                color.B.ToString("X2");
        }
    }
}
