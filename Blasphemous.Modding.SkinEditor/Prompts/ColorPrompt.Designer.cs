namespace Blasphemous.Modding.SkinEditor.Prompts;

partial class ColorPrompt
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
        _preview_color = new Panel();
        _r_slider = new TrackBar();
        _r_text = new TextBox();
        _r_label = new Label();
        _preview = new Panel();
        _preview_label = new Label();
        _preview_text = new TextBox();
        _r = new Panel();
        _g = new Panel();
        _g_slider = new TrackBar();
        _g_text = new TextBox();
        _g_label = new Label();
        _buttons = new Panel();
        _b = new Panel();
        _b_slider = new TrackBar();
        _b_text = new TextBox();
        _b_label = new Label();
        ((System.ComponentModel.ISupportInitialize)_r_slider).BeginInit();
        _preview.SuspendLayout();
        _r.SuspendLayout();
        _g.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_g_slider).BeginInit();
        _buttons.SuspendLayout();
        _b.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_b_slider).BeginInit();
        SuspendLayout();
        // 
        // _buttons_confirm
        // 
        _buttons_confirm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_confirm.AutoSize = true;
        _buttons_confirm.DialogResult = DialogResult.OK;
        _buttons_confirm.Location = new Point(166, 6);
        _buttons_confirm.Name = "_buttons_confirm";
        _buttons_confirm.Size = new Size(75, 25);
        _buttons_confirm.TabIndex = 4;
        _buttons_confirm.Text = "Confirm";
        _buttons_confirm.UseVisualStyleBackColor = true;
        // 
        // _buttons_cancel
        // 
        _buttons_cancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _buttons_cancel.AutoSize = true;
        _buttons_cancel.DialogResult = DialogResult.Cancel;
        _buttons_cancel.Location = new Point(247, 6);
        _buttons_cancel.Name = "_buttons_cancel";
        _buttons_cancel.Size = new Size(75, 25);
        _buttons_cancel.TabIndex = 5;
        _buttons_cancel.Text = "Cancel";
        _buttons_cancel.UseVisualStyleBackColor = true;
        // 
        // _preview_color
        // 
        _preview_color.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        _preview_color.BackColor = Color.Red;
        _preview_color.BorderStyle = BorderStyle.FixedSingle;
        _preview_color.Location = new Point(10, 10);
        _preview_color.Name = "_preview_color";
        _preview_color.Size = new Size(100, 100);
        _preview_color.TabIndex = 8;
        // 
        // _r_slider
        // 
        _r_slider.Location = new Point(80, 0);
        _r_slider.Maximum = 255;
        _r_slider.Name = "_r_slider";
        _r_slider.Size = new Size(250, 45);
        _r_slider.TabIndex = 8;
        _r_slider.TabStop = false;
        _r_slider.Value = 255;
        _r_slider.ValueChanged += OnRgbSliderChanged;
        // 
        // _r_text
        // 
        _r_text.CharacterCasing = CharacterCasing.Upper;
        _r_text.Location = new Point(30, 0);
        _r_text.MaxLength = 2;
        _r_text.Name = "_r_text";
        _r_text.Size = new Size(40, 23);
        _r_text.TabIndex = 1;
        _r_text.Text = "FF";
        _r_text.TextAlign = HorizontalAlignment.Center;
        _r_text.TextChanged += OnRgbTextChanged;
        // 
        // _r_label
        // 
        _r_label.AutoSize = true;
        _r_label.Location = new Point(10, 0);
        _r_label.Name = "_r_label";
        _r_label.Size = new Size(17, 15);
        _r_label.TabIndex = 8;
        _r_label.Text = "R:";
        _r_label.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _preview
        // 
        _preview.BackColor = SystemColors.ControlLight;
        _preview.Controls.Add(_preview_label);
        _preview.Controls.Add(_preview_text);
        _preview.Controls.Add(_preview_color);
        _preview.Dock = DockStyle.Top;
        _preview.Location = new Point(0, 0);
        _preview.Name = "_preview";
        _preview.Size = new Size(334, 120);
        _preview.TabIndex = 8;
        // 
        // _preview_label
        // 
        _preview_label.AutoSize = true;
        _preview_label.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
        _preview_label.Location = new Point(150, 40);
        _preview_label.Name = "_preview_label";
        _preview_label.Size = new Size(33, 37);
        _preview_label.TabIndex = 8;
        _preview_label.Text = "#";
        _preview_label.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _preview_text
        // 
        _preview_text.CharacterCasing = CharacterCasing.Upper;
        _preview_text.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
        _preview_text.Location = new Point(187, 43);
        _preview_text.MaxLength = 6;
        _preview_text.Name = "_preview_text";
        _preview_text.Size = new Size(100, 35);
        _preview_text.TabIndex = 0;
        _preview_text.Text = "FF0000";
        _preview_text.TextAlign = HorizontalAlignment.Center;
        _preview_text.TextChanged += OnPreviewTextChanged;
        // 
        // _r
        // 
        _r.AutoSize = true;
        _r.BackColor = SystemColors.ControlLight;
        _r.Controls.Add(_r_slider);
        _r.Controls.Add(_r_text);
        _r.Controls.Add(_r_label);
        _r.Dock = DockStyle.Top;
        _r.Location = new Point(0, 120);
        _r.Name = "_r";
        _r.Size = new Size(334, 48);
        _r.TabIndex = 8;
        // 
        // _g
        // 
        _g.AutoSize = true;
        _g.BackColor = SystemColors.ControlLight;
        _g.Controls.Add(_g_slider);
        _g.Controls.Add(_g_text);
        _g.Controls.Add(_g_label);
        _g.Dock = DockStyle.Top;
        _g.Location = new Point(0, 168);
        _g.Name = "_g";
        _g.Size = new Size(334, 48);
        _g.TabIndex = 8;
        // 
        // _g_slider
        // 
        _g_slider.Location = new Point(80, 0);
        _g_slider.Maximum = 255;
        _g_slider.Name = "_g_slider";
        _g_slider.Size = new Size(250, 45);
        _g_slider.TabIndex = 8;
        _g_slider.TabStop = false;
        _g_slider.ValueChanged += OnRgbSliderChanged;
        // 
        // _g_text
        // 
        _g_text.CharacterCasing = CharacterCasing.Upper;
        _g_text.Location = new Point(30, 0);
        _g_text.MaxLength = 2;
        _g_text.Name = "_g_text";
        _g_text.Size = new Size(40, 23);
        _g_text.TabIndex = 2;
        _g_text.Text = "00";
        _g_text.TextAlign = HorizontalAlignment.Center;
        _g_text.TextChanged += OnRgbTextChanged;
        // 
        // _g_label
        // 
        _g_label.AutoSize = true;
        _g_label.Location = new Point(10, 0);
        _g_label.Name = "_g_label";
        _g_label.Size = new Size(18, 15);
        _g_label.TabIndex = 8;
        _g_label.Text = "G:";
        _g_label.TextAlign = ContentAlignment.MiddleRight;
        // 
        // _buttons
        // 
        _buttons.AutoSize = true;
        _buttons.Controls.Add(_buttons_cancel);
        _buttons.Controls.Add(_buttons_confirm);
        _buttons.Dock = DockStyle.Top;
        _buttons.Location = new Point(0, 264);
        _buttons.Name = "_buttons";
        _buttons.Size = new Size(334, 34);
        _buttons.TabIndex = 8;
        // 
        // _b
        // 
        _b.AutoSize = true;
        _b.BackColor = SystemColors.ControlLight;
        _b.Controls.Add(_b_slider);
        _b.Controls.Add(_b_text);
        _b.Controls.Add(_b_label);
        _b.Dock = DockStyle.Top;
        _b.Location = new Point(0, 216);
        _b.Name = "_b";
        _b.Size = new Size(334, 48);
        _b.TabIndex = 8;
        // 
        // _b_slider
        // 
        _b_slider.Location = new Point(80, 0);
        _b_slider.Maximum = 255;
        _b_slider.Name = "_b_slider";
        _b_slider.Size = new Size(250, 45);
        _b_slider.TabIndex = 8;
        _b_slider.TabStop = false;
        _b_slider.ValueChanged += OnRgbSliderChanged;
        // 
        // _b_text
        // 
        _b_text.CharacterCasing = CharacterCasing.Upper;
        _b_text.Location = new Point(30, 0);
        _b_text.MaxLength = 2;
        _b_text.Name = "_b_text";
        _b_text.Size = new Size(40, 23);
        _b_text.TabIndex = 3;
        _b_text.Text = "00";
        _b_text.TextAlign = HorizontalAlignment.Center;
        _b_text.TextChanged += OnRgbTextChanged;
        // 
        // _b_label
        // 
        _b_label.AutoSize = true;
        _b_label.Location = new Point(10, 0);
        _b_label.Name = "_b_label";
        _b_label.Size = new Size(17, 15);
        _b_label.TabIndex = 8;
        _b_label.Text = "B:";
        _b_label.TextAlign = ContentAlignment.MiddleRight;
        // 
        // ColorPrompt
        // 
        AcceptButton = _buttons_confirm;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = _buttons_cancel;
        ClientSize = new Size(334, 301);
        Controls.Add(_buttons);
        Controls.Add(_b);
        Controls.Add(_g);
        Controls.Add(_r);
        Controls.Add(_preview);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ColorPrompt";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Choose a color";
        TopMost = true;
        ((System.ComponentModel.ISupportInitialize)_r_slider).EndInit();
        _preview.ResumeLayout(false);
        _preview.PerformLayout();
        _r.ResumeLayout(false);
        _r.PerformLayout();
        _g.ResumeLayout(false);
        _g.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_g_slider).EndInit();
        _buttons.ResumeLayout(false);
        _buttons.PerformLayout();
        _b.ResumeLayout(false);
        _b.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_b_slider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button _buttons_confirm;
    private Button _buttons_cancel;
    private Panel _preview_color;
    private TrackBar _r_slider;
    private TextBox _r_text;
    private Label _r_label;
    private Panel _preview;
    private Panel _r;
    private Panel _g;
    private TrackBar _g_slider;
    private TextBox _g_text;
    private Label _g_label;
    private Panel _buttons;
    private Panel _b;
    private TrackBar _b_slider;
    private TextBox _b_text;
    private Label _b_label;
    private Label _preview_label;
    private TextBox _preview_text;
}