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
    public partial class Seleccionar_Rack : Form
    {
        #region Variables Globales
        ConsultasMySQL consultas = new ConsultasMySQL();
        public DataTable tabla;
        public string fecha;
        public string patrono;
        public string bodegas;
        public string codigos;
        public string nombre_inventario;
        public string nombre_usuario;
        public bool inventario_local;
        public bool edit;
        public string ip;
        public string prueba;
        #endregion
        #region Constructor
        public Seleccionar_Rack()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void Seleccionar_Rack_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
            CheckBoxColumn.HeaderText = "✓";
            dgvBodega.Columns.Add(CheckBoxColumn);
            dgvBodega.DataSource = consultas.verRacks(bodegas);
        }
        #endregion

        private void chk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBodega.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            capturarID();
            if (prueba == null)
            {
                MessageBox.Show("Seleccione un rack como mínimo", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Seleccion seleccion = new Seleccion();
            seleccion.patrono = patrono;
            seleccion.bodegas = prueba;
            seleccion.fecha = fecha;
            seleccion.nombre_inventario = nombre_inventario;
            seleccion.nombre_usuario = nombre_usuario;
            seleccion.tabla = tabla;
            seleccion.ip = ip;
            seleccion.inventario_local = inventario_local;
            seleccion.Show();
            Close();
        }

        #region capturarID()
        //----------------- * Toma todos los id que están dentro del datagridview * -----------------//
        private void capturarID()
        {
            int contador = 0;
            foreach (DataGridViewRow row in dgvBodega.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (contador == 0)
                    {
                        prueba = row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        prueba = prueba + "," + row.Cells[1].Value.ToString();
                    }
                    contador++;
                }
            }
        }
        #endregion
    }
}
