using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            String[] strWBSLines = GetWBS(strPath_I);


        }

        private String[] GetWBS(String strPathToArray_I)
        {
            String[] arrstrWBS_O;

            //                                              //Prosses file into strArray
            String strLine;
            List<String> lststrWBS = new List<String>();
            using (StreamReader reader = new StreamReader("file.txt"))
            {
                while ((strLine = reader.ReadLine()) != null)
                {
                    lststrWBS.Add(strLine); // Add to list.
                }
            }

                return arrstrWBS_O = lststrWBS.ToArray();
        }

        private String[][] SplitWBS(String[] arrstrToSplit_I)
        {
            String[][] SplitedWBS;

            List<String[]> lststrSplitWBS = new List<String[]>();
            foreach (String strLineToSplit in arrstrToSplit_I)
            {
                lststrSplitWBS.Add(strLineToSplit.Split(','));
            }
            return SplitedWBS = lststrSplitWBS.ToArray();
        }
        #endregion


    }
}
