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
        private int pasPoveste = 0;
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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings fereastraSetari = new FormSettings();

            // ShowDialog oprește timpul în FormNewGame. 
            // Jocul așteaptă aici până când jucătorul apasă "Back" / "X" în Setări.
            fereastraSetari.ShowDialog();

            // Imediat ce setările se închid, codul continuă de aici automat!
            // Aici vom putea aplica noile setări (ex. să dăm muzica mai încet),
            // iar jucătorul va fi fix la replica la care rămăsese.
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
                    lblNume.Text = "Arthur";
                    lblText.Text = "Valentine... un oraș de noroi, oi și probleme.";
                    break;

                case 1:
                    lblNume.Text = "Arthur";
                    lblText.Text = "Dar e un loc bun să faci niște bani pentru tabără.";
                    break;

                case 2: // Unchiul Dutch (Afiș)
                    pbFundal.Image = Properties.Resources.unchiu_dutch;
                    lblNume.Text = "Arthur";
                    lblText.Text = "Dutch are întotdeauna un plan... sper doar să funcționeze de data asta.";
                    break;

                case 3: // Intrarea în tabără
                    pbFundal.Image = Properties.Resources.intrare;
                    lblNume.Text = "Arthur";
                    lblText.Text = "În sfârșit, m-am întors la Horseshoe Overlook.";
                    break;

                case 4: // Apare Bill
                    // Fundalul ramane intrarea, dar îl afișăm pe Bill
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hei, englezule! Pe unde ai umblat?";
                    break;

                case 5: // Dutch în tabără
                    pbFundal.Image = Properties.Resources.dutch;
                    pbCaracter.Visible = false; // Îl ascundem pe Bill un moment
                    lblNume.Text = "Dutch";
                    lblText.Text = "Arthur, fiule! Avem nevoie de zgomot și de niște credite!";
                    break;

                case 6: // Apare Arthur răspundând
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.IMG_2747; // Imaginea cu Arthur
                    lblNume.Text = "Arthur";
                    lblText.Text = "Sigur, Dutch. Dar ne cam calcă legea pe coadă.";
                    break;

                default: // Etapa următoare (Placeholder)
                    pbCaracter.Visible = false;
                    lblNume.Text = "Sistem";
                    lblText.Text = ">> ACESTA ESTE UN PLACEHOLDER. AICI VOR APĂREA DECIZIILE. <<";
                    break;
            }
        }
    }
}
