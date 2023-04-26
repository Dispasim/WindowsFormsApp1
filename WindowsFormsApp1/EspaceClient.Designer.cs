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
            this.label1.Location = new System.Drawing.Point(221, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue ";
            // 
            // buttoncommande
            // 
            this.buttoncommande.Location = new System.Drawing.Point(181, 75);
            this.buttoncommande.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttoncommande.Name = "buttoncommande";
            this.buttoncommande.Size = new System.Drawing.Size(147, 50);
            this.buttoncommande.TabIndex = 1;
            this.buttoncommande.Text = "Commander";
            this.buttoncommande.UseVisualStyleBackColor = true;
            this.buttoncommande.Click += new System.EventHandler(this.buttoncommande_Click);
            // 
            // buttonsuivi
            // 
            this.buttonsuivi.Location = new System.Drawing.Point(181, 152);
            this.buttonsuivi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonsuivi.Name = "buttonsuivi";
            this.buttonsuivi.Size = new System.Drawing.Size(147, 50);
            this.buttonsuivi.TabIndex = 2;
            this.buttonsuivi.Text = "Suivi commande";
            this.buttonsuivi.UseVisualStyleBackColor = true;
            this.buttonsuivi.Click += new System.EventHandler(this.buttonsuivi_Click);
            // 
            // buttondeco
            // 
            this.buttondeco.Location = new System.Drawing.Point(181, 229);
            this.buttondeco.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttondeco.Name = "buttondeco";
            this.buttondeco.Size = new System.Drawing.Size(147, 50);
            this.buttondeco.TabIndex = 3;
            this.buttondeco.Text = "Déconnection";
            this.buttondeco.UseVisualStyleBackColor = true;
            this.buttondeco.Click += new System.EventHandler(this.buttondeco_Click);
            // 
            // EspaceClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 302);
            this.Controls.Add(this.buttondeco);
            this.Controls.Add(this.buttonsuivi);
            this.Controls.Add(this.buttoncommande);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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