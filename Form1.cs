using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDR2_Visual_Novel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.stretchToFit = true;
            this.AutoScaleMode = AutoScaleMode.None;
            axWindowsMediaPlayer1.Left = 0;
            axWindowsMediaPlayer1.Top = 500; 
            axWindowsMediaPlayer1.Width = this.ClientSize.Width;
            axWindowsMediaPlayer1.Height = 244;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Width = this.ClientSize.Width;
            // 1. Ascundem butoanele de play/pauză și bara de progres (să arate ca un element grafic pur)
            axWindowsMediaPlayer1.uiMode = "none";

            // 2. Tăiem sunetul videoului (ca să poți pune melodia ta de meniu separat)
            axWindowsMediaPlayer1.settings.mute = true;

            // 3. Setăm videoul să se repete la infinit (loop)
            axWindowsMediaPlayer1.settings.setMode("loop", true);

            // 4. Îi spunem ce video să ruleze (pune calea TA exactă între ghilimele)
            // ATENȚIE: Lasă simbolul @ în fața ghilimelelor, este necesar pentru căile din Windows!
            axWindowsMediaPlayer1.URL = @"D:\cursuri si lectii\POO\Visual Novel\meniu.mp4";

        }
        public void SetVolume(int volume)
        {
            axWindowsMediaPlayer1.settings.volume = volume;
        }
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
           
        }

        private void btnNG_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();

            // Creează și deschide instanța unicului Form de joc
            FormNewGame joculMeu = new FormNewGame();

            // Ascunde meniul principal
            this.Hide();

            // Arată jocul și așteaptă până când acesta este închis
            joculMeu.ShowDialog();

            // Când jucătorul iese din joc și se întoarce, reafișăm meniul
            this.Show();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            // 1. Verificăm dacă există fizic fișierul de salvare pe calculator
            if (System.IO.File.Exists("salvare.txt"))
            {
                try
                {
                    // 2. Citim numărul salvat în fișier
                    string textSalvat = System.IO.File.ReadAllText("salvare.txt");
                    int pasSalvat = int.Parse(textSalvat);

                    // 3. Creăm o instanță nouă pentru fereastra de joc
                    FormNewGame joculMeu = new FormNewGame();

                    // 4. Îi injectăm pasul salvat ÎNAINTE ca fereastra să se încarce pe ecran!
                    joculMeu.pasPoveste = pasSalvat;

                    // 5. Oprim muzica meniului și ascundem meniul principal
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    this.Hide();

                    // 6. Deschidem jocul. Când se va încărca, va vedea noul pas și va sări direct la el
                    joculMeu.ShowDialog();

                    // 7. Când jucătorul va închide jocul și va reveni în meniu, reafișăm meniul principal
                    this.Show();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fișierul de salvare este corupt sau nu poate fi citit: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Dacă fișierul nu există (jocul nu a fost salvat niciodată)
                MessageBox.Show("Nu există nicio salvare anterioară! Apasă pe 'New Game' pentru a începe o poveste nouă.", "Fără Salvare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
