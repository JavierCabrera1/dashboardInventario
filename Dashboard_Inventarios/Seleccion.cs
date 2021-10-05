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
    public partial class Seleccion : Form
    {
        #region Variables
        ConsultasMySQL consultas = new ConsultasMySQL();
        public DataTable tabla;
        public string fecha;
        public string patrono;
        public string bodegas;
        public string codigos;
        public string nombre_inventario;
        public string nombre_usuario;
        public bool edit;
        string idUsuario;
        string Hora_Inicio;
        string idInventario;
        public string ip;
        #endregion
        #region Load()
        public Seleccion()
        {
            InitializeComponent();
        }

        private void Seleccion_Load(object sender, EventArgs e)
        {

            consultas.obtenerConf();
            dgvProductos.DataSource = consultas.Productos(bodegas, patrono);
            dgvPreInventario.Columns.Add("descripcion", "Descripción");
            dgvPreInventario.Columns.Add("codigo", "Código");
            dgvPreInventario.Columns.Add("medida", "Medida");
            dgvPreInventario.Columns.Add("#bodega", "#Bodega");
            dgvPreInventario.Columns.Add("bodega", "Bodega");
            dgvPreInventario.Columns.Add("existencia", "Existencia");
            dgvPreInventario.Columns.Add("costo", "Costo");
            dgvPreInventario.Columns.Add("empresa", "Empresa");
            dgvPreInventario.Columns.Add("riesgo", "Riesgo");
            if (!edit)
            {
                btnEnviar.Text = "  Generar Inventario";
                dtFecha.Text = fecha;
                if (tabla != null)
                {
                    if (tabla.Rows.Count != 0)
                    {
                        foreach (DataRow row in tabla.Rows)
                        {
                            dgvPreInventario.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]);
                        }
                        foreach (DataGridViewRow row in dgvPreInventario.Rows)
                        {
                            foreach (DataGridViewRow rowP in dgvProductos.Rows)
                            {
                                if (rowP.Cells[1].Value.ToString() == row.Cells["codigo"].Value.ToString() && rowP.Cells[3].Value.ToString() == row.Cells["#bodega"].Value.ToString())
                                {
                                    rowP.DefaultCellStyle.BackColor = Color.LawnGreen;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                btnEnviar.Text = "  Editar Inventario";
            }
        }
        #endregion
        #region capturarID()
        //----------------- * Toma todos los id de activos que están dentro del datagridview * -----------------//
        private void capturarID()
        {
            int contador = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (contador == 0)
                    {
                        codigos = row.Cells[2].Value.ToString();
                    }
                    else
                    {
                        codigos = codigos + "," + row.Cells[2].Value.ToString();
                    }
                    contador++;
                }
            }
        }
        #endregion
        #region Celll Double Click
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string descripcion = dgvProductos.CurrentRow.Cells[0].Value.ToString();
                string codigo = dgvProductos.CurrentRow.Cells[1].Value.ToString();
                string unidad_de_medida = dgvProductos.CurrentRow.Cells[2].Value.ToString();
                string codigo_bodega = dgvProductos.CurrentRow.Cells[3].Value.ToString();
                string nombre_bodega = dgvProductos.CurrentRow.Cells[4].Value.ToString();
                decimal existencia = 0;
                decimal costo_promedio = Convert.ToDecimal(dgvProductos.CurrentRow.Cells[6].Value.ToString());
                string empresa = dgvProductos.CurrentRow.Cells[7].Value.ToString();
                string riesgo = dgvProductos.CurrentRow.Cells[8].Value.ToString();
                foreach (DataGridViewRow row in dgvPreInventario.Rows)
                {
                    if (codigo == row.Cells["codigo"].Value.ToString() && codigo_bodega == row.Cells["#bodega"].Value.ToString())
                    {
                        MessageBox.Show("Este producto ya está registrado", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (MessageBox.Show("¿Está seguro de cagar este producto al pre-inventario?", "Cargar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvPreInventario.Rows.Add(descripcion, codigo, unidad_de_medida, codigo_bodega, nombre_bodega, existencia, costo_promedio, empresa, riesgo);
                }
                foreach (DataGridViewRow row in dgvPreInventario.Rows)
                {
                    if (codigo == row.Cells["codigo"].Value.ToString() && codigo_bodega == row.Cells["#bodega"].Value.ToString())
                    {
                        dgvProductos.CurrentRow.DefaultCellStyle.BackColor = Color.LawnGreen;
                    }
                }

            }
        }
        #endregion
        #region Cell Double Click
        private void dgvPreInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string descripcion = dgvPreInventario.CurrentRow.Cells[0].Value.ToString();
                string codigo = dgvPreInventario.CurrentRow.Cells[1].Value.ToString();
                string unidad_de_medida = dgvPreInventario.CurrentRow.Cells[2].Value.ToString();
                string codigo_bodega = dgvPreInventario.CurrentRow.Cells[3].Value.ToString();
                string nombre_bodega = dgvPreInventario.CurrentRow.Cells[4].Value.ToString();
                decimal existencia = Convert.ToDecimal(dgvPreInventario.CurrentRow.Cells[5].Value.ToString());
                decimal costo_promedio = Convert.ToDecimal(dgvPreInventario.CurrentRow.Cells[6].Value.ToString());
                string empresa = dgvPreInventario.CurrentRow.Cells[7].Value.ToString();
                if (MessageBox.Show("¿Está seguro de descartar este producto del pre-inventario?", "Descartar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = 0;
                    foreach (DataGridViewRow row in dgvProductos.Rows)
                    {
                        if (codigo == row.Cells[1].Value.ToString() && codigo_bodega == row.Cells[3].Value.ToString())
                        {
                            dgvProductos.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            dgvProductos.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                        i++;
                    }
                    dgvPreInventario.Rows.RemoveAt(dgvPreInventario.CurrentRow.Index);
                }
            }
        }
        #endregion
        #region Botón para ingresar el inventario
        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            if (dgvPreInventario.Rows.Count == 0)
            {
                MessageBox.Show("No hay ningún registro, por favor ingrese productos seleccionados", "Sin Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string fecha_apertura = dtFecha.Value.ToString("yyyy-MM-dd");
            string hoy = DateTime.Now.ToString("yyyy-MM-dd");
            if (fecha_apertura == hoy)
            {
                if (MessageBox.Show("La fecha de apertura está fijada en el día de hoy. Aun así, ¿Quiere continuar?", "Fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }
            if (MessageBox.Show("¿Está seguro de querer guardar este inventario?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string idEstado = "10";
                    idUsuario = Convert.ToString(consultas.obtenerIdUsuario(nombre_usuario));
                    consultas.insertInventario(nombre_inventario, idUsuario, fecha_apertura, "4", idEstado);
                    idInventario = consultas.idInventario();

                    foreach (DataGridViewRow row in dgvPreInventario.Rows)
                    {
                        string descripcion = row.Cells["descripcion"].Value.ToString();
                        string codigo = row.Cells["codigo"].Value.ToString();
                        string unidad_de_medida = row.Cells["medida"].Value.ToString();
                        string codigo_bodega = row.Cells["#bodega"].Value.ToString();
                        string nombre_bodega = row.Cells["bodega"].Value.ToString();
                        decimal existencia = Convert.ToDecimal(row.Cells["existencia"].Value.ToString());
                        decimal costo_promedio = Convert.ToDecimal(row.Cells["costo"].Value.ToString());
                        string nombre_empresa = row.Cells["empresa"].Value.ToString();
                        string riesgo = row.Cells["riesgo"].Value.ToString();
                        string id_empresa;
                        if (nombre_empresa == "Unhesa")
                        {
                            id_empresa = "1";
                        }
                        else
                        {
                            id_empresa = "2";
                        }
                        consultas.InsertConteoSelectivos(descripcion, codigo, unidad_de_medida, codigo_bodega, nombre_bodega, existencia, costo_promedio, id_empresa, idInventario, riesgo);
                    }
                    Carga carga = new Carga();
                    carga.nombre_usuario = nombre_usuario;
                    carga.apertura = false;
                    carga.empresa = "";
                    carga.idInventario = idInventario;
                    carga.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió una excepción: " + ex, "Exepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region btnBodega
        private void btnBodega_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de querer modificar bodegas y patrono?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable table = new DataTable();
                table.Columns.Add("descripcion", typeof(string));
                table.Columns.Add("codigo", typeof(string));
                table.Columns.Add("medida", typeof(string));
                table.Columns.Add("#bodega", typeof(string));
                table.Columns.Add("bodega", typeof(string));
                table.Columns.Add("existencia", typeof(string));
                table.Columns.Add("costo", typeof(string));
                table.Columns.Add("empresa", typeof(string));
                table.Columns.Add("riesgo", typeof(string));
                foreach (DataGridViewRow row in dgvPreInventario.Rows)
                {
                    DataRow fila = table.NewRow();
                    fila["descripcion"] = row.Cells[0].Value.ToString();
                    fila["codigo"] = row.Cells[1].Value.ToString();
                    fila["medida"] = row.Cells[2].Value.ToString();
                    fila["#bodega"] = row.Cells[3].Value.ToString();
                    fila["bodega"] = row.Cells[4].Value.ToString();
                    fila["existencia"] = row.Cells[5].Value.ToString();
                    fila["costo"] = row.Cells[6].Value.ToString();
                    fila["empresa"] = row.Cells[7].Value.ToString();
                    fila["riesgo"] = row.Cells[8].Value.ToString();

                    table.Rows.Add(fila);
                }
                Seleccionar_Bodega seleccionar = new Seleccionar_Bodega();
                seleccionar.fecha = dtFecha.Value.ToString();
                seleccionar.table = table;
                seleccionar.inventario = nombre_inventario;
                seleccionar.nombre_usuario = nombre_usuario;
                seleccionar.Show();
                Close();
            }
        }
        #endregion
    }
}
