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
    public partial class ThisCorrect : Form
    {
        public ThisCorrect()
        {
            InitializeComponent();
        }

        public bool confirm
        {
            get;
            private set;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            confirm = false;
            this.Hide();

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            confirm = true;
            this.Hide();
        }
    }
}
