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
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultas = new ConsultasMySQL();
        private void Categorias_Load(object sender, EventArgs e)
        {
            consultas.obtenerConf();
            dataGridView1.DataSource = consultas.ObtenerCategorias();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categoria menu = new Categoria();
            menu.opcion = 1;
            menu.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

            Categoria menu = new Categoria();
            menu.opcion = 2;
            menu.id = Convert.ToString(fila.Cells[0].Value);
            menu.nombre = Convert.ToString(fila.Cells[1].Value);
            menu.Show();
            this.Close();
        }
    }
}
