﻿namespace WindowsFormsApp1
{
    partial class CreationCompte
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxnom = new System.Windows.Forms.TextBox();
            this.textBoxmdp = new System.Windows.Forms.TextBox();
            this.textBoxprenom = new System.Windows.Forms.TextBox();
            this.textBoxtelephone = new System.Windows.Forms.TextBox();
            this.textBoxadresse = new System.Windows.Forms.TextBox();
            this.textBoxnumero = new System.Windows.Forms.TextBox();
            this.textBoxDateexpiration = new System.Windows.Forms.TextBox();
            this.textBoxcrypto = new System.Windows.Forms.TextBox();
            this.buttonvalider = new System.Windows.Forms.Button();
            this.button2retour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creation du compte";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(320, 116);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 26);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mot de passe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Numéro de téléphone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(346, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nom";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Prénom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 522);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Adresse de facturation";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 622);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Numéro de carte";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(300, 706);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Date d\'expiration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 806);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Cryptogramme secret";
            // 
            // textBoxnom
            // 
            this.textBoxnom.Location = new System.Drawing.Point(320, 301);
            this.textBoxnom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxnom.Name = "textBoxnom";
            this.textBoxnom.Size = new System.Drawing.Size(100, 26);
            this.textBoxnom.TabIndex = 11;
            // 
            // textBoxmdp
            // 
            this.textBoxmdp.Location = new System.Drawing.Point(320, 211);
            this.textBoxmdp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxmdp.Name = "textBoxmdp";
            this.textBoxmdp.Size = new System.Drawing.Size(100, 26);
            this.textBoxmdp.TabIndex = 12;
            // 
            // textBoxprenom
            // 
            this.textBoxprenom.Location = new System.Drawing.Point(320, 382);
            this.textBoxprenom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxprenom.Name = "textBoxprenom";
            this.textBoxprenom.Size = new System.Drawing.Size(100, 26);
            this.textBoxprenom.TabIndex = 13;
            // 
            // textBoxtelephone
            // 
            this.textBoxtelephone.Location = new System.Drawing.Point(320, 475);
            this.textBoxtelephone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxtelephone.Name = "textBoxtelephone";
            this.textBoxtelephone.Size = new System.Drawing.Size(100, 26);
            this.textBoxtelephone.TabIndex = 14;
            // 
            // textBoxadresse
            // 
            this.textBoxadresse.Location = new System.Drawing.Point(320, 572);
            this.textBoxadresse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxadresse.Name = "textBoxadresse";
            this.textBoxadresse.Size = new System.Drawing.Size(100, 26);
            this.textBoxadresse.TabIndex = 15;
            // 
            // textBoxnumero
            // 
            this.textBoxnumero.Location = new System.Drawing.Point(320, 664);
            this.textBoxnumero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxnumero.Name = "textBoxnumero";
            this.textBoxnumero.Size = new System.Drawing.Size(100, 26);
            this.textBoxnumero.TabIndex = 16;
            // 
            // textBoxDateexpiration
            // 
            this.textBoxDateexpiration.Location = new System.Drawing.Point(320, 755);
            this.textBoxDateexpiration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDateexpiration.Name = "textBoxDateexpiration";
            this.textBoxDateexpiration.Size = new System.Drawing.Size(100, 26);
            this.textBoxDateexpiration.TabIndex = 17;
            // 
            // textBoxcrypto
            // 
            this.textBoxcrypto.Location = new System.Drawing.Point(320, 852);
            this.textBoxcrypto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxcrypto.Name = "textBoxcrypto";
            this.textBoxcrypto.Size = new System.Drawing.Size(100, 26);
            this.textBoxcrypto.TabIndex = 18;
            // 
            // buttonvalider
            // 
            this.buttonvalider.Location = new System.Drawing.Point(271, 921);
            this.buttonvalider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonvalider.Name = "buttonvalider";
            this.buttonvalider.Size = new System.Drawing.Size(206, 54);
            this.buttonvalider.TabIndex = 19;
            this.buttonvalider.Text = "Valider";
            this.buttonvalider.UseVisualStyleBackColor = true;
            this.buttonvalider.Click += new System.EventHandler(this.buttonvalider_Click);
            // 
            // button2retour
            // 
            this.button2retour.Location = new System.Drawing.Point(638, 921);
            this.button2retour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2retour.Name = "button2retour";
            this.button2retour.Size = new System.Drawing.Size(146, 69);
            this.button2retour.TabIndex = 20;
            this.button2retour.Text = "Retour";
            this.button2retour.UseVisualStyleBackColor = true;
            this.button2retour.Click += new System.EventHandler(this.button2retour_Click);
            // 
            // CreationCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 1002);
            this.Controls.Add(this.button2retour);
            this.Controls.Add(this.buttonvalider);
            this.Controls.Add(this.textBoxcrypto);
            this.Controls.Add(this.textBoxDateexpiration);
            this.Controls.Add(this.textBoxnumero);
            this.Controls.Add(this.textBoxadresse);
            this.Controls.Add(this.textBoxtelephone);
            this.Controls.Add(this.textBoxprenom);
            this.Controls.Add(this.textBoxmdp);
            this.Controls.Add(this.textBoxnom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreationCompte";
            this.Text = "CreationCompte";
            this.Load += new System.EventHandler(this.CreationCompte_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxnom;
        private System.Windows.Forms.TextBox textBoxmdp;
        private System.Windows.Forms.TextBox textBoxprenom;
        private System.Windows.Forms.TextBox textBoxtelephone;
        private System.Windows.Forms.TextBox textBoxadresse;
        private System.Windows.Forms.TextBox textBoxnumero;
        private System.Windows.Forms.TextBox textBoxDateexpiration;
        private System.Windows.Forms.TextBox textBoxcrypto;
        private System.Windows.Forms.Button buttonvalider;
        private System.Windows.Forms.Button button2retour;
    }
}