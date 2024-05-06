using Blasphemous.Modding.SkinEditor.Extensions;
using Blasphemous.Modding.SkinEditor.Models;
using Blasphemous.Modding.SkinEditor.Previewing;
using Newtonsoft.Json;

namespace Blasphemous.Modding.SkinEditor.Recoloring;

public class RecolorHandler : IRecolorHandler
{
    private readonly TextureHandler _textureHandler;
    private readonly ISpritePreviewer _spritePreviewer;
    private readonly Panel _parent;

    private readonly IEnumerable<PixelGroup> _groups;

    public RecolorHandler(TextureHandler textureHandler, ISpritePreviewer spritePreviewer, Panel parent)
    {
        _textureHandler = textureHandler;
        _spritePreviewer = spritePreviewer;
        _parent = parent;

        _groups = LoadPixelGroups();
    }

    private IEnumerable<PixelGroup> LoadPixelGroups()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "data", "pixels.json");
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<PixelGroup[]>(json) ?? Array.Empty<PixelGroup>();
    }

    public void RefreshButtonsVisibility()
    {
        _parent.Visible = false;
        DeleteButtons();
        CreateButtons();
        _parent.Visible = true;

        RefreshButtonsColor();
    }

    public void RefreshButtonsColor()
    {
        foreach (Control c in _parent.Controls)
        {
            if (c is Button btn)
            {
                byte pixel = byte.Parse(btn.Name);
                Color color = _textureHandler.GetPixel(pixel);
                UpdateButtonColor(btn, color);
            }
        }
    }

    private void CreateButtons()
    {
        var previewPixels = _spritePreviewer.GetPixelsInPreview();

        int y = START_OFFSET;
        foreach (var group in _groups)
        {
            if (group.Pixels.Except(previewPixels).Count() == group.Pixels.Length)
                continue;

            CreateLabel(group.Name, _parent, new Point(0, y));
            y += LABEL_SIZE + LABEL_GAP;

            int x = START_OFFSET;
            foreach (var pixel in group.Pixels)
            {
                if (!previewPixels.Contains(pixel))
                    continue;

                if (x + BUTTON_SIZE > _parent.Width)
                {
                    x = START_OFFSET;
                    y += BUTTON_SIZE + BUTTON_GAP;
                }

                CreateButton(pixel, _parent, new Point(x, y));
                x += BUTTON_SIZE + BUTTON_GAP;
            }
            y += BUTTON_SIZE + GROUP_GAP;
        }

        Label CreateLabel(string name, Panel parent, Point location)
        {
            var lbl = new Label()
            {
                Name = name,
                Parent = parent,
                Location = location,
                Size = new Size(parent.Width, LABEL_SIZE),
                TextAlign = ContentAlignment.TopCenter,
                Text = name
            };

            return lbl;
        }

        Button CreateButton(byte pixel, Panel parent, Point location)
        {
            var btn = new Button()
            {
                Name = pixel.ToString(),
                Parent = parent,
                Location = location,
                Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
                Font = new Font(parent.Font.FontFamily, 7),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = pixel.ToString()
            };

            btn.MouseDown += OnClickColorButton;
            return btn;
        }
    }

    private void DeleteButtons()
    {
        while (_parent.Controls.Count > 0)
        {
            _parent.Controls[0].Dispose();
        }
    }

    private void OnClickColorButton(object? sender, MouseEventArgs e)
    {
        if (sender == null || e.Button != MouseButtons.Left)
            return;

        Button btn = (Button)sender;

        using ColorDialog colorDialog = new()
        {
            AnyColor = true,
            Color = btn.BackColor,
            FullOpen = true,
            SolidColorOnly = true,
        };

        if (colorDialog.ShowDialog() != DialogResult.OK)
            return;

        Logger.Warn($"Changed pixel {btn.Name} to {colorDialog.Color}");
        UpdateButtonColor(btn, colorDialog.Color);

        byte pixel = byte.Parse(btn.Name);
        _textureHandler.SetPixel(pixel, colorDialog.Color);
        _spritePreviewer.UpdatePreview(pixel, colorDialog.Color);
    }

    public void UpdateButtonColor(Button btn, Color color)
    {
        btn.BackColor = color;
        btn.ForeColor = color.GetTextColor();
    }

    private const int START_OFFSET = 10;
    private const int LABEL_SIZE = 20;
    private const int LABEL_GAP = 0;
    private const int BUTTON_SIZE = 30;
    private const int BUTTON_GAP = 5;
    private const int GROUP_GAP = 10;
}
