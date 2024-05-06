using Blasphemous.Modding.SkinEditor.Extensions;
using Blasphemous.Modding.SkinEditor.Models;
using Blasphemous.Modding.SkinEditor.Previewing;
using Blasphemous.Modding.SkinEditor.Undo;
using Newtonsoft.Json;

namespace Blasphemous.Modding.SkinEditor.Recoloring;

public class RecolorHandler : IRecolorHandler
{
    private readonly ISpritePreviewer _spritePreviewer;
    private readonly Panel _parent;

    private readonly IEnumerable<PixelGroup> _groups;

    private bool _showingAll;

    public RecolorHandler(ISpritePreviewer spritePreviewer, Panel parent, ToolStripMenuItem allMenu)
    {
        _spritePreviewer = spritePreviewer;
        _parent = parent;

        _groups = LoadPixelGroups();
        _showingAll = (bool)Properties.Settings.Default["view_all"];
        allMenu.Checked = _showingAll;
    }

    private IEnumerable<PixelGroup> LoadPixelGroups()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "data", "pixels.json");
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<PixelGroup[]>(json) ?? Array.Empty<PixelGroup>();
    }

    public void ToggleShowingAll()
    {
        _showingAll = !_showingAll;
        Properties.Settings.Default.view_all = _showingAll;
        Properties.Settings.Default.Save();

        RefreshButtonsVisibility();
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
                Color color = Core.TextureManager.GetPixel(pixel);
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
            if (!_showingAll && group.Pixels.Except(previewPixels).Count() == group.Pixels.Length)
                continue;

            CreateLabel(group.Name, _parent, new Point(START_OFFSET, y));
            y += LABEL_SIZE + LABEL_GAP;

            int x = START_OFFSET;
            foreach (var pixel in group.Pixels)
            {
                if (!_showingAll && !previewPixels.Contains(pixel))
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
                Size = new Size(parent.Width - START_OFFSET, LABEL_SIZE),
                TextAlign = ContentAlignment.TopLeft,
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

        byte pixel = byte.Parse(btn.Name);
        Color color = colorDialog.Color;
        Logger.Warn($"Changed pixel {pixel} to {color}");

        Core.UndoManager.Do(new PixelColorUndoCommand(pixel, btn.BackColor, color));
        Core.TextureManager.SetPixel(pixel, color);
        _spritePreviewer.UpdatePreview(pixel, color);

        UpdateButtonColor(btn, color);
    }

    public void UpdateButtonColor(Button btn, Color color)
    {
        btn.BackColor = color;
        btn.ForeColor = color.GetTextColor();
    }

    public void UpdateButtonColor(byte pixel, Color color)
    {
        Button btn = (Button)_parent.Controls.Find(pixel.ToString(), false)[0];
        UpdateButtonColor(btn, color);
    }

    // Event handling

    public void Initialize()
    {
        Core.UndoManager.OnUndo += OnUndo;
        Core.UndoManager.OnRedo += OnRedo;
    }

    private void OnUndo(IUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        UpdateButtonColor(pc.Pixel, pc.OldColor);
    }

    private void OnRedo(IUndoCommand command)
    {
        if (command is not PixelColorUndoCommand pc)
            return;

        UpdateButtonColor(pc.Pixel, pc.NewColor);
    }

    private const int START_OFFSET = 10;
    private const int LABEL_SIZE = 20;
    private const int LABEL_GAP = 0;
    private const int BUTTON_SIZE = 30;
    private const int BUTTON_GAP = 5;
    private const int GROUP_GAP = 10;
}
