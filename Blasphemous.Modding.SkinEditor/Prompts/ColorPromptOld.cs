
namespace Blasphemous.Modding.SkinEditor.Prompts;

public class ColorPromptOld : IDisposable
{
    private readonly Form _prompt;

    public bool Result { get; private set; }
    public Color Color { get; private set; }

    public ColorPromptOld(string title, Color color)
    {
        // Main form
        _prompt = new Form()
        {
            Text = title,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterScreen,
            Size = new Size(400, 300),
            MinimizeBox = false,
            MaximizeBox = false,
            TopMost = true,
        };

        // Confirm button
        Button confirm = new()
        {
            Text = "Confirm",
            Parent = _prompt,
            AutoSize = true,
            Anchor = AnchorStyles.Bottom,
            Location = new Point(-30, -10),
            DialogResult = DialogResult.OK
        };
        confirm.Click += (_, __) => _prompt.Close();
        _prompt.AcceptButton = confirm;

        // Cancel button
        Button cancel = new()
        {
            Text = "Cancel",
            Parent = _prompt,
            AutoSize = true,
            Anchor = AnchorStyles.Bottom,
            Location = new Point(30, -10),
            DialogResult = DialogResult.Cancel
        };
        cancel.Click += (_, __) => _prompt.Close();
        _prompt.CancelButton = cancel;

        Result = _prompt.ShowDialog() == DialogResult.OK;
    }

    public void Dispose()
    {
        _prompt.Dispose();
    }
}
