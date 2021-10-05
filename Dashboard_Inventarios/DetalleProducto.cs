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
    public partial class DetalleProducto : Form
    {
        public DetalleProducto()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultas = new ConsultasMySQL();
        public int opcion;
        public string nombre;
        public string unidad;
        public string valor;
        public string Categoria;
        public string Riesgo;
        public string id;

        private void DetalleProducto_Load(object sender, EventArgs e)
        {
            consultas.obtenerConf();
            comboBox2.DataSource = consultas.ObtenerCategorias();
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "ID";

            comboBox3.DataSource = consultas.ObtenerRiesgos();
            comboBox3.DisplayMember = "Nombre";
            comboBox3.ValueMember = "ID";

            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("Kilogramos", "Kilogramos");
            test.Add("Unidades", "Unidades");
            test.Add("Litros", "Litros");

            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Value";

            if (opcion == 1)
            {
                button1.Visible = true;
            }
            else
            {
                textBox1.Text = nombre;
                numericUpDown1.Value = decimal.Parse(valor);
                consultas.ObtenerProducto(id);
                comboBox2.SelectedValue = consultas.idCategoria;
                comboBox3.SelectedValue = consultas.idRiesgo;
                comboBox1.SelectedValue = consultas.unidad;
                button3.Visible = true;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarProducto(textBox1.Text) == true)
            {
                consultas.InsertProducto(textBox1.Text, comboBox1.SelectedValue.ToString(), numericUpDown1.Value.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                MessageBox.Show("Producto ingresado exitosamente.");
                Producto menu = new Producto();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe un Producto con ese nombre. Elija otro nombre.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarProducto(textBox1.Text) == true)
            {
                consultas.EditarProducto(textBox1.Text, comboBox1.SelectedValue.ToString(), numericUpDown1.Value.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), id);
                MessageBox.Show("Producto editado exitosamente.");
                Producto menu = new Producto();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe un Producto con ese nombre. Elija otro nombre.");
            }
        }
    }
}
