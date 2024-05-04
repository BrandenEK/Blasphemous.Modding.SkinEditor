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
        return new Button()
        {
            Name = pixel.ToString(),
            Parent = parent,
            Location = location,
            Size = new Size(BUTTON_SIZE, BUTTON_SIZE),
            BackColor = Color.FromArgb(pixel, pixel, pixel),
            ForeColor = InvertColor(Color.FromArgb(pixel, pixel, pixel)),
            Font = new Font(parent.Font.FontFamily, 7),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = pixel.ToString()
        };
    }

    private Color InvertColor(Color c)
    {
        return c.R * 2 + c.G * 7 + c.B < 500 ? Color.White : Color.Black;
    }

    private const int START_OFFSET = 10;
    private const int LABEL_SIZE = 20;
    private const int LABEL_GAP = 0;
    private const int BUTTON_SIZE = 30;
    private const int BUTTON_GAP = 5;
    private const int GROUP_GAP = 10;
}
