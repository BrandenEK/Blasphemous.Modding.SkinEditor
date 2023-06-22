using System.Drawing;

namespace BlasphemousSkinEditor
{
    public class PixelGroup
    {
        public string name;
        public Size boxSize;
        public byte[] pixels;

        public PixelGroup(string name, Size boxSize, byte[] pixels)
        {
            this.name = name;
            this.boxSize = boxSize;
            this.pixels = pixels;
        }
    }
}
