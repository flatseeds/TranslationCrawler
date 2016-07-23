namespace TranslationCrawler
{
    partial class TranslationCrawler
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
            this.lblSourcePath = new System.Windows.Forms.Label();
            this.tbxSourcePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(13, 13);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(69, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Source Path:";
            // 
            // tbxSourcePath
            // 
            this.tbxSourcePath.Location = new System.Drawing.Point(130, 10);
            this.tbxSourcePath.Name = "tbxSourcePath";
            this.tbxSourcePath.Size = new System.Drawing.Size(201, 20);
            this.tbxSourcePath.TabIndex = 1;
            // 
            // TranslationCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 505);
            this.Controls.Add(this.tbxSourcePath);
            this.Controls.Add(this.lblSourcePath);
            this.Name = "TranslationCrawler";
            this.Text = "Translation Crawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.TextBox tbxSourcePath;
    }
}

