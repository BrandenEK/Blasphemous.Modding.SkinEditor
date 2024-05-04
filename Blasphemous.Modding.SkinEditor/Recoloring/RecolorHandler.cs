using Blasphemous.Modding.SkinEditor.Extensions;
using Blasphemous.Modding.SkinEditor.Models;
using Newtonsoft.Json;

namespace Blasphemous.Modding.SkinEditor.Recoloring;

public class RecolorHandler : IRecolorHandler
{
    private readonly Button[] _buttons;

    public RecolorHandler(Panel buttonParent)
    {
        var groups = LoadPixelGroups();
        _buttons = new Button[groups.Sum(x => x.Pixels.Length)];
        int currButton = 0;

        int y = START_OFFSET;
        foreach (var group in groups)
        {
            CreateLabel(group.Name, buttonParent, new Point(0, y));
            y += LABEL_SIZE + LABEL_GAP;

            int x = START_OFFSET;
            foreach (var pixel in group.Pixels)
            {
                if (x + BUTTON_SIZE > buttonParent.Width)
                {
                    x = START_OFFSET;
                    y += BUTTON_SIZE + BUTTON_GAP;
                }

                _buttons[currButton++] = CreateButton(pixel, buttonParent, new Point(x, y));
                x += BUTTON_SIZE + BUTTON_GAP;
            }
            y += BUTTON_SIZE + GROUP_GAP;
        }

        foreach (var btn in _buttons)
        {
            byte pixel = byte.Parse(btn.Name);
            UpdateButtonColor(btn, Color.FromArgb(pixel, pixel, pixel));
        }

        Logger.Info("Created all recolor buttons");
    }

    private IEnumerable<PixelGroup> LoadPixelGroups()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "data", "pixels.json");
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<PixelGroup[]>(json) ?? Array.Empty<PixelGroup>();
    }

    private Label CreateLabel(string name, Panel parent, Point location)
    {
        return new Label()
        {
            Name = name,
            Parent = parent,
            Location = location,
            Size = new Size(parent.Width, LABEL_SIZE),
            TextAlign = ContentAlignment.TopCenter,
            Text = name
        };
    }

    private Button CreateButton(byte pixel, Panel parent, Point location)
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

        if (colorDialog.ShowDialog() == DialogResult.OK)
            UpdateButtonColor(btn, colorDialog.Color);
    }

    public void UpdateButtonColor(Button btn, Color color)
    {
        btn.BackColor = color;
        btn.ForeColor = color.GetTextColor();

        byte pixel = byte.Parse(btn.Name);
        Logger.Warn($"Changed pixel {pixel} to {color}");
    }

    private const int START_OFFSET = 10;
    private const int LABEL_SIZE = 20;
    private const int LABEL_GAP = 0;
    private const int BUTTON_SIZE = 30;
    private const int BUTTON_GAP = 5;
    private const int GROUP_GAP = 10;
}
