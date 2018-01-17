namespace ComputerMigration
{
    partial class Form1
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
            this.checkBoxInfo = new System.Windows.Forms.CheckBox();
            this.checkBoxBookmarks = new System.Windows.Forms.CheckBox();
            this.checkBoxMigration = new System.Windows.Forms.CheckBox();
            this.buttonDodat = new System.Windows.Forms.Button();
            this.checkBoxDomain = new System.Windows.Forms.CheckBox();
            this.checkBoxPrinters = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxInfo
            // 
            this.checkBoxInfo.AutoSize = true;
            this.checkBoxInfo.Location = new System.Drawing.Point(34, 12);
            this.checkBoxInfo.Name = "checkBoxInfo";
            this.checkBoxInfo.Size = new System.Drawing.Size(92, 17);
            this.checkBoxInfo.TabIndex = 0;
            this.checkBoxInfo.Text = "Computer Info";
            this.checkBoxInfo.UseVisualStyleBackColor = true;
            this.checkBoxInfo.CheckedChanged += new System.EventHandler(this.checkBoxInfo_CheckedChanged);
            // 
            // checkBoxBookmarks
            // 
            this.checkBoxBookmarks.AutoSize = true;
            this.checkBoxBookmarks.Location = new System.Drawing.Point(34, 58);
            this.checkBoxBookmarks.Name = "checkBoxBookmarks";
            this.checkBoxBookmarks.Size = new System.Drawing.Size(79, 17);
            this.checkBoxBookmarks.TabIndex = 1;
            this.checkBoxBookmarks.Text = "Bookmarks";
            this.checkBoxBookmarks.UseVisualStyleBackColor = true;
            this.checkBoxBookmarks.CheckedChanged += new System.EventHandler(this.checkBoxBookmarks_CheckedChanged);
            // 
            // checkBoxMigration
            // 
            this.checkBoxMigration.AutoSize = true;
            this.checkBoxMigration.Location = new System.Drawing.Point(34, 81);
            this.checkBoxMigration.Name = "checkBoxMigration";
            this.checkBoxMigration.Size = new System.Drawing.Size(69, 17);
            this.checkBoxMigration.TabIndex = 2;
            this.checkBoxMigration.Text = "Migration";
            this.checkBoxMigration.UseVisualStyleBackColor = true;
            this.checkBoxMigration.CheckedChanged += new System.EventHandler(this.checkBoxMigration_CheckedChanged);
            // 
            // buttonDodat
            // 
            this.buttonDodat.Location = new System.Drawing.Point(55, 131);
            this.buttonDodat.Name = "buttonDodat";
            this.buttonDodat.Size = new System.Drawing.Size(75, 23);
            this.buttonDodat.TabIndex = 3;
            this.buttonDodat.Text = "Do dat";
            this.buttonDodat.UseVisualStyleBackColor = true;
            this.buttonDodat.Click += new System.EventHandler(this.buttonDodat_Click);
            // 
            // checkBoxDomain
            // 
            this.checkBoxDomain.AutoSize = true;
            this.checkBoxDomain.Location = new System.Drawing.Point(34, 104);
            this.checkBoxDomain.Name = "checkBoxDomain";
            this.checkBoxDomain.Size = new System.Drawing.Size(62, 17);
            this.checkBoxDomain.TabIndex = 4;
            this.checkBoxDomain.Text = "Domain";
            this.checkBoxDomain.UseVisualStyleBackColor = true;
            this.checkBoxDomain.CheckedChanged += new System.EventHandler(this.checkBoxDomain_CheckedChanged);
            // 
            // checkBoxPrinters
            // 
            this.checkBoxPrinters.AutoSize = true;
            this.checkBoxPrinters.Location = new System.Drawing.Point(34, 35);
            this.checkBoxPrinters.Name = "checkBoxPrinters";
            this.checkBoxPrinters.Size = new System.Drawing.Size(61, 17);
            this.checkBoxPrinters.TabIndex = 5;
            this.checkBoxPrinters.Text = "Printers";
            this.checkBoxPrinters.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 166);
            this.Controls.Add(this.checkBoxPrinters);
            this.Controls.Add(this.checkBoxDomain);
            this.Controls.Add(this.buttonDodat);
            this.Controls.Add(this.checkBoxMigration);
            this.Controls.Add(this.checkBoxBookmarks);
            this.Controls.Add(this.checkBoxInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxInfo;
        private System.Windows.Forms.CheckBox checkBoxBookmarks;
        private System.Windows.Forms.CheckBox checkBoxMigration;
        private System.Windows.Forms.Button buttonDodat;
        private System.Windows.Forms.CheckBox checkBoxDomain;
        private System.Windows.Forms.CheckBox checkBoxPrinters;
    }
}

