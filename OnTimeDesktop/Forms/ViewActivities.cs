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
    public partial class ViewActivities : Form
    {
        public ViewActivities()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            using (Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {

                List<Entity.CRH> allCRH = model.CRH.ToList();

                dataGridView1.Columns.Add("Padre", "PERTENECE A");
                dataGridView1.Columns.Add("Clave", "CLAVE");
                dataGridView1.Columns.Add("Nombre", "NOMBRE");
                dataGridView1.Columns.Add("Descripcion", "DESCRIPCION");
                dataGridView1.Columns.Add("Responsable", "RESPONSABLE");

                int intRow = 0;

                foreach (Entity.CRH crh in allCRH)
                {
                    Entity.CRH padre = model.CRH.Where(x => x.ID_CRH == crh.ID_CRH_Padre).FirstOrDefault();
                    Entity.Persona responsable = model.Persona.Where(x => x.ID_Persona == crh.ID_Responsable).FirstOrDefault();
                    String strPadre, strResponsable;
                    if (padre == null)
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
        }
    }
}
