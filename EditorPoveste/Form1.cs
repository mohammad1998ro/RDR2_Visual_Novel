using RDR2_Visual_Novel.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorPoveste
{
    public partial class Form1 : Form
    {
        private PovesteData povesteCurenta = new PovesteData();
        public Form1()
        {
            InitializeComponent();
            povesteCurenta.blocks = new List<BlocPoveste>();
        }

        private void btnIncarcaJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JSON Files|*.json";
            ofd.Title = "Alege fișierul story.json din joc";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Citim fișierul și îl transformăm în obiecte
                string textJson = File.ReadAllText(ofd.FileName);
                povesteCurenta = JsonSerializer.Deserialize<PovesteData>(textJson);

                ActualizeazaListaDinStanga();
                MessageBox.Show("Povestea a fost încărcată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // --- FUNCȚIE AJUTĂTOARE PENTRU REÎMPROSPĂTAREA LISTEI ---
        private void ActualizeazaListaDinStanga()
        {
            tvBlocuri.Nodes.Clear(); // Curățăm lista

            foreach (BlocPoveste bloc in povesteCurenta.blocks)
            {
                // Creăm un nod în listă (ex: "10 - Dutch")
                TreeNode nod = new TreeNode(bloc.Id + " - " + bloc.NumePersonaj);
                nod.Tag = bloc; // Ascundem tot obiectul de poveste "în spatele" textului din listă
                tvBlocuri.Nodes.Add(nod);
            }
        }

        private void btnAdaugaBloc_Click(object sender, EventArgs e)
        {
            BlocPoveste blocNou = new BlocPoveste();
            blocNou.Id = "ID_Nou";
            blocNou.NumePersonaj = "Personaj Nou";
            blocNou.Text = "Scrie povestea aici...";

            povesteCurenta.blocks.Add(blocNou);
            ActualizeazaListaDinStanga();
        }

        private void btnSalveazaBloc_Click(object sender, EventArgs e)
        {
            if (tvBlocuri.SelectedNode != null)
            {
                BlocPoveste blocSelectat = (BlocPoveste)tvBlocuri.SelectedNode.Tag;

                // Luăm textele scrise de tine și le băgăm înapoi în obiect
                blocSelectat.Id = txtIdBloc.Text;
                blocSelectat.NumePersonaj = txtPersonaj.Text;
                blocSelectat.ImagineFundal = txtImagineFundal.Text;
                blocSelectat.Text = txtPoveste.Text;

                ActualizeazaListaDinStanga(); // Reîmprospătăm ca să se vadă noul ID în listă
                MessageBox.Show("Blocul a fost modificat în memorie.\nNu uita să exporți JSON-ul la final!", "Salvat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportaJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JSON Files|*.json";
            sfd.FileName = "story.json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Setăm opțiunile ca JSON-ul să fie "aratos" (pe mai multe rânduri)
                var optiuni = new JsonSerializerOptions { WriteIndented = true };

                // Transformăm obiectele înapoi în text JSON
                string jsonFinal = JsonSerializer.Serialize(povesteCurenta, optiuni);

                // Salvăm fișierul
                File.WriteAllText(sfd.FileName, jsonFinal);
                MessageBox.Show("Povestea a fost exportată cu succes!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tvBlocuri_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvBlocuri.SelectedNode != null)
            {
                // Scoatem obiectul ascuns
                BlocPoveste blocSelectat = (BlocPoveste)tvBlocuri.SelectedNode.Tag;

                // Umplem căsuțele din dreapta cu datele lui
                txtIdBloc.Text = blocSelectat.Id;
                txtPersonaj.Text = blocSelectat.NumePersonaj;
                txtImagineFundal.Text = blocSelectat.ImagineFundal;
                txtPoveste.Text = blocSelectat.Text;
            }
        }
    }
}
