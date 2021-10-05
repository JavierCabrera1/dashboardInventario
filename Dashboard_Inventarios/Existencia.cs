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
    public partial class Existencia : Form
    {
        public Existencia()
        {
            InitializeComponent();
        }

        ConsultasMySQL consultas = new ConsultasMySQL();
        public int opcion;
        public string idProducto;
        public string idBodega;
        public string existencia;        
        public string id;

        private void Existencia_Load(object sender, EventArgs e)
        {
            consultas.obtenerConf();
            comboBox2.DataSource = consultas.ObtenerProductos();
            comboBox2.DisplayMember = "Descripción";
            comboBox2.ValueMember = "ID";

            comboBox1.DataSource = consultas.ObtenerBodegas();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "ID";

            if (opcion == 1)
            {
                button1.Visible = true;
            }
            else
            {                
                consultas.ObtenerExistencia(id);
                numericUpDown1.Value = decimal.Parse(consultas.existencia);
                comboBox2.SelectedValue = consultas.idProducto;
                comboBox1.SelectedValue = consultas.idBodega;
                button3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarExistencias(comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString()) == true)
            {
                consultas.InsertExistencia(comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), numericUpDown1.Value.ToString());
                MessageBox.Show("Existencia ingresa exitosamente.");
                Existencias menu = new Existencias();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe ese Producto en esa Bodega...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                consultas.EditarExistencia(comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString(), numericUpDown1.Value.ToString(), id);
                MessageBox.Show("Existencia editada exitosamente.");
                Existencias menu = new Existencias();
                menu.Show();
                this.Close();
        }
    }
}
