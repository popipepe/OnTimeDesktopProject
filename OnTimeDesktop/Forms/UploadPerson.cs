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
    public partial class UploadPerson : Form
    {
        public UploadPerson()
        {
            InitializeComponent();
        }
        #region Events

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            bool boolSave = VerifyData(txtName.Text, txtIDTowa.Text, txtIdSup.Text);
            if (
                boolSave
                )
            {
                SaveData(txtName.Text, txtIDTowa.Text, txtIdSup.Text);
                MessageBox.Show(txtName.Text + " Saved!");
                txtIdSup.Clear();
                txtIDTowa.Clear();
                txtName.Clear();

            }
            else
            {
                MessageBox.Show("Information Not Valid, Please check it again.");
            }


        }

        #endregion


        #region Metodos

        private bool VerifyData(String Name, String IDTowa, String IDSupervisor)
        {
            using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {
                bool UniqueName = false;
                bool UniqueID = false;
                bool SupExists = false;

                Entity.Persona PersonToVerify = model.Persona.Where(x => x.Nombre == Name).FirstOrDefault();
                if(PersonToVerify == null)
                {
                    UniqueName = true;
                }

                PersonToVerify = model.Persona.Where(x => x.ID_Towa == IDTowa).FirstOrDefault();
                if (PersonToVerify == null)
                {
                    UniqueID = true;
                }

                PersonToVerify = model.Persona.Where(x => x.ID_Towa == IDSupervisor).FirstOrDefault();
                if (PersonToVerify != null || IDTowa == "GLG")
                {
                    SupExists = true;
                }



                return UniqueID && UniqueName && SupExists;
            }


        }

        private void SaveData(String Name, String IDTowa, String IDSupervisor)
        {
            using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {
                Entity.Persona PersonToSave = new Entity.Persona();
                PersonToSave.Nombre = Name;
                PersonToSave.Nombre = IDTowa;
                if (IDTowa != "GLG")
                {
                    Entity.Persona PersonSup = model.Persona.Where(x => x.ID_Towa == IDSupervisor).FirstOrDefault();
                    PersonToSave.ID_Supervisor = PersonSup.ID_Persona;
                }
                else
                {
                    PersonToSave.ID_Supervisor = null;
                }
                model.Persona.Add(PersonToSave);
                model.SaveChanges();
            }
        }


        #endregion
    }
}
