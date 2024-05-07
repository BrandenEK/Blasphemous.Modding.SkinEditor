namespace Blasphemous.Modding.SkinEditor.Prompts;

partial class InfoPrompt
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
        _buttons = new Panel();
        _buttons_cancel = new Button();
        _buttons_confirm = new Button();
        _id = new Panel();
        _id_text = new TextBox();
        _id_label = new Label();
        _buttons.SuspendLayout();
        _id.SuspendLayout();
        SuspendLayout();
        // 
        // _buttons
        // 
        _buttons.AutoSize = true;
        _buttons.Controls.Add(_buttons_cancel);
        _buttons.Controls.Add(_buttons_confirm);
        _buttons.Dock = DockStyle.Top;
        _buttons.Location = new Point(0, 58);
        _buttons.Name = "_buttons";
        _buttons.Size = new Size(237, 34);
        _buttons.TabIndex = 9;
        // 
        // _buttons_cancel
        // 
        _buttons_cancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_cancel.AutoSize = true;
        _buttons_cancel.DialogResult = DialogResult.Cancel;
        _buttons_cancel.Location = new Point(150, 6);
        _buttons_cancel.Name = "_buttons_cancel";
        _buttons_cancel.Size = new Size(75, 25);
        _buttons_cancel.TabIndex = 5;
        _buttons_cancel.Text = "Cancel";
        _buttons_cancel.UseVisualStyleBackColor = true;
        // 
        // _buttons_confirm
        // 
        _buttons_confirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_confirm.AutoSize = true;
        _buttons_confirm.DialogResult = DialogResult.OK;
        _buttons_confirm.Location = new Point(69, 6);
        _buttons_confirm.Name = "_buttons_confirm";
        _buttons_confirm.Size = new Size(75, 25);
        _buttons_confirm.TabIndex = 4;
        _buttons_confirm.Text = "Confirm";
        _buttons_confirm.UseVisualStyleBackColor = true;
        // 
        // _id
        // 
        _id.AutoSize = true;
        _id.BackColor = SystemColors.ControlLight;
        _id.Controls.Add(_id_text);
        _id.Controls.Add(_id_label);
        _id.Dock = DockStyle.Top;
        _id.Location = new Point(0, 0);
        _id.Name = "_id";
        _id.Padding = new Padding(10, 0, 10, 10);
        _id.Size = new Size(237, 58);
        _id.TabIndex = 10;
        // 
        // _id_text
        // 
        _id_text.CharacterCasing = CharacterCasing.Upper;
        _id_text.Dock = DockStyle.Top;
        _id_text.Location = new Point(10, 25);
        _id_text.MaxLength = 32;
        _id_text.Name = "_id_text";
        _id_text.PlaceholderText = "PENITENT_DM_EXAMPLE";
        _id_text.Size = new Size(217, 23);
        _id_text.TabIndex = 1;
        // 
        // _id_label
        // 
        _id_label.Dock = DockStyle.Top;
        _id_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        _id_label.Location = new Point(10, 0);
        _id_label.Name = "_id_label";
        _id_label.Padding = new Padding(0, 3, 0, 0);
        _id_label.Size = new Size(217, 25);
        _id_label.TabIndex = 0;
        _id_label.Text = "Skin Id:";
        _id_label.TextAlign = ContentAlignment.TopCenter;
        // 
        // InfoPrompt
        // 
        AcceptButton = _buttons_confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _buttons_cancel;
        ClientSize = new Size(237, 244);
        Controls.Add(_buttons);
        Controls.Add(_id);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "InfoPrompt";
        ShowIcon = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Enter skin details";
        TopMost = true;
        _buttons.ResumeLayout(false);
        _buttons.PerformLayout();
        _id.ResumeLayout(false);
        _id.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel _buttons;
    private Button _buttons_cancel;
    private Button _buttons_confirm;
    private Panel _id;
    private Label _id_label;
    private TextBox _id_text;
}