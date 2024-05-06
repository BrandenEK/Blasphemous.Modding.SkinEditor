namespace Blasphemous.Modding.SkinEditor;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        UI = new Panel();
        _right = new Panel();
        _right_selector = new ComboBox();
        _right_image = new PictureBox();
        _left = new Panel();
        _right_buttonsBtn = new Button();
        UI.SuspendLayout();
        _right.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_right_image).BeginInit();
        SuspendLayout();
        // 
        // UI
        // 
        UI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        UI.BackColor = Color.Fuchsia;
        UI.Controls.Add(_right);
        UI.Controls.Add(_left);
        UI.Location = new Point(30, 15);
        UI.Name = "UI";
        UI.Size = new Size(1200, 650);
        UI.TabIndex = 0;
        // 
        // _right
        // 
        _right.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _right.BackColor = Color.FromArgb(17, 8, 3);
        _right.BorderStyle = BorderStyle.Fixed3D;
        _right.Controls.Add(_right_buttonsBtn);
        _right.Controls.Add(_right_selector);
        _right.Controls.Add(_right_image);
        _right.Location = new Point(300, 0);
        _right.Name = "_right";
        _right.Size = new Size(900, 650);
        _right.TabIndex = 1;
        // 
        // _right_selector
        // 
        _right_selector.FormattingEnabled = true;
        _right_selector.Location = new Point(4, 3);
        _right_selector.Name = "_right_selector";
        _right_selector.Size = new Size(121, 23);
        _right_selector.TabIndex = 0;
        _right_selector.SelectedIndexChanged += OnSelectAnim;
        // 
        // _right_image
        // 
        _right_image.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _right_image.Location = new Point(100, 100);
        _right_image.Name = "_right_image";
        _right_image.Size = new Size(700, 450);
        _right_image.SizeMode = PictureBoxSizeMode.CenterImage;
        _right_image.TabIndex = 0;
        _right_image.TabStop = false;
        // 
        // _left
        // 
        _left.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        _left.BackColor = Color.Gray;
        _left.BorderStyle = BorderStyle.Fixed3D;
        _left.Location = new Point(0, 0);
        _left.Name = "_left";
        _left.Size = new Size(300, 650);
        _left.TabIndex = 0;
        // 
        // _right_buttonsBtn
        // 
        _right_buttonsBtn.AutoSize = true;
        _right_buttonsBtn.Location = new Point(140, 3);
        _right_buttonsBtn.Name = "_right_buttonsBtn";
        _right_buttonsBtn.Size = new Size(137, 25);
        _right_buttonsBtn.TabIndex = 1;
        _right_buttonsBtn.Text = "Toggle button visibility";
        _right_buttonsBtn.UseVisualStyleBackColor = true;
        _right_buttonsBtn.Click += OnClickButtonsBtn;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1264, 681);
        Controls.Add(UI);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(1280, 720);
        Name = "MainForm";
        Text = "Blasphemous Skin Editor";
        FormClosing += OnFormClose;
        Load += OnFormOpen;
        SizeChanged += OnFormResized;
        UI.ResumeLayout(false);
        _right.ResumeLayout(false);
        _right.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_right_image).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel UI;
    private Panel _left;
    private Panel _right;
    private PictureBox _right_image;
    private ComboBox _right_selector;
    private Button _right_buttonsBtn;
}
