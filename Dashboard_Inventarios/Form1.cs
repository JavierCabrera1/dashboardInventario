using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Office;
using Excel = Microsoft.Office.Interop.Excel;
//Uso de la librería de MySql para la conexión con phpMyAdmin (Data.dill)
using MySql.Data.MySqlClient;

namespace Dashboard_Inventarios
{
    public partial class Form1 : Form
    {
        #region Variables
        //Es una clase que hace todas las consultas a phpMyAdmin MySQL para esta clase y otras del proyecto
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
    
        //Variable que guarda la DataTable de la consulta de verEtiqueta(), esto para que todos los filtro funciones con una sola llamada
        DataTable TableInventario = new DataTable();

        //Array que llenan la cantidad de contados en UNHESA y PROQUIMA
        ArrayList contadosUNHESA = new ArrayList();
        ArrayList contadosProquima = new ArrayList();
        ArrayList contadosECONSA = new ArrayList();
        ArrayList contadoYnoContado = new ArrayList();

        //Total, contados y no contados salen de las consultas a los procedimientos que hago, nocontados sale de la resta de las consultas U (Unhesa), P (proquima)
        int totalP;
        int contadosP;
        int nocontadosP;
        
        int totalU;
        int contadosU;
        int nocontadosU;

        public int idCategoria;
        public bool aperturar;
        public string empresaApertura;
        public string idInventario;
        public string nombre_del_inventario;
        public string codigoBod1;
        public string codigoBod2;

        //el usuario que ingresa a la app
        public string user;
        #endregion
        #region Bienvenida y primeros procesos
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultasMySQL.obtenerConf();
            //Bienvenida al Usuario
            lbUser.Text = ("Bienvenido " + user);
            btnRefrescar_Click(sender, e);
            privilegios();
            llenarCombox();
            cmbEmpresa.Text = "";
            cmbBodega.Text = "";
            cmbEstado.Text = "";
            casosCombo();
            if(user == "Jimenez Sosa Luis Eduardo")
            {
                btnLuis.Visible = true;
                dgvLuis.DataSource = consultasMySQL.verLuis(idInventario);
            }
            if (btnFinalizar.Text == "Aperturar Inventario")
            {
                btnPausa.Enabled = false;
            }
            else
            {
                btnPausa.Enabled = true;
            }
        }
        #endregion
        #region Privilegios
        //------------------------------------------------------Dependiendo de si el usuario tiene privilegios o no se desencadena una serie consecuencias--------------------------------------------------------//
        private void privilegios()
        {
            lbInventario.Text = consultasMySQL.nombreInventario(idInventario);
            if (consultasMySQL.verificarAdmin(user) == "1")
            {
                btnFinalizar.Visible = true;
            }
            if (consultasMySQL.verificarAdmin(user) == "3")
            {
                if (consultasMySQL.categoriaInventario(lbInventario.Text) == "1")
                {
                    btnFinalizar.Visible = true;
                }
            }
            if(aperturar == true)
            {
                lbInventario.Text = nombre_del_inventario;
                switch (empresaApertura)
                {
                    case "Econsa":
                        if (idCategoria == 2)
                        {
                            //Select Listo
                            TableInventario = consultasMySQL.mostrarAperturaEconsa();
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                            lbInventario.Text = nombre_del_inventario;
                        }
                        else
                        {
                            //Insert Listo
                            string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                            consultasMySQL.insertInventario(nombre_del_inventario, idUsuario, Hora_Inicio, idCategoria.ToString(), "10");
                            idInventario = consultasMySQL.idInventario();

                            consultasMySQL.insertarAleatoriosProquima(idInventario, "2", codigoBod1, codigoBod2);
                            consultasMySQL.insertarAleatoriosUnhesa(idInventario, "1", codigoBod1, codigoBod2);

                            TableInventario = consultasMySQL.VerEtiqueta(idInventario);
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                        }
                        break;
                    case "Unhesa":
                        if(idCategoria == 2)
                        {
                            //Select Lito
                            TableInventario = consultasMySQL.mostrarAperturaUnhesa();
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                            lbInventario.Text = nombre_del_inventario;
                        }
                        else
                        {
                            //Insert Listo
                            string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                            consultasMySQL.insertInventario(nombre_del_inventario, idUsuario, Hora_Inicio, idCategoria.ToString(), "10");
                            idInventario = consultasMySQL.idInventario();

                            consultasMySQL.insertarAleatoriosUnhesa(idInventario, "1", codigoBod1, codigoBod2);
                            TableInventario = consultasMySQL.VerEtiqueta(idInventario);
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                        }
                        break;
                    case "Proquima":
                        if(idCategoria == 2)
                        {
                            //Select Listo
                            TableInventario = consultasMySQL.mostrarAperturaProquima();
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                            lbInventario.Text = nombre_del_inventario;
                        }
                        else
                        {
                            //Insert Listo
                            string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                            consultasMySQL.insertInventario(nombre_del_inventario, idUsuario, Hora_Inicio, idCategoria.ToString(), "10");
                            idInventario = consultasMySQL.idInventario();

                            consultasMySQL.insertarAleatoriosProquima(idInventario, "2", codigoBod1, codigoBod2);
                            TableInventario = consultasMySQL.VerEtiqueta(idInventario);
                            dgvInventario.DataSource = TableInventario;
                            GridFill();
                        }
                        break;
                }
                btnFinalizar.Visible = true;
                btnFinalizar.Text = "Aperturar Inventario";
                btnNuevoInventario.Text = "Cancelar";
                dgvInventario.Enabled = false;
                dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                dgvInventario.DefaultCellStyle.BackColor = Color.Gainsboro;
                cmbEmpresa.Enabled = false;
                cmbBodega.Enabled = false;
                cmbEstado.Enabled = false;
                btnRefrescar.Enabled = false;
                lbFecha.Enabled = false;
                btnExcel.Enabled = false;
            }
            else
            {
                btnNuevoInventario.Visible = false;
                btnFinalizar.Location = new Point(381, 651);
                lbInventario.Location = new Point(540, 655);
                if (btnFinalizar.Visible == false)
                {
                    lbInventario.Location = new Point(405, 654);
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Timer cada 3 minutos
            //---------------------------------------------------------------------Cada 3 minutos se ejecuta el timer---------------------------------------------------------//
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cada 3 minutos actualiza
            btnRefrescar_Click(sender, e);
        }
        public void CapturarFechaActual()
        {
            //Captura la fecha y hora actual y la muestra en el label de Fecha
            lbFecha.Text = "Última Actualización a las: "+ DateTime.Now.ToLongTimeString();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Ver en el DashBoard la Data (VerEtiqueta)
        //---------------------------------------------------------------------------Hace Consultas a la Base de Datos para traer todos los inventarios---------------------------------------------------------------------------------------//
        public void VerEtiqueta()
        {
            if(aperturar == false)
            {
                if(idInventario == "")
                {
                    idInventario = consultasMySQL.idInventario();
                }
                lbInventario.Text = consultasMySQL.nombreInventario(idInventario);
                TableInventario = consultasMySQL.VerEtiqueta(idInventario);
                dgvInventario.DataSource = TableInventario;
                GridFill();
                if (consultasMySQL.InventarioFinalizado(idInventario))
                {
                    dgvInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
                    dgvInventario.DefaultCellStyle.BackColor = Color.Gainsboro;
                    txtBuscarId.Enabled = false;
                    cmbEmpresa.Enabled = false;
                    cmbBodega.Enabled = false;
                    cmbEstado.Enabled = false;
                    btnRefrescar.Enabled = false;
                    btnFinalizar.Enabled = false;
                    lbCountEconsa.Enabled = false;
                    lbNoCountEconsa.Enabled = false;
                    lbCountProquima.Enabled = false;
                    lbNoCountProquima.Enabled = false;
                    lbCountUnhesa.Enabled = false;
                    lbNoCountUnhesa.Enabled = false;
                }
                if (consultasMySQL.InventarioPausado(idInventario))
                {
                    btnPausa.Text = "Reanudar";
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Ordena los inventarios por Valor Absoluto y oculta esa columna (GridFill)
        //---------------------------------Ordena los inventarios por Valor Absoluto y oculta esa columna------------------------------------------------------------//
        public void GridFill()
        {
            //Ocultar Valor Absoluto
            dgvInventario.Columns[15].Visible = false;
            //Ordenar la tabla según el valor Absoluto
            dgvInventario.Sort(dgvInventario.Columns[15], ListSortDirection.Descending);
            dgvInventario.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvInventario.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventario.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botón Refrescar
        //-----------------------------------------------------------------------Cada vez que dan click llama al método refrescar------------------------------------------------------------------------//

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            refrescar();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Método Refrescar
        //-----------------------------------------------------Cada vez que refresca, actualiza el DashBoard según sea el caso de los combobox seleccionados------------------------------------//

        public void refrescar()
        {
            VerEtiqueta();
            CapturarFechaActual();
            DashBoardUnhesa();
            DashBoardProquima();
            DashBoardECONSA();
            casosCombo();
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Botón excel
        //--------------------------------------------------------------------------------Botón que exporta la data del dgvInventario a una hoja de Excel----------------------------------------------------------------------------------//

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
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//

        #endregion
        #region Detalle Inventario
        //--------------------------------------------------------------------------------Cada vez que dan doble click a una celda abre el detalle de ese inventario----------------------------------------------------------------------------------//

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en una celda, los datos de esa fila se guardan en variables y luego se envían al Form de Detalle y lo abre
            if (e.RowIndex != -1)
            {
                int ID = Convert.ToInt32(dgvInventario.CurrentRow.Cells[0].Value.ToString());
                string CodigoSAP = dgvInventario.CurrentRow.Cells[1].Value.ToString();
                string Descripcion = dgvInventario.CurrentRow.Cells[2].Value.ToString();
                string coBodega = dgvInventario.CurrentRow.Cells[3].Value.ToString();
                string nombreBodega = dgvInventario.CurrentRow.Cells[4].Value.ToString();
                string uni = dgvInventario.CurrentRow.Cells[5].Value.ToString();
                string empresa = dgvInventario.CurrentRow.Cells[11].Value.ToString();
                string usuario = dgvInventario.CurrentRow.Cells[12].Value.ToString();
                string estado = dgvInventario.CurrentRow.Cells[13].Value.ToString();
                string Fecha = dgvInventario.CurrentRow.Cells[14].Value.ToString();
                string ObservacionesContador = dgvInventario.CurrentRow.Cells[16].Value.ToString();
                string Observaciones = dgvInventario.CurrentRow.Cells[17].Value.ToString();

                //Aveces el valor de conteo físico puede ser null, como los "Sin contar extraordinario", así que para esos casos, cambio el valor de nulll a 0
                Decimal exis;
                if (dgvInventario.CurrentRow.Cells[6].Value.ToString() == "") exis = 0;
                else exis = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[6].Value.ToString());

                Decimal costoPromedio;
                if (dgvInventario.CurrentRow.Cells[7].Value.ToString() == "") costoPromedio = 0;
                else costoPromedio = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[7].Value.ToString());

                Decimal cantidadDiferencia;
                if (dgvInventario.CurrentRow.Cells[9].Value.ToString() == "") cantidadDiferencia = 0;
                else cantidadDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[9].Value.ToString());

                Decimal costoDiferencia;
                if (dgvInventario.CurrentRow.Cells[10].Value.ToString() == "") costoDiferencia = 0;
                else costoDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[10].Value.ToString());

                Decimal conteoFisico;
                if (dgvInventario.CurrentRow.Cells[8].Value.ToString() == "") conteoFisico = 0; /*Si es null lo cambio a cero*/
                else conteoFisico = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[8].Value.ToString());/*Si no es null, lo dejo como estaba*/

                //Abre la ventana con los datos que le mandé
                Detalle_Inventario dtInv = new Detalle_Inventario(ID, Descripcion, CodigoSAP, coBodega, nombreBodega, uni, exis, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, Fecha, true, user, Observaciones, ObservacionesContador);
                dtInv.Show();
            }
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region DashBoard de Unhesa
        //------------Para el dasboard de Unhesa filtro el datatable que mando a llamar en el inicio de la aplicación, así solo hago 1 consulta-----------------------//
        public void DashBoardUnhesa()
        {
            //Los array empiezan en blanco, ya que a la hora de refrescar se llenan con nuevos datos
            contadoYnoContado.Clear();
            contadosUNHESA.Clear();

            //Cuento cuantos contados hay en Unhesa y los asigno a la variable contadosU que será usado para el dashboard del proyecto (Cuento Cuantos Contados XD)
            contadosU = contarContados("Unhesa");
            
            //en total solo filtro por empresa, no importa si están contados o no
            totalU = contarTotal("Unhesa");
           
            //Operación que guarda en No contados el total - los contados
            nocontadosU = Convert.ToInt32(totalU) - contadosU;
            //El nombre de las variables que seran igualadas a las consultas
            contadoYnoContado.Add("Contados");
            contadoYnoContado.Add("No Contados");
            //Los Array Guardan los COUNT de contados y nocontados
            contadosUNHESA.Add(contadosU);
            contadosUNHESA.Add(nocontadosU);
            //El chart (DashBoard) manda los datos de los array para mostrarlos en gráfica
            chtUnhesa.Series[0].Points.DataBindXY(contadoYnoContado, contadosUNHESA);

            if (totalU > 0)
            {
                //Operación(Solo es una regla de tres) que saca el porcentaje de revisiones que lleva la base de datos (valores sacados del Back y no hay consultas)
                lbUnhesa.Text = Convert.ToString(Convert.ToDecimal((Convert.ToInt32(contadosU) * 100) / Convert.ToInt32(totalU))) + "%";
            }
            else
            {
                lbUnhesa.Text = "0%";
            }
            lbCountUnhesa.Text = ("Contados: " + contadosU);
            lbNoCountUnhesa.Text = ("No Contados: " + nocontadosU);
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region DashBoard Proquima
        //------------------------------------------------------Hago lo mismo que en Unhesa para filtrar en Proquima-------------------------------------------------//
        public void DashBoardProquima()
        {
            //Los array empiezan en blanco, ya que a la hora de refrescar se llenan con nuevos datos y hay que cambiarlos por los que tenían
            contadoYnoContado.Clear();
            contadosProquima.Clear();

            //Cuento cuantos contados hay en Proquima y los asigno a la variable contadosP que será usado para el dashboard del proyecto
            contadosP = contarContados("Proquima");

            //igual para total
            totalP = contarTotal("Proquima");

            //Operación que guarda en No contados el total - los contados
            nocontadosP = Convert.ToInt32(totalP) - Convert.ToInt32(contadosP);

            //El nombre de las variables que seran igualadas a las consultas
            contadoYnoContado.Add("Contados");
            contadoYnoContado.Add("No Contados");

            //Los Array Guardan los COUNT de contados y nocontados
            contadosProquima.Add(contadosP);
            contadosProquima.Add(nocontadosP);

            //El chart (DashBoard) manda los datos de los array para mostrarlos en gráfica
            chtProquima.Series[0].Points.DataBindXY(contadoYnoContado, contadosProquima);

            if (totalP > 0)
            {
                //Operación(Solo es una regla de tres) que saca el porcentaje de revisiones que lleva la base de datos (valores sacados del Back y no hay consultas)
                lbProquima.Text = Convert.ToString(Convert.ToDecimal((Convert.ToInt32(contadosP) * 100) / Convert.ToInt32(totalP))) + "%";
            }
            else
            {
                lbProquima.Text = "0%";
            }
            lbCountProquima.Text = ("Contados: " + contadosP);
            lbNoCountProquima.Text = ("No Contados: " + nocontadosP);
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region DashBoard Econsa
        //-Sumo los resultados de la suma de Unhesa y Proquima y los resultados de Total Unhesa y Total Proquima y de allí es de donde saco la las variables ContadosEconsa, TotalEconsa y noContadosEconsa-//
        public void DashBoardECONSA()
        {
            contadoYnoContado.Clear();
            contadosECONSA.Clear();
            int RevECONSA;
            int NoRevECONSA;
            int TotalECONSA;
            TotalECONSA = (Convert.ToInt32(totalP) + Convert.ToInt32(totalU));
            RevECONSA = (Convert.ToInt32(contadosP) + Convert.ToInt32(contadosU));
            NoRevECONSA = (TotalECONSA - RevECONSA);
            contadoYnoContado.Add("Contados");
            contadoYnoContado.Add("No Contados");
            contadosECONSA.Add(RevECONSA);
            contadosECONSA.Add(NoRevECONSA);
            chtTotal.Series[0].Points.DataBindXY(contadoYnoContado, contadosECONSA);
            if(TotalECONSA > 0)
            {
                lbTotal.Text = Convert.ToString(Convert.ToDecimal((Convert.ToInt32(RevECONSA) * 100) / Convert.ToInt32(TotalECONSA))) + "%";
            }
            else
            {
                lbTotal.Text = "0%";
            }
            lbCountEconsa.Text = ("Contados: " + RevECONSA);
            lbNoCountEconsa.Text = ("No Contados: " + NoRevECONSA);
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Creditos ;)
        //--------------------------------------------------------------------------------Thank´s for playing----------------------------------------------------------------------------------//
        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por Harim Palma, Jonathan Guerra Y Oscar Felipe. Agradecimientos Especiales a Luis Jimenez, Walter Mendez, Juan Andrés Mendez, Fernando Moreno, Rony Rodas.", "Informática 2020", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //----------------------------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Botón para Cerrar Sesión
        //------------------------------------------------------------------------- Cerrar Sesión ----------------------------------------------------------------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el DashBoard principal?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Hide();
            }
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Llena los ComboBox de Empresa y Estado, (los de bodega están quemados en código)
        //----------------------------------------------------Llena los ComboBox de Empresa y Estado por medio de consultas--------------------------------------------------------------//

        public void llenarCombox()
        {
            //Hago consultas para traer DataTables par llenar los ComboBox
            DataTable empresa = consultasMySQL.llenarEmpresa();
            cmbEmpresa.DataSource = empresa;
            cmbEmpresa.ValueMember = "idEmpresa";
            cmbEmpresa.DisplayMember = "nombre";

            DataTable estado = consultasMySQL.llenarEstado();
            cmbEstado.DataSource = estado;
            cmbEstado.ValueMember = "idEstado";
            cmbEstado.DisplayMember = "nombre";

            Bodega();
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
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
            bodega.Add("31", "31 - BODEGA CALIDADES");
            bodega.Add("35", "35 - BODEGA CALIDADES II");
            bodega.Add("36", "36 - BODEGA TRANSITO (BODEGA-PRODUCCION)");
            bodega.Add("37", "37 - BODEGA CONSIGNACION FILTROS");
            bodega.Add("99", "99 - BODEGA PRODUCTO PT MAL ESTADO DEST");

            cmbBodega.DataSource = new BindingSource(bodega, null);
            cmbBodega.DisplayMember = "Value";
            cmbBodega.ValueMember = "Key";
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region ComboBox´s Text_Changed
        //--------------------------------------Cada vez que el texto de un comboBox cambia se ejecutan estos eventos---------------------------------------------//
        private void cmbEmpresa_TextChanged(object sender, EventArgs e)
        {
            casosCombo();
        }

        private void cmbBodega_TextChanged(object sender, EventArgs e)
        {
            casosCombo();
        }

        private void cmbEstado_TextChanged(object sender, EventArgs e)
        {
            casosCombo();
        }
        private void txtBuscarId_TextChanged(object sender, EventArgs e)
        {
            casosCombo();
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Casos Combo 2^3 depende de el contenido de los ComboBox y manda a llamar el método switchComboBox
        //---------------------------------Estos casos hacen referencia a si lo que se filtra(Empresa, Bodega, Estado) 2^3-----------------------------------------//
        public void casosCombo()
        {
            
            if (cmbEmpresa.Text != "" && cmbBodega.Text == "" && cmbEstado.Text == "")
            {
                switchComboBox("empresa");
            }
            if (cmbEmpresa.Text == "" && cmbBodega.Text != "" && cmbEstado.Text == "")
            {
                switchComboBox("bodega");
            }
            if (cmbEmpresa.Text == "" && cmbBodega.Text == "" && cmbEstado.Text != "")
            {
                switchComboBox("estado");
            }
            if (cmbEmpresa.Text != "" && cmbBodega.Text != "" && cmbEstado.Text == "")
            {
                switchComboBox("empresaBodega");
            }
            if (cmbEmpresa.Text != "" && cmbBodega.Text == "" && cmbEstado.Text != "")
            {
                switchComboBox("empresaEstado");
            }
            if (cmbEmpresa.Text == "" && cmbBodega.Text != "" && cmbEstado.Text != "")
            {
                switchComboBox("bodegaEstado");
            }
            if (cmbEmpresa.Text != "" && cmbBodega.Text != "" && cmbEstado.Text != "")
            {
                switchComboBox("empresaBodegaEstado");
            }
            if (cmbEmpresa.Text == "" && cmbBodega.Text == "" && cmbEstado.Text == "")
            {
                if (aperturar == false)
                {
                    dgvInventario.DataSource = TableInventario;
                    GridFill();
                }
            }
            if (txtBuscarId.Text != "")
            {
                DataTable filtro = new DataTable();

                filtro = nuevaTabla();

                foreach (DataRow row in TableInventario.Rows)
                {
                    if (row["ID"].ToString() == txtBuscarId.Text)
                    {
                        asignarDatos(filtro, row);
                    }
                }
                dgvInventario.DataSource = filtro;
                GridFill();
            }
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Método switchComboBox que filtra por un método llamado tal cual "filtrar()"
        //Según el caso se decide que hay que filtrar, pero se filtra de la tabla de la primera consulta verEtiqueta() y ya no se hacen mas consultas, a menos que se actualice o pasen 3 minutos//
        public void switchComboBox(string combinacion)
        {
            switch (combinacion)
            {
                case "empresa":
                    {
                        filtrar("Empresa", cmbEmpresa.Text, "", "", "", "", 1);
                    }
                    break;
                case "bodega":
                    {
                        try
                        {
                            filtrar("Codigo Bodega", cmbBodega.SelectedValue.ToString(), "", "", "", "", 1);
                        }
                        catch
                        {
                            filtrar("Codigo Bodega", cmbBodega.Text, "", "", "", "", 1);
                        }
                    }
                    break;
                case "estado":
                    {
                        filtrar("Estado", cmbEstado.Text, "", "", "", "", 1);
                    }
                    break;
                case "empresaBodega":
                    {
                        try
                        {
                            filtrar("Empresa", cmbEmpresa.Text, "Codigo Bodega", cmbBodega.SelectedValue.ToString(), "", "", 2);
                        }
                        catch
                        {
                            filtrar("Empresa", cmbEmpresa.Text, "Codigo Bodega", cmbBodega.Text, "", "", 2);
                        }
                    }
                    break;
                case "empresaEstado":
                    {
                        filtrar("Empresa", cmbEmpresa.Text, "Estado", cmbEstado.Text, "", "", 2);
                    }
                    break;
                case "bodegaEstado":
                    {
                        try
                        {
                            filtrar("Codigo Bodega", cmbBodega.SelectedValue.ToString(), "Estado", cmbEstado.Text, "", "", 2);
                        }
                        catch
                        {
                            filtrar("Codigo Bodega", cmbBodega.Text, "Estado", cmbEstado.Text, "", "", 2);
                        }
                    }
                    break;
                case "empresaBodegaEstado":
                    {
                        try
                        {
                            filtrar("Empresa", cmbEmpresa.Text, "Codigo Bodega", cmbBodega.SelectedValue.ToString(), "Estado", cmbEstado.Text, 3);
                        }
                        catch
                        {
                            filtrar("Empresa", cmbEmpresa.Text, "Codigo Bodega", cmbBodega.Text, "Estado", cmbEstado.Text, 3);
                        }
                    }
                    break;
            }
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Hover de Labels
        //-----------------------------------------Labels que cambian de color si se pasa el mouse sobre ellos----------------------------------------//
        private void lbCountUnhesa_MouseHover(object sender, EventArgs e)
        {
            lbCountUnhesa.ForeColor = Color.Green; 
        }
        private void lbCountUnhesa_MouseLeave(object sender, EventArgs e)
        {
            lbCountUnhesa.ForeColor = Color.Black;
        }
        private void lbNoCountUnhesa_MouseHover(object sender, EventArgs e)
        {
            lbNoCountUnhesa.ForeColor = Color.Green;
        }
        private void lbNoCountUnhesa_MouseLeave(object sender, EventArgs e)
        {
            lbNoCountUnhesa.ForeColor = Color.Black;
        }
        private void lbCountProquima_MouseHover(object sender, EventArgs e)
        {
            lbCountProquima.ForeColor = Color.Green;
        }
        private void lbCountProquima_MouseLeave(object sender, EventArgs e)
        {
            lbCountProquima.ForeColor = Color.Black;
        }
        private void lbNoCountProquima_MouseHover(object sender, EventArgs e)
        {
            lbNoCountProquima.ForeColor = Color.Green;
        }
        private void lbNoCountProquima_MouseLeave(object sender, EventArgs e)
        {
            lbNoCountProquima.ForeColor = Color.Black;
        }
        private void lbCountEconsa_MouseHover(object sender, EventArgs e)
        {
            lbCountEconsa.ForeColor = Color.Green;
        }
        private void lbCountEconsa_MouseLeave(object sender, EventArgs e)
        {
            lbCountEconsa.ForeColor = Color.Black;
        }
        private void lbNoCountEconsa_MouseHover(object sender, EventArgs e)
        {
            lbNoCountEconsa.ForeColor = Color.Green;
        }
        private void lbNoCountEconsa_MouseLeave(object sender, EventArgs e)
        {
            lbNoCountEconsa.ForeColor = Color.Black;
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Click en Labels de Contados o No Contados que abre (CountView.designer)
        //------------------------------------Si se hace click sobre un label de contados o no contados abre la ventada con el datagrid---------------------------------------------//
        private void lbCountUnhesa_Click(object sender, EventArgs e)
        {
            CountView("Unhesa", "Unhesa", "si");
        }

        private void lbCountProquima_Click(object sender, EventArgs e)
        {
            CountView("Proquima", "Proquima", "si");
        }

        private void lbCountEconsa_Click(object sender, EventArgs e)
        {
            CountView("Unhesa", "Proquima", "si");
        }

        private void lbNoCountProquima_Click(object sender, EventArgs e)
        {
            CountView("Proquima", "Proquima", "no");
        }

        private void lbNoCountUnhesa_Click(object sender, EventArgs e)
        {
            CountView("Unhesa", "Unhesa", "no");
        }

        private void lbNoCountEconsa_Click(object sender, EventArgs e)
        {
            CountView("Unhesa","Proquima","no");
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Método que abre la ventana de (CountView.designer)
        //--------------Metodo que abre la ventana del DataGrid para los contados o no contados (dependiendo de a cual label le dieron click)-----------------------------------//
        public void CountView(string count1, string count2, string contar)
        {
            DataTable dv = new DataTable();
            CountView countV = new CountView();
            countV.TableInventario = TableInventario;
            countV.nombre_usuario = user;
            countV.contar = contar;
            countV.empresa1 = count1;
            countV.empresa2 = count2;
            countV.Show();
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Método de filtrar
        //------------------------------------------------------------------------Filtra según sea el caso de 2^3---------------------------------------------------------//
        public void filtrar(string columna, string valor, string columna2, string valor2, string columna3, string valor3 ,int valores)
        {
            DataTable filtro = new DataTable();

            filtro = nuevaTabla();

            foreach (DataRow row in TableInventario.Rows)
            {
                //si es un solo campo que se filtra
                if (valores == 1)
                {
                    if (row[columna].ToString() == valor)
                    {
                        asignarDatos(filtro, row);
                    }
                }
                //si son 2
                if(valores == 2)
                {
                    if (row[columna].ToString() == valor && row[columna2].ToString() == valor2)
                    {
                        asignarDatos(filtro, row);
                    }
                }
                //si son 3
                if(valores == 3)
                {
                    if (row[columna].ToString() == valor && row[columna2].ToString() == valor2 && row[columna3].ToString() == valor3)
                    {
                        asignarDatos(filtro, row);
                    }
                }
            }
            if(aperturar == false)
            {
                dgvInventario.DataSource = filtro;
                GridFill();
            }
        }
        //-------------------------------------------------------------------------------- ----------------------------------------------------------------------------------//
        #endregion
        #region Método que cuenta Inventarios
        //--------------------------------------------------------------------------------Método que cuenta cuantos Inventarios tienen el estado "Contado, según su empresa" ----------------------------------------------------------------------------------//
        public int contarContados(string empresa)
        {
            //DataTable count va a ser la tabla que contenga el filtrado por empresa
            DataTable count = new DataTable();

            //asigno a count todas las columnas que lleva TableInventario
            count = nuevaTabla();

            //DataRow 'row' contendra todas las filas que tenga TableInventario
            foreach (DataRow row in TableInventario.Rows)
            {
                //Va a filtrar todas las filas que contengan en el campo "Empresa" el valor de la variable 'empresa' que puede ser Unhesa o Proquima
                if (row["Empresa"].ToString() == empresa)
                {
                    //Vuelve a filtrar para obtener solo las filas que ya esten contadas de la empresa ingresada
                    if (row["Estado"].ToString() == "Contado" || row["Estado"].ToString() == "Recontado" || row["Estado"].ToString() == "Contado Extraordinario" || row["Estado"].ToString() == "Recontado Extraordinario")
                    {
                        //Cuando termine de filtrar asignara todas las filas filtradas a count
                        asignarDatos(count, row);
                    }
                }
            }
            //al finalizar este proceso contara todas las filas que tiene count y las retornará
            return count.Rows.Count;
        }
        //------------------------------------------------------------------------------------------ ------------------------------------------------------------------------------------//
        #endregion
        #region Contar el total de Inventarios de una empresa
        //------------------------------------------------------------------------------------------Cuenta cuantos Invenatarios hay en una empresa en específico------------------------------------------------------------------------------------//
        public int contarTotal(string empresa)
        {
            //Hace lo mismo que contar contados pero este no filtra por estado, sino que solo por empresa
            DataTable total = new DataTable();
            total = nuevaTabla();
            foreach (DataRow row in TableInventario.Rows)
            {
                if (row["Empresa"].ToString() == empresa)
                {
                    asignarDatos(total, row);
                }
            }
            return total.Rows.Count;
        }
        //------------------------------------------------------------------------------------------ ------------------------------------------------------------------------------------//
        #endregion
        #region nuevaTabla()
        //------------------------------------------------------------------------------------------Asigna valores filtrados en una nueva tabla que retorna luego ,nuevaTabla() ------------------------------------------------------------------------------------//
        public DataTable nuevaTabla()
        {
            //se asignan todas las columnas de TableInventario a una nueva tabla
            DataTable nuevaTabla = new DataTable();
            nuevaTabla.Columns.Add("ID", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Código SAP");
            nuevaTabla.Columns.Add("Descripción SAP");
            nuevaTabla.Columns.Add("Código Bodega");
            nuevaTabla.Columns.Add("Nombre Bodega");
            nuevaTabla.Columns.Add("Unidad de Medida");
            nuevaTabla.Columns.Add("Existencia SAP", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Costo Promedio", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Conteo Fisico", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Cantidad Diferencia", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Costo Diferencia", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Empresa");
            nuevaTabla.Columns.Add("Usuario");
            nuevaTabla.Columns.Add("Estado");
            nuevaTabla.Columns.Add("Fecha Actualización", Type.GetType("System.DateTime"));
            nuevaTabla.Columns.Add("Costo Diferencia Absoluto", Type.GetType("System.Decimal"));
            nuevaTabla.Columns.Add("Observaciones Contador");
            nuevaTabla.Columns.Add("Observaciones Gerencia");
            //se retorna la tabla para que el metodo que la llamo la use como se deba
            return nuevaTabla;
        }
        //------------------------------------------------------------------------------ --------------------------------------------------------------------------------//
        #endregion
        #region asignarDatos()
        //------------------------------------------------Asigna los datos filtrados a nuevas columnas para que después esas columnas se agregen a una nueva tabla-------------------------------------------------//
        public void asignarDatos(DataTable filtro, DataRow row)
        {
            //Se crea un nuevo DataTable que guarda solo la Data que contiene el filtro de IF
            DataRow datos = null;
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
            //se ingresan todos los valores de las filas filtradas al DataTable
            filtro.Rows.Add(datos);
        }
        //------------------------------------------------------------------------------ --------------------------------------------------------------------------------//
        #endregion
        #region Ver Hallazgos
        //------------------------------------------------------------------------------Botón para ver Hallazgos--------------------------------------------------------------------------------//
        private void button2_Click(object sender, EventArgs e)
        {
            Hallazgos hallazgos = new Hallazgos();
            hallazgos.idInventario = idInventario;
            hallazgos.Show();
        }
        //------------------------------------------------------------------------------ --------------------------------------------------------------------------------//
        #endregion
        #region Finalizar la App
        //------------------------------------------------------------------------------ Si se cierra el formulario, la aplicación se detiene--------------------------------------------------------------------------------//
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        //------------------------------------------------------------------------------ --------------------------------------------------------------------------------//
        #endregion
        #region btnEnter, Detalle Inventario
        //------------------------------------- Cada Vez que den enter en el dgv se abrirá el Detalle dependiendo de que celda esté seleccionada -----------------------------//
        private void dgvInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (int)Keys.Enter)
            {
                int ID = Convert.ToInt32(dgvInventario.CurrentRow.Cells[0].Value.ToString());
                string CodigoSAP = dgvInventario.CurrentRow.Cells[1].Value.ToString();
                string Descripcion = dgvInventario.CurrentRow.Cells[2].Value.ToString();
                string coBodega = dgvInventario.CurrentRow.Cells[3].Value.ToString();
                string nombreBodega = dgvInventario.CurrentRow.Cells[4].Value.ToString();
                string uni = dgvInventario.CurrentRow.Cells[5].Value.ToString();
                string empresa = dgvInventario.CurrentRow.Cells[11].Value.ToString();
                string usuario = dgvInventario.CurrentRow.Cells[12].Value.ToString();
                string estado = dgvInventario.CurrentRow.Cells[13].Value.ToString();
                string Fecha = dgvInventario.CurrentRow.Cells[14].Value.ToString();
                string ObservacionesContador = dgvInventario.CurrentRow.Cells[16].Value.ToString();
                string Observaciones = dgvInventario.CurrentRow.Cells[17].Value.ToString();

                //Aveces el valor de conteo físico puede ser null, como los "Sin contar extraordinario", así que para esos casos, cambio el valor de nulll a 0
                Decimal exis;
                if (dgvInventario.CurrentRow.Cells[6].Value.ToString() == "") exis = 0;
                else exis = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[6].Value.ToString());

                Decimal costoPromedio;
                if (dgvInventario.CurrentRow.Cells[7].Value.ToString() == "") costoPromedio = 0;
                else costoPromedio = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[7].Value.ToString());

                Decimal cantidadDiferencia;
                if (dgvInventario.CurrentRow.Cells[9].Value.ToString() == "") cantidadDiferencia = 0;
                else cantidadDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[9].Value.ToString());

                Decimal costoDiferencia;
                if (dgvInventario.CurrentRow.Cells[10].Value.ToString() == "") costoDiferencia = 0;
                else costoDiferencia = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[10].Value.ToString());

                Decimal conteoFisico;
                if (dgvInventario.CurrentRow.Cells[8].Value.ToString() == "") conteoFisico = 0; /*Si es null lo cambio a cero*/
                else conteoFisico = Convert.ToDecimal(dgvInventario.CurrentRow.Cells[8].Value.ToString());/*Si no es null, lo dejo como estaba*/

                //Abre la ventana con los datos que le mandé
                Detalle_Inventario dtInv = new Detalle_Inventario(ID, Descripcion, CodigoSAP, coBodega, nombreBodega, uni, exis, costoPromedio, conteoFisico, cantidadDiferencia, costoDiferencia, empresa, usuario, estado, Fecha, true, user, Observaciones, ObservacionesContador);
                dtInv.Show();
            }
        }
        //------------------------------------------------------------------------------ --------------------------------------------------------------------------------//
        #endregion
        #region Botón para ver Extraordinarios [btnExtraordinarios_Click()]
        //----------------------------------------------------------------------- Ver Extraordinarios ----------------------------------------------------------------//
        private void btnExtraordinarios_Click(object sender, EventArgs e)
        {
            Extraordinarios ext = new Extraordinarios();
            ext.idInventario = idInventario;
            ext.user = user;
            ext.Show();
        }
        //----------------------------------------------------------------------- ----------------------------------------------------------------//
        #endregion
        #region Botón para ver opciones de inventario [btnNuevoInventario_Click()]
        //----------------------------------------------------------------------- Ver las opciones de Inventario, como buscar o agrega un Inventario ----------------------------------------------------------------//
        private void btnNuevoInventario_Click(object sender, EventArgs e)
        {
            if(btnNuevoInventario.Text == "Inventario")
            {
               
            }
            else
            {
                DialogResult result = MessageBox.Show("Estás segur@ de querer cancelar la apertura de este Inventario?", "Abortar Apertura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.Yes)
                {
                    Carga carga = new Carga();
                    carga.nombre_usuario = user;
                    carga.apertura = false;
                    carga.empresa = "";
                    carga.idInventario = idInventario;
                    carga.Show();
                    Hide();
                }
            }
        }
        //----------------------------------------------------------------------- -----------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Botón para Finalizar Un Inventario o Aperturarlo si está en modo Administrador
        //------------------------------------------------------------------------------------------------------------- Clausura un Inventario -------------------------------------------------------------------------------------//
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (btnFinalizar.Text == "Finalizar Inventario")
            {
                if (consultasMySQL.verificarAdmin(user) == "1" || consultasMySQL.verificarAdmin(user) == "3")
                {
                    DialogResult result = MessageBox.Show("Está seguro de querer finalizar este inventario?", "Finalizar Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if(result == DialogResult.Yes)
                    {
                        if(idInventario == "")
                        {
                            idInventario = consultasMySQL.idInventario();
                        }
                        string Hora_Final = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        consultasMySQL.clausurarInventario(idInventario, Hora_Final);
                        refrescar();
                    }
                }
            }
            else if (btnFinalizar.Text == "Aperturar Inventario")
            {
                DialogResult result = MessageBox.Show("Desea aperturar el inventario, este contara con el alias de " + lbInventario.Text, "Aperturar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if(result == DialogResult.Yes)
                {
                    switch (empresaApertura)
                    {
                        case "Econsa":
                            if (idCategoria == 2)
                            {
                                //Insert Listo
                                string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                                consultasMySQL.insertInventario(lbInventario.Text, idUsuario, Hora_Inicio, idCategoria.ToString(), "9");
                                idInventario = consultasMySQL.idInventario();
                                consultasMySQL.insertarConteosEconsa(idInventario);
                            }
                            else
                            {
                                consultasMySQL.cambiar_Estado_Inventario("9", idInventario);
                            }
                            break;
                        case "Proquima":
                            if(idCategoria == 2)
                            {
                                //Insert Listo
                                string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                                consultasMySQL.insertInventario(lbInventario.Text, idUsuario, Hora_Inicio, idCategoria.ToString(), "9");
                                idInventario = consultasMySQL.idInventario();
                                consultasMySQL.insertarConteosEmpresa(idInventario, "proquima", "2");
                            }
                            else
                            {
                                consultasMySQL.cambiar_Estado_Inventario("9", idInventario);
                            }
                            break;
                        case "Unhesa":
                            if (idCategoria == 2)
                            {
                                //Insert Listo
                                string Hora_Inicio = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                string idUsuario = consultasMySQL.obtenerIdUsuario(user).ToString();
                                consultasMySQL.insertInventario(lbInventario.Text, idUsuario, Hora_Inicio, idCategoria.ToString(), "9");
                                idInventario = consultasMySQL.idInventario();
                                consultasMySQL.insertarConteosEmpresa(idInventario, "unhesa", "1");
                            }
                            else
                            {
                                consultasMySQL.cambiar_Estado_Inventario("9", idInventario);
                            }
                            break;
                    }
                    Carga carga = new Carga();
                    carga.nombre_usuario = user;
                    carga.apertura = false;
                    carga.empresa = "";
                    carga.idInventario = idInventario;
                    carga.Show();
                    Hide();
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------- -------------------------------------------------------------------------------------//
        #endregion
        #region Botón Luis
        //-------------------------------------------------- * Botón para las consultas de Luis Jimenez * -----------------------------------------------------------------//
        private void btnLuis_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLuis.DataSource != null)
                {
                    dgvLuis.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dgvLuis.MultiSelect = true;
                    dgvLuis.SelectAll();
                    DataObject dataObj = dgvLuis.GetClipboardContent();
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
                    dgvLuis.ClearSelection();
                    dgvLuis.MultiSelect = false;
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
        //---------------------------------------------------------------------**-------------------------------------------------------------------------------------//
        #endregion
        #region btn Pausa
        private void btnPausa_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnPausa.Text == "Pausar")
                {
                    if (consultasMySQL.verificarAdmin(user) == "1" || consultasMySQL.verificarAdmin(user) == "3")
                    {
                        DialogResult result = MessageBox.Show("Está seguro de querer pausar este inventario?", "Finalizar Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            timer1.Stop();
                            btnPausa.Text = "Reanudar";
                        }
                    }
                }
                else
                {
                    if (consultasMySQL.verificarAdmin(user) == "1" || consultasMySQL.verificarAdmin(user) == "3")
                    {
                        DialogResult result = MessageBox.Show("Está seguro de querer reanudar este inventario?", "Finalizar Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            timer1.Start();
                            btnPausa.Text = "Pausar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        #endregion
    }
}
