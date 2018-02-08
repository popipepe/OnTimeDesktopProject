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
                uploadToGrid(strPathToUpload);

            }
            else
            {
                this.Focus();
                pathselect.Close();
            }
        }

        #endregion

        #region Methods

        private void uploadToGrid(String strPath_I)
        {
            String[] strWBSLines = GetWBS(strPath_I);
            String[][] arrarrstrWBS = SplitWBS(strWBSLines);
        }

        private String[] GetWBS(String strPathToArray_I)
        {
            String[] arrstrWBS_O;

            //                                              //Prosses file into strArray
            String strLine;
            List<String> lststrWBS = new List<String>();
            using (StreamReader reader = new StreamReader(strPathToArray_I))
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

        private void CreateCRH(String[][] arrarrWBS_I, out Entity.OnTimeDataSet.CRHRow[] CRH_O, int intSRows_I,
                                    int intERows_I, int intColumns_I, Entity.OnTimeDataSet.CRHRow CRHPadre_I)
        {
            List<Entity.OnTimeDataSet.CRHRow> lstCRH = new List<Entity.OnTimeDataSet.CRHRow>();
            for (; intERows_I < arrarrWBS_I.Length; intSRows_I = intSRows_I + 1)
            {
                //Entity.OnTimeDataSet.CRHRow CRHRow
            }


                CRH_O = lstCRH.ToArray();
        }
        #endregion


    }
}
