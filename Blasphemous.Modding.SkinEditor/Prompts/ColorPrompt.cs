
namespace Blasphemous.Modding.SkinEditor.Prompts;

public class ColorPrompt : IDisposable
{
    private readonly Form _prompt;

    public bool Result { get; private set; }
    public Color Color { get; private set; }

    public ColorPrompt(string title, Color color)
    {
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

        Result = _prompt.ShowDialog() == DialogResult.OK;
    }

    public void Dispose()
    {
        _prompt.Dispose();
    }
}
