using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RDR2_Visual_Novel.Modele;
using System.Text.Json;

namespace RDR2_Visual_Novel
{
    public partial class FormNewGame : Form
    {
        //public int pasPoveste = 0;
        public int apreciereGang = 0;

        //private int urmatorulPas = 0;
        private bool asteaptaAlegere = false;
        // Aceste variabile vor stoca ce face fiecare buton în funcție de scena curentă
        //private int tintaAlegere1 = 0;
        //private int tintaAlegere2 = 0;

        private string piesaCurenta = ""; // Ține minte ce piesă rulează acum

        private Dictionary<string, BlocPoveste> poveste = new Dictionary<string, BlocPoveste>();

        // Reține ID-ul blocului în care se află jucătorul acum (în loc de pasPoveste)
        public string blocCurentId = "0";
        public FormNewGame()
        {
            InitializeComponent();
            panelDialog1.BackColor = Color.FromArgb(80, Color.LightGray);
            lbText.AutoSize = true;
            lbText.MaximumSize = new Size(panelDialog1.Width - 20, 0);
        }
        private void IncarcaScena()
        {
            // 1. Extragem blocul curent din dicționar folosind ID-ul
            if (poveste.ContainsKey(blocCurentId))
            {
                BlocPoveste bloc = poveste[blocCurentId];

                // 2. Afișăm textul pe ecran
                lbText.Text = bloc.Text;
                lbNume.Text = bloc.NumePersonaj;
                if (!string.IsNullOrEmpty(bloc.MelodieFundal))
                {
                    // Construim calea completă către folderul Audio, folosind numele din JSON
                    string caleMelodie = Path.Combine(Application.StartupPath, "Audio", bloc.MelodieFundal);
                    SchimbaMuzica(caleMelodie);
                }

                //Trucul pentru a încărca imaginea direct din Resurse folosind un text!
                if (!string.IsNullOrEmpty(bloc.ImagineFundal))
                {
                    // Caută în Resurse un fișier cu exact același nume ca textul din bloc.ImagineFundal
                    object poza = Properties.Resources.ResourceManager.GetObject(bloc.ImagineFundal);
                    if (poza != null)
                    {
                        pbFundal1.Image = (Image)poza;
                    }
                }
                if (!string.IsNullOrEmpty(bloc.ImaginePersonaj))
                {
                    // Căutăm imaginea personajului în Resurse
                    object pozaPersonaj = Properties.Resources.ResourceManager.GetObject(bloc.ImaginePersonaj);
                    if (pozaPersonaj != null)
                    {
                        Image imgPersonaj = (Image)pozaPersonaj;

                        // Dacă am setat în date că vrem să-l rotim, o facem aici!
                        if (bloc.RotestePersonaj)
                        {
                            imgPersonaj.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        }

                        pbCaracter1.Image = imgPersonaj;
                        pbCaracter1.Visible = true; // Afișăm personajul
                    }
                    else
                    {
                        pbCaracter1.Visible = false;
                    }
                }
                else
                {
                    // Dacă blocul nu are niciun personaj setat (ex. e doar un peisaj), ascundem personajul vechi
                    pbCaracter1.Visible = false;
                }

                // 3. Verificăm dacă avem alegeri (mai mult de 1 decizie)
                if (bloc.Decizii.Count > 1)
                {
                    asteaptaAlegere = true;

                    // Verificăm condiția matematică pentru Butonul 1
                    if (apreciereGang >= bloc.Decizii[0].ConditieMinima && apreciereGang <= bloc.Decizii[0].ConditieMaxima)
                    {
                        btnAlegere11.Visible = true;
                        btnAlegere11.Text = bloc.Decizii[0].Text;
                    }
                    else { btnAlegere11.Visible = false; }

                    // Verificăm condiția matematică pentru Butonul 2
                    if (apreciereGang >= bloc.Decizii[1].ConditieMinima && apreciereGang <= bloc.Decizii[1].ConditieMaxima)
                    {
                        btnAlegere22.Visible = true;
                        btnAlegere22.Text = bloc.Decizii[1].Text;
                    }
                    else { btnAlegere22.Visible = false; }
                }
                else
                {
                    asteaptaAlegere = false;
                    btnAlegere11.Visible = false;
                    btnAlegere22.Visible = false;
                }
            }
            else
            {
                lbText.Text = "Eroare: Blocul cu ID-ul " + blocCurentId + " nu există în poveste!";
            }
        }

        private void SchimbaMuzica(string calePiesa)
        {
            // Verificăm dacă piesa cerută este DIFERITĂ de cea care cântă deja
            if (piesaCurenta != calePiesa)
            {
                piesaCurenta = calePiesa; // Actualizăm piesa curentă
                axMuzica1.URL = calePiesa; // Încărcăm fișierul MP3
                axMuzica1.settings.setMode("loop", true); // O setăm să cânte în buclă
                axMuzica1.Ctlcontrols.play(); // Pornim melodia
            }
        }
        
        private void ActualizeazaHUD()
        {
            // Actualizează textul label-ului cu valoarea curentă
            lbApreciere.Text = "Apreciere Gang: " + apreciereGang.ToString();
        }

        private void btnSave1_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                string dateDeSalvat = blocCurentId + Environment.NewLine + apreciereGang.ToString();
                System.IO.File.WriteAllText("salvare.txt", dateDeSalvat);

                MessageBox.Show("Jocul a fost salvat cu succes!", "Salvare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvarea jocului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad1_Click_1(object sender, EventArgs e)
        {
            // Verificăm dacă fișierul de salvare există
            if (System.IO.File.Exists("salvare.txt"))
            {
                try
                {
                    string[] liniiSalvate = System.IO.File.ReadAllLines("salvare.txt");

                    blocCurentId = liniiSalvate[0]; // Acum e string, nu mai are nevoie de int.Parse!
                    apreciereGang = int.Parse(liniiSalvate[1]);
                    ActualizeazaHUD();
                    // ESTENȚIAL: Resetăm starea deciziilor. 
                    // Dacă jucătorul apasă Load fix când e la o alegere, trebuie să ascundem butoanele 
                    // înainte să încărcăm scena salvată (care poate fi o scenă normală de text).
                    asteaptaAlegere = false;
                    btnAlegere11.Visible = false;
                    btnAlegere22.Visible = false;

                    piesaCurenta = ""; // Îi resetăm memoria
                    axMuzica1.Ctlcontrols.stop(); // Oprim piesa veche ca să reînceapă de la 0
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

        private void btnExit1_Click_1(object sender, EventArgs e)
        {
            axMuzica1.Ctlcontrols.stop();
            Close();
        }

        private void pbFundal1_Click_1(object sender, EventArgs e)
        {
            if (!asteaptaAlegere)
            {
                // Verificăm dacă suntem la un bloc liniar (1 singură decizie "ascunsă")
                if (poveste.ContainsKey(blocCurentId) && poveste[blocCurentId].Decizii.Count == 1)
                {
                    // FIX: Aplicăm aprecierea și la click-ul pe fundal!
                    apreciereGang += poveste[blocCurentId].Decizii[0].EfectApreciere;
                    ActualizeazaHUD();

                    // Trecem la pasul următor
                    blocCurentId = poveste[blocCurentId].Decizii[0].TargetBlock;
                    IncarcaScena();
                }
            }
        }

        private void FormNewGame_Load_1(object sender, EventArgs e)
        {
            pbCaracter1.Parent = pbFundal1;
            panelDialog1.Parent = pbFundal1;
            panelDialog1.BringToFront();

            // Adaugă aceste două linii pentru HUD:
            lbApreciere.Parent = pbFundal1;
            ActualizeazaHUD();

            pbCaracter1.Visible = false;
            IncarcaPovesteDinJSON();
            IncarcaScena();
        }

        private void btnAlegere11_Click_1(object sender, EventArgs e)
        {
            // 1. Aplicăm efectul deciziei asupra aprecierii
            apreciereGang += poveste[blocCurentId].Decizii[0].EfectApreciere;
            ActualizeazaHUD(); // Actualizăm direct pe ecran

            // 2. Trecem la blocul următor
            blocCurentId = poveste[blocCurentId].Decizii[0].TargetBlock;

            btnAlegere11.Visible = false;
            btnAlegere22.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void btnAlegere22_Click_1(object sender, EventArgs e)
        {
            // Aici luăm efectul de la decizia 2 (index 1)
            apreciereGang += poveste[blocCurentId].Decizii[1].EfectApreciere;
            ActualizeazaHUD();

            blocCurentId = poveste[blocCurentId].Decizii[1].TargetBlock;

            btnAlegere11.Visible = false;
            btnAlegere22.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void pbCaracter1_Click(object sender, EventArgs e)
        {

        }
        
        private void IncarcaPovesteDinJSON()
        {
            // 1. Căutăm fișierul JSON lângă executabilul jocului
            string caleJSON = Path.Combine(Application.StartupPath, "story.json");

            if (File.Exists(caleJSON))
            {
                // 2. Citim tot textul din fișier
                string textJSON = File.ReadAllText(caleJSON);

                // 3. Transformăm automat JSON-ul în obiecte C#
                PovesteData dateIncarcate = JsonSerializer.Deserialize<PovesteData>(textJSON);

                // 4. Golim dicționarul și îl umplem cu noile blocuri din fișier
                poveste.Clear();
                foreach (BlocPoveste bloc in dateIncarcate.blocks)
                {
                    poveste.Add(bloc.Id, bloc);
                }
            }
            else
            {
                MessageBox.Show("Fișierul story.json lipsește!", "Eroare Critică", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Închidem dacă nu avem poveste
            }
        }
    }
}

