using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Uso de la librería de MySql para la conexión con phpMyAdmin (Data.dill)
using MySql.Data.MySqlClient;

namespace Dashboard_Inventarios
{
    public partial class Login : Form
    {
        string nombre;
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        public Login()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "" && txtContrasena.Text != "")
            {
                using (MySqlConnection mysqlCon = new MySqlConnection(consultasMySQL.connectionString))
                {
                    mysqlCon.Open();
                    //Nombre del procedimiento "viewAll" que llama a todos lo usuarios
                    MySqlDataAdapter mySqlCmd = new MySqlDataAdapter($"SELECT Nombre FROM usuario WHERE User = '{txtUsuario.Text}' and Password = '{txtContrasena.Text}'", consultasMySQL.connectionString);
                    DataTable usuario = new DataTable();
                    mySqlCmd.Fill(usuario);
                    //Extraigo el único dato que me regresa la consulta y lo pongo en una variable
                    if (usuario.Rows.Count > 0)
                    {
                        DataRow row = usuario.Rows[0];
                        DataRow name = usuario.Rows[0];
                        //Guardo en revisados el COUNT de los que tienen el idEstado.Nombre = revisado
                        nombre = Convert.ToString(row[0]);
                    }
                    if (nombre != null)
                    {
                        Interfaz AgregarInventario = new Interfaz();
                        AgregarInventario.nombre = nombre;
                        AgregarInventario.dashBoard = false;
                        AgregarInventario.atras = true;
                        AgregarInventario.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese usuario y contraseña para entrar" ,"" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
