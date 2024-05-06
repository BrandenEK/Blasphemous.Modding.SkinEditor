namespace Blasphemous.Modding.SkinEditor.Prompts;

partial class ColorForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        _buttons_confirm = new Button();
        _buttons_cancel = new Button();
        SuspendLayout();
        // 
        // _buttons_confirm
        // 
        _buttons_confirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _buttons_confirm.AutoSize = true;
        _buttons_confirm.DialogResult = DialogResult.OK;
        _buttons_confirm.Location = new Point(216, 224);
        _buttons_confirm.Name = "_buttons_confirm";
        _buttons_confirm.Size = new Size(75, 25);
        _buttons_confirm.TabIndex = 0;
        _buttons_confirm.Text = "Confirm";
        _buttons_confirm.UseVisualStyleBackColor = true;
        // 
        // _buttons_cancel
        // 
        _buttons_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _buttons_cancel.AutoSize = true;
        _buttons_cancel.DialogResult = DialogResult.Cancel;
        _buttons_cancel.Location = new Point(297, 224);
        _buttons_cancel.Name = "_buttons_cancel";
        _buttons_cancel.Size = new Size(75, 25);
        _buttons_cancel.TabIndex = 1;
        _buttons_cancel.Text = "Cancel";
        _buttons_cancel.UseVisualStyleBackColor = true;
        // 
        // ColorForm
        // 
        AcceptButton = _buttons_confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _buttons_cancel;
        ClientSize = new Size(384, 261);
        Controls.Add(_buttons_cancel);
        Controls.Add(_buttons_confirm);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ColorForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Choose a color";
        TopMost = true;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button _buttons_confirm;
    private Button _buttons_cancel;
}