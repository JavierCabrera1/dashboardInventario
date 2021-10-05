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
    public partial class MenuLocal : Form
    {
        #region Variables Globales
        public string nombre;
        #endregion
        #region Constructor
        public MenuLocal()
        {
            InitializeComponent();
        }
        #endregion
        #region Click Boton Atras
        private void btnAtras_Click(object sender, EventArgs e)
        {
            Interfaz menu = new Interfaz();
            menu.Show();
            Hide();
        }
        #endregion
        #region Click Boton Administración
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Administracion menu = new Administracion();
            menu.Show();
        }
        #endregion
        #region Click Boton Inventario
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            Agregar_Inventario menu = new Agregar_Inventario();
            menu.inventario_local = true;
            menu.nombre_usuario = nombre;
            menu.dashBoard = false;
            menu.atras = true;
            menu.Show();
            Hide();
        }
        #endregion
    }
}
