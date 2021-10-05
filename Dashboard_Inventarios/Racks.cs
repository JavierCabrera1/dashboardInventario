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
    public partial class Racks : Form
    {
        #region Variables Globales
        ConsultasMySQL consultas = new ConsultasMySQL();
        public string idBodega;
        #endregion
        #region Constructor
        public Racks()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void Racks_Load(object sender, EventArgs e)
        {
            consultas.obtenerConf();
            dataGridView1.DataSource = consultas.ObtenerRacks(idBodega);
        }
        #endregion
        #region Click Boton Agregar
        private void agregar_rack_btn_Click(object sender, EventArgs e)
        {
            Agregar_Rack rack = new Agregar_Rack();
            rack.opcion = 1;
            rack.idBodega = idBodega;
            rack.Show();
            this.Close();
        }
        #endregion

        #region Doble Click Celda
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            Agregar_Rack rack = new Agregar_Rack();
            rack.opcion = 2;
            rack.idRack = Convert.ToString(fila.Cells[0].Value);
            rack.nombre = Convert.ToString(fila.Cells[1].Value);
            rack.idBodega = idBodega;
            rack.Show();
            this.Close();
        }
        #endregion
    }
}
