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
    public partial class ver_selectivos : Form
    {
        #region Variables
        public string nombre_usuario;
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        #endregion
        #region Load
        public ver_selectivos()
        {
            InitializeComponent();
        }

        private void ver_selectivos_Load(object sender, EventArgs e)
        {
            dgvSelectivos.DataSource = consultasMySQL.verSelectivos();
        }
        #endregion

        private void dgvSelectivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Carga carga = new Carga();
            carga.nombre_usuario = nombre_usuario;
            carga.apertura = false;
            carga.empresa = "";
            carga.idInventario = dgvSelectivos.CurrentRow.Cells[0].Value.ToString();
            carga.Show();
            Close();
            //DataTable table = consultasMySQL.editarSelectivos();
            //string ID = dgvSelectivos.CurrentRow.Cells[0].Value.ToString();
            //Seleccion seleccion = new Seleccion();
            //seleccion.edit = true;
            //seleccion.Show();
        }
    }
}
