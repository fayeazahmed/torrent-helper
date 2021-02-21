
namespace TorrentDownloader
{
    partial class Form1
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
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultPanelLabel = new System.Windows.Forms.Label();
            this.ResultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchLabel.ForeColor = System.Drawing.Color.Honeydew;
            this.SearchLabel.Location = new System.Drawing.Point(29, 22);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(241, 29);
            this.SearchLabel.TabIndex = 0;
            this.SearchLabel.Text = "Search for something";
            this.SearchLabel.Click += new System.EventHandler(this.SearchLabel_Click);
            // 
            // SearchText
            // 
            this.SearchText.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.SearchText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchText.Location = new System.Drawing.Point(276, 22);
            this.SearchText.Multiline = true;
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(436, 29);
            this.SearchText.TabIndex = 1;
            this.SearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchText_KeyDown);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubmitBtn.Location = new System.Drawing.Point(719, 22);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(90, 29);
            this.SubmitBtn.TabIndex = 2;
            this.SubmitBtn.Text = "Search";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ResultPanel
            // 
            this.ResultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ResultPanel.AutoScroll = true;
            this.ResultPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ResultPanel.Controls.Add(this.ResultPanelLabel);
            this.ResultPanel.Location = new System.Drawing.Point(29, 81);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(811, 505);
            this.ResultPanel.TabIndex = 3;
            // 
            // ResultPanelLabel
            // 
            this.ResultPanelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultPanelLabel.Font = new System.Drawing.Font("Siyam Rupali", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ResultPanelLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ResultPanelLabel.Location = new System.Drawing.Point(0, 0);
            this.ResultPanelLabel.Name = "ResultPanelLabel";
            this.ResultPanelLabel.Size = new System.Drawing.Size(811, 50);
            this.ResultPanelLabel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1067, 622);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.SearchLabel);
            this.MaximumSize = new System.Drawing.Size(1083, 661);
            this.Name = "Form1";
            this.Text = "Torrent Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResultPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.Label ResultPanelLabel;
    }
}

