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
    public partial class Seleccionar_Bodega : Form
    {
        #region Variables
        public DataTable table;
        public string fecha;
        string prueba;
        public string inventario;
        public string nombre_usuario;
        public string ip;
        #endregion
        #region Load()
        public Seleccionar_Bodega()
        {
            InitializeComponent();
        }

        private void Seleccionar_Bodega_Load(object sender, EventArgs e)
        {
            lbInventario.Text = inventario;
            Bodega();
        }
        #endregion
        #region ComboBox de Bodega Quemado En código
        //--------------------------------------------------------------------------------Llena el ComboBox de Bodega----------------------------------------------------------------------------------//
        public void Bodega()
        {
            //Diccionario quemado en código para bodega
            Dictionary<string, string> bodega = new Dictionary<string, string>();
            bodega.Add("01", "01 - BODEGA PRORRATEO");
            bodega.Add("02", "02 - BODEGA MATERIA PRIMA");
            bodega.Add("03", "03 - PRODUCCION MATERIA PRIMA");
            bodega.Add("04", "04 - PRODUCCION PROCESO");
            bodega.Add("05", "05 - PRODUCCION PRODUCTO TERMINADO");
            bodega.Add("06", "06 - BODEGA PRODUCTO TERMINADO");
            bodega.Add("07", "07 - BODEGA CUARENTENA");
            bodega.Add("08", "08 - BODEGA CONSIGNACION");
            bodega.Add("09", "09 - LABORATORIO");
            bodega.Add("10", "10 - BODEGA DE OBSOLETOS Y MAL ESTADO ANEXO 1");
            bodega.Add("11", "11 - BODEGA NÚMERO 11");
            bodega.Add("12", "12 - BODEGA MATERIA PRIMA 29-89");
            bodega.Add("13", "13 - PRODUCCION MATERIA PRIMA 29-89");
            bodega.Add("14", "14 - PRODUCCION PROCESO 29-89");
            bodega.Add("15", "15 - PRODUCCION PRODUCTO TERMINADO 29-89");
            bodega.Add("16", "16 - BODEGA PRODUCTO TERMINADO 29-89");
            bodega.Add("17", "17 - BODEGA CUARENTENA 29-89");
            bodega.Add("18", "18 - Bodega Consignación Mariposa");
            bodega.Add("19", "19 - BODEGA PT MAL ESTADO");
            bodega.Add("20", "20 - BODEGA ALMAGUATE MATERIA PRIMA");
            bodega.Add("21", "21 - BODEGA MATERIAS PRIMAS (VENTAS) ALMACEN #21");
            bodega.Add("22", "22 - BODEGA DE FILTROS");
            bodega.Add("23", "23 - Bodega de Ruteo");
            bodega.Add("24", "24 - BODEGA UNIDAD MOVIL");
            bodega.Add("25", "25 - BODEGA 25");
            bodega.Add("26", "26 - BODEGA 26");
            bodega.Add("27", "27 - BODEGA 27");
            bodega.Add("28", "28 - BODEGA 28");
            bodega.Add("29", "29 - BODEGA 29");
            bodega.Add("30", "30 - BODEGA 30");
            bodega.Add("31", "31 - BODEGA CALIDADES");
            bodega.Add("32", "32 - BODEGA 32");
            bodega.Add("33", "33 - BODEGA 33");
            bodega.Add("34", "34 - BODEGA 34");
            bodega.Add("35", "35 - BODEGA CALIDADES II");
            bodega.Add("36", "36 - BODEGA TRANSITO (BODEGA-PRODUCCION)");
            bodega.Add("37", "37 - BODEGA CONSIGNACION FILTROS");
            bodega.Add("38", "38 - BODEGA 38");
            bodega.Add("39", "39 - BODEGA 39");
            bodega.Add("99", "99 - BODEGA PRODUCTO PT MAL ESTADO DEST");

            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
            CheckBoxColumn.HeaderText = "✓";
            dgvBodega.Columns.Add(CheckBoxColumn);
            dgvBodega.DataSource = new BindingSource(bodega, null);
            dgvBodega.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBodega.Columns[0].Name = "Check";
            dgvBodega.Columns[1].Visible = false;
            dgvBodega.Columns[2].HeaderText = "Bodega";

        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Botón de enviar
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            capturarID();
            if (prueba == null)
            {
                MessageBox.Show("Seleccione una bodega como mínimo", "Seleccione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Seleccion seleccion = new Seleccion();
            if (rbUnhesa.Checked)
            {
                seleccion.patrono = "Unhesa";
            }
            if (rbProquima.Checked)
            {
                seleccion.patrono = "Proquima";
            }
            if (rbAmbas.Checked)
            {
                seleccion.patrono = "Ambas" ;
            }
            seleccion.bodegas = prueba;
            seleccion.fecha = fecha;
            seleccion.nombre_inventario = inventario;
            seleccion.nombre_usuario = nombre_usuario;
            seleccion.tabla = table;
            seleccion.ip = ip;
            seleccion.Show();
            Close();
        } 
        #endregion
        #region capturarID()
        //----------------- * Toma todos los id de activos que están dentro del datagridview * -----------------//
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
        #region check button
        private void chk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBodega.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
            }
        }
        #endregion
    }
}
