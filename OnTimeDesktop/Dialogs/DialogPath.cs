using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTimeDesktop.Dialogs
{
    public partial class DialogPath : Form
    {
        public bool boolPath
        {
            get;
            private set;
        }
        public String strPath
        {
            get;
            private set;
        }

        public DialogPath()
        {
            InitializeComponent();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            boolPath = false;
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ThisCorrect confirmation = new ThisCorrect();
            confirmation.ShowDialog();
            if (confirmation.confirm)
            {
                strPath = txtPath.Text;
                boolPath = true;
                confirmation.Close();
                this.Hide();
            }
            else
            {
                this.Focus();
                confirmation.Close();
            }
        }
    }
}
