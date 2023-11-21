using BlasphemousSkinEditor.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BlasphemousSkinEditor
{
    public class Exporter
    {
        public void ExportTexture(Skin settings, Bitmap texture)
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
            using (Bitmap scaledIdle = SkinForm.PreviewManager.IdlePreview.ScaledPreview)
            {
                scaledIdle.Save(outputPath + "idlePreview.png", ImageFormat.Png);
            }

            // Save charged preview
            using (Bitmap scaledCharged = SkinForm.PreviewManager.ChargedPreview.ScaledPreview)
            {
                scaledCharged.Save(outputPath + "chargedPreview.png", ImageFormat.Png);
            }

            // 0b,1a,2e,3c,3f,4e,53,57,76,8a,8b,8d,a0,a3,af,b7,bc,bd

            // Serialize the colors from palette into a dictionary
            var colors = new Dictionary<byte, string>();
            byte[] colorIndexes = new byte[]
            {
                11, 26, 46, 60, 63, 78, 83, 87, 118, 138,
                139, 141, 160, 163, 175, 183, 188, 189
            };
            for (int i = 0; i < colorIndexes.Length; i++)
                colors[colorIndexes[i]] = texture.GetPixel(colorIndexes[i], 0).ToHTML();
            string json = JsonConvert.SerializeObject(colors);

            // Parse the json into a dictionary of real colors
            var jsonColors = JsonConvert.DeserializeObject<Dictionary<byte, string>>(json);
            var realColors = new Dictionary<byte, Color>();
            foreach (var kvp in jsonColors)
            {
                realColors[kvp.Key] = ColorTranslator.FromHtml(kvp.Value);
            }

            // Color each pixel of the preview based on the json value
            using (Bitmap unlock = Resources.final_grayscale)
            {
                for (int i = 0; i < unlock.Width; i++)
                {
                    for (int j = 0; j < unlock.Height; j++)
                    {
                        Color pixel = unlock.GetPixel(i, j);
                        if (pixel.R != pixel.G || pixel.R != pixel.B || !realColors.TryGetValue(pixel.R, out Color color))
                            continue;

                        unlock.SetPixel(i, j, color);
                    }
                }
                unlock.Save(outputPath + "unlock.png", ImageFormat.Png);
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
