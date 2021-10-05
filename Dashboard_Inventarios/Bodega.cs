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
    public partial class Bodega : Form
    {
        public Bodega()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultas = new ConsultasMySQL();
        public int opcion;
        public string nombre;
        public string id;

        private void Bodega_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                button1.Visible = true;
            }
            else
            {
                textBox1.Text = nombre;
                button3.Visible = true;
                rack_btn.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarBodega(textBox1.Text) == true)
            {
                consultas.InsertBodega(textBox1.Text);
                MessageBox.Show("Bodega ingresada exitosamente.");
                Bodegas menu = new Bodegas();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe una Bodega con ese nombre. Elija otro nombre.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarBodega(textBox1.Text) == true)
            {
                consultas.EditarBodega(textBox1.Text, id);
                MessageBox.Show("Bodega editada exitosamente.");
                Bodegas menu = new Bodegas();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe una Bodega con ese nombre. Elija otro nombre.");
            }
        }

        private void rack_btn_Click(object sender, EventArgs e)
        {
            Racks racks = new Racks();
            racks.idBodega = id;
            racks.Show();
        }
    }
}
