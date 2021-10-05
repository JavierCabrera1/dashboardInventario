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
    public partial class Agregar_Rack : Form
    {
        #region Variables Globales
        ConsultasMySQL consultas = new ConsultasMySQL();
        public int opcion;
        public string nombre;
        public string idRack;
        public string idBodega;
        #endregion
        #region Contructor
        public Agregar_Rack()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void Agregar_Rack_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                button1.Visible = true;
            }
            else
            {
                textBox1.Text = nombre;
                button3.Visible = true;
            }
        }
        #endregion
        #region Crear Rack
        private void button1_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarRack(textBox1.Text, idBodega) == true)
            {
                consultas.AgregarRack(textBox1.Text, idBodega);
                MessageBox.Show("Rack ingresado exitosamente.");
                Racks racks = new Racks();
                racks.idBodega = idBodega;
                racks.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe un Rack con ese nombre. Elija otro nombre.");
            }
        }
        #endregion
        #region Editar Rack
        private void button3_Click(object sender, EventArgs e)
        {
            if (consultas.VerificarRack(textBox1.Text, idBodega) == true)
            {
                consultas.EditarRack(textBox1.Text, idRack);
                MessageBox.Show("Rack editado exitosamente.");
                Racks racks = new Racks();
                racks.idBodega = idBodega;
                racks.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ya existe un Rack con ese nombre. Elija otro nombre.");
            }
        }
        #endregion
    }
}
