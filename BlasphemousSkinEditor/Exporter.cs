using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public class Exporter
    {
        public void ExportTexture(Skin settings, Bitmap texture, PreviewImage idlePreview, PreviewImage chargedPreview)
        {
            // Prompt user for new settings
            string id = PromptId(settings.id);
            string name = PromptName(settings.name);
            string author = PromptAuthor(settings.author);
            string version = PromptVersion(settings.version);
            settings = new Skin(id, name, author, version);
            SkinForm.Instance.UpdateSkinSettings(settings);

            // Create output path
            string outputPath = $"{Environment.CurrentDirectory}\\output\\{id}\\";
            Directory.CreateDirectory(outputPath);

            // Save texture
            texture.Save(outputPath + "texture.png", ImageFormat.Png);

            // Save idle preview
            using (Bitmap scaledIdle = idlePreview.ScaledPreview)
            {
                scaledIdle.Save(outputPath + "idlePreview.png", ImageFormat.Png);
            }

            // Save charged preview
            using (Bitmap scaledCharged = chargedPreview.ScaledPreview)
            {
                scaledCharged.Save(outputPath + "chargedPreview.png", ImageFormat.Png);
            }

            // Save info
            string jsonString = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(outputPath + "info.txt", jsonString);

            MessageBox.Show("Texture successfully saved!", "Export Texture");
        }

        private string PromptId(string currentId)
        {
            using (TextPrompt idPrompt = new TextPrompt("Skin Id:", "Export Texture", currentId))
            {
                return idPrompt.Result.IsNullOrEmpty() ? SkinForm.UNKNOWN_ID : idPrompt.Result.FormatId();
            }
        }

        private string PromptName(string currentName)
        {
            using (TextPrompt namePrompt = new TextPrompt("Skin Name:", "Export Texture", currentName))
            {
                return namePrompt.Result.IsNullOrEmpty() ? SkinForm.UNKNOWN_NAME : namePrompt.Result;
            }
        }

        private string PromptAuthor(string currentAuthor)
        {
            using (TextPrompt authorPrompt = new TextPrompt("Skin Author:", "Export Texture", currentAuthor))
            {
                return authorPrompt.Result.IsNullOrEmpty() ? SkinForm.UNKNOWN_AUTHOR : authorPrompt.Result;
            }
        }

        private string PromptVersion(string currentVersion)
        {
            using (TextPrompt versionPrompt = new TextPrompt("Skin Version:", "Export Texture", currentVersion))
            {
                return versionPrompt.Result.IsNullOrEmpty() ? SkinForm.UNKNOWN_VERSION : versionPrompt.Result;
            }
        }
    }
}
