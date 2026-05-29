using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RDR2_Visual_Novel
{
    public partial class FormNewGame : Form
    {
        public int pasPoveste = 0;
        public FormNewGame()
        {
            InitializeComponent();
            panelDialog.BackColor = Color.FromArgb(80, Color.LightGray);
            lblText.AutoSize = true;
            lblText.MaximumSize = new Size(panelDialog.Width - 20, 0);
        }

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            // TRUCUL PENTRU TRANSPARENȚĂ:
            // Îi spunem personajului și textului că "tatăl" lor este fundalul, 
            // astfel încât transparența lor să lase să se vadă poza de fundal, nu ecranul negru.
            pbCaracter.Parent = pbFundal;
            panelDialog.Parent = pbFundal;
            panelDialog.BringToFront();

            // Ascundem personajul la început
            pbCaracter.Visible = false;

            // Pornim prima scenă
            IncarcaScena();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
  
            Close();
        }

        private void pbFundal_Click(object sender, EventArgs e)
        {
            pasPoveste++;
            IncarcaScena();
        }
        private void IncarcaScena()
        {
            switch (pasPoveste)
            {
                case 0: // Valentine
                    pbFundal.Image = Properties.Resources.valentine;
                    pbCaracter.Visible = false;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Am strabatut vestul salbatic ani intregi fara niciun scop.";
                    break;

                case 1:
                    lblNume.Text = "Protagonist";
                    lblText.Text = "E timpul sa gasesc acel scop, sa fac parte dintr-o familie.";
                    break;

                case 2: // Unchiul Dutch (Afiș)
                    pbFundal.Image = Properties.Resources.unchiu_dutch;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Hmm... Am auzit de acest gang. Sper ca ma vor accepta. O sa ma plimb prin zona pana ii gasesc.";
                    break;

                case 3: // Intrarea în tabără
                    pbFundal.Image = Properties.Resources.intrare;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Dupa o ora de cautare, in sfarsit am ajuns aici.";
                    break;

                case 4: // Apare Bill
                    // Fundalul ramane intrarea, dar îl afișăm pe Bill
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hei! Cine esti si ce cauti aici?";
                    break;
                case 5:
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1; // Imaginea cu Bill
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Salut, sunt nou in oras. Am auzit de gangul vostru si as vrea sa ma alatur.";
                    break;
                case 6: 
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hmm... Nu stiu daca Dutch te va accepta. El e destul de pretentios. Hai cu mine sa vedem.";
                    break;

                case 7: // Dutch în tabără
                    pbFundal.Image = Properties.Resources.dutch;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hei Dutch, tipul acesta vrea să se alăture.";
                    break;

                case 8:
                    pbFundal.Image = Properties.Resources.dutch;
                    pbCaracter.Visible = false;
                    lblNume.Text = "Dutch";
                    lblText.Text = "Interesant...Noi nu acceptam pe oricine in comunitatea noastra. Va trebui sa dovedesti ca meriti sa te alaturi.";
                    break;
                case 9:
                    pbFundal.Image = Properties.Resources.harta;
                    pbCaracter.Visible = false;
                    lblNume.Text = "Arthur";
                    lblText.Text = "Harta ne arată unde să căutăm următoarea țintă.";
                    break;

                default: // Etapa următoare (Placeholder)
                    pbCaracter.Visible = false;
                    lblNume.Text = "Sistem";
                    lblText.Text = ">> ACESTA ESTE UN PLACEHOLDER. AICI VOR APĂREA DECIZIILE. <<";
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Salvăm valoarea variabilei pasPoveste într-un fișier numit "salvare.txt"
                // Acest fișier se va crea singur în folderul unde rulează jocul (.exe)
                System.IO.File.WriteAllText("salvare.txt", pasPoveste.ToString());

                MessageBox.Show("Jocul a fost salvat cu succes!", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvarea jocului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
