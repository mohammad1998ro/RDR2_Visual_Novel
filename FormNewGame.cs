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
using System.IO;

namespace RDR2_Visual_Novel
{
    public partial class FormNewGame : Form
    {
        public int pasPoveste = 0;
        public int apreciereGang = 0;

        private int urmatorulPas = 0;
        private bool asteaptaAlegere = false;
        // Aceste variabile vor stoca ce face fiecare buton în funcție de scena curentă
        private int tintaAlegere1 = 0;
        private int tintaAlegere2 = 0;
        private int tintaAlegere3 = 0;

        private string piesaCurenta = ""; // Ține minte ce piesă rulează acum
        public FormNewGame()
        {
            InitializeComponent();
            panelDialog.BackColor = Color.FromArgb(80, Color.LightGray);
            lblText.AutoSize = true;
            lblText.MaximumSize = new Size(panelDialog.Width - 20, 0);
        }

        private void FormNewGame_Load(object sender, EventArgs e)
        {
            pbCaracter.Parent = pbFundal;
            panelDialog.Parent = pbFundal;
            panelDialog.BringToFront();

            // Adaugă aceste două linii pentru HUD:
            lblApreciere.Parent = pbFundal;
            ActualizeazaHUD();

            pbCaracter.Visible = false;
            IncarcaScena();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            axMuzica.Ctlcontrols.stop();
            Close();
        }

        private void pbFundal_Click(object sender, EventArgs e)
        {
            if (!asteaptaAlegere)
            {
                pasPoveste = urmatorulPas; 
                IncarcaScena();
            }
        }
        private void IncarcaScena()
        {
            urmatorulPas = pasPoveste + 1;

            switch (pasPoveste)
            {
                case 0: // Valentine
                    string caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal.Image = Properties.Resources.valentine;
                    pbCaracter.Visible = false;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Am strabatut vestul salbatic ani intregi fara niciun scop.";
                    break;

                case 1:
                    string caleMelodie1 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie1);

                    pbFundal.Image = Properties.Resources.valentine;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "E timpul sa gasesc acel scop, sa fac parte dintr-o familie.";
                    break;

                case 2: // Unchiul Dutch (Afiș)
                    string caleMelodie2 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie2);

                    pbFundal.Image = Properties.Resources.unchiu_dutch;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Hmm... Am auzit de acest gang. Sper ca ma vor accepta. O sa ma plimb prin zona pana ii gasesc.";
                    break;

                case 3: // Intrarea în tabără
                    string caleMelodie3 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie3);

                    pbFundal.Image = Properties.Resources.intrare;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Dupa o ora de cautare, in sfarsit am ajuns aici.";
                    break;

                case 4: // Apare Bill
                    // Fundalul ramane intrarea, dar îl afișăm pe Bill
                    string caleMelodie4 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie4);
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hei! Cine esti si ce cauti aici?";

                //    Image img = Properties.Resources.Bill1;
                //    img.RotateFlip(RotateFlipType.RotateNoneFlipX);   (pentru rotatia imaginilor)
                //    pbCaracter.Image = img;

                    break;

                case 5:
                    string caleMelodie5 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie5);
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1; // Imaginea cu Bill
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Salut, sunt nou in oras. Am auzit de gangul vostru si as vrea sa ma alatur.";
                    break;

                case 6:
                    string caleMelodie6 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie6);
                    pbFundal.Image = Properties.Resources.intrare;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hmm... Nu stiu daca Dutch te va accepta. El e destul de pretentios. Hai cu mine sa vedem.";
                    break;

                case 7: // Dutch în tabără
                    string caleMelodie7 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie7);
                    pbFundal.Image = Properties.Resources.dutch;
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.Bill1;
                    lblNume.Text = "Bill";
                    lblText.Text = "Hei Dutch, tipul acesta vrea să se alăture.";
                    break;

                case 8:
                    string caleMelodie8 = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie8);
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

                case 10:
                    pbFundal.Image = Properties.Resources.harta;
                    pbCaracter.Visible = true;

                    Image img = Properties.Resources.ARTHURo;
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pbCaracter.Image = img;

                    lblNume.Text = "Dutch";
                    lblText.Text = "Arthur, avem nevoie de bani. Jefuim trenul sau mergem la vânătoare?";

                    // 1. Oprim progresia automată a poveștii
                    asteaptaAlegere = true;

                    // 2. Configurăm Butonul 1 (Jefuim trenul)
                    btnAlegere1.Visible = true;
                    btnAlegere1.Text = "Jefuim trenul (Riscant)";
                    tintaAlegere1 = 11; // Butonul ne va trimite pe Ramura 1

                    // 3. Configurăm Butonul 2 (Vânătoare)
                    btnAlegere2.Visible = true;
                    btnAlegere2.Text = "Mergem la vânătoare (Sigur)";
                    tintaAlegere2 = 14; // Butonul ne va trimite pe Ramura 2

                    break; // OBLIGATORIU: Împiedică executarea codului din case 11

                // ==========================================================
                // --- RAMURA 1 (Jefuim trenul) ---
                // ==========================================================
                case 11:
                    lblNume.Text = "Arthur";
                    lblText.Text = "Bine, Dutch. Ne mascăm și oprim trenul.";
                    break;

                case 12:
                    lblText.Text = "A fost o luptă grea, dar ne-am întors cu buzunarele pline.";
                    break;

                case 13: // CASE-UL SPECIAL DE CONSECINȚĂ - RAMURA 1
                         // Aplicăm decizia
                    apreciereGang += 10;
                    ActualizeazaHUD();

                    // Informăm jucătorul
                    lblNume.Text = "Sistem";
                    lblText.Text = "Tabăra este fericită de pradă. (Apreciere Gang +10)";

                    // Forțăm întoarcerea la povestea principală
                    urmatorulPas = 17;
                    break;

                // ==========================================================
                // --- RAMURA 2 (Vânătoare) ---
                // ==========================================================
                case 14:
                    lblNume.Text = "Arthur";
                    lblText.Text = "Să nu atragem atenția. Voi prinde niște căprioare.";
                    break;

                case 15:
                    lblText.Text = "Am adus mâncare, dar tabăra are nevoie disperată de bani, nu doar de carne.";
                    break;

                case 16: // CASE-UL SPECIAL DE CONSECINȚĂ - RAMURA 2
                         // Aplicăm decizia
                    apreciereGang -= 10;
                    ActualizeazaHUD();

                    // Informăm jucătorul
                    lblNume.Text = "Sistem";
                    lblText.Text = "Lui Dutch nu i-a convenit lipsa ta de curaj. (Apreciere Gang -10)";

                    // Aici nu e nevoie neapărat de urmatorulPas = 17, deoarece case 17
                    // este oricum următorul la rând, dar îl poți lăsa pentru claritate.
                    urmatorulPas = 17;
                    break;

                // ==========================================================
                // --- CONVERGENȚA (Unde ramurile se întâlnesc din nou) ---
                // ==========================================================
                case 17:
                    pbCaracter.Visible = false; // Ascundem personajul dacă nu mai e nevoie
                    lblNume.Text = "Dutch";
                    lblText.Text = "Oricum ar fi, legea e pe urmele noastre. Trebuie să ne mutăm tabăra...";
                    break;

                default:
                    pbCaracter.Visible = false;
                    lblNume.Text = "Sistem";
                    lblText.Text = ">> ACESTA ESTE UN PLACEHOLDER. JOCUL ESTE ÎN DEZVOLTARE. <<";
                    break;
            }
        }
        private void SchimbaMuzica(string calePiesa)
        {
            // Verificăm dacă piesa cerută este DIFERITĂ de cea care cântă deja
            if (piesaCurenta != calePiesa)
            {
                piesaCurenta = calePiesa; // Actualizăm piesa curentă
                axMuzica.URL = calePiesa; // Încărcăm fișierul MP3
                axMuzica.settings.setMode("loop", true); // O setăm să cânte în buclă
                axMuzica.Ctlcontrols.play(); // Pornim melodia
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Creăm un text cu mai multe rânduri. 
                // Environment.NewLine pune automat un "Enter" între ele.
                string dateDeSalvat = pasPoveste.ToString() + Environment.NewLine + apreciereGang.ToString();

                // Salvăm ambele date în fișier
                System.IO.File.WriteAllText("salvare.txt", dateDeSalvat);

                MessageBox.Show("Jocul a fost salvat cu succes!", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvarea jocului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizeazaHUD()
        {
            // Actualizează textul label-ului cu valoarea curentă
            lblApreciere.Text = "Apreciere Gang: " + apreciereGang.ToString();
        }

        private void btnAlegere1_Click(object sender, EventArgs e)
        {
            pasPoveste = tintaAlegere1;

            btnAlegere1.Visible = false;
            btnAlegere2.Visible = false;
            btnAlegere3.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void btnAlegere2_Click(object sender, EventArgs e)
        {
            pasPoveste = tintaAlegere2;

            btnAlegere1.Visible = false;
            btnAlegere2.Visible = false;
            btnAlegere3.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Verificăm dacă fișierul de salvare există
            if (System.IO.File.Exists("salvare.txt"))
            {
                try
                {
                    // Citim liniile din fișier
                    string[] liniiSalvate = System.IO.File.ReadAllLines("salvare.txt");

                    // Actualizăm variabilele jocului curent
                    pasPoveste = int.Parse(liniiSalvate[0]);
                    apreciereGang = int.Parse(liniiSalvate[1]);
                    ActualizeazaHUD();
                    // ESTENȚIAL: Resetăm starea deciziilor. 
                    // Dacă jucătorul apasă Load fix când e la o alegere, trebuie să ascundem butoanele 
                    // înainte să încărcăm scena salvată (care poate fi o scenă normală de text).
                    asteaptaAlegere = false;
                    btnAlegere1.Visible = false;
                    btnAlegere2.Visible = false;

                    piesaCurenta = ""; // Îi resetăm memoria
                    axMuzica.Ctlcontrols.stop(); // Oprim piesa veche ca să reînceapă de la 0
                    // Reîncărcăm scena folosind noul pasPoveste
                    IncarcaScena();

                    MessageBox.Show("Joc încărcat cu succes!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la citirea fișierului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nu există nicio salvare pe care să o încarci!", "Fără Salvare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAlegere3_Click(object sender, EventArgs e)
        {
            pasPoveste = tintaAlegere3;

            btnAlegere1.Visible = false;
            btnAlegere2.Visible = false;
            btnAlegere3.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }
    }
}
