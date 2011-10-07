using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotToPngGenerator
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void browse_dotFile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "(*.exe)|*.exe";
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.OK)
            {
                dotFileNameTextBox.Text = f.FileName;
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            //store the settings and close the dialog
            GlobalSettings g = GlobalSettings.GetInstance();
            g.DotToPNGConverterPath = dotFileNameTextBox.Text;
            g.ShowInExternalViewer = externalViewerCheckBox.Checked;
            g.WriteGlobalSettings();
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            //close the dialog
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            GlobalSettings g = GlobalSettings.GetInstance();
            dotFileNameTextBox.Text = g.DotToPNGConverterPath;
            externalViewerCheckBox.Checked = g.ShowInExternalViewer;            
        }
    }
}
