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

        private string piesaCurenta = ""; // Ține minte ce piesă rulează acum
        public FormNewGame()
        {
            InitializeComponent();
            panelDialog1.BackColor = Color.FromArgb(80, Color.LightGray);
            lbText.AutoSize = true;
            lbText.MaximumSize = new Size(panelDialog1.Width - 20, 0);
        }
        
        private void IncarcaScena()
        {
            urmatorulPas = pasPoveste + 1;
            string caleMelodie = "";
            switch (pasPoveste)
            {
                case 0: // Valentine
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.valentine;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Am strabatut vestul salbatic ani intregi fara niciun scop.";
                    break;

                case 1:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.valentine;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "E timpul sa gasesc acel scop, sa fac parte dintr-o familie.";
                    break;

                case 2: // Unchiul Dutch (Afiș)
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 3 Valentine.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.unchiu_dutch;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Hmm... Am auzit de acest gang. Sper ca ma vor accepta. O sa ma plimb prin zona pana ii gasesc.";
                    break;

                case 3: // Intrarea în tabără
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Dupa o ora de cautare, in sfarsit am ajuns aici.";
                    break;

                case 4: // Apare Bill
                    // Fundalul ramane intrarea, dar îl afișăm pe Bill
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Bill1;
                    lbNume.Text = "Bill";
                    lbText.Text = "Hei! Cine esti si ce cauti aici?";

                //    Image img = Properties.Resources.Bill1;
                //    img.RotateFlip(RotateFlipType.RotateNoneFlipX);   (pentru rotatia imaginilor)
                //    pbCaracter1.Image = img;

                    break;

                case 5:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Bill1; // Imaginea cu Bill
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Salut, sunt nou in oras. Am auzit de gangul vostru si as vrea sa ma alatur.";
                    break;

                case 6:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Bill1;
                    lbNume.Text = "Bill";
                    lbText.Text = "Hmm... Nu stiu daca Dutch te va accepta. El e destul de pretentios. Hai cu mine sa vedem.";
                    break;

                case 7: // Dutch în tabără
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Bill1;
                    lbNume.Text = "Bill";
                    lbText.Text = "Hei Dutch, tipul acesta vrea să se alăture.";
                    break;

                case 8:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Interesant...Noi nu acceptam pe oricine in comunitatea noastra. Va trebui sa dovedesti ca meriti sa te alaturi.";
                    break;
                case 9: // Valentine
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Arthur, vino aici o secunda!";
                    break;
                case 10: // Valentine
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Domnul acesta vrea sa faca parte din gangul nostru. Trebuie sa ne asiguram ca este de incredere.";
                    break;
                case 11: // Valentine
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Bine Dutch, o fac pentru tine.";
                    break;
                case 12: // Valentine
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Ok durule, sa vedem de ce esti in stare.";
                    break;
                case 13:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;                  
                    Image img = Properties.Resources.ARTHURo;
                    img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pbCaracter1.Image = img;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Cu ce vrei sa incepi pentru a ajuta gangul?";

                    // 1. Oprim progresia automată a poveștii
                    asteaptaAlegere = true;

                    // 2. Configurăm Butonul 1 (Vanatoare)
                    btnAlegere11.Visible = true;
                    btnAlegere11.Text = "Merg la vanatoare.";
                    tintaAlegere1 = 14; // Butonul ne va trimite pe Ramura 1

                    // 3. Configurăm Butonul 2 (Jefuiesc oamenii din Valentine)
                    btnAlegere22.Visible = true;
                    btnAlegere22.Text = "Jefuiesc oamenii din Valentine";
                    tintaAlegere2 = 35; // Butonul ne va trimite pe Ramura 2

                    break; // OBLIGATORIU: Împiedică executarea codului din case 11

                // --- RAMURA 1 (mergem la vanatoare) ---
                case 14:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Vreau sa mergem la vanatoare";
                    break;

                case 15:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The Heartlands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Bine, sa vedem ce prinzi.";
                    break;

                case 16:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.harta;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Arthur_Horse1;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ne plimbam prin Heartlands pana gasim niste animale.";
                    break;
                case 17:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.vanatoare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Arthur_Horse1;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Zona asta pare buna. Uite! Caprioare si iepuri.";
                    break;
                case 18:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.vanatoare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Arthur_Horse1;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Ce vrei sa prindem?";
                    // 1. Oprim progresia automată a poveștii
                    asteaptaAlegere = true;
                    // 2. Configurăm Butonul 1 (Caprioare)
                    btnAlegere11.Visible = true;
                    btnAlegere11.Text = "Caprioare.";
                    tintaAlegere1 = 19; // Butonul ne va trimite pe Ramura 1.1
                    // 3. Configurăm Butonul 2 (Iepuri)
                    btnAlegere22.Visible = true;
                    btnAlegere22.Text = "Iepuri";
                    tintaAlegere2 = 27; // Butonul ne va trimite pe Ramura 1.2
                    break;
                case 19:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.caprioara;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Arthur_Horse3;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ne furisam prin iarba si tragem cu arcul.";
                    break;
                case 20:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.caprioaram;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Am prins una.";
                    break;
                case 21:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ce facem cu caprioarele?";
                    break;
                case 22:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Le aducem la caruta cu mancare pentru a hrani restul gangului.";
                    break;
                case 23:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Vino cu mine.";
                    break;
                case 24:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.ARTHURo;
                    Image imgg = Properties.Resources.ARTHURo;
                    imgg.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pbCaracter1.Image = imgg;

                    lbNume.Text = "Arthur";
                    lbText.Text = "Buna domnule Pearson. Uite ce am adus pentru tocanita.";
                    break;
                case 25:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Pearson";
                    lbText.Text = "Multumesc baieti, o sa fie o tocanita fenomenala.";
                    break;
                case 26:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "sistem";
                    lbText.Text = "Aprecierea gangului a crescut cu +5";
                    apreciereGang += 5;
                    ActualizeazaHUD();
                    urmatorulPas = 56; // Setăm următorul pas la convergență
                    break;
                case 27:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.iepure;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.Arthur_Horse3;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ne furisam prin iarba si tragem cu arcul.";
                    break;
                case 28:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 10 Cumberland forest.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.iepurem;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Am prins unul.";
                    break;
                case 29:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ce facem cu iepurii?";
                    break;
                case 30:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Ii aducem la caruta cu mancare pentru a hrani restul gangului.";
                    break;
                case 31:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._1;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Vino cu mine.";
                    break;
                case 32:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.ARTHURo;
                    Image imggg = Properties.Resources.ARTHURo;
                    imggg.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pbCaracter1.Image = imggg;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Buna domnule Pearson. Uite ce am adus pentru tocanita.";
                    break;
                case 33:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Pearson";
                    lbText.Text = "Multumesc baieti. Hmm... Iepurele acesta pare ca era bolnav. Vom vomita cu totii daca il folosesc.";
                    break;
                case 34:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 ambient music 23 Cholla Springs.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.pearson1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "sistem";
                    lbText.Text = "Aprecierea gangului a scazut cu -10";
                    apreciereGang -= 10;
                    ActualizeazaHUD();
                    urmatorulPas = 56; // Setăm următorul pas la convergență
                    break;

                // --- RAMURA 2 (Vânătoare) ---
                case 35:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The HeartLands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Jefuiesc oamenii din Valentine.";
                    break;


                case 36:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Rdr2 Ambient Music 5 The HeartLands.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Ok; ai grija la oamenii legii";
                    break;

                case 37:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.valentine;
                    pbCaracter1.Visible = false;

                    lbNume.Text = "Protagonist";
                    lbText.Text = "Mă plimb prin Valentine după niște ținte ușoare.";
                    break;

                case 38:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.strada;
                    pbCaracter1.Visible = false;

                    lbNume.Text = "Protagonist";
                    lbText.Text = "Sunt pe strada principală.";
                    break;

                case 39:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.strada;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Pe cine sǎ jefuiesc?";
                    // 1. Oprim progresia automată a poveștii
                    asteaptaAlegere = true;
                    // 2. Configurăm Butonul 1 (Oameni)
                    btnAlegere11.Visible = true;
                    btnAlegere11.Text = "Oameni.";
                    tintaAlegere1 = 40; // Butonul ne va trimite pe Ramura 2.1
                    // 3. Configurăm Butonul 2 (Magazin)
                    btnAlegere22.Visible = true;
                    btnAlegere22.Text = "Magazin";
                    tintaAlegere2 = 46; // Butonul ne va trimite pe Ramura 2.2
                    break;

                case 40:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.alee;
                    pbCaracter1.Visible = false;

                    lbNume.Text = "Protagonist";
                    lbText.Text = "DA-MI TOTI BANI PE CARE II AI!";
                    break;

                case 41:

                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);

                    pbFundal1.Image = Properties.Resources.intrare;
                    pbCaracter1.Visible = false;

                    lbNume.Text = "Protagonist";
                    lbText.Text = "Sper sǎ le placa cât am adus";
                    break;
                case 42:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.cutie;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Am adus banii inapoi la tabara.";
                    break;
                case 43:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2752;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Buna treaba! Nu-i mult dar e un inceput.";
                    break;
                case 44:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2752;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Este o suma modesta dar este nevoie de mult mai mult de atat.";
                    break;
                case 45:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "sistem";
                    lbText.Text = "Aprecierea gangului a crescut cu +10";
                    apreciereGang += 10;
                    ActualizeazaHUD();
                    urmatorulPas = 56; // Setăm următorul pas la convergență
                    break;

                case 46:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.magazin_v;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Jefuiesc magazinul.";
                    break;
                case 47:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.vanzator1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "DESCHIDE CASA DE MARCAT!";
                    break;
                case 48:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.vanzator1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Vanzator";
                    lbText.Text = "HA, crezi ca m-am nascut ieri? Am vazut balega de cal mai infricosatoare decat tine.";
                    break;
                case 49:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.vanzator1;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Vanzator";
                    lbText.Text = "Mars de aici pana nu chem autoritatile";
                    break;
                case 50:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.npc;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Strain";
                    lbText.Text = "Hei, tipul acela a incercat sa jefuiasca magazinul!";
                    break;
                case 51:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.serif;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Serif";
                    lbText.Text = "Tu, opreste-te acolo!";
                    break;
                case 52:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.serif;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Ăăăă...nu.Pa!";
                    break;
                case 53:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Protagonist";
                    lbText.Text = "Abia am reusit sa scap dar cu mana goala.";
                    break;
                case 54:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources._5;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Ai creat probleme si ai venit si cu mana goala.Slabut!";
                    break;
                case 55:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Paying A Social Call.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.ft;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "sistem";
                    lbText.Text = "Aprecierea gangului a scazut cu -20";
                    apreciereGang -= 20;
                    ActualizeazaHUD();
                    urmatorulPas = 56; // Setăm următorul pas la convergență
                    break;
                // CONVERGENȚA (Unde ramurile se întâlnesc din nou) 
                case 56:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Ne-am consultat cu toții și am luat o decizie în privința ta...";
                    if (apreciereGang >= 0)
                    {
                        urmatorulPas = 57; // Ramura: GOOD ENDING
                    }
                    else
                    {
                        urmatorulPas = 59; // Ramura: BAD ENDING
                    }
                    break;
                    
                case 57:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Ai dovedit că ești loial și ai potențial. De azi ești unul de-ai noștri.";
                    break;
                case 58:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Pregătește-te, avem un jaf mare planificat pentru mâine dimineață!";
                    urmatorulPas = 61;
                    break;
                case 59:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Dutch";
                    lbText.Text = "Ne-ai adus doar probleme. Nu avem nevoie de alti bezmetici în tabără.";
                    break;
                case 60:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.dutch;
                    pbCaracter1.Visible = true;
                    pbCaracter1.Image = Properties.Resources.IMG_2747;
                    lbNume.Text = "Arthur";
                    lbText.Text = "Ia-ți calul și dispari. Dacă te mai prindem prin preajmă, te împușcăm pe loc!";
                    urmatorulPas = 61;
                    break;
                case 61:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbFundal1.Image = Properties.Resources.rdr2_gangul;
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Sistem";
                    lbText.Text = "Thank you for playing.";

                    break;

                default:
                    caleMelodie = Path.Combine(Application.StartupPath, "Audio", "Red Dead Redemption 2 Official Soundtrack - Eastward Bound.mp3");
                    SchimbaMuzica(caleMelodie);
                    pbCaracter1.Visible = false;
                    lbNume.Text = "Sistem";
                    lbText.Text = ">> Ai ajuns la final sau ceva nu a mers bine. Poti inchide jocul<<";
                    break;
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

        private void btnLoad1_Click_1(object sender, EventArgs e)
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
                pasPoveste = urmatorulPas;
                IncarcaScena();
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
            IncarcaScena();
        }

        private void btnAlegere11_Click_1(object sender, EventArgs e)
        {
            pasPoveste = tintaAlegere1;

            btnAlegere11.Visible = false;
            btnAlegere22.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void btnAlegere22_Click_1(object sender, EventArgs e)
        {
            pasPoveste = tintaAlegere2;

            btnAlegere11.Visible = false;
            btnAlegere22.Visible = false;
            asteaptaAlegere = false;

            IncarcaScena();
        }

        private void pbCaracter1_Click(object sender, EventArgs e)
        {

        }
    }
}
