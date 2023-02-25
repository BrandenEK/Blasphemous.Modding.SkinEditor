
namespace BlasphemousSkinEditor
{
    partial class SkinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkinForm));
            this.TextureColor = new System.Windows.Forms.ColorDialog();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.importBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.backgroundBtn = new System.Windows.Forms.Button();
            this.previewType1 = new System.Windows.Forms.ComboBox();
            this.previewType2 = new System.Windows.Forms.ComboBox();
            this.currentBtn = new System.Windows.Forms.Button();
            this.currentText = new System.Windows.Forms.TextBox();
            this.undoBtn = new System.Windows.Forms.Button();
            this.previewImage2 = new System.Windows.Forms.PictureBox();
            this.previewImage1 = new System.Windows.Forms.PictureBox();
            this.redoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage1)).BeginInit();
            this.SuspendLayout();
            // 
            // TextureColor
            // 
            this.TextureColor.AnyColor = true;
            this.TextureColor.FullOpen = true;
            this.TextureColor.SolidColorOnly = true;
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colorPanel.Location = new System.Drawing.Point(0, 0);
            this.colorPanel.Margin = new System.Windows.Forms.Padding(2);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(1350, 171);
            this.colorPanel.TabIndex = 2;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(1094, 177);
            this.importBtn.Margin = new System.Windows.Forms.Padding(2);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(90, 30);
            this.importBtn.TabIndex = 3;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(1188, 177);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(2);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(90, 30);
            this.exportBtn.TabIndex = 3;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(971, 196);
            this.nameText.Margin = new System.Windows.Forms.Padding(2);
            this.nameText.MaxLength = 20;
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(99, 20);
            this.nameText.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(991, 180);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(57, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Skin name";
            // 
            // backgroundBtn
            // 
            this.backgroundBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.backgroundBtn.Location = new System.Drawing.Point(11, 177);
            this.backgroundBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backgroundBtn.Name = "backgroundBtn";
            this.backgroundBtn.Size = new System.Drawing.Size(114, 25);
            this.backgroundBtn.TabIndex = 8;
            this.backgroundBtn.Text = "Toggle Background";
            this.backgroundBtn.UseVisualStyleBackColor = false;
            this.backgroundBtn.Click += new System.EventHandler(this.backgroundBtn_Click);
            // 
            // previewType1
            // 
            this.previewType1.FormattingEnabled = true;
            this.previewType1.Items.AddRange(new object[] {
            "Idle",
            "Kneel",
            "Charged",
            "Parry",
            "Bleed"});
            this.previewType1.Location = new System.Drawing.Point(10, 224);
            this.previewType1.Name = "previewType1";
            this.previewType1.Size = new System.Drawing.Size(121, 21);
            this.previewType1.TabIndex = 10;
            this.previewType1.SelectedIndexChanged += new System.EventHandler(this.previewType1_SelectedIndexChanged);
            // 
            // previewType2
            // 
            this.previewType2.FormattingEnabled = true;
            this.previewType2.Items.AddRange(new object[] {
            "Idle",
            "Kneel",
            "Charged",
            "Parry",
            "Bleed"});
            this.previewType2.Location = new System.Drawing.Point(655, 224);
            this.previewType2.Name = "previewType2";
            this.previewType2.Size = new System.Drawing.Size(121, 21);
            this.previewType2.TabIndex = 11;
            this.previewType2.SelectedIndexChanged += new System.EventHandler(this.previewType2_SelectedIndexChanged);
            // 
            // currentBtn
            // 
            this.currentBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentBtn.Enabled = false;
            this.currentBtn.Location = new System.Drawing.Point(159, 174);
            this.currentBtn.Margin = new System.Windows.Forms.Padding(2);
            this.currentBtn.Name = "currentBtn";
            this.currentBtn.Size = new System.Drawing.Size(30, 30);
            this.currentBtn.TabIndex = 12;
            this.currentBtn.UseVisualStyleBackColor = false;
            // 
            // currentText
            // 
            this.currentText.Location = new System.Drawing.Point(193, 180);
            this.currentText.Margin = new System.Windows.Forms.Padding(2);
            this.currentText.MaxLength = 7;
            this.currentText.Name = "currentText";
            this.currentText.Size = new System.Drawing.Size(70, 20);
            this.currentText.TabIndex = 13;
            this.currentText.TextChanged += new System.EventHandler(this.currentText_TextChanged);
            this.currentText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentText_KeyDown);
            this.currentText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.currentText_MouseDown);
            // 
            // undoBtn
            // 
            this.undoBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.undoBtn.BackgroundImage = global::BlasphemousSkinEditor.Properties.Resources.undo;
            this.undoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.undoBtn.Location = new System.Drawing.Point(1202, 211);
            this.undoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.undoBtn.Name = "undoBtn";
            this.undoBtn.Size = new System.Drawing.Size(30, 30);
            this.undoBtn.TabIndex = 14;
            this.undoBtn.UseVisualStyleBackColor = false;
            // 
            // previewImage2
            // 
            this.previewImage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.previewImage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previewImage2.BackgroundImage")));
            this.previewImage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewImage2.Location = new System.Drawing.Point(655, 250);
            this.previewImage2.Margin = new System.Windows.Forms.Padding(2);
            this.previewImage2.Name = "previewImage2";
            this.previewImage2.Size = new System.Drawing.Size(620, 480);
            this.previewImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewImage2.TabIndex = 4;
            this.previewImage2.TabStop = false;
            // 
            // previewImage1
            // 
            this.previewImage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.previewImage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previewImage1.BackgroundImage")));
            this.previewImage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewImage1.Location = new System.Drawing.Point(10, 250);
            this.previewImage1.Margin = new System.Windows.Forms.Padding(2);
            this.previewImage1.Name = "previewImage1";
            this.previewImage1.Size = new System.Drawing.Size(620, 480);
            this.previewImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.previewImage1.TabIndex = 0;
            this.previewImage1.TabStop = false;
            // 
            // redoBtn
            // 
            this.redoBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.redoBtn.BackgroundImage = global::BlasphemousSkinEditor.Properties.Resources.redo;
            this.redoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.redoBtn.Location = new System.Drawing.Point(1236, 211);
            this.redoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.redoBtn.Name = "redoBtn";
            this.redoBtn.Size = new System.Drawing.Size(30, 30);
            this.redoBtn.TabIndex = 15;
            this.redoBtn.UseVisualStyleBackColor = false;
            // 
            // SkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1289, 761);
            this.Controls.Add(this.redoBtn);
            this.Controls.Add(this.undoBtn);
            this.Controls.Add(this.currentText);
            this.Controls.Add(this.currentBtn);
            this.Controls.Add(this.previewType2);
            this.Controls.Add(this.previewType1);
            this.Controls.Add(this.backgroundBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.previewImage2);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.previewImage1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SkinForm";
            this.Text = "Blasphemous Skin Editor";
            this.Load += new System.EventHandler(this.SkinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewImage1;
        private System.Windows.Forms.ColorDialog TextureColor;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.PictureBox previewImage2;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button backgroundBtn;
        private System.Windows.Forms.ComboBox previewType1;
        private System.Windows.Forms.ComboBox previewType2;
        private System.Windows.Forms.Button currentBtn;
        private System.Windows.Forms.TextBox currentText;
        private System.Windows.Forms.Button undoBtn;
        private System.Windows.Forms.Button redoBtn;
    }
}

