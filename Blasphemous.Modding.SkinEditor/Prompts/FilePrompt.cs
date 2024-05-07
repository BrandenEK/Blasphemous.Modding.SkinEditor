
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

        _main_list_inner.BackColor = GetAlternateColor(5, false);
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

    private void UpdatePreviewImage()
    {
        _main_preview.Image?.Dispose();

        using Bitmap texture = new(Path.Combine(Environment.CurrentDirectory, "data", "default.png"));
        Bitmap preview = new(Path.Combine(Environment.CurrentDirectory, "data", "preview.png"));
        
        _main_preview.Image = ColorPreview(preview, texture);
    }

    private Bitmap ColorPreview(Bitmap preview, Bitmap texture)
    {
        for (int i = 0; i < preview.Width; i++)
        {
            for (int j = 0; j < preview.Height; j++)
            {
                Color pixel = preview.GetPixel(i, j);
                if (pixel.R != pixel.G || pixel.R != pixel.B)
                    continue;

                preview.SetPixel(i, j, texture.GetPixel(pixel.R, 0));
            }
        }

        return preview;
    }

    private void SelectRow(Control row)
    {
        if (_selectedRow == row)
            return;

        DeselectCurrentRow();

        int idx = _main_list_inner.Controls.GetChildIndex(row);
        row.BackColor = GetAlternateColor(idx, true);
        _selectedRow = row;
        
        UpdatePreviewImage();
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
