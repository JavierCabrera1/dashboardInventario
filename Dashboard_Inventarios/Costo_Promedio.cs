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
    public partial class Costo_Promedio : Form
    {
        #region Variables
        //consultasMySQL me servirá para actualizar toda la información de un Inventario
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();

        public int ID;
        public string descripcionSAP;
        public string codigoSAP;
        public string unidadDeMedida;
        public string codigoBodega;
        public string nombreBodega;
        public Decimal costoPromedio;
        public Decimal existenciaSAP;
        public Decimal conteoFisico;
        public Decimal cantidadDiferencia;
        public Decimal costoDiferencia;
        public string usuario;
        public string empresa;
        public string observacionesContador;
        public Decimal CostoDiferenciaAbsoluto;
        #endregion
        #region Load
        public Costo_Promedio()
        {
            InitializeComponent();
            //Dependiendo de la empresa cambio el fondo de la ventana
            switch (empresa)
            {
                case "Unhesa":
                    BackgroundImage = Image.FromFile("fondo5.png");
                    break;
                case "Proquima":
                    BackgroundImage = Image.FromFile("fondo4.png");
                    break;
            }
        }
        private void Costo_Promedio_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region Cambiar el costo
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            //Agrego el costo diferencia por medio del valor de costoPromedio * cantidadDiferencia
            costoDiferencia = (cantidadDiferencia * nudCostoPromedio.Value);
            if(costoDiferencia > 0)
            {
                CostoDiferenciaAbsoluto = costoDiferencia;/*el costo diferencia Absoluto será siempre igual al costoDiferencia si es extraordinaria*/
            }
            else
            {
                CostoDiferenciaAbsoluto = (costoDiferencia * (-1));/*Por si alguna razón el costo diferencia es < 0, que lo pase a positivo*/
            }
            DialogResult result = MessageBox.Show("Está seguro de que el costo promedio de este inventario sea: Q."+nudCostoPromedio.Value+" ?", "Costo Promedio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result == DialogResult.Yes)
            {
                //Solo tengo el nombre de la empresa y del usuario, pero necesito enviar el ID de cada uno para registrarlos en Historial
                int idUsuario = Convert.ToInt32(consultasMySQL.verificarAdmin(usuario));
                int idEmpresa = Convert.ToInt32(consultasMySQL.idEmpresa(empresa));
                consultasMySQL.actualizarInventarioExtraordinario(nudCostoPromedio.Value, cantidadDiferencia, costoDiferencia, CostoDiferenciaAbsoluto, ID);
                Close();
            }
        }
        #endregion
    }
}
