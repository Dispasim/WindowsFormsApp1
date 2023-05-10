namespace WindowsFormsApp1
{
    partial class EspaceAdminStats
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Valider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 585);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 89);
            this.button1.TabIndex = 0;
            this.button1.Text = "Retour";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Exporter les clients aillant commandé plusieurs fois le mois précédent.",
            "Exporter les clients n\'aillant pas commandé depuis plus de 6 mois.",
            "Bouquet standard le plus acheté.",
            "Meilleur client du mois.",
            "Meilleur client de l\'année.",
            "Prix moyen d\'un bouquet.",
            "Prix moyen d\'un bouquet acheté.",
            "Fleurs plus chères que la moyenne.",
            "Nombre total de commandes.",
            "Chiffre d\'affaire."});
            this.listBox1.Location = new System.Drawing.Point(18, 42);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(510, 384);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(18, 437);
            this.Valider.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(512, 80);
            this.Valider.TabIndex = 2;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // EspaceAdminStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 692);
            this.Controls.Add(this.Valider);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EspaceAdminStats";
            this.Text = "EspaceAdminStats";
            this.Load += new System.EventHandler(this.EspaceAdminStats_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Valider;
    }
}