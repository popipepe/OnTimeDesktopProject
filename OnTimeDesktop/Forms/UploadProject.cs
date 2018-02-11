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
        Entity.CRH[] ProcessedCRH;

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {
                foreach(Entity.CRH crh in ProcessedCRH)
                {
                    
                }
                
                
            }
        }
        #endregion

        #region Methods

        private void uploadToGrid(String strPath_I)
        {
            String[] strWBSLines = GetWBS(strPath_I);
            String[][] arrarrstrWBS = SplitWBS(strWBSLines);
            int StartRowAndColumn = 0;
            ProcessedCRH = CreateCRH(arrarrstrWBS, StartRowAndColumn, arrarrstrWBS.Length - 1, StartRowAndColumn, null);
            dataGridView1.Columns.Add("Padre", "PERTENECE A");
            dataGridView1.Columns.Add("Clave", "CLAVE");
            dataGridView1.Columns.Add("Nombre", "NOMBRE");
            dataGridView1.Columns.Add("Descripcion", "DESCRIPCION");
            dataGridView1.Columns.Add("Responsable", "RESPONSABLE");

            using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {
                int intRow = 0;
                foreach (Entity.CRH crh in ProcessedCRH)
                {
                    Entity.CRH padre = model.CRH.Where(x => x.ID_CRH == crh.ID_CRH_Padre).FirstOrDefault();
                    Entity.Persona responsable = model.Persona.Where(x => x.ID_Persona == crh.ID_Responsable).FirstOrDefault();
                    String strPadre, strResponsable;
                    if(padre == null)
                    {
                        strPadre = "";
                    }
                    else
                    {
                        strPadre = padre.Clave;
                    }

                    if (responsable == null)
                    {
                        strResponsable = "";
                    }
                    else
                    {
                        strResponsable = responsable.ID_Towa;
                    }

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[intRow].Cells[0].Value = strPadre;
                    dataGridView1.Rows[intRow].Cells[1].Value = crh.Clave;
                    dataGridView1.Rows[intRow].Cells[2].Value = crh.Nombre;
                    dataGridView1.Rows[intRow].Cells[3].Value = crh.Descripcion;
                    dataGridView1.Rows[intRow].Cells[4].Value = strResponsable;
                    intRow = intRow + 1;
                }
            }
            MessageBox.Show("Work breakdown structure Uploaded Succesfully");
            
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
            for (; intCurrentRow <= intERows_I; intCurrentRow = intCurrentRow + 1)
            {
                Entity.CRH CRHRow = new Entity.CRH();

                //                                          //Process row of current level.
                CRHRow.Clave = arrarrWBS_I[intCurrentRow][intColumn];
                CRHRow.Nombre = arrarrWBS_I[intCurrentRow][intColumn + 1];
                CRHRow.Descripcion = arrarrWBS_I[intCurrentRow][intColumn + 2];
                int intResp;
                using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
                {
                    String IDresponsable = arrarrWBS_I[intSRows_I][intColumns_I + 3];
                    Entity.Persona resp = model.Persona.Where(x => x.ID_Towa == IDresponsable).FirstOrDefault();
                    intResp = resp.ID_Persona;
                    model.CRH.Add(CRHRow);
                    if (CRHPadre_I != null)
                    {
                        CRHRow.ID_CRH_Padre = CRHPadre_I.ID_CRH;
                    }
                    model.SaveChanges();
                }
                    CRHRow.ID_Responsable = intResp;

                lstCRH.Add(CRHRow);

                //                                          //Find next in same level.
                int intNextBrother = intCurrentRow + 1;
                while (
                        intNextBrother <= arrarrWBS_I.Length - 1 &&
                        intNextBrother <= intERows_I

                       )
                {
                    //                                      //If there is no brothers nextend is Lenght - 1
                    if (isNextBrother(arrarrWBS_I, intNextBrother, intColumn))
                    {
                        break;
                    }
                    intNextBrother = intNextBrother + 1;

                }

                //                                          //If next brother is not next process children from current.
                if (intCurrentRow + 1 != intNextBrother)
                {
                    intNextLevelEnd = intNextBrother - 1;
                    
                    Entity.CRH[] CRHToAdd = CreateCRH(arrarrWBS_I, intCurrentRow + 1, intNextLevelEnd, intNextColumn, CRHRow);
                    foreach(Entity.CRH toAdd in CRHToAdd)
                    {
                        lstCRH.Add(toAdd);
                        intCurrentRow = intCurrentRow + 1;
                    }
                }
            }

                return CRH_O = lstCRH.ToArray();
        }

        private bool isNextBrother(String[][] arrarrstrWBS, int intCurrentRow, int intColumn)
        {
            bool IsBrother = false;
            bool isFirstCol = false;
            bool inSameCol = false;
            bool whiteLeft = false;

            if (intColumn == 0)
            {
                isFirstCol = true;
            }

            if (
                arrarrstrWBS[intCurrentRow][intColumn] != ""
                )
            {
                inSameCol = true;
            }

            if (
                isFirstCol &&
                inSameCol
                )
            {
                whiteLeft = true;
            }
            else if (
                    !isFirstCol &&
                    inSameCol &&
                    arrarrstrWBS[intCurrentRow][intColumn - 1] == ""
                    )
            {
                whiteLeft = true;
            }

            IsBrother =inSameCol && whiteLeft;
            return IsBrother;

        }
        #endregion


    }
}
