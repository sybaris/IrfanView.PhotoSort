using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sybaris.IrfanView.Extensions.PhotoSort.Verbs
{
    public partial class SplitFolderForm : Form
    {
        public SplitFolderForm()
        {
            InitializeComponent();
            ActiveControl = txbFolderName;
            
        }

        public static DialogResult Run(ref string newFolderName, string infoNbFiles, string infoDeltaDate)
        {
            using (var form = new SplitFolderForm())
            {
                form.txbFolderName.Text = newFolderName;
                form.txbFolderName.SelectionStart = form.txbFolderName.Text.Length;
                form.txbFolderName.SelectionLength = 0;
                form.lblNbFichiers.Text = infoNbFiles;
                form.lblDeltaDate.Text = infoDeltaDate;
                form.txbFolderName.Focus();
                var result = form.ShowDialog();
                newFolderName = form.txbFolderName.Text;
                return result;
            }
        }

        private void SplitFolderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
