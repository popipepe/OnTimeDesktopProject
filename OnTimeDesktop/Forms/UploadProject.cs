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
    public partial class UploadProject : Form
    {
        public UploadProject()
        {
            InitializeComponent();
        }

        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCVS_Click(object sender, EventArgs e)
        {
            String strPathToUpload;
            Dialogs.DialogPath pathselect = new Dialogs.DialogPath();
            pathselect.ShowDialog();

            if ( pathselect.boolPath)
            {
                strPathToUpload = pathselect.strPath;
                pathselect.Close();
                upload(strPathToUpload);

            }
            else
            {
                this.Focus();
                pathselect.Close();
            }
        }

        #endregion

        #region Methods

        private void upload(String strPath_I)
        {
            //                                              //TO-DO
            MessageBox.Show(strPath_I);
        }

        #endregion


    }
}
