namespace Blasphemous.Modding.SkinEditor.Prompts;

partial class FilePrompt
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
        _main = new Panel();
        _main_list_outer = new Panel();
        _main_list_inner = new Panel();
        _main_preview = new PictureBox();
        _main_list_label = new Label();
        _buttons.SuspendLayout();
        _main.SuspendLayout();
        _main_list_outer.SuspendLayout();
        _main_list_inner.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_main_preview).BeginInit();
        SuspendLayout();
        // 
        // _buttons
        // 
        _buttons.AutoSize = true;
        _buttons.Controls.Add(_buttons_cancel);
        _buttons.Controls.Add(_buttons_confirm);
        _buttons.Dock = DockStyle.Top;
        _buttons.Location = new Point(0, 447);
        _buttons.Name = "_buttons";
        _buttons.Size = new Size(898, 34);
        _buttons.TabIndex = 5;
        // 
        // _buttons_cancel
        // 
        _buttons_cancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_cancel.AutoSize = true;
        _buttons_cancel.DialogResult = DialogResult.Cancel;
        _buttons_cancel.Location = new Point(811, 6);
        _buttons_cancel.Name = "_buttons_cancel";
        _buttons_cancel.Size = new Size(75, 25);
        _buttons_cancel.TabIndex = 1;
        _buttons_cancel.Text = "Cancel";
        _buttons_cancel.UseVisualStyleBackColor = true;
        // 
        // _buttons_confirm
        // 
        _buttons_confirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_confirm.AutoSize = true;
        _buttons_confirm.DialogResult = DialogResult.OK;
        _buttons_confirm.Location = new Point(730, 6);
        _buttons_confirm.Name = "_buttons_confirm";
        _buttons_confirm.Size = new Size(75, 25);
        _buttons_confirm.TabIndex = 0;
        _buttons_confirm.Text = "Confirm";
        _buttons_confirm.UseVisualStyleBackColor = true;
        // 
        // _main
        // 
        _main.AutoSize = true;
        _main.BackColor = SystemColors.ControlLight;
        _main.Controls.Add(_main_list_outer);
        _main.Controls.Add(_main_preview);
        _main.Dock = DockStyle.Top;
        _main.Location = new Point(0, 0);
        _main.Name = "_main";
        _main.Padding = new Padding(10);
        _main.Size = new Size(898, 447);
        _main.TabIndex = 0;
        // 
        // _main_list_outer
        // 
        _main_list_outer.BackColor = SystemColors.ActiveCaptionText;
        _main_list_outer.BorderStyle = BorderStyle.FixedSingle;
        _main_list_outer.Controls.Add(_main_list_inner);
        _main_list_outer.Location = new Point(582, 12);
        _main_list_outer.Name = "_main_list_outer";
        _main_list_outer.Padding = new Padding(2);
        _main_list_outer.Size = new Size(304, 422);
        _main_list_outer.TabIndex = 1;
        // 
        // _main_list_inner
        // 
        _main_list_inner.AutoScroll = true;
        _main_list_inner.BackColor = SystemColors.ControlDark;
        _main_list_inner.Controls.Add(_main_list_label);
        _main_list_inner.Dock = DockStyle.Fill;
        _main_list_inner.Location = new Point(2, 2);
        _main_list_inner.Name = "_main_list_inner";
        _main_list_inner.Size = new Size(298, 416);
        _main_list_inner.TabIndex = 0;
        // 
        // _main_preview
        // 
        _main_preview.BackColor = Color.FromArgb(17, 8, 3);
        _main_preview.BorderStyle = BorderStyle.Fixed3D;
        _main_preview.Location = new Point(12, 12);
        _main_preview.Name = "_main_preview";
        _main_preview.Size = new Size(564, 422);
        _main_preview.SizeMode = PictureBoxSizeMode.StretchImage;
        _main_preview.TabIndex = 0;
        _main_preview.TabStop = false;
        // 
        // _main_list_label
        // 
        _main_list_label.Dock = DockStyle.Fill;
        _main_list_label.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
        _main_list_label.Location = new Point(0, 0);
        _main_list_label.Name = "_main_list_label";
        _main_list_label.Size = new Size(298, 416);
        _main_list_label.TabIndex = 0;
        _main_list_label.Text = "The skins folder is empty...";
        _main_list_label.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FilePrompt
        // 
        AcceptButton = _buttons_confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _buttons_cancel;
        ClientSize = new Size(898, 484);
        Controls.Add(_buttons);
        Controls.Add(_main);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FilePrompt";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Select a file to open";
        TopMost = true;
        _buttons.ResumeLayout(false);
        _buttons.PerformLayout();
        _main.ResumeLayout(false);
        _main_list_outer.ResumeLayout(false);
        _main_list_inner.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_main_preview).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel _buttons;
    private Button _buttons_cancel;
    private Button _buttons_confirm;
    private Panel _main;
    private PictureBox _main_preview;
    private Panel _main_list_outer;
    private Panel _main_list_inner;
    private Label _main_list_label;
}