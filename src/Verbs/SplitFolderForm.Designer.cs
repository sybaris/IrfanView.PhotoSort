namespace Sybaris.IrfanView.Extensions.PhotoSort.Verbs
{
    partial class SplitFolderForm
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
            panel1 = new Panel();
            btnCancel = new Button();
            btnOK = new Button();
            panel2 = new Panel();
            groupBox1 = new GroupBox();
            lblDeltaDate = new Label();
            lblNbFichiers = new Label();
            label1 = new Label();
            txbFolderName = new TextBox();
            groupBox2 = new GroupBox();
            txbLogs = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 373);
            panel1.Name = "panel1";
            panel1.Size = new Size(659, 42);
            panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(412, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Annuler";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(117, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txbFolderName);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(659, 373);
            panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(lblDeltaDate);
            groupBox1.Controls.Add(lblNbFichiers);
            groupBox1.Location = new Point(12, 61);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(636, 79);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informations complémentaires";
            // 
            // lblDeltaDate
            // 
            lblDeltaDate.AutoSize = true;
            lblDeltaDate.Location = new Point(6, 45);
            lblDeltaDate.Name = "lblDeltaDate";
            lblDeltaDate.Size = new Size(71, 15);
            lblDeltaDate.TabIndex = 1;
            lblDeltaDate.Text = "lblDeltaDate";
            // 
            // lblNbFichiers
            // 
            lblNbFichiers.AutoSize = true;
            lblNbFichiers.Location = new Point(6, 26);
            lblNbFichiers.Name = "lblNbFichiers";
            lblNbFichiers.Size = new Size(76, 15);
            lblNbFichiers.TabIndex = 0;
            lblNbFichiers.Text = "lblNbFichiers";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(274, 15);
            label1.TabIndex = 1;
            label1.Text = "Nouveau nom de dossier de ce groupe de fichiers :";
            // 
            // txbFolderName
            // 
            txbFolderName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txbFolderName.BorderStyle = BorderStyle.FixedSingle;
            txbFolderName.Location = new Point(12, 30);
            txbFolderName.Name = "txbFolderName";
            txbFolderName.Size = new Size(636, 23);
            txbFolderName.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txbLogs);
            groupBox2.Location = new Point(12, 146);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(636, 220);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Logs";
            // 
            // txbLogs
            // 
            txbLogs.Dock = DockStyle.Fill;
            txbLogs.Location = new Point(3, 19);
            txbLogs.Multiline = true;
            txbLogs.Name = "txbLogs";
            txbLogs.Size = new Size(630, 198);
            txbLogs.TabIndex = 0;
            // 
            // SplitFolderForm
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(659, 415);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SplitFolderForm";
            Text = "Création d'un nouveau dossier avec ce groupe de fichiers";
            Load += SplitFolderForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCancel;
        private Button btnOK;
        private Panel panel2;
        private Label label1;
        private TextBox txbFolderName;
        private GroupBox groupBox1;
        private Label lblNbFichiers;
        private Label lblDeltaDate;
        private GroupBox groupBox2;
        private TextBox txbLogs;
    }
}