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
            int StartRowAndColumn = 0;
            Entity.CRH[] ProcessedCRH = CreateCRH(arrarrstrWBS, StartRowAndColumn, arrarrstrWBS.Length, StartRowAndColumn, null);
            dataGridView1.DataSource = ProcessedCRH;
            dataGridView1.Refresh();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
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

        private  Entity.CRH[] CreateCRH(String[][] arrarrWBS_I, int intSRows_I, int intERows_I, int intColumns_I, Entity.CRH CRHPadre_I)
        {
            Entity.CRH[] CRH_O;

            int intNextLevelEnd;
            int intCurrentRow = intSRows_I;
            int intColumn = intColumns_I;
            int intNextColumn = intColumns_I + 1;
            List<Entity.CRH> lstCRH = new List<Entity.CRH>();
            for (; intCurrentRow < intERows_I; intCurrentRow = intCurrentRow + 1)
            {
                Entity.CRH CRHRow = new Entity.CRH();
                
                //                                          //Process row of current level.
                CRHRow.Clave = arrarrWBS_I[intCurrentRow][intColumn];
                CRHRow.Nombre = arrarrWBS_I[intCurrentRow][intColumn + 1];
                CRHRow.Descripcion = arrarrWBS_I[intCurrentRow][intColumn + 2];
                CRHRow.ID_Responsable = 1 /*TO-DO int.Parse(arrarrWBS_I[intSRows_I][intColumns_I + 3])*/;
                lstCRH.Add(CRHRow);

                //                                          //Find next in same level.
                int intNextBrother = intCurrentRow + 1;
                while ( 
                        intNextBrother < arrarrWBS_I.Length &&
                        (
                        arrarrWBS_I[intNextBrother][intColumns_I] != "" ||
                        intColumns_I - 1 == -1 ||
                        arrarrWBS_I[intNextBrother][intColumns_I - 1] == ""
                        )
                       )
                {
                    //                                      //If there is no brothers nextend is Lenght - 1
                    intNextBrother = intNextBrother + 1;
                }

                //                                          //If next brother is not next process children from current.
                if (intCurrentRow != intNextBrother)
                {
                    intNextLevelEnd = intNextBrother - 1;
                    Entity.CRH[] CRHToAdd = CreateCRH(arrarrWBS_I, intCurrentRow + 1, intNextLevelEnd, intNextColumn, CRHRow);
                    foreach(Entity.CRH toAdd in CRHToAdd)
                    {
                        lstCRH.Add(toAdd);
                    }
                }
            }

                return CRH_O = lstCRH.ToArray();
        }
        #endregion


    }
}
