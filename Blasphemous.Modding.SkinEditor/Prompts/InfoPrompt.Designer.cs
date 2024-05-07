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
        _name = new Panel();
        _name_text = new TextBox();
        _name_label = new Label();
        _author = new Panel();
        _author_text = new TextBox();
        _author_label = new Label();
        _version = new Panel();
        _version_text = new TextBox();
        _version_label = new Label();
        _buttons.SuspendLayout();
        _id.SuspendLayout();
        _name.SuspendLayout();
        _author.SuspendLayout();
        _version.SuspendLayout();
        SuspendLayout();
        // 
        // _buttons
        // 
        _buttons.AutoSize = true;
        _buttons.Controls.Add(_buttons_cancel);
        _buttons.Controls.Add(_buttons_confirm);
        _buttons.Dock = DockStyle.Top;
        _buttons.Location = new Point(0, 232);
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
        // _name
        // 
        _name.AutoSize = true;
        _name.BackColor = SystemColors.ControlLight;
        _name.Controls.Add(_name_text);
        _name.Controls.Add(_name_label);
        _name.Dock = DockStyle.Top;
        _name.Location = new Point(0, 58);
        _name.Name = "_name";
        _name.Padding = new Padding(10, 0, 10, 10);
        _name.Size = new Size(237, 58);
        _name.TabIndex = 11;
        // 
        // _name_text
        // 
        _name_text.Dock = DockStyle.Top;
        _name_text.Location = new Point(10, 25);
        _name_text.MaxLength = 32;
        _name_text.Name = "_name_text";
        _name_text.PlaceholderText = "Example skin";
        _name_text.Size = new Size(217, 23);
        _name_text.TabIndex = 1;
        // 
        // _name_label
        // 
        _name_label.Dock = DockStyle.Top;
        _name_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        _name_label.Location = new Point(10, 0);
        _name_label.Name = "_name_label";
        _name_label.Padding = new Padding(0, 3, 0, 0);
        _name_label.Size = new Size(217, 25);
        _name_label.TabIndex = 0;
        _name_label.Text = "Skin Name:";
        _name_label.TextAlign = ContentAlignment.TopCenter;
        // 
        // _author
        // 
        _author.AutoSize = true;
        _author.BackColor = SystemColors.ControlLight;
        _author.Controls.Add(_author_text);
        _author.Controls.Add(_author_label);
        _author.Dock = DockStyle.Top;
        _author.Location = new Point(0, 116);
        _author.Name = "_author";
        _author.Padding = new Padding(10, 0, 10, 10);
        _author.Size = new Size(237, 58);
        _author.TabIndex = 11;
        // 
        // _author_text
        // 
        _author_text.Dock = DockStyle.Top;
        _author_text.Location = new Point(10, 25);
        _author_text.MaxLength = 32;
        _author_text.Name = "_author_text";
        _author_text.PlaceholderText = "Damocles";
        _author_text.Size = new Size(217, 23);
        _author_text.TabIndex = 1;
        // 
        // _author_label
        // 
        _author_label.Dock = DockStyle.Top;
        _author_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        _author_label.Location = new Point(10, 0);
        _author_label.Name = "_author_label";
        _author_label.Padding = new Padding(0, 3, 0, 0);
        _author_label.Size = new Size(217, 25);
        _author_label.TabIndex = 0;
        _author_label.Text = "Skin Author:";
        _author_label.TextAlign = ContentAlignment.TopCenter;
        // 
        // _version
        // 
        _version.AutoSize = true;
        _version.BackColor = SystemColors.ControlLight;
        _version.Controls.Add(_version_text);
        _version.Controls.Add(_version_label);
        _version.Dock = DockStyle.Top;
        _version.Location = new Point(0, 174);
        _version.Name = "_version";
        _version.Padding = new Padding(10, 0, 10, 10);
        _version.Size = new Size(237, 58);
        _version.TabIndex = 11;
        // 
        // _version_text
        // 
        _version_text.Dock = DockStyle.Top;
        _version_text.Location = new Point(10, 25);
        _version_text.MaxLength = 32;
        _version_text.Name = "_version_text";
        _version_text.PlaceholderText = "1.0.0";
        _version_text.Size = new Size(217, 23);
        _version_text.TabIndex = 1;
        // 
        // _version_label
        // 
        _version_label.Dock = DockStyle.Top;
        _version_label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        _version_label.Location = new Point(10, 0);
        _version_label.Name = "_version_label";
        _version_label.Padding = new Padding(0, 3, 0, 0);
        _version_label.Size = new Size(217, 25);
        _version_label.TabIndex = 0;
        _version_label.Text = "Skin Version:";
        _version_label.TextAlign = ContentAlignment.TopCenter;
        // 
        // InfoPrompt
        // 
        AcceptButton = _buttons_confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _buttons_cancel;
        ClientSize = new Size(237, 267);
        Controls.Add(_buttons);
        Controls.Add(_version);
        Controls.Add(_author);
        Controls.Add(_name);
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
        _name.ResumeLayout(false);
        _name.PerformLayout();
        _author.ResumeLayout(false);
        _author.PerformLayout();
        _version.ResumeLayout(false);
        _version.PerformLayout();
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
    private Panel _name;
    private TextBox _name_text;
    private Label _name_label;
    private Panel _author;
    private TextBox _author_text;
    private Label _author_label;
    private Panel _version;
    private TextBox _version_text;
    private Label _version_label;
}