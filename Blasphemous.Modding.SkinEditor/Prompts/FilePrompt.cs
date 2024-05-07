
namespace Blasphemous.Modding.SkinEditor.Prompts;

public partial class FilePrompt : Form
{
    public string SelectedFile => _selectedRow?.Name ?? throw new Exception("Selected row was null");

    private Control? _selectedRow;

    public FilePrompt()
    {
        InitializeComponent();
        _buttons_confirm.Enabled = false;

        int idx = 0;
        string path = Path.Combine(Environment.CurrentDirectory, "skins");
        foreach (string folder in Directory.GetDirectories(path))
        {
            bool allFilesExist =
                File.Exists(Path.Combine(folder, "texture.png")) &&
                File.Exists(Path.Combine(folder, "preview.png")) &&
                File.Exists(Path.Combine(folder, "info.txt"));

            if (allFilesExist)
                CreateFileRow(folder[(folder.LastIndexOf('\\') + 1)..], idx++);
            else
                Logger.Error($"{folder} is missing skin files");
        }

        _main_list_inner.BackColor = GetAlternateColor(idx, false);
        if (idx > 0)
            _main_list_label.Visible = false;
    }

    private Panel CreateFileRow(string name, int idx)
    {
        Panel panel = new()
        {
            Name = name,
            Parent = _main_list_inner,
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

    private void UpdatePreviewImage(Control row)
    {
        Logger.Warn($"Updating import preview for {row.Name}");
        Bitmap preview = new(Path.Combine(Environment.CurrentDirectory, "skins", row.Name, "preview.png"));

        _main_preview.Image?.Dispose();
        _main_preview.Image = preview;
    }

    private void SelectRow(Control row)
    {
        if (_selectedRow == row)
            return;

        DeselectCurrentRow();

        int idx = _main_list_inner.Controls.GetChildIndex(row);
        row.BackColor = GetAlternateColor(idx, true);
        _selectedRow = row;
        
        UpdatePreviewImage(row);
    }

    private void DeselectCurrentRow()
    {
        if (_selectedRow is null)
            return;

        int idx = _main_list_inner.Controls.GetChildIndex(_selectedRow);
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
