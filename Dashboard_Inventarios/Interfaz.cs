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
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
        }
        public bool atras;
        bool usuario_privilegiado;
        public bool dashBoard;
        public int nivel_de_privilegio;
        public string ip;
        public string nombre;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Interfaz_Load(object sender, EventArgs e)
        {

        }

        private void btnAperturar_Click(object sender, EventArgs e)
        {
            Agregar_Inventario menu = new Agregar_Inventario();
            menu.inventario_local = false;
            menu.nombre_usuario = nombre;
            menu.dashBoard = false;
            menu.atras = true;
            menu.Show();
            Hide();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MenuLocal menu = new MenuLocal();
            menu.nombre = nombre;
            menu.Show();
            Hide();
        }
    }
}
