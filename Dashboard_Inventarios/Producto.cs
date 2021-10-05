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
    public partial class Producto : Form
    {
        public Producto()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultas = new ConsultasMySQL();
        private void Producto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consultas.ObtenerProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleProducto menu = new DetalleProducto();
            menu.opcion = 1;
            menu.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            DetalleProducto menu = new DetalleProducto();
            menu.opcion = 2;
            menu.id = Convert.ToString(fila.Cells[0].Value);
            menu.nombre = Convert.ToString(fila.Cells[1].Value);
            menu.valor = Convert.ToString(fila.Cells[2].Value);
            menu.Show();
            this.Close();
        }
    }
}
