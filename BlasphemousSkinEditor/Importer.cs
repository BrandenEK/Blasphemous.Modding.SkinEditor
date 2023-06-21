using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public class Importer
    {
        public void ImportTexture()
        {
            // Prompt user for texture path
            string texturePath = null;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Import existing texture";
                dialog.Filter = "PNG files (*.png)|*.png";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                texturePath = dialog.FileName;
            }

            using (Bitmap fileTexture = new Bitmap(texturePath))
            {
                // Validate texture
                if (fileTexture.Width != 256 || fileTexture.Height != 1)
                {
                    MessageBox.Show("Error: The texture must be 256x1 pixels!", "Import Texture");
                    return;
                }

                // Load info data if it exists
                string infoPath = texturePath.Substring(0, texturePath.LastIndexOf("\\") + 1) + "info.txt";
                Skin newSettings;
                if (File.Exists(infoPath))
                {
                    string jsonString = File.ReadAllText(infoPath);
                    newSettings = JsonConvert.DeserializeObject<Skin>(jsonString);
                }
                else
                {
                    newSettings = new Skin(SkinForm.UNKNOWN_ID, SkinForm.UNKNOWN_NAME, SkinForm.UNKNOWN_AUTHOR, SkinForm.UNKNOWN_VERSION);
                }

                // Update all necessary properties
                SkinForm.Instance.RealTexture = fileTexture;
                SkinForm.PreviewManager.UpdatePreviewImages(fileTexture);
                SkinForm.ButtonManager.UpdateAllButtons(fileTexture);
                SkinForm.Instance.UpdateSkinSettings(newSettings);
                SkinForm.UndoManager.Reset();
            }
        }
    }
}
