using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasphemousSkinEditor
{
    public class TextPrompt : IDisposable
    {
        private Form prompt { get; set; }
        public string Result { get; }

        public TextPrompt(string text, string caption, string initial)
        {
            Result = ShowDialog(text, caption, initial);
        }
        //use a using statement
        private string ShowDialog(string text, string caption, string initial)
        {
            prompt = new Form()
            {
                Width = 250,
                Height = 120,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            Label textLabel = new Label() { Left = 50, Top = 30, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
            TextBox textBox = new TextBox() { Left = 40, Top = 30, Width = 150, Text = initial };
            Button confirmation = new Button() { Text = "Ok", Left = 90, Width = 50, Top = 55, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public void Dispose()
        {
            if (prompt != null)
            {
                prompt.Dispose();
            }
        }
    }
}
