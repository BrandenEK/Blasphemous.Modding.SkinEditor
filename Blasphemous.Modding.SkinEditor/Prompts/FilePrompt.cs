
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class FilePrompt : Form
{
    public FilePrompt()
    {
        InitializeComponent();

        for (int i = 15; i >= 0; i--)
        {
            CreateFileRow("PENITENT_" + i, i);
        }
    }

    private Panel CreateFileRow(string name, int idx)
    {
        Panel panel = new()
        {
            Name = name,
            Parent = _main_list,
            BackColor = idx % 2 == 0 ? SystemColors.ControlDark : SystemColors.ControlDarkDark,
            Size = new Size(100, 40),
            Dock = DockStyle.Top,
        };

        Label label = new()
        {
            Name = name,
            Parent = panel,
            Dock = DockStyle.Fill,
            Font = new Font(panel.Font.FontFamily, 12),
            TextAlign = ContentAlignment.MiddleLeft,
            Text = name,
        };

        // backcolor later
        return panel;
    }
}
