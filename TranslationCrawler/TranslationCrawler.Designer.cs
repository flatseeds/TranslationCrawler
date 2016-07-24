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
            this.lblDestinationPath = new System.Windows.Forms.Label();
            this.lblBaseSource = new System.Windows.Forms.Label();
            this.txtBaseSource = new System.Windows.Forms.TextBox();
            this.lbxTranslations = new System.Windows.Forms.ListBox();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.btnCopyTranslation = new System.Windows.Forms.Button();
            this.cbxSourcePath = new System.Windows.Forms.ComboBox();
            this.cbxDestinationPath = new System.Windows.Forms.ComboBox();
            this.lblLanguages = new System.Windows.Forms.Label();
            this.cbxLanguages = new System.Windows.Forms.ComboBox();
            this.rbtInsert = new System.Windows.Forms.RadioButton();
            this.rbtUpdate = new System.Windows.Forms.RadioButton();
            this.grbActions = new System.Windows.Forms.GroupBox();
            this.lbxInsertedTranslations = new System.Windows.Forms.ListBox();
            this.grbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSourcePath
            // 
            this.lblSourcePath.AutoSize = true;
            this.lblSourcePath.Location = new System.Drawing.Point(13, 47);
            this.lblSourcePath.Name = "lblSourcePath";
            this.lblSourcePath.Size = new System.Drawing.Size(69, 13);
            this.lblSourcePath.TabIndex = 0;
            this.lblSourcePath.Text = "Source Path:";
            // 
            // lblDestinationPath
            // 
            this.lblDestinationPath.AutoSize = true;
            this.lblDestinationPath.Location = new System.Drawing.Point(13, 79);
            this.lblDestinationPath.Name = "lblDestinationPath";
            this.lblDestinationPath.Size = new System.Drawing.Size(88, 13);
            this.lblDestinationPath.TabIndex = 2;
            this.lblDestinationPath.Text = "Destination Path:";
            // 
            // lblBaseSource
            // 
            this.lblBaseSource.AutoSize = true;
            this.lblBaseSource.Location = new System.Drawing.Point(14, 16);
            this.lblBaseSource.Name = "lblBaseSource";
            this.lblBaseSource.Size = new System.Drawing.Size(71, 13);
            this.lblBaseSource.TabIndex = 5;
            this.lblBaseSource.Text = "Base Source:";
            // 
            // txtBaseSource
            // 
            this.txtBaseSource.Location = new System.Drawing.Point(148, 12);
            this.txtBaseSource.Name = "txtBaseSource";
            this.txtBaseSource.Size = new System.Drawing.Size(408, 20);
            this.txtBaseSource.TabIndex = 4;
            // 
            // lbxTranslations
            // 
            this.lbxTranslations.FormattingEnabled = true;
            this.lbxTranslations.Location = new System.Drawing.Point(12, 190);
            this.lbxTranslations.Name = "lbxTranslations";
            this.lbxTranslations.Size = new System.Drawing.Size(262, 303);
            this.lbxTranslations.TabIndex = 6;
            // 
            // btnCrawl
            // 
            this.btnCrawl.Location = new System.Drawing.Point(12, 156);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(126, 23);
            this.btnCrawl.TabIndex = 7;
            this.btnCrawl.Text = "Crawl";
            this.btnCrawl.UseVisualStyleBackColor = true;
            this.btnCrawl.Click += new System.EventHandler(this.btnCrawl_Click);
            // 
            // btnCopyTranslation
            // 
            this.btnCopyTranslation.Location = new System.Drawing.Point(148, 156);
            this.btnCopyTranslation.Name = "btnCopyTranslation";
            this.btnCopyTranslation.Size = new System.Drawing.Size(126, 23);
            this.btnCopyTranslation.TabIndex = 8;
            this.btnCopyTranslation.Text = "Copy translation";
            this.btnCopyTranslation.UseVisualStyleBackColor = true;
            this.btnCopyTranslation.Click += new System.EventHandler(this.btnCopyTranslation_Click);
            // 
            // cbxSourcePath
            // 
            this.cbxSourcePath.FormattingEnabled = true;
            this.cbxSourcePath.Location = new System.Drawing.Point(148, 44);
            this.cbxSourcePath.Name = "cbxSourcePath";
            this.cbxSourcePath.Size = new System.Drawing.Size(408, 21);
            this.cbxSourcePath.TabIndex = 9;
            this.cbxSourcePath.SelectedIndexChanged += new System.EventHandler(this.cbxSourcePath_SelectedIndexChanged);
            // 
            // cbxDestinationPath
            // 
            this.cbxDestinationPath.FormattingEnabled = true;
            this.cbxDestinationPath.Location = new System.Drawing.Point(148, 76);
            this.cbxDestinationPath.Name = "cbxDestinationPath";
            this.cbxDestinationPath.Size = new System.Drawing.Size(408, 21);
            this.cbxDestinationPath.TabIndex = 10;
            // 
            // lblLanguages
            // 
            this.lblLanguages.AutoSize = true;
            this.lblLanguages.Location = new System.Drawing.Point(13, 109);
            this.lblLanguages.Name = "lblLanguages";
            this.lblLanguages.Size = new System.Drawing.Size(63, 13);
            this.lblLanguages.TabIndex = 11;
            this.lblLanguages.Text = "Languages:";
            // 
            // cbxLanguages
            // 
            this.cbxLanguages.FormattingEnabled = true;
            this.cbxLanguages.Location = new System.Drawing.Point(148, 109);
            this.cbxLanguages.Name = "cbxLanguages";
            this.cbxLanguages.Size = new System.Drawing.Size(126, 21);
            this.cbxLanguages.TabIndex = 12;
            // 
            // rbtInsert
            // 
            this.rbtInsert.AutoSize = true;
            this.rbtInsert.Location = new System.Drawing.Point(16, 19);
            this.rbtInsert.Name = "rbtInsert";
            this.rbtInsert.Size = new System.Drawing.Size(51, 17);
            this.rbtInsert.TabIndex = 14;
            this.rbtInsert.TabStop = true;
            this.rbtInsert.Text = "Insert";
            this.rbtInsert.UseVisualStyleBackColor = true;
            // 
            // rbtUpdate
            // 
            this.rbtUpdate.AutoSize = true;
            this.rbtUpdate.Location = new System.Drawing.Point(16, 42);
            this.rbtUpdate.Name = "rbtUpdate";
            this.rbtUpdate.Size = new System.Drawing.Size(60, 17);
            this.rbtUpdate.TabIndex = 15;
            this.rbtUpdate.TabStop = true;
            this.rbtUpdate.Text = "Update";
            this.rbtUpdate.UseVisualStyleBackColor = true;
            // 
            // grbActions
            // 
            this.grbActions.Controls.Add(this.rbtInsert);
            this.grbActions.Controls.Add(this.rbtUpdate);
            this.grbActions.Location = new System.Drawing.Point(356, 109);
            this.grbActions.Name = "grbActions";
            this.grbActions.Size = new System.Drawing.Size(200, 70);
            this.grbActions.TabIndex = 16;
            this.grbActions.TabStop = false;
            this.grbActions.Text = "Actions:";
            // 
            // lbxInsertedTranslations
            // 
            this.lbxInsertedTranslations.FormattingEnabled = true;
            this.lbxInsertedTranslations.Location = new System.Drawing.Point(289, 190);
            this.lbxInsertedTranslations.Name = "lbxInsertedTranslations";
            this.lbxInsertedTranslations.Size = new System.Drawing.Size(267, 303);
            this.lbxInsertedTranslations.TabIndex = 17;
            // 
            // TranslationCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 505);
            this.Controls.Add(this.lbxInsertedTranslations);
            this.Controls.Add(this.grbActions);
            this.Controls.Add(this.cbxLanguages);
            this.Controls.Add(this.lblLanguages);
            this.Controls.Add(this.cbxDestinationPath);
            this.Controls.Add(this.cbxSourcePath);
            this.Controls.Add(this.btnCopyTranslation);
            this.Controls.Add(this.btnCrawl);
            this.Controls.Add(this.lbxTranslations);
            this.Controls.Add(this.lblBaseSource);
            this.Controls.Add(this.txtBaseSource);
            this.Controls.Add(this.lblDestinationPath);
            this.Controls.Add(this.lblSourcePath);
            this.Name = "TranslationCrawler";
            this.Text = "Translation Crawler";
            this.grbActions.ResumeLayout(false);
            this.grbActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSourcePath;
        private System.Windows.Forms.Label lblDestinationPath;
        private System.Windows.Forms.Label lblBaseSource;
        private System.Windows.Forms.TextBox txtBaseSource;
        private System.Windows.Forms.ListBox lbxTranslations;
        private System.Windows.Forms.Button btnCrawl;
        private System.Windows.Forms.Button btnCopyTranslation;
        private System.Windows.Forms.ComboBox cbxSourcePath;
        private System.Windows.Forms.ComboBox cbxDestinationPath;
        private System.Windows.Forms.Label lblLanguages;
        private System.Windows.Forms.ComboBox cbxLanguages;
        private System.Windows.Forms.RadioButton rbtInsert;
        private System.Windows.Forms.RadioButton rbtUpdate;
        private System.Windows.Forms.GroupBox grbActions;
        private System.Windows.Forms.ListBox lbxInsertedTranslations;
    }
}

