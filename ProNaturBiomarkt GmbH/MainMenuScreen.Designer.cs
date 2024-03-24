namespace ProNaturBiomarkt_GmbH
{
    partial class MainMenuScreen
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
            this.btnCustomerManagement = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerManagement.ForeColor = System.Drawing.Color.White;
            this.btnCustomerManagement.Image = global::ProNaturBiomarkt_GmbH.Properties.Resources.BtnImgProducts;
            this.btnCustomerManagement.Location = new System.Drawing.Point(12, 158);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Size = new System.Drawing.Size(275, 125);
            this.btnCustomerManagement.TabIndex = 2;
            this.btnCustomerManagement.Text = "Kundenverwaltung";
            this.btnCustomerManagement.UseVisualStyleBackColor = true;
            this.btnCustomerManagement.Click += new System.EventHandler(this.btnCustomerManagement_Click);
            // 
            // btnBill
            // 
            this.btnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.Color.White;
            this.btnBill.Image = global::ProNaturBiomarkt_GmbH.Properties.Resources.BtnImgBill;
            this.btnBill.Location = new System.Drawing.Point(293, 27);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(275, 125);
            this.btnBill.TabIndex = 1;
            this.btnBill.Text = "Rechnung stellen";
            this.btnBill.UseVisualStyleBackColor = true;
            // 
            // btnProducts
            // 
            this.btnProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Image = global::ProNaturBiomarkt_GmbH.Properties.Resources.BtnImgProducts;
            this.btnProducts.Location = new System.Drawing.Point(12, 27);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(275, 125);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Produkte verwalten";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.Black;
            this.buttonExit.Location = new System.Drawing.Point(293, 158);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(275, 125);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Anwendung beenden";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(590, 310);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.btnCustomerManagement);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.btnProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hauptmenü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnCustomerManagement;
        private System.Windows.Forms.Button buttonExit;
    }
}