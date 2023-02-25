
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
            this.chargePrev = new System.Windows.Forms.PictureBox();
            this.idlePrev = new System.Windows.Forms.PictureBox();
            this.backgroundBtn = new System.Windows.Forms.Button();
            this.previewType1 = new System.Windows.Forms.ComboBox();
            this.previewType2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chargePrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idlePrev)).BeginInit();
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
            // chargePrev
            // 
            this.chargePrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chargePrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chargePrev.BackgroundImage")));
            this.chargePrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chargePrev.Location = new System.Drawing.Point(655, 250);
            this.chargePrev.Margin = new System.Windows.Forms.Padding(2);
            this.chargePrev.Name = "chargePrev";
            this.chargePrev.Size = new System.Drawing.Size(620, 480);
            this.chargePrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.chargePrev.TabIndex = 4;
            this.chargePrev.TabStop = false;
            // 
            // idlePrev
            // 
            this.idlePrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.idlePrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("idlePrev.BackgroundImage")));
            this.idlePrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.idlePrev.Location = new System.Drawing.Point(10, 250);
            this.idlePrev.Margin = new System.Windows.Forms.Padding(2);
            this.idlePrev.Name = "idlePrev";
            this.idlePrev.Size = new System.Drawing.Size(620, 480);
            this.idlePrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.idlePrev.TabIndex = 0;
            this.idlePrev.TabStop = false;
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
            this.previewType1.Location = new System.Drawing.Point(4, 224);
            this.previewType1.Name = "previewType1";
            this.previewType1.Size = new System.Drawing.Size(121, 21);
            this.previewType1.TabIndex = 10;
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
            // 
            // SkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1289, 761);
            this.Controls.Add(this.previewType2);
            this.Controls.Add(this.previewType1);
            this.Controls.Add(this.backgroundBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.chargePrev);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.idlePrev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SkinForm";
            this.Text = "Blasphemous Skin Editor";
            this.Load += new System.EventHandler(this.SkinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chargePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idlePrev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox idlePrev;
        private System.Windows.Forms.ColorDialog TextureColor;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.PictureBox chargePrev;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button backgroundBtn;
        private System.Windows.Forms.ComboBox previewType1;
        private System.Windows.Forms.ComboBox previewType2;
    }
}

