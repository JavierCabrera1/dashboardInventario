using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
//Uso de la librería de MySql para la conexión con phpMyAdmin (Data.dill)
using MySql.Data.MySqlClient;

namespace Dashboard_Inventarios
{
    public partial class Extraordinarios : Form
    {
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        public string user;
        public string idInventario;
        public Extraordinarios()
        {
            InitializeComponent();
        }

        private void Extraordinarios_Load(object sender, EventArgs e)
        {
            dgvExtraordinario.DataSource = consultasMySQL.verExtraordinario(idInventario);
            dgvExtraordinario.Columns[15].Visible = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExtraordinario.DataSource != null)
                {
                    dgvExtraordinario.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dgvExtraordinario.MultiSelect = true;
                    dgvExtraordinario.SelectAll();

                    DataObject dataObj = dgvExtraordinario.GetClipboardContent();
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
                    rango.NumberFormat = "@";
                    rango.Select();
                    xlWorkSheet.PasteSpecial(rango, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);


                    //  la primera fila en negrita, centrada y con fondo gris
                    Excel.Range fila1 = (Excel.Range)xlWorkSheet.Rows[1];
                    fila1.NumberFormat = "@";
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
                    Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[5, 5];
                    c1.NumberFormat = "@";
                    c1.Select();
                    xlexcel.Cells.Select();
                    xlexcel.Cells.EntireColumn.AutoFit();
                    dgvExtraordinario.ClearSelection();
                    xlexcel.Visible = true;
                    dgvExtraordinario.MultiSelect = false;
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

        private void dgvExtraordinario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en una celda, los datos de esa fila se guardan en variables y luego se envían al Form de Detalle y lo abre
            if (e.RowIndex != -1)
            {
                int ID = Convert.ToInt32(dgvExtraordinario.CurrentRow.Cells[0].Value.ToString());
                string CodigoSAP = dgvExtraordinario.CurrentRow.Cells[1].Value.ToString();
                string Descripcion = dgvExtraordinario.CurrentRow.Cells[2].Value.ToString();
                string coBodega = dgvExtraordinario.CurrentRow.Cells[3].Value.ToString();
                string nombreBodega = dgvExtraordinario.CurrentRow.Cells[4].Value.ToString();
                string uni = dgvExtraordinario.CurrentRow.Cells[5].Value.ToString();
                string empresa = dgvExtraordinario.CurrentRow.Cells[11].Value.ToString();
                string usuario = dgvExtraordinario.CurrentRow.Cells[12].Value.ToString();
                string estado = dgvExtraordinario.CurrentRow.Cells[13].Value.ToString();
                string Fecha = dgvExtraordinario.CurrentRow.Cells[14].Value.ToString();
                string ObservacionesContador = dgvExtraordinario.CurrentRow.Cells[16].Value.ToString();
                string Observaciones = dgvExtraordinario.CurrentRow.Cells[17].Value.ToString();

                //Aveces el valor de conteo físico puede ser null, como los "Sin contar extraordinario", así que para esos casos, cambio el valor de nulll a 0
                Decimal exis;
                if (dgvExtraordinario.CurrentRow.Cells[6].Value.ToString() == "") exis = 0;
                else exis = Convert.ToDecimal(dgvExtraordinario.CurrentRow.Cells[6].Value.ToString());

                Decimal costoPromedio;
                if (dgvExtraordinario.CurrentRow.Cells[7].Value.ToString() == "") costoPromedio = 0;
                else costoPromedio = Convert.ToDecimal(dgvExtraordinario.CurrentRow.Cells[7].Value.ToString());

                Decimal cantidadDiferencia;
                if (dgvExtraordinario.CurrentRow.Cells[9].Value.ToString() == "") cantidadDiferencia = 0;
                else cantidadDiferencia = Convert.ToDecimal(dgvExtraordinario.CurrentRow.Cells[9].Value.ToString());

                Decimal costoDiferencia;
                if (dgvExtraordinario.CurrentRow.Cells[10].Value.ToString() == "") costoDiferencia = 0;
                else costoDiferencia = Convert.ToDecimal(dgvExtraordinario.CurrentRow.Cells[10].Value.ToString());

                Decimal conteoFisico;
                if (dgvExtraordinario.CurrentRow.Cells[8].Value.ToString() == "") conteoFisico = 0; /*Si es null lo cambio a cero*/
                else conteoFisico = Convert.ToDecimal(dgvExtraordinario.CurrentRow.Cells[8].Value.ToString());/*Si no es null, lo dejo como estaba*/

                //Abre la ventana con los datos que le mandé
                Detalle_Inventario dtInv = new Detalle_Inventario(ID, Descripcion, CodigoSAP, coBodega, nombreBodega, uni, exis, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, Fecha, true, user, Observaciones, ObservacionesContador);
                dtInv.Show();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            dgvExtraordinario.DataSource = consultasMySQL.verExtraordinario(idInventario);
            dgvExtraordinario.Columns[15].Visible = false;
        }
    }
}
