using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            axWindowsMediaPlayer1.URL = Path.Combine(Application.StartupPath, "Video", "meniu.mp4");
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
            if (System.IO.File.Exists("salvare.txt"))
            {
                try
                {
                    // Folosim ReadAllLines pentru a citi fișierul rând cu rând într-o listă (array)
                    string[] liniiSalvate = System.IO.File.ReadAllLines("salvare.txt");

                    // Extragem datele: prima linie [0] e ID-ul (text), a doua e aprecierea (număr)
                    string pasSalvat = liniiSalvate[0];
                    int apreciereSalvata = int.Parse(liniiSalvate[1]);

                    FormNewGame joculMeu = new FormNewGame();

                    // Injectăm datele în noul sistem
                    joculMeu.blocCurentId = pasSalvat;
                    joculMeu.apreciereGang = apreciereSalvata;

                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    this.Hide();


                    joculMeu.ShowDialog();

                    this.Show();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fișierul de salvare este corupt sau formatul este greșit: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nu există nicio salvare anterioară!", "Fără Salvare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
