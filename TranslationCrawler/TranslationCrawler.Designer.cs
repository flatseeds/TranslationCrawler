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
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.txtDesinationPath = new System.Windows.Forms.TextBox();
            this.lblBaseSource = new System.Windows.Forms.Label();
            this.txtBaseSource = new System.Windows.Forms.TextBox();
            this.lbxTranslations = new System.Windows.Forms.ListBox();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.btnCopyTranslation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(13, 52);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(69, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Source Path:";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(130, 49);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(201, 20);
            this.txtSourcePath.TabIndex = 1;
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(13, 76);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(85, 13);
            this.lblDestinationPath.TabIndex = 2;
            this.lblDestinationPath.Text = "Destination Path";
            // 
            // txtDesinationPath
            // 
            this.txtDesinationPath.Location = new System.Drawing.Point(130, 76);
            this.txtDesinationPath.Name = "txtDesinationPath";
            this.txtDesinationPath.Size = new System.Drawing.Size(201, 20);
            this.txtDesinationPath.TabIndex = 3;
            // 
            // lblBaseSource
            // 
            this.lblBaseSource.AutoSize = true;
            this.lblBaseSource.Location = new System.Drawing.Point(13, 13);
            this.lblBaseSource.Name = "lblBaseSource";
            this.lblBaseSource.Size = new System.Drawing.Size(68, 13);
            this.lblBaseSource.TabIndex = 5;
            this.lblBaseSource.Text = "Base Source";
            // 
            // txtBaseSource
            // 
            this.txtBaseSource.Location = new System.Drawing.Point(130, 13);
            this.txtBaseSource.Name = "txtBaseSource";
            this.txtBaseSource.Size = new System.Drawing.Size(201, 20);
            this.txtBaseSource.TabIndex = 4;
            // 
            // lbxTranslations
            // 
            this.lbxTranslations.FormattingEnabled = true;
            this.lbxTranslations.Location = new System.Drawing.Point(12, 203);
            this.lbxTranslations.Name = "lbxTranslations";
            this.lbxTranslations.Size = new System.Drawing.Size(262, 290);
            this.lbxTranslations.TabIndex = 6;
            // 
            // btnCrawl
            // 
            this.btnCrawl.Location = new System.Drawing.Point(12, 174);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(126, 23);
            this.btnCrawl.TabIndex = 7;
            this.btnCrawl.Text = "Crawl";
            this.btnCrawl.UseVisualStyleBackColor = true;
            this.btnCrawl.Click += new System.EventHandler(this.btnCrawl_Click);
            // 
            // btnCopyTranslation
            // 
            this.btnCopyTranslation.Location = new System.Drawing.Point(148, 174);
            this.btnCopyTranslation.Name = "btnCopyTranslation";
            this.btnCopyTranslation.Size = new System.Drawing.Size(126, 23);
            this.btnCopyTranslation.TabIndex = 8;
            this.btnCopyTranslation.Text = "Copy translation";
            this.btnCopyTranslation.UseVisualStyleBackColor = true;
            this.btnCopyTranslation.Click += new System.EventHandler(this.btnCopyTranslation_Click);
            // 
            // TranslationCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 505);
            this.Controls.Add(this.btnCopyTranslation);
            this.Controls.Add(this.btnCrawl);
            this.Controls.Add(this.lbxTranslations);
            this.Controls.Add(this.lblBaseSource);
            this.Controls.Add(this.txtBaseSource);
            this.Controls.Add(this.txtDesinationPath);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lblSourcePath);
            this.Name = "TranslationCrawler";
            this.Text = "Translation Crawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.TextBox txtDesinationPath;
        private System.Windows.Forms.Label lblBaseSource;
        private System.Windows.Forms.TextBox txtBaseSource;
        private System.Windows.Forms.ListBox lbxTranslations;
        private System.Windows.Forms.Button btnCrawl;
        private System.Windows.Forms.Button btnCopyTranslation;
    }
}

