using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dashboard_Inventarios
{
    public partial class Data_Historial : Form
    {
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        //Variable ID que se usa para mandar a buscar todo el historial que contenga idEtiqueta = ID
        int ID;
        string user;
        public Data_Historial(int ID, string empresa, string user)
        {
            InitializeComponent();
            this.ID = ID;
            this.user = user;
            if (empresa == "Unhesa")
            {
                BackgroundImage = Image.FromFile("fondo5.png");
            }
            else
            {
                BackgroundImage = Image.FromFile("fondo4.png");
            }
        }

        private void Data_Historial_Load(object sender, EventArgs e)
        {
            ViewH();
            dgvInventario.Columns[15].Visible = false;
        }
        public void ViewH()
        {
            //Muestro todos los inventario de historial dependiendo del inventario que quiero ver
            DataTable dtbInventario = consultasMySQL.verHistorial(ID);
            dgvInventario.DataSource = dtbInventario;
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                int ID = Convert.ToInt32(dgvInventario.CurrentRow.Cells[0].Value.ToString());
                string descripcion = dgvInventario.CurrentRow.Cells[1].Value.ToString();
                string codigoSAP = dgvInventario.CurrentRow.Cells[2].Value.ToString();
                string unidadMedida = dgvInventario.CurrentRow.Cells[3].Value.ToString();
                string codigoBodega = dgvInventario.CurrentRow.Cells[4].Value.ToString();
                string nombreBodega = dgvInventario.CurrentRow.Cells[5].Value.ToString();
                Decimal existenciaSAP = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[6].Value.ToString());
                Decimal costoPromedio = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[7].Value.ToString());
                Decimal cantidadDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[9].Value.ToString());
                Decimal costoDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[10].Value.ToString());
                string usuario = dgvInventario.CurrentRow.Cells[11].Value.ToString();
                string empresa = dgvInventario.CurrentRow.Cells[12].Value.ToString();
                string fechaActualización = dgvInventario.CurrentRow.Cells[13].Value.ToString();
                string estado = "";
                string ObservacionesContador = dgvInventario.CurrentRow.Cells[16].Value.ToString();
                string observacion = dgvInventario.CurrentRow.Cells[17].Value.ToString();
                Decimal conteoFisico;
                //A veces el conteo fisico en null y eso debo cambiarlo a 0 para enviarlo al Detalle_Inventario
                if (dgvInventario.CurrentRow.Cells[8].Value.ToString() == "")
                {
                    conteoFisico = 0;
                }
                else
                {
                    conteoFisico = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[8].Value.ToString());
                }

                Detalle_Inventario dtInv = new Detalle_Inventario(ID, descripcion, codigoSAP, codigoBodega, nombreBodega, unidadMedida, existenciaSAP, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, fechaActualización, false, user, observacion, ObservacionesContador);
                dtInv.ShowDialog();
                ViewH();
                dgvInventario.Columns[15].Visible = false;
            }
        }

        private void dgvInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                int ID = Convert.ToInt32(dgvInventario.CurrentRow.Cells[0].Value.ToString());
                string descripcion = dgvInventario.CurrentRow.Cells[1].Value.ToString();
                string codigoSAP = dgvInventario.CurrentRow.Cells[2].Value.ToString();
                string unidadMedida = dgvInventario.CurrentRow.Cells[3].Value.ToString();
                string codigoBodega = dgvInventario.CurrentRow.Cells[4].Value.ToString();
                string nombreBodega = dgvInventario.CurrentRow.Cells[5].Value.ToString();
                Decimal existenciaSAP = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[6].Value.ToString());
                Decimal costoPromedio = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[7].Value.ToString());
                Decimal cantidadDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[9].Value.ToString());
                Decimal costoDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[10].Value.ToString());
                string usuario = dgvInventario.CurrentRow.Cells[11].Value.ToString();
                string empresa = dgvInventario.CurrentRow.Cells[12].Value.ToString();
                string fechaActualización = dgvInventario.CurrentRow.Cells[13].Value.ToString();
                string estado = "";
                string ObservacionesContador = dgvInventario.CurrentRow.Cells[16].Value.ToString();
                string observacion = dgvInventario.CurrentRow.Cells[17].Value.ToString();
                Decimal conteoFisico;
                //A veces el conteo fisico en null y eso debo cambiarlo a 0 para enviarlo al Detalle_Inventario
                if (dgvInventario.CurrentRow.Cells[8].Value.ToString() == "")
                {
                    conteoFisico = 0;
                }
                else
                {
                    conteoFisico = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[8].Value.ToString());
                }

                Detalle_Inventario dtInv = new Detalle_Inventario(ID, descripcion, codigoSAP, codigoBodega, nombreBodega, unidadMedida, existenciaSAP, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, fechaActualización, false, user, observacion, ObservacionesContador);
                dtInv.ShowDialog();
                ViewH();
                dgvInventario.Columns[15].Visible = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventario.DataSource != null)
                {
                    dgvInventario.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dgvInventario.MultiSelect = true;
                    dgvInventario.SelectAll();
                    DataObject dataObj = dgvInventario.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    Microsoft.Office.Interop.Excel.Application xlexcel;
                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
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
                    dgvInventario.ClearSelection();
                    dgvInventario.MultiSelect = false;
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
