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
        public int apreciereGang = 50;

        private int urmatorulPas = 0;
        private bool asteaptaAlegere = false;

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
            if (!asteaptaAlegere)
            {
                pasPoveste = urmatorulPas; // Folosim noua variabilă în loc de pasPoveste++
                IncarcaScena();
            }
        }
        private void IncarcaScena()
        {
            urmatorulPas = pasPoveste + 1;

            switch (pasPoveste)
            {
                case 0: // Valentine
                    SchimbaMuzica(@"D:\cursuri si lectii\POO\Visual Novel\melodii\Rdr2 Ambient Music 3 Valentine.mp3.mpeg");
                    pbFundal.Image = Properties.Resources.valentine;
                    pbCaracter.Visible = false;
                    lblNume.Text = "Protagonist";
                    lblText.Text = "Am strabatut vestul salbatic ani intregi fara niciun scop.";
                    break;

                case 1:
                    SchimbaMuzica(@"D:\cursuri si lectii\POO\Visual Novel\melodii\Rdr2 Ambient Music 3 Valentine.mp3.mpeg");
                    lblNume.Text = "Protagonist";
                    lblText.Text = "E timpul sa gasesc acel scop, sa fac parte dintr-o familie.";
                    break;

                case 2: // Unchiul Dutch (Afiș)
                    SchimbaMuzica(@"D:\cursuri si lectii\POO\Visual Novel\melodii\Rdr2 Ambient Music 3 Valentine.mp3.mpeg");
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

                //    Image img = Properties.Resources.Bill1;
                //    img.RotateFlip(RotateFlipType.RotateNoneFlipX);   (pentru rotatia imaginilor)
                //    pbCaracter.Image = img;

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

                case 10: // Momentul alegerii
                    pbFundal.Image = Properties.Resources.harta; // Pune o imagine potrivită
                    pbCaracter.Visible = true;
                    pbCaracter.Image = Properties.Resources.ARTHURo; 
                    lblNume.Text = "Dutch";
                    lblText.Text = "Arthur, avem nevoie de bani. Jefuim trenul sau mergem la vânătoare?";

                        Image img = Properties.Resources.ARTHURo;
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);   //(pentru rotatia imaginilor)
                        pbCaracter.Image = img;

                    // Oprim povestea și afișăm alegerile
                    asteaptaAlegere = true;
                    btnAlegere1.Visible = true;
                    btnAlegere1.Text = "Jefuim trenul (Riscant)";
                    btnAlegere2.Visible = true;
                    btnAlegere2.Text = "Mergem la vânătoare (Sigur)";
                    break;

                // --- RAMURA 1 (Jefuim trenul) ---
                case 11:
                    lblNume.Text = "Arthur";
                    lblText.Text = "Bine, Dutch. Ne mascăm și oprim trenul.";
                    break;
                case 12:
                    lblText.Text = "A fost o luptă grea, dar ne-am întors cu buzunarele pline.";
                    break;
                case 13:
                    lblText.Text = "Membrii taberei sunt fericiți de pradă.";
                    // AICI E SECRETUL: Nu vrem să trecem la 14! Sărim la convergență (17)
                    urmatorulPas = 17;
                    break;

                // --- RAMURA 2 (Vânătoare) ---
                case 14:
                    lblNume.Text = "Arthur";
                    lblText.Text = "Să nu atragem atenția. Voi prinde niște căprioare.";
                    break;
                case 15:
                    lblText.Text = "Am adus mâncare, dar Dutch pare dezamăgit de lipsa de acțiune.";
                    break;
                case 16:
                    lblText.Text = "Măcar nu am fost împușcați astăzi...";
                    // Merge natural la 27, nu trebuie să setăm urmatorulPas
                    break;

                // --- CONVERGENȚA ---
                case 17:
                    lblNume.Text = "Sistem";
                    lblText.Text = $"Povestea se unește. Aprecierea actuală a gang-ului este: {apreciereGang}";
                    break;

                default: // Etapa următoare (Placeholder)
                    pbCaracter.Visible = false;
                    lblNume.Text = "Sistem";
                    lblText.Text = ">> ACESTA ESTE UN PLACEHOLDER. AICI VOR APĂREA DECIZIILE. <<";
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

        private void btnAlegere1_Click(object sender, EventArgs e)
        {
            apreciereGang += 10; // Creștem aprecierea
            pasPoveste = 11;     // Sărim pe ramura 1

            // Ascundem butoanele și deblocăm click-ul pe fundal
            btnAlegere1.Visible = false;
            btnAlegere2.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena(); // Încărcăm noua scenă
        }

        private void btnAlegere2_Click(object sender, EventArgs e)
        {
            apreciereGang -= 10; // Scădem aprecierea (gang-ul e dezamăgit)
            pasPoveste = 14;     // Sărim pe ramura 2

            btnAlegere1.Visible = false;
            btnAlegere2.Visible = false;
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

                    // ESTENȚIAL: Resetăm starea deciziilor. 
                    // Dacă jucătorul apasă Load fix când e la o alegere, trebuie să ascundem butoanele 
                    // înainte să încărcăm scena salvată (care poate fi o scenă normală de text).
                    asteaptaAlegere = false;
                    btnAlegere1.Visible = false;
                    btnAlegere2.Visible = false;

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
    }
}
