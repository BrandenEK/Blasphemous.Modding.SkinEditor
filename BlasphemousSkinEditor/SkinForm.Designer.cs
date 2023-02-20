
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
            this.TextureColor = new System.Windows.Forms.ColorDialog();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.importBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.cutPrev = new System.Windows.Forms.PictureBox();
            this.chargePrev = new System.Windows.Forms.PictureBox();
            this.idlePrev = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cutPrev)).BeginInit();
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
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(1800, 160);
            this.colorPanel.TabIndex = 2;
            // 
            // importBtn
            // 
            this.importBtn.Location = new System.Drawing.Point(970, 234);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(110, 35);
            this.importBtn.TabIndex = 3;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(1095, 234);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(110, 35);
            this.exportBtn.TabIndex = 3;
            this.exportBtn.Text = "Export";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // cutPrev
            // 
            this.cutPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cutPrev.BackgroundImage = global::BlasphemousSkinEditor.Properties.Resources.transparent;
            this.cutPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cutPrev.Location = new System.Drawing.Point(835, 183);
            this.cutPrev.Name = "cutPrev";
            this.cutPrev.Size = new System.Drawing.Size(370, 347);
            this.cutPrev.TabIndex = 5;
            this.cutPrev.TabStop = false;
            // 
            // chargePrev
            // 
            this.chargePrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chargePrev.BackgroundImage = global::BlasphemousSkinEditor.Properties.Resources.transparent;
            this.chargePrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.chargePrev.Location = new System.Drawing.Point(424, 183);
            this.chargePrev.Name = "chargePrev";
            this.chargePrev.Size = new System.Drawing.Size(370, 347);
            this.chargePrev.TabIndex = 4;
            this.chargePrev.TabStop = false;
            // 
            // idlePrev
            // 
            this.idlePrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.idlePrev.BackgroundImage = global::BlasphemousSkinEditor.Properties.Resources.transparent;
            this.idlePrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.idlePrev.Location = new System.Drawing.Point(12, 183);
            this.idlePrev.Name = "idlePrev";
            this.idlePrev.Size = new System.Drawing.Size(370, 347);
            this.idlePrev.TabIndex = 0;
            this.idlePrev.TabStop = false;
            // 
            // SkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1287, 753);
            this.Controls.Add(this.cutPrev);
            this.Controls.Add(this.chargePrev);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.idlePrev);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SkinForm";
            this.Text = "Blasphemous Skin Editor";
            this.Load += new System.EventHandler(this.SkinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cutPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idlePrev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox idlePrev;
        private System.Windows.Forms.ColorDialog TextureColor;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.PictureBox chargePrev;
        private System.Windows.Forms.PictureBox cutPrev;
    }
}

