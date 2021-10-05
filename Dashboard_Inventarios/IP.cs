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
    public partial class IP : Form
    {
        public IP()
        {
            InitializeComponent();
        }
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();

        private void IP_Load(object sender, EventArgs e)
        {
            consultasMySQL.obtenerConf();
            textBox1.Text = consultasMySQL.ip;
            textBox2.Text = consultasMySQL.usuarioSAP;
            textBox3.Text = consultasMySQL.PasswordSAP;
        }

        private void btnSelectivos_Click(object sender, EventArgs e)
        {
            consultasMySQL.ActualizarConf(textBox1.Text, textBox2.Text, textBox3.Text);
        }
    }
}
