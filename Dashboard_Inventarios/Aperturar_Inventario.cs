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
    public partial class Aperturar_Inventario : Form
    {
        #region Variables
        //---------------------------------------- Variables ------------------------------------------------//
        public string nombre_usuario;
        public int nivel_de_privilegio;
        public bool dashBoard;
        public string ip;
        public bool inventario_local;
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        
        //Si va a crear un invenario que indique de que categoria será
        int idCategoria = 0;
        //------------------------------------- -------------------------- -------------------------------------//
        #endregion
        #region Load
        public Aperturar_Inventario()
        {
            InitializeComponent();
        }

        private void Aperturar_Inventario_Load(object sender, EventArgs e)
        {
            consultasMySQL.obtenerConf();
            llenarEmpresa();
            llenarCategoria();
            llenarBodega();
            if (nivel_de_privilegio == 3)
            {
                cmbCategoria.DataSource = null;
                cmbCategoria.Items.Clear();

                DataTable categoria = consultasMySQL.aleatorio();
                cmbCategoria.DataSource = categoria;
                cmbCategoria.ValueMember = "idCategoria";
                cmbCategoria.DisplayMember = "nombre";
            }
        }
        #endregion
        #region llenarCategoria
        private void llenarCategoria()
        {
            //Hago consultas para traer DataTables par llenar los ComboBox
            DataTable categoria = consultasMySQL.llenarCategoria();
            DataTable categoriaLocal = consultasMySQL.llenarCategoriaLocal();
            if(inventario_local == true)
            {
                cmbCategoria.DataSource = categoriaLocal;
            }
            else
            {
                cmbCategoria.DataSource = categoria;
            }
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DisplayMember = "nombre";
        }
        #endregion
        #region llenarEmpresa
        private void llenarEmpresa()
        {
            //Hago consultas para traer DataTables par llenar los ComboBox
            DataTable empresa = consultasMySQL.llenarEmpresa();
            DataTable empresaLocal = consultasMySQL.llenarEmpresaLocal();
            if(inventario_local == true)
            {
                cmbEmpresa.DataSource = empresaLocal;
            } else
            {
                cmbEmpresa.DataSource = empresa;
            }
            cmbEmpresa.ValueMember = "idEmpresa";
            cmbEmpresa.DisplayMember = "nombre";
        }
        #endregion
        #region aperturar Una Empresa
        private void btnUna_Click(object sender, EventArgs e)
        {
            cmbEmpresa.Visible = true;
            label10.Visible = true;
            btnMas.Enabled = false;
            btnAperturar.Visible = true;
        }
        #endregion
        #region Aperturar
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un elemento del Listado", "Opción incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(Form1))
                    {
                        frm.Hide();
                    }
                }
                Form1 form1 = new Form1();
                form1.user = nombre_usuario;
                form1.aperturar = true;
                form1.empresaApertura = cmbEmpresa.Text;
                form1.idInventario = "";
                form1.idCategoria = idCategoria;
                form1.nombre_del_inventario = txtInventario.Text;
                if (cmbBodega.SelectedValue.ToString() != "AMBAS")
                {
                    form1.codigoBod1 = cmbBodega.SelectedValue.ToString();
                    form1.codigoBod2 = cmbBodega.SelectedValue.ToString();
                }
                else
                {
                    form1.codigoBod1 = "06";
                    form1.codigoBod2 = "02";
                }
                form1.Show();
                Hide();
        }
        #endregion
        #region aperturar todas las empresas
        private void btnMas_Click(object sender, EventArgs e)
        {
            if (cmbEmpresa.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un elemento del Listado", "Opción incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.GetType() == typeof(Form1))
                    {
                        frm.Hide();
                    }
                }
                Form1 form1 = new Form1();
                form1.user = nombre_usuario;
                form1.aperturar = true;
                form1.empresaApertura = "Econsa";
                form1.idInventario = "";
                form1.idCategoria = idCategoria;
                form1.nombre_del_inventario = txtInventario.Text;
                if (cmbBodega.SelectedValue.ToString() != "AMBAS")
                {
                    form1.codigoBod1 = cmbBodega.SelectedValue.ToString();
                    form1.codigoBod2 = cmbBodega.SelectedValue.ToString();
                }
                else
                {
                    form1.codigoBod1 = "06";
                    form1.codigoBod2 = "02";
                }
                form1.Show();
                Hide();
            }
        }
        #endregion
        #region Elegir Categoria
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            if(cmbCategoria.SelectedIndex != -1)
            {
                idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue.ToString());

                if (cmbCategoria.SelectedIndex == 0)
                {
                    txtInventario.Visible = true;
                    lbInventario.Visible = true;
                    btnInventario.Visible = true;
                }
                else if (cmbCategoria.SelectedIndex == 1)
                {
                    btnInventario.Visible = true;
                    lbInventario.Visible = true;
                    txtInventario.Visible = true;
                }
                else if (idCategoria == 4)
                {
                    btnInventario.Visible = true;
                    lbInventario.Visible = true;
                    txtInventario.Visible = true;
                }
                label2.Visible = false;
                cmbCategoria.Visible = false;
                btnCategoria.Visible = false;
            }
        }
        #endregion
        #region botón atras
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (btnMas.Enabled == false)
            {
                cmbEmpresa.Visible = false;
                label10.Visible = false;
                btnMas.Enabled = true;
                btnAperturar.Visible = false;
            }
            else if (btnUna.Visible == true)
            {
                btnBodega.Visible = true;
                cmbBodega.Visible = true;
                lbBodega.Visible = true;
                btnUna.Visible = false;
                btnMas.Visible = false;
            }
            else if (btnBodega.Visible == true)
            {
                btnInventario.Visible = true;
                txtInventario.Visible = true;
                lbInventario.Visible = true;
                btnBodega.Visible = false;
                cmbBodega.Visible = false;
                lbBodega.Visible = false;
            }
            else if (btnInventario.Visible == true)
            {
                idCategoria = 0;
                cmbCategoria.SelectedValue = 1;
                label2.Visible = true;
                cmbCategoria.Visible = true;
                btnCategoria.Visible = true;
                btnInventario.Visible = false;
                txtInventario.Visible = false;
                lbInventario.Visible = false;
            }
            else if (btnMas.Visible == true)
            {
                btnMas.Visible = false;
                btnInventario.Visible = true;
                txtInventario.Visible = true;
                lbInventario.Visible = true;
                btnBodega.Visible = false;
                cmbBodega.Visible = false;
                lbBodega.Visible = false;
            }
            else if (btnCategoria.Visible == true)
            {
                Hide();
            }
        }
        #endregion
        #region cerrar formulario
        private void Aperturar_Inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        #endregion
        #region btnInventario Click
        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (txtInventario.Text == "")
            {
                MessageBox.Show("Escriba el nombre del inventario para continuar");
            }
            else
            {
                if (consultasMySQL.verificarInventario(txtInventario.Text))
                {
                    MessageBox.Show("Este nombre ya está siendo utilizado por otro inventario, Elija otro nombre para aperturarlo ", "Nombre no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(inventario_local == true)
                    {
                        btnLocal.Visible = true;
                        btnLocal.Location = new Point(328, 114);
                    }
                    else if (cmbCategoria.SelectedIndex == 0)
                    {
                        lbBodega.Visible = true;
                        cmbBodega.Visible = true;
                        btnBodega.Visible = true;
                    }
                    else if (cmbCategoria.SelectedIndex == 1)
                    {
                        btnMas.Visible = true;
                        btnMas.Location = new Point(328, 114);
                    }
                    if (idCategoria == 4)
                    {
                        Seleccionar_Bodega seleccionar = new Seleccionar_Bodega();
                        seleccionar.inventario = txtInventario.Text;
                        seleccionar.nombre_usuario = nombre_usuario;
                        seleccionar.ip = ip;
                        seleccionar.Show();
                        Close();
                    }
                    btnInventario.Visible = false;
                    txtInventario.Visible = false;
                    lbInventario.Visible = false;
                }
            }
        }
        #endregion
        #region Bodega
        public void llenarBodega()
        {
            Dictionary<string, string> bodega = new Dictionary<string, string>();
            bodega.Add("02", "02 - BODEGA MATERIA PRIMA");
            bodega.Add("06", "06 - BODEGA PRODUCTO TERMINADO");
            bodega.Add("AMBAS", "ELEGIR AMBAS BODEGAS");
            DataTable bodegaLocal = consultasMySQL.llenarBodegaLocal();
            if(inventario_local == true)
            {
                cmbBodega.DataSource = bodegaLocal;
                cmbBodega.DisplayMember = "nombre";
                cmbBodega.ValueMember = "idBodega";
            } else
            {
            cmbBodega.DataSource = new BindingSource(bodega, null);
            cmbBodega.DisplayMember = "Value";
            cmbBodega.ValueMember = "Key";
            }
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            if(cmbBodega.SelectedIndex != -1)
            {
                if (cmbCategoria.Text == "General")
                {
                    btnUna.Visible = false;
                    btnMas.Location = new Point(328, 114);
                }
                else
                {
                    btnUna.Visible = true;
                    btnMas.Location = new Point(453, 114);
                }
                btnMas.Visible = true;
                btnBodega.Visible = false;
                cmbBodega.Visible = false;
                lbBodega.Visible = false;
            }
            else
            {
                MessageBox.Show("Elija una bodega", "Bodega Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region Click Boton Inventario Local
        private void btnLocal_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(Inventario_Local))
                {
                    frm.Hide();
                }
            }
            Inventario_Local inventario_Local = new Inventario_Local();
            inventario_Local.user = nombre_usuario;
            inventario_Local.aperturar = true;
            inventario_Local.empresaApertura = "test";
            inventario_Local.idInventario = "";
            inventario_Local.idCategoria = idCategoria;
            inventario_Local.nombre_del_inventario = txtInventario.Text;
            inventario_Local.Show();
            Close();
        }
        #endregion
    }
}
