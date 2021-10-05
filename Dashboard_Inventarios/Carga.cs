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
    //Pagina de carga, esto debido a que la aplicación de de Form1, se tarda demasiado en mostrar toda la información que procesa
    public partial class Carga : Form
    {
        #region Variables
        int timerLife;

        public string nombre_usuario;
        public bool apertura;
        public string empresa;
        public string idInventario;
        public bool inventario_local;
        #endregion
        #region Load
        public Carga()
        {
            InitializeComponent();
        }

        private void Carga_Load(object sender, EventArgs e)
        {
            timerLife = 10;
            timer1.Start();
        }
        #endregion
        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerLife > 0)
            {
                timerLife = timerLife - 1;
                progressBar1.Value = progressBar1.Value + 10;
            }
            else if(inventario_local == false)
            {
                Form1 frm = new Form1();
                frm.user = nombre_usuario;
                frm.aperturar = apertura;
                frm.empresaApertura = empresa;
                frm.idInventario = idInventario;
                frm.Show();
                Close();
            } else
            {
                Inventario_Local inventario_Local = new Inventario_Local();
                inventario_Local.user = nombre_usuario;
                inventario_Local.aperturar = apertura;
                inventario_Local.empresaApertura = empresa;
                inventario_Local.idInventario = idInventario;
                inventario_Local.Show();
                Close();
            }
        }
        #endregion
    }
}
