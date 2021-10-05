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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultas = new ConsultasMySQL();
        public int opcion;
        public string nombre;
        public string id;
        private void Categoria_Load(object sender, EventArgs e)
        {
            if(opcion == 1)
            {
                button1.Visible = true;
            }
            else
            {
                textBox1.Text = nombre;
                button3.Visible = true;                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarCategoria(textBox1.Text) == true)
            {
                consultas.InsertCategoria(textBox1.Text);
                MessageBox.Show("Categoría ingresada exitosamente.");
                Categorias menu = new Categorias();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe una categoría con ese nombre. Elija otro nombre.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarCategoria(textBox1.Text) == true)
            {
                consultas.EditarCategoria(textBox1.Text,id);
                MessageBox.Show("Categoría editada exitosamente.");
                Categorias menu = new Categorias();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe una categoría con ese nombre. Elija otro nombre.");
            }
        }


    }
}
