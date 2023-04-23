namespace WindowsFormsApp1
{
    partial class PageConnection
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
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.TextBox_Mdp = new System.Windows.Forms.MaskedTextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.label_Mdp = new System.Windows.Forms.Label();
            this.button_Valider = new System.Windows.Forms.Button();
            this.Boutton_Retour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(379, 98);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(100, 26);
            this.textBox_Email.TabIndex = 0;
            this.textBox_Email.TextChanged += new System.EventHandler(this.textBox_Email_TextChanged);
            // 
            // TextBox_Mdp
            // 
            this.TextBox_Mdp.Location = new System.Drawing.Point(379, 238);
            this.TextBox_Mdp.Name = "TextBox_Mdp";
            this.TextBox_Mdp.Size = new System.Drawing.Size(100, 26);
            this.TextBox_Mdp.TabIndex = 1;
            this.TextBox_Mdp.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TextBox_Mdp_MaskInputRejected);
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Location = new System.Drawing.Point(401, 34);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(48, 20);
            this.label_Email.TabIndex = 2;
            this.label_Email.Text = "Email";
            // 
            // label_Mdp
            // 
            this.label_Mdp.AutoSize = true;
            this.label_Mdp.Location = new System.Drawing.Point(375, 169);
            this.label_Mdp.Name = "label_Mdp";
            this.label_Mdp.Size = new System.Drawing.Size(105, 20);
            this.label_Mdp.TabIndex = 3;
            this.label_Mdp.Text = "Mot de passe";
            // 
            // button_Valider
            // 
            this.button_Valider.Location = new System.Drawing.Point(352, 333);
            this.button_Valider.Name = "button_Valider";
            this.button_Valider.Size = new System.Drawing.Size(156, 66);
            this.button_Valider.TabIndex = 4;
            this.button_Valider.Text = "Valider";
            this.button_Valider.UseVisualStyleBackColor = true;
            this.button_Valider.Click += new System.EventHandler(this.button_Valider_Click);
            // 
            // Boutton_Retour
            // 
            this.Boutton_Retour.Location = new System.Drawing.Point(639, 356);
            this.Boutton_Retour.Name = "Boutton_Retour";
            this.Boutton_Retour.Size = new System.Drawing.Size(149, 82);
            this.Boutton_Retour.TabIndex = 5;
            this.Boutton_Retour.Text = "Retour";
            this.Boutton_Retour.UseVisualStyleBackColor = true;
            this.Boutton_Retour.Click += new System.EventHandler(this.Boutton_Retour_Click);
            // 
            // PageConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Boutton_Retour);
            this.Controls.Add(this.button_Valider);
            this.Controls.Add(this.label_Mdp);
            this.Controls.Add(this.label_Email);
            this.Controls.Add(this.TextBox_Mdp);
            this.Controls.Add(this.textBox_Email);
            this.Name = "PageConnection";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.PageConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.MaskedTextBox TextBox_Mdp;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.Label label_Mdp;
        private System.Windows.Forms.Button button_Valider;
        private System.Windows.Forms.Button Boutton_Retour;
    }
}