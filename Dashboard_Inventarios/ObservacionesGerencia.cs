using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard_Inventarios
{
    public partial class ObservacionesGerencia : Form
    {
        public string testamento;
        public string ID;
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        public ObservacionesGerencia()
        {
            InitializeComponent();
        }

        private void ObservacionesGerencia_Load(object sender, EventArgs e)
        {
            txtTestamento.Text = testamento;
            if(testamento != null)
            {
                btnSend.Text = "Editar Observación";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea agregar esta observación al conteo con el ID: "+ ID +" ?", "Agregar Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    consultasMySQL.updateObservación(ID, txtTestamento.Text);
                    MessageBox.Show("Observación Agregada.", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
