using System;
using System.Data;
using System.Windows.Forms;

namespace Dashboard_Inventarios
{
    public partial class Agregar_Inventario : Form
    {
        #region Varibles
        //------------------------------------- Variables ----------------------------------------//
        public bool atras;
        bool usuario_privilegiado;
        public bool dashBoard;
        public int nivel_de_privilegio;
        public string ip;
        public bool inventario_local;
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();

        //El nombre del usuario y si cuenta con privilegios
        public string nombre_usuario;
        //----------------------------------------------------------------------------------------------//
        #endregion
        #region Load
        public Agregar_Inventario()
        {
            InitializeComponent();
        }

        private void Agregar_Inventario_Load(object sender, EventArgs e)
        {
            if(atras == true)
            {
                btnAtras.Visible = true;
            }
            else
            {
                btnAtras.Visible = false;
            }
            if(inventario_local == true)
            {
                btnSelectivos.Visible = false;
            }
            llenarComboBoxCategoria();
            nivel_de_privilegio = Convert.ToInt32(consultasMySQL.nivelPrivilegio(nombre_usuario));
            //Si tiene privilegios 1
            if (nivel_de_privilegio == 1 || nivel_de_privilegio == 3)
            {
                btnAperturar.Visible = true;
                usuario_privilegiado = true;
            }
            else
            {
                //Si no tiene privilegios que active la busqueda de inventarios
                btnAperturar.Visible = false;
                cmbCategoria.Visible = true;
                lbCategoria.Visible = true;
                usuario_privilegiado = false;
                cmbCategoria.Text = "";
            }
        }
        #endregion
        #region llenar ComboBox
        private void llenarComboBoxCategoria()
        {
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
            //Oculta el Combobox y el label de Inventario ya que cuando el index cambia estos se vuelven visibles
            cmbInventario.Visible = false;
            label9.Visible = false;
        }
        #endregion
        #region botón aperturar
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            Aperturar_Inventario aperturar = new Aperturar_Inventario();
            aperturar.inventario_local = inventario_local;
            aperturar.nombre_usuario = nombre_usuario;
            aperturar.dashBoard = dashBoard;
            aperturar.nivel_de_privilegio = nivel_de_privilegio;
            aperturar.ip = ip;
            aperturar.Show();
        }
        #endregion
        #region botón buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(usuario_privilegiado == true)
            {
                cmbCategoria.Visible = true;
                lbCategoria.Visible = true;
                btnAperturar.Visible = false;
                usuario_privilegiado = false;
                cmbCategoria.Text = "";
            }
            else
            {
                if(cmbInventario.SelectedIndex != -1)
                {
                    foreach (Form form1 in Application.OpenForms)
                    {
                        if (form1.GetType() == typeof(Form1))
                        {
                            form1.Hide();
                        }
                    }
                    Carga carga = new Carga();
                    carga.nombre_usuario = nombre_usuario;
                    carga.apertura = false;
                    carga.empresa = "";
                    carga.idInventario = cmbInventario.SelectedValue.ToString();
                    usuario_privilegiado = false;
                    if(inventario_local == true)
                    {
                        carga.inventario_local = true;
                    }
                    carga.Show();
                }
                else
                {
                    MessageBox.Show("Porfavor seleccione un inventario valido", "Inventario Invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        #region Selected Value Changed
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCategoria.SelectedIndex > -1)
            {
                cmbInventario.Text = "";
                label9.Visible = true;
                cmbInventario.Visible = true;
                cmbInventario.DataSource = consultasMySQL.llenarInventario(cmbCategoria.Text);
                cmbInventario.ValueMember = "idInventario";
                cmbInventario.DisplayMember = "nombre";
            }
            else
            {
                MessageBox.Show("Seleccione una opción válida", "Opción Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region btnAtras
        private void btnAtras_Click(object sender, EventArgs e)
        {
            nivel_de_privilegio = Convert.ToInt32(consultasMySQL.nivelPrivilegio(nombre_usuario));
            if (btnAperturar.Visible == false && (nivel_de_privilegio == 1 || nivel_de_privilegio == 3))
            {
                btnAperturar.Visible = true;
                lbCategoria.Visible = false;
                label9.Visible = false;
                cmbInventario.Visible = false;
                cmbCategoria.Visible = false;
                usuario_privilegiado = true;
            }
            else
            {
                if (dashBoard == false)
                {
                    if (MessageBox.Show("Desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Login login = new Login();
                        Hide();
                        login.Show();
                    }
                }
                else
                {
                    Hide();
                }
            }
        }
        #endregion
        #region Close()
        private void Agregar_Inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Creditos
        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por Harim Palma, Jonathan Guerra Y Oscar Felipe. Agradecimientos Especiales a Luis Jimenez, Walter Mendez, Juan Andrés Mendez, Fernando Moreno, Rony Rodas.", "Informática 2020", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Selectivo
        private void btnSelectivos_Click(object sender, EventArgs e)
        {
            ver_selectivos selectivos = new ver_selectivos();
            selectivos.nombre_usuario = nombre_usuario;
            selectivos.Show();
        }
        #endregion
        #region Click Boton Servidor
        private void button1_Click(object sender, EventArgs e)
        {
            IP menu = new IP();
            menu.Show();
        }
        #endregion
    }
}
