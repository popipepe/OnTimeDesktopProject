using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnTimeDesktop.Forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            //                                              //Login sequence, will not work if you dont close frmLogin.
            //                                              //Login pass and user checked in login dialog.
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Show();
        }

        #region Events

        private void btnUpProj_Click(object sender, EventArgs e)
        {
            UploadProject Upload = new UploadProject();
            Upload.Show();
            Upload.Focus();
        }

        #endregion

        #region Methods

        #endregion

    }
}
