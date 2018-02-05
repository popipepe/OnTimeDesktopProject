using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTimeDesktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
        }
       
        #region Events
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUser.Clear();
            txtUser.Focus();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

            //                                             //If for loggin check, 
            //                                             //   for now does nothing but change window.
            if (true)/*TO-DO*/
            {
                this.Close();
            }

        }

        #endregion

        #region Methods

        #endregion
    }
}
