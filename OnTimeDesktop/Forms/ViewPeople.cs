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
    public partial class ViewPeople : Form
    {
        public ViewPeople()
        {
            InitializeComponent();
            LoadPeople();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPeople()
        {
            using(Entity.ONTIME_DBEntities model = new Entity.ONTIME_DBEntities())
            {
                List<Entity.Persona> personas = model.Persona.ToList();

                dataGridView1.Columns.Add("nombre", "Nombre");
                dataGridView1.Columns.Add("idtowa", "ID Towa");
                dataGridView1.Columns.Add("idSup", "ID Supervisor");
                dataGridView1.Columns.Add("nomSup", "Nombre Supervisor");

                int intRow = 0;
                foreach(Entity.Persona  persona in personas)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[intRow].Cells[0].Value = persona.Nombre;
                    dataGridView1.Rows[intRow].Cells[1].Value = persona.ID_Towa;

                    Entity.Persona supervisor = model.Persona.Where(x => x.ID_Persona == persona.ID_Supervisor).FirstOrDefault();
                    if (supervisor != null)
                    {
                        dataGridView1.Rows[intRow].Cells[2].Value = supervisor.Nombre;
                        dataGridView1.Rows[intRow].Cells[3].Value = supervisor.ID_Towa;
                    }

                    intRow = intRow + 1;
                }
            }
        }
    }
}
