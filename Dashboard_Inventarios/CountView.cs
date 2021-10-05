using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace Dashboard_Inventarios
{
    public partial class CountView : Form
    {
        //variables que usaré para saber si debo filtrar por Unhesa, Porquima o Econsa
        public string empresa1;
        public string empresa2;
        public string nombre_usuario;
        public string contar;
        public DataTable TableInventario;
        public CountView()
        {
            InitializeComponent();
        }

        private void CountView_Load(object sender, EventArgs e)
        {
            string contado;
            string reconteo;
            string contadoEx;
            string recontadoEx;
            //IF para saber si filtro contados o no contados
            if (contar == "si")
            {
                contado = "Contado";
                reconteo = "Recontado";
                contadoEx = "Contado Extraordinario";
                recontadoEx = "Recontado Extraordinario";
            }
            else
            {
                contado = "Sin Contar";
                reconteo = "Habilitar Reconteo";
                contadoEx = "Sin Contar Extraordinario";
                recontadoEx = "Habilitar Reconteo Extraordinario";
            }
            //asigno al DataTable filtro todas las columnas que lleva TableInventario
            DataTable filtro = new DataTable();

            filtro.Columns.Add("ID", Type.GetType("System.Int32"));
            filtro.Columns.Add("Código SAP");
            filtro.Columns.Add("Descripción SAP");
            filtro.Columns.Add("Código Bodega");
            filtro.Columns.Add("Nombre Bodega");
            filtro.Columns.Add("Unidad de Medida");
            filtro.Columns.Add("Existencia SAP", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Costo Promedio", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Conteo Fisico", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Cantidad Diferencia", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Costo Diferencia", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Empresa");
            filtro.Columns.Add("Usuario");
            filtro.Columns.Add("Estado");
            filtro.Columns.Add("Fecha Actualización", Type.GetType("System.DateTime"));
            filtro.Columns.Add("Costo Diferencia Absoluto", Type.GetType("System.Decimal"));
            filtro.Columns.Add("Observaciones Contador");
            filtro.Columns.Add("Observaciones Gerencia");
            DataRow datos = null;

            //filtro por empresa y estado dependiendo de cuales fueron las variables que me mandaron
            foreach (DataRow row in TableInventario.Rows)
            {
                if (row["Empresa"].ToString() == empresa1 || row["Empresa"].ToString() == empresa2)
                {
                    if (row["Estado"].ToString() == contado || row["Estado"].ToString() == reconteo || row["Estado"].ToString() == contadoEx || row["Estado"].ToString() == recontadoEx)
                    {
                        datos = filtro.NewRow();
                        datos["ID"] = Convert.ToInt32(row["ID"]);
                        datos["Código SAP"] = row["Codigo SAP"];
                        datos["Descripción SAP"] = row["Descripcion SAP"];
                        datos["Código Bodega"] = row["Codigo Bodega"];
                        datos["Nombre Bodega"] = row["Nombre Bodega"];
                        datos["Unidad de Medida"] = row["Unidad de Medida"];
                        datos["Existencia SAP"] = row["Existencia SAP"];
                        datos["Costo Promedio"] = row["Costo Promedio"];
                        datos["Conteo Fisico"] = row["Conteo Fisico"];
                        datos["Cantidad Diferencia"] = row["Cantidad Diferencia"];
                        datos["Costo Diferencia"] = row["Costo Diferencia"];
                        datos["Empresa"] = row["Empresa"];
                        datos["Usuario"] = row["Usuario"];
                        datos["Estado"] = row["Estado"];
                        datos["Fecha Actualización"] = row["Fecha Actualizacion"];
                        datos["Costo Diferencia Absoluto"] = row["CostoDiferenciaAbsoluto"];
                        datos["Observaciones Contador"] = row["Observaciones Contador"];
                        datos["Observaciones Gerencia"] = row["Observaciones Gerencia"];
                        filtro.Rows.Add(datos);
                    }
                }
            }
            //y lo muestro en el DataGrid
            dgvCount.DataSource = filtro;
            dgvCount.Sort(dgvCount.Columns[15], ListSortDirection.Descending);
            dgvCount.Columns[15].Visible = false;
            dgvCount.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCount.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCount.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCount.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCount.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCount.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dependiendo de la empresa, se cambia en fondo de la ventana
            if (empresa1 == "Unhesa" && empresa2 == "Proquima")
            {
                lbContados.Text = "Contados Econsa";
                BackgroundImage = Image.FromFile("fondo6.png");
            }
            if (empresa1 == "Unhesa" && empresa2 == "Unhesa")
            {
                BackgroundImage = Image.FromFile("fondo5.png");
                lbContados.Text = "Contados Unhesa";
            }
            if (empresa1 == "Proquima" && empresa2 == "Proquima")
            {
                BackgroundImage = Image.FromFile("fondo4.png");
                lbContados.Text = "Contados Proquima";
            }
        }

        private void dgvCount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en una celda, los datos de esa fila se guardan en variables y luego se envían al Form de Detalle y lo abre
            if (e.RowIndex != -1)
            {
                int ID = Convert.ToInt32(dgvCount.CurrentRow.Cells[0].Value.ToString());
                string CodigoSAP = dgvCount.CurrentRow.Cells[1].Value.ToString();
                string Descripcion = dgvCount.CurrentRow.Cells[2].Value.ToString();
                string coBodega = dgvCount.CurrentRow.Cells[3].Value.ToString();
                string nombreBodega = dgvCount.CurrentRow.Cells[4].Value.ToString();
                string uni = dgvCount.CurrentRow.Cells[5].Value.ToString();
                string empresa = dgvCount.CurrentRow.Cells[11].Value.ToString();
                string usuario = dgvCount.CurrentRow.Cells[12].Value.ToString();
                string estado = dgvCount.CurrentRow.Cells[13].Value.ToString();
                string Fecha = dgvCount.CurrentRow.Cells[14].Value.ToString();
                string ObservacionesContador = dgvCount.CurrentRow.Cells[16].Value.ToString();
                string Observaciones = dgvCount.CurrentRow.Cells[17].Value.ToString();

                //A veces algunos valores llegan como null, cuando es así entonces se cambia el valor a 0 para mandarlo como un INT

                Decimal exis;
                if (dgvCount.CurrentRow.Cells[6].Value.ToString() == "") exis = 0;
                else exis = Convert.ToDecimal(dgvCount.CurrentRow.Cells[6].Value.ToString());

                Decimal costoPromedio;
                if (dgvCount.CurrentRow.Cells[7].Value.ToString() == "") costoPromedio = 0;
                else costoPromedio = Convert.ToDecimal(dgvCount.CurrentRow.Cells[7].Value.ToString());

                Decimal conteoFisico;
                if (dgvCount.CurrentRow.Cells[8].Value.ToString() == "") conteoFisico = 0;
                else conteoFisico = Convert.ToDecimal(dgvCount.CurrentRow.Cells[8].Value.ToString());

                Decimal cantidadDiferencia;
                if (dgvCount.CurrentRow.Cells[9].Value.ToString() == "") cantidadDiferencia = 0;
                else cantidadDiferencia = Convert.ToDecimal(dgvCount.CurrentRow.Cells[9].Value.ToString());

                Decimal costoDiferencia;
                if (dgvCount.CurrentRow.Cells[10].Value.ToString() == "") costoDiferencia = 0;
                else costoDiferencia = Convert.ToDecimal(dgvCount.CurrentRow.Cells[10].Value.ToString());

                //Abre la ventana con los datos que le mandé

                Detalle_Inventario dtInv = new Detalle_Inventario(ID, Descripcion, CodigoSAP, coBodega, nombreBodega, uni, exis, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, Fecha, true, nombre_usuario, Observaciones, ObservacionesContador);
                dtInv.Show();
            }
        }

        private void dgvCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                int ID = Convert.ToInt32(dgvCount.CurrentRow.Cells[0].Value.ToString());
                string CodigoSAP = dgvCount.CurrentRow.Cells[1].Value.ToString();
                string Descripcion = dgvCount.CurrentRow.Cells[2].Value.ToString();
                string coBodega = dgvCount.CurrentRow.Cells[3].Value.ToString();
                string nombreBodega = dgvCount.CurrentRow.Cells[4].Value.ToString();
                string uni = dgvCount.CurrentRow.Cells[5].Value.ToString();
                string empresa = dgvCount.CurrentRow.Cells[11].Value.ToString();
                string usuario = dgvCount.CurrentRow.Cells[12].Value.ToString();
                string estado = dgvCount.CurrentRow.Cells[13].Value.ToString();
                string Fecha = dgvCount.CurrentRow.Cells[14].Value.ToString();
                string ObservacionesContador = dgvCount.CurrentRow.Cells[16].Value.ToString();
                string Observaciones = dgvCount.CurrentRow.Cells[17].Value.ToString();

                //A veces algunos valores llegan como null, cuando es así entonces se cambia el valor a 0 para mandarlo como un INT

                Decimal exis;
                if (dgvCount.CurrentRow.Cells[6].Value.ToString() == "") exis = 0;
                else exis = Convert.ToDecimal(dgvCount.CurrentRow.Cells[6].Value.ToString());

                Decimal costoPromedio;
                if (dgvCount.CurrentRow.Cells[7].Value.ToString() == "") costoPromedio = 0;
                else costoPromedio = Convert.ToDecimal(dgvCount.CurrentRow.Cells[7].Value.ToString());

                Decimal conteoFisico;
                if (dgvCount.CurrentRow.Cells[8].Value.ToString() == "") conteoFisico = 0;
                else conteoFisico = Convert.ToDecimal(dgvCount.CurrentRow.Cells[8].Value.ToString());

                Decimal cantidadDiferencia;
                if (dgvCount.CurrentRow.Cells[9].Value.ToString() == "") cantidadDiferencia = 0;
                else cantidadDiferencia = Convert.ToDecimal(dgvCount.CurrentRow.Cells[9].Value.ToString());

                Decimal costoDiferencia;
                if (dgvCount.CurrentRow.Cells[10].Value.ToString() == "") costoDiferencia = 0;
                else costoDiferencia = Convert.ToDecimal(dgvCount.CurrentRow.Cells[10].Value.ToString());

                //Abre la ventana con los datos que le mandé

                Detalle_Inventario dtInv = new Detalle_Inventario(ID, Descripcion, CodigoSAP, coBodega, nombreBodega, uni, exis, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, Fecha, true, nombre_usuario, Observaciones, ObservacionesContador);
                dtInv.Show();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCount.DataSource != null)
                {
                    dgvCount.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dgvCount.MultiSelect = true;
                    dgvCount.SelectAll();
                    DataObject dataObj = dgvCount.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    Excel.Application xlexcel;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;
                    xlexcel = new Excel.Application();
                    xlWorkBook = xlexcel.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    //Convierto en string todo el formato
                    Excel.Range filas = xlWorkSheet.Rows;
                    filas.NumberFormat = "@";
                    filas.Select();

                    Excel.Range rango = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    rango.Select();
                    xlWorkSheet.PasteSpecial(rango, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                    //  la primera fila en negrita, centrada y con fondo gris
                    Excel.Range fila1 = (Excel.Range)xlWorkSheet.Rows[1];
                    fila1.Select();
                    fila1.EntireRow.Font.Bold = true;
                    fila1.EntireRow.HorizontalAlignment = HorizontalAlignment.Center;
                    // si la primera celda de la primera columna está vacía, elimino la primera columna
                    Excel.Range c1f1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    if (c1f1.Text == "")
                    {
                        Excel.Range columna1 = (Excel.Range)xlWorkSheet.Columns[1];
                        columna1.Select();
                        columna1.Delete();
                    }

                    //selecciono la primera celda de la primera columna
                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                    c1.Select();
                    xlexcel.Cells.Select();
                    xlexcel.Cells.EntireColumn.AutoFit();
                    xlexcel.Visible = true;
                    dgvCount.ClearSelection();
                    dgvCount.MultiSelect = false;
                }
                else
                {
                    MessageBox.Show("No hay nada en la tabla...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
