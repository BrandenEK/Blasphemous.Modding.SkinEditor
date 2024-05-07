
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class FilePrompt : Form
{
    private Control? _selectedRow;

    public FilePrompt()
    {
        InitializeComponent();
        _buttons_confirm.Enabled = false;

        for (int i = 0; i < 15; i++)
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
            BackColor = GetAlternateColor(idx, false),
            Size = new Size(100, 40),
            Dock = DockStyle.Top,
        };
        panel.Click += OnClickRow;

        Label label = new()
        {
            Name = name,
            Parent = panel,
            Dock = DockStyle.Fill,
            Font = new Font(panel.Font.FontFamily, 12),
            TextAlign = ContentAlignment.MiddleLeft,
            Text = name,
        };
        label.Click += OnClickRow;

        return panel;
    }

    private void SelectRow(Control row)
    {
        DeselectCurrentRow();

        int idx = _main_list.Controls.GetChildIndex(row);
        row.BackColor = GetAlternateColor(idx, true);
        _selectedRow = row;
        
        // Update preview
    }

    private void DeselectCurrentRow()
    {
        if (_selectedRow is null)
            return;

        int idx = _main_list.Controls.GetChildIndex(_selectedRow);
        _selectedRow.BackColor = GetAlternateColor(idx, false);
        _selectedRow = null;
    }

    private void OnClickRow(object? sender, EventArgs _)
    {
        if (sender is null)
            return;

        SelectRow(sender is Panel p ? p : ((Label)sender).Parent);
        _buttons_confirm.Enabled = true;
        _buttons_confirm.Select();
    }

    private Color GetAlternateColor(int idx, bool selected)
    {
        return selected
            ? idx % 2 == 0 ? SystemColors.InactiveCaption : SystemColors.ActiveCaption
            : idx % 2 == 0 ? SystemColors.ControlDark : SystemColors.ControlDarkDark;
    }
}
