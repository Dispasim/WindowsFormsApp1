﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CommandePerso : Form
    {
        private MySqlConnection connection;
        private string courriel;
        
        public CommandePerso(MySqlConnection _connection, string _courriel)
        {
            InitializeComponent();
            connection = _connection;
            courriel = _courriel;
            

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CommandePerso_Load(object sender, EventArgs e)
        {
            labelqt.Text = "0";
            labelprix.Text = "0€";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageCommande Pagecommande = new PageCommande(connection, courriel);
            Pagecommande.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            DateTime dateLivraison = dateTimePicker1.Value;
            if ((dateLivraison - DateTime.Today).Days < 1)
            {
                MessageBox.Show("Merci de séléectionner une date valide");
            }
            else
            {
                bool Vase = checkBox1.Checked;
                bool Boite = boite.Checked;
                bool Ruban = checkBox2.Checked;
                if (checkBox14.Checked)
                {
                    SortedList<int, string> fleurs = new SortedList<int, string>();
                    fleurs.Add(10001, textBox1.Text);
                    fleurs.Add(10002, textBox2.Text);
                    fleurs.Add(10003, textBox3.Text);
                    fleurs.Add(10004, textBox4.Text);
                    fleurs.Add(10005, textBox5.Text);
                    fleurs.Add(10006, textBox6.Text);
                    fleurs.Add(10007, textBox7.Text);
                    fleurs.Add(10008, textBox8.Text);
                    fleurs.Add(10009, textBox9.Text);
                    fleurs.Add(100010, textBox10.Text);
                    fleurs.Add(100011, textBox11.Text);
                    fleurs.Add(100012, Verdure.Text);
                    
                    Program.CreationCommandePerso(connection, fleurs, Vase, Boite, Ruban, textBox13.Text, richTextBox1.Text, courriel, 30001, dateLivraison, richTextBox2.Text);
                }
                else
                {
                    List<int> fleurs= new List<int>();
                    if (Gerbera.Checked)
                    {
                        fleurs.Add(10001);
                    }
                    if (checkBox3.Checked)
                    {
                        fleurs.Add(10002);
                    }
                    if (checkBox4.Checked)
                    {
                        fleurs.Add(10003);
                    }
                    if (checkBox5.Checked)
                    {
                        fleurs.Add(10004);
                    }
                    if (checkBox6.Checked)
                    {
                        fleurs.Add(10005);
                    }
                    if (checkBox7.Checked)
                    {
                        fleurs.Add(10006);
                    }
                    if (checkBox8.Checked)
                    {
                        fleurs.Add(10007);
                    }
                    if (checkBox9.Checked)
                    {
                        fleurs.Add(10008);
                    }
                    if (checkBox10.Checked)
                    {
                        fleurs.Add(10009);
                    }
                    if (checkBox11.Checked)
                    {
                        fleurs.Add(100010);
                    }
                    if (checkBox12.Checked)
                    {
                        fleurs.Add(100011);
                    }
                    if (checkBox13.Checked)
                    {
                        fleurs.Add(100012);
                    }
                    Program.creationCommandePerso1(connection, fleurs, Vase, Boite, Ruban, textBox13.Text, richTextBox1.Text, courriel, 30001, dateLivraison, richTextBox2.Text);


                }
                EspaceClient Espaceclient = new EspaceClient(connection, courriel);
                Espaceclient.ShowDialog();
                this.Close();
            }
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.Now.Month != 6 && DateTime.Now.Month != 7 && DateTime.Now.Month != 8 && DateTime.Now.Month != 9 && DateTime.Now.Month != 10 && DateTime.Now.Month != 11 && textBox3.Text != "0")
            {
                MessageBox.Show("Cette fleur est disponible de juillet à novembre.");
                textBox3.Text = "0";
            }

            else 
            {
                labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
                labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            labelqt.Text = Program.SommeFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text);
            labelprix.Text = Program.SommePrixFleur(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, Verdure.Text) + "€";
        }

        private void Gerbera_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
