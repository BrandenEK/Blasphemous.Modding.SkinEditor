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
        _preview = new Panel();
        _preview_selector = new ComboBox();
        _preview_image = new PictureBox();
        _buttons = new Panel();
        _menu = new MenuStrip();
        _menu_file = new ToolStripMenuItem();
        _menu_edit = new ToolStripMenuItem();
        _menu_edit_undo = new ToolStripMenuItem();
        _menu_edit_redo = new ToolStripMenuItem();
        _menu_view = new ToolStripMenuItem();
        _menu_view_all = new ToolStripMenuItem();
        _menu_view_back = new ToolStripMenuItem();
        _menu_view_side = new ToolStripMenuItem();
        _preview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_preview_image).BeginInit();
        _menu.SuspendLayout();
        SuspendLayout();
        // 
        // _preview
        // 
        _preview.BackColor = Color.FromArgb(17, 8, 3);
        _preview.BorderStyle = BorderStyle.Fixed3D;
        _preview.Controls.Add(_preview_selector);
        _preview.Controls.Add(_preview_image);
        _preview.Dock = DockStyle.Fill;
        _preview.Location = new Point(300, 24);
        _preview.Name = "_preview";
        _preview.Size = new Size(964, 657);
        _preview.TabIndex = 1;
        // 
        // _preview_selector
        // 
        _preview_selector.FormattingEnabled = true;
        _preview_selector.Location = new Point(4, 3);
        _preview_selector.Name = "_preview_selector";
        _preview_selector.Size = new Size(121, 23);
        _preview_selector.TabIndex = 0;
        _preview_selector.SelectedIndexChanged += OnSelectAnim;
        // 
        // _preview_image
        // 
        _preview_image.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _preview_image.Location = new Point(100, 100);
        _preview_image.Name = "_preview_image";
        _preview_image.Size = new Size(764, 457);
        _preview_image.SizeMode = PictureBoxSizeMode.CenterImage;
        _preview_image.TabIndex = 0;
        _preview_image.TabStop = false;
        // 
        // _buttons
        // 
        _buttons.BackColor = Color.Gray;
        _buttons.BorderStyle = BorderStyle.Fixed3D;
        _buttons.Dock = DockStyle.Left;
        _buttons.Location = new Point(0, 24);
        _buttons.Name = "_buttons";
        _buttons.Size = new Size(300, 657);
        _buttons.TabIndex = 0;
        // 
        // _menu
        // 
        _menu.Items.AddRange(new ToolStripItem[] { _menu_file, _menu_edit, _menu_view });
        _menu.Location = new Point(0, 0);
        _menu.Name = "_menu";
        _menu.Size = new Size(1264, 24);
        _menu.TabIndex = 1;
        _menu.Text = "Menu Bar";
        // 
        // _menu_file
        // 
        _menu_file.Name = "_menu_file";
        _menu_file.Size = new Size(37, 20);
        _menu_file.Text = "File";
        // 
        // _menu_edit
        // 
        _menu_edit.DropDownItems.AddRange(new ToolStripItem[] { _menu_edit_undo, _menu_edit_redo });
        _menu_edit.Name = "_menu_edit";
        _menu_edit.Size = new Size(39, 20);
        _menu_edit.Text = "Edit";
        // 
        // _menu_edit_undo
        // 
        _menu_edit_undo.Name = "_menu_edit_undo";
        _menu_edit_undo.ShortcutKeys = Keys.Control | Keys.Z;
        _menu_edit_undo.Size = new Size(144, 22);
        _menu_edit_undo.Text = "Undo";
        _menu_edit_undo.Click += OnClickMenu_Edit_Undo;
        // 
        // _menu_edit_redo
        // 
        _menu_edit_redo.Name = "_menu_edit_redo";
        _menu_edit_redo.ShortcutKeys = Keys.Control | Keys.Y;
        _menu_edit_redo.Size = new Size(144, 22);
        _menu_edit_redo.Text = "Redo";
        // 
        // _menu_view
        // 
        _menu_view.DropDownItems.AddRange(new ToolStripItem[] { _menu_view_all, _menu_view_back, _menu_view_side });
        _menu_view.Name = "_menu_view";
        _menu_view.Size = new Size(44, 20);
        _menu_view.Text = "View";
        // 
        // _menu_view_all
        // 
        _menu_view_all.CheckOnClick = true;
        _menu_view_all.Name = "_menu_view_all";
        _menu_view_all.ShortcutKeys = Keys.Control | Keys.A;
        _menu_view_all.Size = new Size(232, 22);
        _menu_view_all.Text = "Show all pixel buttons";
        _menu_view_all.Click += OnClickMenu_View_Buttons;
        // 
        // _menu_view_back
        // 
        _menu_view_back.CheckOnClick = true;
        _menu_view_back.Name = "_menu_view_back";
        _menu_view_back.ShortcutKeys = Keys.Control | Keys.B;
        _menu_view_back.Size = new Size(232, 22);
        _menu_view_back.Text = "Use dark background";
        _menu_view_back.Click += OnClickMenu_View_Background;
        // 
        // _menu_view_side
        // 
        _menu_view_side.CheckOnClick = true;
        _menu_view_side.Name = "_menu_view_side";
        _menu_view_side.ShortcutKeys = Keys.Control | Keys.L;
        _menu_view_side.Size = new Size(232, 22);
        _menu_view_side.Text = "Preview on left side";
        _menu_view_side.Click += OnClickMenu_View_Side;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1264, 681);
        Controls.Add(_preview);
        Controls.Add(_buttons);
        Controls.Add(_menu);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = _menu;
        MinimumSize = new Size(1280, 720);
        Name = "MainForm";
        Text = "Blasphemous Skin Editor";
        FormClosing += OnFormClose;
        Load += OnFormOpen;
        _preview.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_preview_image).EndInit();
        _menu.ResumeLayout(false);
        _menu.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Panel _buttons;
    private Panel _preview;
    private PictureBox _preview_image;
    private ComboBox _preview_selector;
    private MenuStrip _menu;
    private ToolStripMenuItem _menu_view;
    private ToolStripMenuItem _menu_view_all;
    private ToolStripMenuItem _menu_view_back;
    private ToolStripMenuItem _menu_edit;
    private ToolStripMenuItem _menu_edit_undo;
    private ToolStripMenuItem _menu_edit_redo;
    private ToolStripMenuItem _menu_file;
    private ToolStripMenuItem _menu_view_side;
}
