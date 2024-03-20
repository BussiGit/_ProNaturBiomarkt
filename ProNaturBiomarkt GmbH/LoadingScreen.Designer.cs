namespace ProNaturBiomarkt_GmbH
{
    partial class LoadingScreen
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loadingPrograssBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLoadingProgress = new System.Windows.Forms.Label();
            this.loadingBarTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingPrograssBar
            // 
            this.loadingPrograssBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loadingPrograssBar.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.loadingPrograssBar.Location = new System.Drawing.Point(161, 308);
            this.loadingPrograssBar.Name = "loadingPrograssBar";
            this.loadingPrograssBar.Size = new System.Drawing.Size(468, 23);
            this.loadingPrograssBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading";
            // 
            // lblLoadingProgress
            // 
            this.lblLoadingProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLoadingProgress.AutoSize = true;
            this.lblLoadingProgress.Location = new System.Drawing.Point(416, 292);
            this.lblLoadingProgress.Name = "lblLoadingProgress";
            this.lblLoadingProgress.Size = new System.Drawing.Size(21, 13);
            this.lblLoadingProgress.TabIndex = 2;
            this.lblLoadingProgress.Text = "0%";
            // 
            // loadingBarTimer
            // 
            this.loadingBarTimer.Tick += new System.EventHandler(this.loadingBarTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = global::ProNaturBiomarkt_GmbH.Properties.Resources.GroceryImg;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 264);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 341);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLoadingProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadingPrograssBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProNatur Biomarkt GmbH";
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar loadingPrograssBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoadingProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer loadingBarTimer;
    }
}

