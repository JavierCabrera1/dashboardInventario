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
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void btnAperturar_Click(object sender, EventArgs e)
        {
            Categorias menu = new Categorias();
            menu.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto menu = new Producto();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bodegas menu = new Bodegas();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Existencias menu = new Existencias();
            menu.Show();
        }
    }
}
