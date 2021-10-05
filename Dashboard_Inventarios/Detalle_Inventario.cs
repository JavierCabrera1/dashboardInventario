using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dashboard_Inventarios
{
    public partial class Detalle_Inventario : Form
    {
        ConsultasMySQL consultasMySQL = new ConsultasMySQL();
        int ID;
        string Descripcion;
        string CodigoSAP;
        string codigoBodega;
        string nombreBodega;
        string unidad;
        Decimal existenciaSAP;
        Decimal costoPromedio;
        Decimal conteoFisico;
        Decimal cantidadDiferencia;
        Decimal costoDiferencia;
        string empresa;
        string usuario;
        string estado;
        string Fecha;
        string user;
        string observacionesGerencia;
        string observacionesContador;
        bool button;
        //recibe los datos del form1 y los guarda en variables locales que luego se usan para mostrarlos en pantalla
        public Detalle_Inventario(int ID, string Descripcion, string CodigoSAP, string codigoBodega, string nombreBodega, string unidad, 
            Decimal existenciaSAP, Decimal costoPromedio, Decimal conteoFisico, Decimal cantidadDiferencia, Decimal costoDiferencia, string empresa,
            string usuario, string estado, string Fecha, Boolean buton, string user, string observacionesGerencia, string observacionesContador)
        {
            InitializeComponent();
            //Obtengo todos lo campos que me proporciona el DataGrid para mostrarlos como un detalle
            this.ID = ID;
            this.Descripcion = Descripcion;
            this.CodigoSAP = CodigoSAP;
            this.codigoBodega = codigoBodega;
            this.nombreBodega = nombreBodega;
            this.unidad = unidad;
            this.existenciaSAP = existenciaSAP;
            this.costoPromedio = costoPromedio;
            this.conteoFisico = conteoFisico;
            this.cantidadDiferencia = cantidadDiferencia;
            this.costoDiferencia = costoDiferencia;
            this.empresa = empresa;
            this.usuario = usuario;
            this.estado = estado;
            this.Fecha = Fecha;
            this.user = user;
            this.observacionesGerencia = observacionesGerencia;
            this.observacionesContador = observacionesContador;
            txtObservacionesContador.Text = observacionesContador;
            button = buton;
            switch (empresa)
            {
                case "Unhesa":
                    BackgroundImage = Image.FromFile("fondo5.png");
                    panel1.BackgroundImage = Image.FromFile("unhesa.png");
                    break;
                case "Proquima":
                    BackgroundImage = Image.FromFile("fondo4.png");
                    panel1.BackgroundImage = Image.FromFile("proquima.png");
                    break;
            }
            btnHistorial.Visible = buton;
        }

        private void Detalle_Inventario_Load(object sender, EventArgs e)
        {
            //picture.Image = consultasMySQL.picture(ID.ToString());
            //Labels que muestran en pantalla las varibales locales
            lbID.Text = Convert.ToString(ID);
            txtDescripcion.Text = Descripcion;
            txtCodigoSAP.Text = CodigoSAP;
            lbCodigoBodega.Text = codigoBodega;
            txtNombreBodega.Text = nombreBodega;
            lbUnidad.Text = unidad;
            lbExistenciaSAP.Text = Convert.ToString(existenciaSAP);
            lbCostoPromedio.Text = Convert.ToString(costoPromedio);
            lbConteoFisico.Text = Convert.ToString(conteoFisico);
            lbCantidadDiferencia.Text = Convert.ToString(cantidadDiferencia);
            lbCostoDiferencia.Text = Convert.ToString(costoDiferencia);
            lbIdEmpresa.Text = empresa;
            lbIdUsuario.Text = usuario;
            lbIdEstado.Text = estado;
            lbFecha.Text = Fecha;
            txtObservaciones.Text = observacionesGerencia;
            //Solo si es desde el historial donde se abre
            if (button == false)
            {
                label16.Text = "Detalle Historial";
            }
            //Si el usuario tiene privilegio 1 en MySQL entonces tendra acceso a poner una Observación en Gerencia
            if(consultasMySQL.verificarAdmin(user) == "1" || consultasMySQL.verificarAdmin(user) == "3") 
            {
                if (txtObservaciones.Text == "")/*Si es admin y no hay observaciones gerencia el puede añadir uno*/
                {
                    btnAgregar.Visible = true;
                    txtObservaciones.Visible = true;
                    txtObservaciones.BorderStyle = BorderStyle.None;
                    txtObservaciones.ReadOnly = true;
                }
                else
                {
                    txtObservaciones.ReadOnly = true;
                    txtObservaciones.BorderStyle = BorderStyle.None;
                    btnAgregar.Text = "Editar Observación";
                    btnAgregar.Visible = true;
                }
                if (estado == "Contado" || estado == "Recontado" || estado == "Contado Extraordinario" || estado == "Recontado Extraordinario")
                {
                    //si el inventario ya está contado o recontado se puede habilitar para volver a contarlo
                    btnHabilitar.Visible = button;
                }
                else
                {
                    btnAgregarCosto.Location = new Point(765, 480);
                }
                if(estado == "Contado Extraordinario" || estado == "Habilitar Reconteo Extraordinario" || estado == "Recontado Extraordinario" || estado == "Sin Contar Extraordinario")
                {
                    if(costoPromedio == 0)
                    {
                        //Se puede agregar el costoPromedio si es amdin y la etiqueta es extraordinaria y si el costoPromedio que tiene es 0
                        btnAgregarCosto.Visible = button;
                        btnAgregarCosto.Text = "Agregar Costo Promedio";
                    }
                    else
                    {
                        //Se puede agregar el costoPromedio si es amdin y la etiqueta es extraordinaria y si el costoPromedio que tiene es 0
                        btnAgregarCosto.Visible = button;
                        btnAgregarCosto.Text = "Cambiar Costo Promedio";
                    }
                }
            }
            else
            {
                txtObservaciones.BorderStyle = BorderStyle.None;
            }
            if (consultasMySQL.estadoInventario(ID.ToString()) == "10")
            {
                txtObservaciones.BorderStyle = BorderStyle.None;
                txtObservaciones.ReadOnly = true;
                btnAgregar.Visible = false;
                btnAgregarCosto.Visible = false;
                btnHabilitar.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data_Historial history = new Data_Historial(ID, empresa, user);
            history.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(btnAgregar.Text == "Agregar")
            {
                ObservacionesGerencia observaciones = new ObservacionesGerencia();
                observaciones.ID = ID.ToString();
                observaciones.ShowDialog();
                Close();
            }
            else
            {
                ObservacionesGerencia observaciones = new ObservacionesGerencia();
                observaciones.testamento = txtObservaciones.Text;
                observaciones.ID = ID.ToString();
                observaciones.ShowDialog();
                Close();
            }
            btnAgregar.Text = "Editar Observación";
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Desea Cambiar estado a 'Habilitar Reconteo'? ", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                if(estado == "Contado" || estado == "Recontado")
                {
                    consultasMySQL.cambiarEstado(Convert.ToInt32(ID), 3);
                    MessageBox.Show("Se ha cambiado el estado a 'Habilitar Reconteo'", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if(estado == "Contado Extraordinario" || estado == "Recontado Extraordinario")
                {
                    consultasMySQL.cambiarEstado(Convert.ToInt32(ID), 7);
                    MessageBox.Show("Se ha cambiado el estado a 'Habilitar Reconteo Extraordinario'", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                var idUsuario = "";

                if (consultasMySQL.verificarAdmin(usuario) == "") idUsuario = null;
                else idUsuario = consultasMySQL.verificarAdmin(usuario);

                int idEmpresa = Convert.ToInt32(consultasMySQL.idEmpresa(empresa));
                Decimal costoDiferenciaAbsoluto;
                if (costoDiferencia > 0)
                {
                    costoDiferenciaAbsoluto = costoDiferencia;
                }
                else
                {
                    costoDiferenciaAbsoluto = costoDiferencia * (-1);
                }
                Hide();
            }
        }

        private void btnAgregarCosto_Click(object sender, EventArgs e)
        {
            Costo_Promedio costo = new Costo_Promedio();
            costo.ID = ID;
            costo.descripcionSAP = Descripcion;
            costo.codigoSAP = CodigoSAP;
            costo.unidadDeMedida = unidad;
            costo.codigoBodega = codigoBodega;
            costo.nombreBodega = nombreBodega;
            costo.costoPromedio = costoPromedio;
            costo.existenciaSAP = existenciaSAP;
            costo.conteoFisico = conteoFisico;
            costo.cantidadDiferencia = cantidadDiferencia;
            costo.costoDiferencia = costoDiferencia;
            costo.usuario = user;
            costo.empresa = empresa;
            costo.observacionesContador = observacionesContador;
            costo.ShowDialog();
            Close();
        }

        private void Detalle_Inventario_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(txtObservaciones.Text, "Observacion Gerencia", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtObservacionesContador.Text, "Observaciones Contador", MessageBoxButtons.OK);
        }
    }
}
