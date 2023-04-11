namespace WindowsFormsApp1
{
    partial class EspaceClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttoncommande = new System.Windows.Forms.Button();
            this.buttonsuivi = new System.Windows.Forms.Button();
            this.buttondeco = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue ";
            // 
            // buttoncommande
            // 
            this.buttoncommande.Location = new System.Drawing.Point(271, 116);
            this.buttoncommande.Name = "buttoncommande";
            this.buttoncommande.Size = new System.Drawing.Size(221, 77);
            this.buttoncommande.TabIndex = 1;
            this.buttoncommande.Text = "Commander";
            this.buttoncommande.UseVisualStyleBackColor = true;
            this.buttoncommande.Click += new System.EventHandler(this.buttoncommande_Click);
            // 
            // buttonsuivi
            // 
            this.buttonsuivi.Location = new System.Drawing.Point(271, 234);
            this.buttonsuivi.Name = "buttonsuivi";
            this.buttonsuivi.Size = new System.Drawing.Size(221, 77);
            this.buttonsuivi.TabIndex = 2;
            this.buttonsuivi.Text = "Suivi commande";
            this.buttonsuivi.UseVisualStyleBackColor = true;
            // 
            // buttondeco
            // 
            this.buttondeco.Location = new System.Drawing.Point(271, 352);
            this.buttondeco.Name = "buttondeco";
            this.buttondeco.Size = new System.Drawing.Size(221, 77);
            this.buttondeco.TabIndex = 3;
            this.buttondeco.Text = "Déconnection";
            this.buttondeco.UseVisualStyleBackColor = true;
            this.buttondeco.Click += new System.EventHandler(this.buttondeco_Click);
            // 
            // EspaceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.buttondeco);
            this.Controls.Add(this.buttonsuivi);
            this.Controls.Add(this.buttoncommande);
            this.Controls.Add(this.label1);
            this.Name = "EspaceClient";
            this.Text = "EspaceClient";
            this.Load += new System.EventHandler(this.EspaceClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttoncommande;
        private System.Windows.Forms.Button buttonsuivi;
        private System.Windows.Forms.Button buttondeco;
    }
}