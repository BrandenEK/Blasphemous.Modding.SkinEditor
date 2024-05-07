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
        _preview_debug = new Button();
        _preview_image = new PictureBox();
        _info_selector = new ComboBox();
        _buttons = new Panel();
        _menu = new MenuStrip();
        _menu_file = new ToolStripMenuItem();
        _menu_file_new = new ToolStripMenuItem();
        _menu_file_open = new ToolStripMenuItem();
        _menu_file_sep = new ToolStripSeparator();
        _menu_file_save = new ToolStripMenuItem();
        _menu_file_saveas = new ToolStripMenuItem();
        _menu_edit = new ToolStripMenuItem();
        _menu_edit_undo = new ToolStripMenuItem();
        _menu_edit_redo = new ToolStripMenuItem();
        _menu_view = new ToolStripMenuItem();
        _menu_view_all = new ToolStripMenuItem();
        _menu_view_background = new ToolStripMenuItem();
        _menu_view_side = new ToolStripMenuItem();
        _info = new Panel();
        _info_header = new Label();
        _preview.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_preview_image).BeginInit();
        _menu.SuspendLayout();
        _info.SuspendLayout();
        SuspendLayout();
        // 
        // _preview
        // 
        _preview.BackColor = Color.FromArgb(17, 8, 3);
        _preview.BorderStyle = BorderStyle.Fixed3D;
        _preview.Controls.Add(_preview_debug);
        _preview.Controls.Add(_preview_image);
        _preview.Dock = DockStyle.Fill;
        _preview.Location = new Point(320, 24);
        _preview.Name = "_preview";
        _preview.Size = new Size(944, 617);
        _preview.TabIndex = 1;
        // 
        // _preview_debug
        // 
        _preview_debug.AutoSize = true;
        _preview_debug.Location = new Point(4, 3);
        _preview_debug.Name = "_preview_debug";
        _preview_debug.Size = new Size(91, 25);
        _preview_debug.TabIndex = 1;
        _preview_debug.Text = "Debug button";
        _preview_debug.UseVisualStyleBackColor = true;
        _preview_debug.Click += OnClickDebug;
        // 
        // _preview_image
        // 
        _preview_image.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _preview_image.Location = new Point(100, 100);
        _preview_image.Name = "_preview_image";
        _preview_image.Size = new Size(744, 417);
        _preview_image.SizeMode = PictureBoxSizeMode.CenterImage;
        _preview_image.TabIndex = 0;
        _preview_image.TabStop = false;
        // 
        // _info_selector
        // 
        _info_selector.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        _info_selector.DropDownStyle = ComboBoxStyle.DropDownList;
        _info_selector.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        _info_selector.FormattingEnabled = true;
        _info_selector.Location = new Point(816, 3);
        _info_selector.Name = "_info_selector";
        _info_selector.Size = new Size(121, 29);
        _info_selector.TabIndex = 0;
        _info_selector.SelectedIndexChanged += OnSelectAnim;
        // 
        // _buttons
        // 
        _buttons.AutoScroll = true;
        _buttons.AutoScrollMargin = new Size(0, 10);
        _buttons.BackColor = Color.Gray;
        _buttons.BorderStyle = BorderStyle.Fixed3D;
        _buttons.Dock = DockStyle.Left;
        _buttons.Location = new Point(0, 24);
        _buttons.Name = "_buttons";
        _buttons.Size = new Size(320, 657);
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
        _menu_file.DropDownItems.AddRange(new ToolStripItem[] { _menu_file_new, _menu_file_open, _menu_file_sep, _menu_file_save, _menu_file_saveas });
        _menu_file.Name = "_menu_file";
        _menu_file.Size = new Size(37, 20);
        _menu_file.Text = "File";
        // 
        // _menu_file_new
        // 
        _menu_file_new.Name = "_menu_file_new";
        _menu_file_new.ShortcutKeys = Keys.Control | Keys.N;
        _menu_file_new.Size = new Size(184, 22);
        _menu_file_new.Text = "New";
        _menu_file_new.Click += OnClickMenu_File_New;
        // 
        // _menu_file_open
        // 
        _menu_file_open.Name = "_menu_file_open";
        _menu_file_open.ShortcutKeys = Keys.Control | Keys.O;
        _menu_file_open.Size = new Size(184, 22);
        _menu_file_open.Text = "Open";
        _menu_file_open.Click += OnClickMenu_File_Open;
        // 
        // _menu_file_sep
        // 
        _menu_file_sep.Name = "_menu_file_sep";
        _menu_file_sep.Size = new Size(181, 6);
        // 
        // _menu_file_save
        // 
        _menu_file_save.Name = "_menu_file_save";
        _menu_file_save.ShortcutKeys = Keys.Control | Keys.S;
        _menu_file_save.Size = new Size(184, 22);
        _menu_file_save.Text = "Save";
        _menu_file_save.Click += OnClickMenu_File_Save;
        // 
        // _menu_file_saveas
        // 
        _menu_file_saveas.Name = "_menu_file_saveas";
        _menu_file_saveas.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
        _menu_file_saveas.Size = new Size(184, 22);
        _menu_file_saveas.Text = "Save as";
        _menu_file_saveas.Click += OnClickMenu_File_SaveAs;
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
        _menu_edit_redo.Click += OnClickMenu_Edit_Redo;
        // 
        // _menu_view
        // 
        _menu_view.DropDownItems.AddRange(new ToolStripItem[] { _menu_view_all, _menu_view_background, _menu_view_side });
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
        _menu_view_all.Click += OnClickMenu_View_All;
        // 
        // _menu_view_background
        // 
        _menu_view_background.CheckOnClick = true;
        _menu_view_background.Name = "_menu_view_background";
        _menu_view_background.ShortcutKeys = Keys.Control | Keys.B;
        _menu_view_background.Size = new Size(232, 22);
        _menu_view_background.Text = "Use dark background";
        _menu_view_background.Click += OnClickMenu_View_Background;
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
        // _info
        // 
        _info.BackColor = Color.Silver;
        _info.BorderStyle = BorderStyle.Fixed3D;
        _info.Controls.Add(_info_header);
        _info.Controls.Add(_info_selector);
        _info.Dock = DockStyle.Bottom;
        _info.Location = new Point(320, 641);
        _info.Name = "_info";
        _info.Size = new Size(944, 40);
        _info.TabIndex = 2;
        // 
        // _info_header
        // 
        _info_header.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
        _info_header.Location = new Point(0, 0);
        _info_header.Name = "_info_header";
        _info_header.Size = new Size(360, 36);
        _info_header.TabIndex = 1;
        _info_header.Text = "SKIN_ID";
        _info_header.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1264, 681);
        Controls.Add(_preview);
        Controls.Add(_info);
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
        _preview.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_preview_image).EndInit();
        _menu.ResumeLayout(false);
        _menu.PerformLayout();
        _info.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Panel _buttons;
    private Panel _preview;
    private PictureBox _preview_image;
    private ComboBox _info_selector;
    private MenuStrip _menu;
    private ToolStripMenuItem _menu_view;
    private ToolStripMenuItem _menu_view_all;
    private ToolStripMenuItem _menu_view_background;
    private ToolStripMenuItem _menu_edit;
    private ToolStripMenuItem _menu_edit_undo;
    private ToolStripMenuItem _menu_edit_redo;
    private ToolStripMenuItem _menu_file;
    private ToolStripMenuItem _menu_view_side;
    private Button _preview_debug;
    private ToolStripMenuItem _menu_file_new;
    private ToolStripMenuItem _menu_file_open;
    private ToolStripSeparator _menu_file_sep;
    private ToolStripMenuItem _menu_file_save;
    private ToolStripMenuItem _menu_file_saveas;
    private Panel _info;
    private Label _info_header;
}
