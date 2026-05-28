namespace RDR2_Visual_Novel
{
    partial class FormNewGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelDialog = new System.Windows.Forms.Panel();
            this.lblNume = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.pbCaracter = new System.Windows.Forms.PictureBox();
            this.pbFundal = new System.Windows.Forms.PictureBox();
            this.panelDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaracter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFundal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Chinese Rocks Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(3, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Chinese Rocks Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSettings.Location = new System.Drawing.Point(84, 177);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Chinese Rocks Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.Location = new System.Drawing.Point(165, 177);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelDialog
            // 
            this.panelDialog.BackColor = System.Drawing.Color.LightGray;
            this.panelDialog.Controls.Add(this.lblNume);
            this.panelDialog.Controls.Add(this.lblText);
            this.panelDialog.Controls.Add(this.btnSave);
            this.panelDialog.Controls.Add(this.btnExit);
            this.panelDialog.Controls.Add(this.btnSettings);
            this.panelDialog.Location = new System.Drawing.Point(213, 810);
            this.panelDialog.Name = "panelDialog";
            this.panelDialog.Size = new System.Drawing.Size(882, 203);
            this.panelDialog.TabIndex = 5;
            // 
            // lblNume
            // 
            this.lblNume.AutoSize = true;
            this.lblNume.BackColor = System.Drawing.Color.Transparent;
            this.lblNume.Font = new System.Drawing.Font("Chinese Rocks Rg", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNume.ForeColor = System.Drawing.Color.Snow;
            this.lblNume.Location = new System.Drawing.Point(3, 17);
            this.lblNume.Name = "lblNume";
            this.lblNume.Size = new System.Drawing.Size(48, 25);
            this.lblNume.TabIndex = 4;
            this.lblNume.Text = "Nume";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Chinese Rocks Rg", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblText.ForeColor = System.Drawing.SystemColors.Control;
            this.lblText.Location = new System.Drawing.Point(79, 17);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(49, 25);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "text";
            this.lblText.Click += new System.EventHandler(this.pbFundal_Click);
            // 
            // pbCaracter
            // 
            this.pbCaracter.BackColor = System.Drawing.Color.Transparent;
            this.pbCaracter.Image = global::RDR2_Visual_Novel.Properties.Resources.Bill1;
            this.pbCaracter.Location = new System.Drawing.Point(779, 204);
            this.pbCaracter.Name = "pbCaracter";
            this.pbCaracter.Size = new System.Drawing.Size(1113, 837);
            this.pbCaracter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCaracter.TabIndex = 6;
            this.pbCaracter.TabStop = false;
            // 
            // pbFundal
            // 
            this.pbFundal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFundal.Image = global::RDR2_Visual_Novel.Properties.Resources.valentine;
            this.pbFundal.Location = new System.Drawing.Point(0, 0);
            this.pbFundal.Name = "pbFundal";
            this.pbFundal.Size = new System.Drawing.Size(1904, 1041);
            this.pbFundal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFundal.TabIndex = 4;
            this.pbFundal.TabStop = false;
            this.pbFundal.Click += new System.EventHandler(this.pbFundal_Click);
            // 
            // FormNewGame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelDialog);
            this.Controls.Add(this.pbCaracter);
            this.Controls.Add(this.pbFundal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNewGame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormNewGame_Load);
            this.panelDialog.ResumeLayout(false);
            this.panelDialog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaracter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFundal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbFundal;
        private System.Windows.Forms.Panel panelDialog;
        private System.Windows.Forms.Label lblNume;
        private System.Windows.Forms.PictureBox pbCaracter;
        private System.Windows.Forms.Label lblText;
    }
}