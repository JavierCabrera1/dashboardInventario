using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
//Uso de la librería de MySql para la conexión con phpMyAdmin (Data.dill)
using MySql.Data.MySqlClient;

namespace Dashboard_Inventarios
{
    class ConsultasMySQL
    {
        //conexión a la base de datos phpMyAdmin
        public string connectionString = @"Server=192.168.0.83;Database=dbinventarios;Uid=admin;Pwd=;port=3306;SslMode=none";
        private SqlConnection conexion = new SqlConnection("data source = 192.168.0.7; initial catalog = master; user id = sa; password = grueconsa");

        #region Varibales Globales
        //-------------TABLAS GLOBALES PARA INVENTARIOS--------------------//
        string Tabla_Conteos = "conteos";
        string Tabla_Inventario = "inventarios";
        string Tabla_Empresa = "empresa";
        string Tabla_Historial = "historial_conteos";
        string Tabla_Usuario = "usuario";
        string Tabla_Estado = "estado";
        string Tabla_Hallazgos = "hallazgos";
        string Tabla_Categoria = "categoria";
        string Tabla_Bodega = "bodega";

        //-----------------------------------------------------------------//


        //configuración de SAP
        public string ip;   //ip del servidor de SAP
        public string usuarioSAP;
        public string PasswordSAP;

        #endregion
        #region Metodo Ver Etiqueta
        //-------------------------------------------------------------------------------------Ver Etiqueta------------------------------------------------------------------------------------//
        public DataTable VerEtiqueta(string idInventario)
        {
            //Consulta para traer los inventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', Unidad De Medida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.User AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualizacion', CostoDiferenciaAbsoluto, ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia' FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado ORDER BY idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado), mysqlCon);
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', UnidadDeMedida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.Nombre AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualizacion', CostoDiferenciaAbsoluto, ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia', riesgo as 'Riesgo'  FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado INNER JOIN {4} ON {0}.idInventario = {4}.idInventario WHERE {0}.idInventario = {5} order by idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado, Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //-------------------------------------------------------------------------------------Ver Etiqueta------------------------------------------------------------------------------------//
        public DataTable VerEtiquetaLocal(string idInventario)
        {
            //Consulta para traer los inventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', Unidad De Medida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.User AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualizacion', CostoDiferenciaAbsoluto, ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia' FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado ORDER BY idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado), mysqlCon);
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', DescripcionSAP AS 'Descripción', CodigoSAP AS 'Codigo Producto', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', UnidadDeMedida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencias', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.Nombre AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualización', CostoDiferenciaAbsoluto as 'Costo Diferencia Absoluto', ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia', riesgo as 'Riesgo'  FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado INNER JOIN {4} ON {0}.idInventario = {4}.idInventario WHERE {0}.idInventario = {5} order by idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado, Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #endregion
        #region Metodo Buscar ID Invetario
        //-------------------------------------------------------------------------------------Buscar Id de Un inventario------------------------------------------------------------------------------------//
        public string idInventario()
        {
            using(MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string idInventario = "";
                mysqlCon.Open();
                //Obtiene el último IDInventario de Conteos
                MySqlDataAdapter mySqlCmdID = new MySqlDataAdapter(string.Format("SELECT idInventario FROM {0} ORDER by idInventario DESC LIMIT 1", Tabla_Inventario), mysqlCon);
                DataTable inventario = new DataTable();
                mySqlCmdID.Fill(inventario);
                if (inventario.Rows.Count > 0)
                {
                    DataRow row = inventario.Rows[0];
                    DataRow name = inventario.Rows[0];
                    idInventario = Convert.ToString(row[0]);
                }
                return idInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Llenar ComboBox
        //-------------------------------------------------------------------------------------Llena los ComboBox Empresa------------------------------------------------------------------------------------//
        public DataTable llenarEmpresa()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0}", Tabla_Empresa), mysqlCon);
                DataTable empresa = new DataTable();
                mySqlCmd.Fill(empresa);
                return empresa;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------Llenar ComboBox Estado--------------------------------------------------------------------------------------------------------//
        public DataTable llenarEstado()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0}", Tabla_Estado), mysqlCon);
                DataTable estado = new DataTable();
                mySqlCmd.Fill(estado);
                return estado;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Poner Observaciones Gerencia
        //---------------------------------------------------------------------------------Poner Observaciones Gerencia---------------------------------------------------------------------------------------------------------//
        public void updateObservación(string ID, string Observación)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET ObservacionesGerencia = '{1}' WHERE idConteo = {2}", Tabla_Conteos, Observación, ID), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        #endregion
        #region Cambiar Estado de los Conteos
        //--------------------------------------------------------------------------------------------Cambiar el Estado de los conteos (Sin contar ... etc)----------------------------------------------------------------------------------------------//
        public void cambiarEstado(int ID, int estado)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET idEstado = {1} WHERE idConteo = {2}", Tabla_Conteos, estado, ID), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Ver Historial
        //-----------------------------------------------------------------------------------------------Ver Historial-------------------------------------------------------------------------------------------//
        public DataTable verHistorial(int ID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT h.idConteoHistorial AS 'ID', h.DescripcionSAP AS 'Descripcion', h.CodigoSAP AS 'Codigo SAP', h.UnidadDeMedida AS 'Unidad de Medida', h.CodigoBodega AS 'Codigo Bodega', h.NombreBodega AS 'Nombre Bodega', h.ExistenciaSAP AS 'Existencia SAP', h.CostoPromedio AS 'Costo Promedio', h.ConteoFisico AS 'Conteo Fisico', h.CantidadDiferencia AS 'Cantidad Diferencia', h.CostoDiferencia AS 'Costo Diferencia', u.Nombre AS 'Usuario', e.Nombre AS 'Empresa', h.FechaActualizacion AS 'Fecha Actualizacion', c.idConteo AS 'ID Inventario', h.CostoDiferenciaAbsoluto, h.ObservacionesContador AS 'Observaciones Contador', h.ObservacionesGerencia AS 'Observaciones Gerencia' FROM {0} h INNER JOIN {1} u ON h.idUsuario = u.idUsuario INNER JOIN {2} e ON h.idEmpresa = e.idEmpresa INNER JOIN {3} c ON h.idConteo = c.idConteo WHERE h.idConteo = {4} ORDER BY h.idConteoHistorial", Tabla_Historial,Tabla_Usuario,Tabla_Empresa,Tabla_Conteos, ID), mysqlCon);
                DataTable dtbInventario = new DataTable();
                mySqlCmd.Fill(dtbInventario);
                return dtbInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Ver si es Admin
        //-------------------------------------------------------------------------------------------Verificar si es Admin-----------------------------------------------------------------------------------------------//
        public string verificarAdmin(string user)
        {
            //Busco el privilegio del usuario que me mandaron, si es privilegio 1 entonces tendrá acceso
            string privilegio = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            { 
                mysqlCon.Open();
                //Nombre del procedimiento "verificarAdmin" que llama a el idusuario 1
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT privilegios FROM {0} WHERE nombre = '{1}'",Tabla_Usuario, user), mysqlCon);
                DataTable usuario = new DataTable();
                mySqlCmd.Fill(usuario);
                //Extraigo el único dato que me regresa la consulta y lo pongo en una variable
                if (usuario.Rows.Count > 0)
                {
                    DataRow row = usuario.Rows[0];
                    DataRow name = usuario.Rows[0];
                    //Guardo en revisados el COUNT de los que tienen el idEstado.Nombre = revisado
                    privilegio = Convert.ToString(row[0]);
                }
                //regresa el ID, si es 1 es admin, si no es otro usuario sin privilegios
                return privilegio;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Actualizar Inventarios Extraordinarios
        //-----------------------------------------------------------------------------------------Actualizar Inventarios Extraordinarios-------------------------------------------------------------------------------------------------//

        public void actualizarInventarioExtraordinario(Decimal costoPromedio, Decimal cantidadDiferencia, Decimal costoDiferencia, Decimal costoDiferenciaAbsoluto, int ID)
        {
            string Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Cambia el Costo Promedio de la base de datos para los Inventarios
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET CostoPromedio = '{1}', CantidadDiferencia = '{2}', CostoDiferencia = '{3}', CostoDiferenciaAbsoluto = '{4}', FechaActualizacion = '{5}' WHERE idConteo = '{6}'", Tabla_Conteos, costoPromedio, cantidadDiferencia, costoDiferencia, costoDiferenciaAbsoluto, Fecha, ID), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Buscar el ID de una empresa por su nombre
        //----------------------------------------------------------------------------------------Buscar el id de una empresa--------------------------------------------------------------------------------------------------//
        public string idEmpresa(string empresa)
        {
            //esta consulta es solo para saber que ID tiene una empresa de la cual solo sé el nombre
            string ID = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idEmpresa FROM {0} WHERE nombre = '{1}'", Tabla_Empresa, empresa), mysqlCon);
                DataTable usuario = new DataTable();
                mySqlCmd.Fill(usuario);
                if (usuario.Rows.Count > 0)
                {
                    DataRow row = usuario.Rows[0];
                    DataRow name = usuario.Rows[0];
                    ID = Convert.ToString(row[0]);
                }
                return ID;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Poner Observaciones de Gerencia en Historial
        //----------------------------------------------------------------------------------------Poner Observaciones de Gerencia en Historial--------------------------------------------------------------------------------------------------//
        public void updateObservacionesHistorial(int ID, string Observación)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Si el admin quiere ingresar una Observación de Gerencia a un Historial
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET ObservacionesGerencia = '{1}' WHERE idConteoHistorial = {2}",Tabla_Historial, Observación, ID), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Metodo Ver hallazgos
        //--------------------------------------------------------------------------------------------Metodo Ver Hallazgos----------------------------------------------------------------------------------------------//
        public DataTable verHallazgos(string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "verHallazgos" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.Nombre AS 'Usuario', Descripcion AS 'Descripcion' FROM {1} INNER JOIN {0} ON {1}.idUsuario = {0}.idUsuario INNER JOIN {2} on {2}.idInventario = {1}.idInventario WHERE {2}.idEstado = 9 AND {1}.idInventario = '{3}'", Tabla_Usuario, Tabla_Hallazgos, Tabla_Inventario, idInventario), mysqlCon);
                DataTable tableHallazgo = new DataTable();
                mySqlCmd.Fill(tableHallazgo);
                return tableHallazgo;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Ver Extraordinarios
        //--------------------------------------------------------------------------------------------Ver Extraordinarios----------------------------------------------------------------------------------------------//
        public DataTable verExtraordinario(string idInventario)
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "mostrarEtiqueta" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', UnidadDeMedida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.Nombre AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualizacion', CostoDiferenciaAbsoluto, ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia' FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado WHERE {0}.idEstado in (5, 6, 7, 8) and {0}.idInventario = '{4}' ORDER BY idConteo",Tabla_Conteos,Tabla_Empresa, Tabla_Usuario, Tabla_Estado, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                Console.WriteLine(idInventario);
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Obtener el Id de un usuario por su nombre
        //-------------------------------------------------------------------------------------------Obtener ID Usuario-----------------------------------------------------------------------------------------------//
        public int obtenerIdUsuario(string nombre)
        {
            int idUsuario = 0;
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "mostrarEtiqueta" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("select idUsuario from {0} where nombre = '{1}'",Tabla_Usuario, nombre), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                if (TableInventario.Rows.Count > 0)
                {
                    DataRow row = TableInventario.Rows[0];
                    DataRow name = TableInventario.Rows[0];
                    idUsuario = Convert.ToInt32(row[0]);
                }
            }
            return idUsuario;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Selects de Aperturas en SQL server Generales
        //---------------------------------------------------------------------------------------------Select de Apertura Econsa---------------------------------------------------------------------------------------------//
        public DataTable mostrarAperturaEconsa()
        {
            conexion.Open();
            SqlDataAdapter cmdP = new SqlDataAdapter(string.Format("select ROW_NUMBER() over (order by (select NULL)) as 'ID', a.ItemCode as 'Codigo SAP', a.ItemName as 'Descripcion SAP', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.OnHand as 'Existencia SAP', b.AvgPrice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', 'Proquima' as 'Empresa', null as 'Usuario', 'Sin Contar' as 'Estado', null as 'Fecha Actualizacion', null as 'CostoDiferenciaAbsoluto', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].proquima.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode"),conexion);
            SqlDataAdapter cmdU = new SqlDataAdapter(string.Format("select ROW_NUMBER() over (order by (select NULL)) as 'ID', a.ItemCode as 'Codigo SAP', a.ItemName as 'Descripcion SAP', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.OnHand as 'Existencia SAP', b.AvgPrice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', 'Unhesa' as 'Empresa', null as 'Usuario', 'Sin Contar' as 'Estado', null as 'Fecha Actualizacion',null as 'CostoDiferenciaAbsoluto', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].unhesa.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode"),conexion);
            DataTable select = new DataTable();
            cmdU.Fill(select);
            cmdP.Fill(select);
            conexion.Close();
            return select;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //---------------------------------------------------------------------------------------Select de Apertura Proquima---------------------------------------------------------------------------------------------------//
        public DataTable mostrarAperturaProquima()
        {
            conexion.Open();
            SqlDataAdapter cmdP = new SqlDataAdapter(string.Format("select ROW_NUMBER() over (order by (select NULL)) as 'ID', a.ItemCode as 'Codigo SAP',a.ItemName as 'Descripcion SAP', b.WhsCode as 'Codigo Bodega',c.WhsName as 'Nombre Bodega', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida',b.OnHand as 'Existencia SAP',b.AvgPrice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', 'Proquima' as 'Empresa', null as 'Usuario', 'Sin Contar' as 'Estado', null as 'Fecha Actualizacion', null as 'CostoDiferenciaAbsoluto', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].proquima.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode"), conexion);
            DataTable select = new DataTable();
            cmdP.Fill(select);
            conexion.Close();
            return select;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------------------------------------------Select de Apertura Unhesa-----------------------------------------------------------------------------------------------//
        public DataTable mostrarAperturaUnhesa()
        {
            conexion.Open();
            SqlDataAdapter cmdU = new SqlDataAdapter(string.Format("select ROW_NUMBER() over (order by (select NULL)) as 'ID', a.ItemCode as 'Codigo SAP',a.ItemName as 'Descripcion SAP', b.WhsCode as 'Codigo Bodega',c.WhsName as 'Nombre Bodega', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida',b.OnHand as 'Existencia SAP',b.AvgPrice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', 'Unhesa' as 'Empresa', null as 'Usuario', 'Sin Contar' as 'Estado', null as 'Fecha Actualizacion',null as 'CostoDiferenciaAbsoluto', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].unhesa.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode"), conexion);
            DataTable select = new DataTable();
            cmdU.Fill(select);
            conexion.Close();
            return select;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------------------------------------------Select de Apertura Local-----------------------------------------------------------------------------------------------//
        public DataTable mostrarAperturaLocal(string inventarioID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT ROW_NUMBER() over (order by (select NULL)) as 'ID', p.descripcion AS 'Descripción', e.idProducto AS 'Codigo Producto', e.idBodega AS 'Codigo Bodega', b.nombre AS 'Nombre Bodega', p.unidadDeMedida AS 'Unidad de Medida', e.existencia AS 'Existencias', p.valorUnitario AS 'Costo Promedio', null AS 'Conteo Fisico', null AS 'Cantidad Diferencia', null AS 'Costo Diferencia', 'test' as 'Empresa', null AS 'Usuario', 1 AS 'Estado', null AS 'Fecha Actualización', null as 'Costo Diferencia Absoluto', null AS 'Observaciones Contador', null AS 'Observaciones Gerencia', r.descripcion AS 'Riesgo' FROM Existencia e INNER JOIN Producto p ON e.idProducto = p.idProducto INNER JOIN Bodega b ON e.idBodega = b.idBodega INNER JOIN Riesgo r ON r.idRiesgo = p.idRiesgo"), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Insertar Conteos Generales
        //-----------------------------------------------------------------------------------------------Insertar Conteos de Unhesa y Proquima-------------------------------------------------------------------------------------------//
        public void insertarConteosEconsa(string idInventario)
        {
            conexion.Open();
            SqlCommand cmdU = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') SELECT NULL AS 'idInventario', a.ItemName AS 'Descripcion', a.ItemCode AS 'Codigo', CONCAT(isnull(a.InvntryUom,'N/A') collate SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv collate SQL_Latin1_General_CP1_CI_AS)  as 'UnidadDeMedida', b.WhsCode AS 'CodigoBodega', c.WhsName AS 'NombreBodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'CostoPromedio', NULL AS 'Conteo Fisico', NULL AS 'Cantidad Diferencia', NULL AS 'Costo Diferencia', NULL AS 'CostoDiferenciaAbsoluto', 1 AS 'idEmpresa', NULL AS 'idUsuario', 1 AS 'idEstado', '{1}' AS 'idInventario', NULL AS 'FechaActualizacion', NULL AS 'Observaciones Contador', NULL AS 'Observaciones Gerencia', U_Riesgo as 'Riesgo' FROM  [" + ip + "].unhesa.dbo.OITM a INNER JOIN  [" + ip + "].unhesa.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN  [" + ip + "].unhesa.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 ORDER BY b.WhsCode", Tabla_Conteos, idInventario), conexion);
            SqlCommand cmdP = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idInventario', a.ItemName as 'Descripcion', a.ItemCode as 'Codigo', CONCAT(isnull(a.InvntryUom,'N/A') collate SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv collate SQL_Latin1_General_CP1_CI_AS)  as 'UnidadDeMedida', b.WhsCode as 'CodigoBodega',c.WhsName as 'NombreBodega',b.OnHand as 'Existencia',b.AvgPrice as 'CostoPromedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', 2 as 'idEmpresa', null as 'idUsuario', 1 as 'idEstado', '{1}' as 'idInventario', null as 'FechaActualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia',  U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].proquima.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode", Tabla_Conteos, idInventario), conexion);
            cmdU.ExecuteNonQuery();
            cmdP.ExecuteNonQuery();
            conexion.Close();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //-----------------------------------------------------------------------------------------------Insertar Conteos de una empresa-------------------------------------------------------------------------------------------//
        public void insertarConteosEmpresa(string idInventario, string empresa, string idEmpresa)
        {
            conexion.Open();
            SqlCommand cmdP = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idInventario', a.ItemName as 'Descripcion', a.ItemCode as 'Codigo', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'CodigoBodega',c.WhsName as 'NombreBodega',b.OnHand as 'Existencia',b.AvgPrice as 'CostoPromedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{3}' as 'idEmpresa', null as 'idUsuario', 1 as 'idEstado', '{1}' as 'idInventario', null as 'FechaActualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].{2}.dbo.OITM a inner join  [" + ip + "].{2}.dbo.OITW b on a.ItemCode=b.ItemCode inner join  [" + ip + "].{2}.dbo.OWHS c on b.WhsCode=c.WhsCode where b.OnHand > 0 order by b.WhsCode", Tabla_Conteos, idInventario, empresa, idEmpresa), conexion);
            cmdP.ExecuteNonQuery();
            conexion.Close();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        //-----------------------------------------------------------------------------------------------Insertar Conteos Local-------------------------------------------------------------------------------------------//
        public DataTable insertarConteoLocal(string inventarioID)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("INSERT INTO `conteos`(`DescripcionSAP`, `CodigoSAP`, `UnidadDeMedida`, `CodigoBodega`, `NombreBodega`, `ExistenciaSAP`, `CostoPromedio`, `ConteoFisico`, `CantidadDiferencia`, `CostoDiferencia`, `CostoDiferenciaAbsoluto`, `idEmpresa`, `idUsuario`, `idEstado`, `idInventario`, `FechaActualizacion`, `ObservacionesGerencia`, `ObservacionesContador`, `Riesgo`) Select p.descripcion, e.idProducto, p.unidadDeMedida, e.idBodega, b.nombre, e.existencia, p.valorUnitario, null, null, null, null, 6, null, 1, {0}, null, null, null, r.descripcion from Existencia e inner join Producto p on e.idProducto = p.idProducto inner join Bodega b on e.idBodega = b.idBodega INNER JOIN Riesgo r on r.idRiesgo = p.idRiesgo", inventarioID), mysqlCon);
                DataTable inventario = new DataTable();
                mySqlCmd.Fill(inventario);
                return inventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Agrega y Muestra los conteos Randoms
        //---------------------------------------------------------------Agrega Proquima----------------------------------------------------------------------------------------//<
        public void insertarAleatoriosProquima(string idInventario, string idEmpresa, string codigo1, string codigo2)
        {
            conexion.Open();
            if (codigo1 == "06" && codigo2 == "06")
            {
                SqlCommand cmdProquimaDefault6 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and   a.U_Categoria <> 'Clarificación' and b.onhand > 0", Tabla_Conteos, idEmpresa, idInventario), conexion);
                cmdProquimaDefault6.ExecuteNonQuery();
            }
            else if (codigo1 == "02" && codigo2 == "02")
            {
                SqlCommand cmdProquimaDefault = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode in ('0103010001', '0103010005', '0103010008', '0103010009','0103010012', '0103010013', '0103010014') and b.onhand > 0", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmdProquimaAleatorio = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{3}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode not in ('0103010001', '0103010005', '0103010008', '0103010009','0103010012', '0103010013', '0103010014') and b.onhand > 0 order by NEWID()", Tabla_Conteos, idEmpresa, 1, idInventario), conexion);
                cmdProquimaAleatorio.ExecuteNonQuery();
                cmdProquimaDefault.ExecuteNonQuery();
            }
            else if ((codigo1 == "02" && codigo2 == "06") || (codigo1 == "06" && codigo2 == "02"))
            {
                SqlCommand cmdProquimaDefault = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode in ('0103010001', '0103010005', '0103010008', '0103010009','0103010012', '0103010013', '0103010014') and b.onhand > 0", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmdProquimaAleatorio = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{3}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode not in ('0103010001', '0103010005', '0103010008', '0103010009','0103010012', '0103010013', '0103010014') order by NEWID()", Tabla_Conteos, idEmpresa, 1, idInventario), conexion);
                SqlCommand cmdProquimaDefault6 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].proquima.dbo.OITM a inner join  [" + ip + "].proquima.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].proquima.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and   a.U_Categoria <> 'Clarificación' and b.onhand > 0", Tabla_Conteos, idEmpresa, idInventario), conexion);
                cmdProquimaDefault.ExecuteNonQuery();
                cmdProquimaAleatorio.ExecuteNonQuery();
                cmdProquimaDefault6.ExecuteNonQuery();
            }
            conexion.Close();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        //---------------------------------------------------------------Agrega Unhesa----------------------------------------------------------------------------------------//
        public void insertarAleatoriosUnhesa(string idInventario, string idEmpresa, string codigo1, string codigo2)
        {
            conexion.Open();
            if (codigo1 == "06" && codigo2 == "06")
            {
                SqlCommand cmbUnhesaDefault_06 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and a.ItemCode in ('PTPPFR001','PTPPFR002','PTPPFR003','PTPPFR005', 'PTPPFR006','PTPPFR015','PTPPFR016','PTPPFR035', 'PTPPFR036','PTPPFR039','PTPPFR041','PTPPFR042', 'PTPPFR044','PTPPFR047','PTPPFR049','PTPPGE009', 'PTPPGE012','PTPPGE016','PTPPGE027','PTPPHX001', 'PTPPHX002','PTPPHX003','PTPPHX004','PTMQCQCP001', 'PTMQMCCP002','PTPPALCP001''PTPPCACP001','PTPPCACP003', 'PTPPCACP007','PTPPCACP008','PTPPCAep001','PTPPCASA001', 'PTPPCASC001','PTPPCASZ009','PTPPDBPQ003','PTPPCACP004', 'PTPPCACP026','PTPPCAES029')", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmbUnhesaAleatorio_06 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and b.onhand > 0 and a.ItemCode not in ('PTPPFR001','PTPPFR002','PTPPFR003','PTPPFR005', 'PTPPFR006','PTPPFR015','PTPPFR016','PTPPFR035', 'PTPPFR036','PTPPFR039','PTPPFR041','PTPPFR042', 'PTPPFR044','PTPPFR047','PTPPFR049','PTPPGE009', 'PTPPGE012','PTPPGE016','PTPPGE027','PTPPHX001', 'PTPPHX002','PTPPHX003','PTPPHX004','PTMQCQCP001', 'PTMQMCCP002','PTPPALCP001''PTPPCACP001','PTPPCACP003', 'PTPPCACP007','PTPPCACP008','PTPPCAep001','PTPPCASA001', 'PTPPCASC001','PTPPCASZ009','PTPPDBPQ003','PTPPCACP004', 'PTPPCACP026','PTPPCAES029') order by NEWID()", Tabla_Conteos, idEmpresa, idInventario), conexion);
                cmbUnhesaDefault_06.ExecuteNonQuery();
                cmbUnhesaAleatorio_06.ExecuteNonQuery();
            }
            else if (codigo1 == "02" && codigo2 == "02")
            {
                SqlCommand cmbUnhesaDefault_02 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode in ('MPFL01CA001','MPFL01FR018', 'MPFL01GE003','MPPU0200005', 'MPPU0200006','MPPU0200008', 'MPPU0200011','MPPU0200013', 'MPPU0200014','MPPU0200018', 'MPPU0200063','MPPU0200074', 'MPPU0200087')", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmbUnhesaAleatorio_02 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode ='02' and b.onhand > 0 and a.ItemCode not in ('MPFL01CA001','MPFL01FR018', 'MPFL01GE003','MPPU0200005', 'MPPU0200006','MPPU0200008', 'MPPU0200011','MPPU0200013', 'MPPU0200014','MPPU0200018', 'MPPU0200063','MPPU0200074', 'MPPU0200087') order by NEWID()", Tabla_Conteos, idEmpresa, idInventario), conexion);
                cmbUnhesaDefault_02.ExecuteNonQuery();
                cmbUnhesaAleatorio_02.ExecuteNonQuery();
            }
            else if ((codigo1 == "02" && codigo2 == "06") || (codigo1 == "06" && codigo2 == "02"))
            {
                SqlCommand cmbUnhesaDefault_02 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '02' and a.ItemCode in ('MPFL01CA001','MPFL01FR018', 'MPFL01GE003','MPPU0200005', 'MPPU0200006','MPPU0200008', 'MPPU0200011','MPPU0200013', 'MPPU0200014','MPPU0200018', 'MPPU0200063','MPPU0200074', 'MPPU0200087')", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmbUnhesaAleatorio_02 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode ='02' and b.onhand > 0 and a.ItemCode not in ('MPFL01CA001','MPFL01FR018', 'MPFL01GE003','MPPU0200005', 'MPPU0200006','MPPU0200008', 'MPPU0200011','MPPU0200013', 'MPPU0200014','MPPU0200018', 'MPPU0200063','MPPU0200074', 'MPPU0200087') order by NEWID()", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmbUnhesaDefault_06 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and a.ItemCode in ('PTPPFR001','PTPPFR002','PTPPFR003','PTPPFR005', 'PTPPFR006','PTPPFR015','PTPPFR016','PTPPFR035', 'PTPPFR036','PTPPFR039','PTPPFR041','PTPPFR042', 'PTPPFR044','PTPPFR047','PTPPFR049','PTPPGE009', 'PTPPGE012','PTPPGE016','PTPPGE027','PTPPHX001', 'PTPPHX002','PTPPHX003','PTPPHX004','PTMQCQCP001', 'PTMQMCCP002','PTPPALCP001''PTPPCACP001','PTPPCACP003', 'PTPPCACP007','PTPPCACP008','PTPPCAep001','PTPPCASA001', 'PTPPCASC001','PTPPCASZ009','PTPPDBPQ003','PTPPCACP004', 'PTPPCACP026','PTPPCAES029')", Tabla_Conteos, idEmpresa, idInventario), conexion);
                SqlCommand cmbUnhesaAleatorio_06 = new SqlCommand(string.Format("insert into openquery(MYSQL, 'select * from {0}') select top 15 null as 'idConteo', a.ItemName as 'Descripcion SAP', a.ItemCode as 'Codigo SAP', isnull(a.InvntryUom,'N/A')+'-'+U_PresentaInv as 'Unidad De Medida', b.WhsCode as 'Codigo Bodega', c.WhsName as 'Nombre Bodega', b.OnHand as 'Existencia SAP', b.avgprice as 'Costo Promedio', null as 'Conteo Fisico', null as 'Cantidad Diferencia', null as 'Costo Diferencia', null as 'CostoDiferenciaAbsoluto', '{1}' as 'Empresa', null as 'Usuario', 1 as 'Estado', '{2}' as 'idInventario', null as 'Fecha Actualizacion', null as 'Observaciones Contador', null as 'Observaciones Gerencia', U_Riesgo as 'Riesgo' from  [" + ip + "].unhesa.dbo.OITM a inner join  [" + ip + "].unhesa.dbo.OITW b on a.itemcode=b.itemcode inner join  [" + ip + "].unhesa.dbo.owhs c on b.WhsCode=c.WhsCode where b.WhsCode = '06' and b.onhand > 0 and a.ItemCode not in ('PTPPFR001','PTPPFR002','PTPPFR003','PTPPFR005', 'PTPPFR006','PTPPFR015','PTPPFR016','PTPPFR035', 'PTPPFR036','PTPPFR039','PTPPFR041','PTPPFR042', 'PTPPFR044','PTPPFR047','PTPPFR049','PTPPGE009', 'PTPPGE012','PTPPGE016','PTPPGE027','PTPPHX001', 'PTPPHX002','PTPPHX003','PTPPHX004','PTMQCQCP001', 'PTMQMCCP002','PTPPALCP001''PTPPCACP001','PTPPCACP003', 'PTPPCACP007','PTPPCACP008','PTPPCAep001','PTPPCASA001', 'PTPPCASC001','PTPPCASZ009','PTPPDBPQ003','PTPPCACP004', 'PTPPCACP026','PTPPCAES029') order by NEWID()", Tabla_Conteos, idEmpresa, idInventario), conexion);
                cmbUnhesaDefault_02.ExecuteNonQuery();
                cmbUnhesaAleatorio_02.ExecuteNonQuery();
                cmbUnhesaDefault_06.ExecuteNonQuery();
                cmbUnhesaAleatorio_06.ExecuteNonQuery();
            }
                conexion.Close();
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Clausura Inventarios
        //------------------------------------------------------------------------------------Clausurar Inventarios------------------------------------------------------------------------------------------------------//
        public void clausurarInventario(string idInventario, string Hora_Final)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Si el admin quiere ingresar una Observación de Gerencia a un Historial
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET {0}.Hora_Final = '{1}', {0}.idEstado = 10 WHERE {0}.idInventario = '{2}'", Tabla_Inventario, Hora_Final, idInventario), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Muestra el nombre de un Inventario dependiendo su ID
        //------------------------------------------------------------------------------------Muestra el nombre de un Inventario------------------------------------------------------------------------------------------------------//
        public string nombreInventario(string idInventario)
        {
            string nombreInventario = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "mostrarEtiqueta" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("select nombre from {0} where idInventario = '{1}'", Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                if (TableInventario.Rows.Count > 0)
                {
                    DataRow row = TableInventario.Rows[0];
                    DataRow name = TableInventario.Rows[0];
                    nombreInventario = Convert.ToString(row[0]);
                }
            }
            return nombreInventario;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Llena el Combobox de Inventarios dependiendo de cual busquen si General o Aleatorio
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        public DataTable llenarInventario(string categoria)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idInventario, {0}.nombre FROM {0} INNER JOIN categoria ON {1}.idCategoria = {0}.idCategoria WHERE categoria.nombre = '{2}' ORDER BY {0}.idInventario DESC", Tabla_Inventario, Tabla_Categoria, categoria), mysqlCon);
                DataTable inventario = new DataTable();
                mySqlCmd.Fill(inventario);
                return inventario;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Crea un Nuevo Inventario
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        public void insertInventario(string nombre, string idUsuario, string Hora_Inicio, string idCategoria, string idEstado)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Si el admin quiere ingresar una Observación de Gerencia a un Historial
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("INSERT INTO {0}(nombre, Hora_Inicio, Hora_Final,idUsuario, idEstado, idCategoria) VALUES('{1}','{2}','{3}', {4}, '{6}', '{5}')", Tabla_Inventario, nombre, Hora_Inicio, "", idUsuario, idCategoria, idEstado), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Muestra los Inventario Clausurados
        //---------------------------------------------------------------------------------Inventarios Clausurados---------------------------------------------------------------------------------------------------------//
        public bool InventarioFinalizado(string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string id = "";
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idEstado FROM {0} WHERE idInventario = {1}", Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                if (TableInventario.Rows.Count > 0)
                {
                    DataRow row = TableInventario.Rows[0];
                    DataRow name = TableInventario.Rows[0];
                    id = Convert.ToString(row[0]);
                }
                if (id == "9")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Llena el ComboBox de Genral o Aleatorio
        //---------------------------------------------------------------------------------ComboBox de Categoria---------------------------------------------------------------------------------------------------------//
        public DataTable llenarCategoria()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {                                                                                                                                                                                                                               
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0} WHERE idCategoria != 3", Tabla_Categoria), mysqlCon);
                DataTable categoria = new DataTable();
                mySqlCmd.Fill(categoria);
                return categoria;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Combobox Categoria Inventario Local
        //---------------------------------------------------------------------------------ComboBox de Categoria---------------------------------------------------------------------------------------------------------//
        public DataTable llenarCategoriaLocal()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0} WHERE idCategoria in (2, 4)", Tabla_Categoria), mysqlCon);
                DataTable categoria = new DataTable();
                mySqlCmd.Fill(categoria);
                return categoria;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region Combobox Bodega Invetario Local
        public DataTable llenarBodegaLocal()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0}", Tabla_Bodega), mysqlCon);
                DataTable bodega = new DataTable();
                mySqlCmd.Fill(bodega);
                return bodega;
            }
        }
        #endregion
        #region Combobox Empresa Invetario Local
        public DataTable llenarEmpresaLocal()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0} where idEmpresa = 6", Tabla_Empresa), mysqlCon);
                DataTable categoria = new DataTable();
                mySqlCmd.Fill(categoria);
                return categoria;
            }
        }
        #endregion
        #region Cambiar el Estado de un Inventario
        //-----------------------------------------------------------------------Cambiar el Estado de un Inventario----------------------------------------------------------------------------//
        public void cambiar_Estado_Inventario(string idEstado, string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Si el admin quiere ingresar una Observación de Gerencia a un Historial
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE {0} SET {0}.idEstado = '{1}' WHERE {0}.idInventario = '{2}'", Tabla_Inventario, idEstado, idInventario), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region nivel de privilegio que posee una persona
        //----------------------------------------------------------Nivel de privilegio-----------------------------------//
        public string nivelPrivilegio(string nombre_usuario)
        {
            //esta consulta es solo para saber que ID tiene una empresa de la cual solo sé el nombre
            string privilegio = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT privilegios FROM {0} WHERE nombre = '{1}'", Tabla_Usuario, nombre_usuario), mysqlCon);
                DataTable usuario = new DataTable();
                mySqlCmd.Fill(usuario);
                if (usuario.Rows.Count > 0)
                {
                    DataRow row = usuario.Rows[0];
                    DataRow name = usuario.Rows[0];
                    privilegio = Convert.ToString(row[0]);
                }
                return privilegio;
            }
        }
        //------------------------------------------------------------------------------------------------------------------//
        #endregion
        #region llama solo al aleatorio y su ID
        public DataTable aleatorio()
        {
            DataTable aleatorio = new DataTable();
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM {0} WHERE idCategoria = 1", Tabla_Categoria), mysqlCon);
                DataTable categoria = new DataTable();
                mySqlCmd.Fill(categoria);
                return categoria;
            }
            return aleatorio;
        }
        #endregion
        #region Traer el id de Categoria de un Inventarios según su nombre
        public string categoriaInventario(string nombre_inventario)
        {
            string idC = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "mostrarEtiqueta" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idCategoria FROM {0} WHERE nombre = '{1}'", Tabla_Inventario, nombre_inventario), mysqlCon);
                DataTable idCategoria = new DataTable();
                mySqlCmd.Fill(idCategoria);
                if (idCategoria.Rows.Count > 0)
                {
                    DataRow row = idCategoria.Rows[0];
                    DataRow name = idCategoria.Rows[0];
                    idC = Convert.ToString(row[0]);
                }
            }
            return idC;
        }
        #endregion
        #region Estado de Inventario según conteo
        public string estadoInventario(string conteo)
        {
            string idC = "";
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "mostrarEtiqueta" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT i.idEstado FROM {0} c INNER JOIN {1} i ON c.idInventario = i.idInventario WHERE c.idconteo = '{2}'", Tabla_Conteos, Tabla_Inventario, conteo), mysqlCon);
                DataTable idCategoria = new DataTable();
                mySqlCmd.Fill(idCategoria);
                if (idCategoria.Rows.Count > 0)
                {
                    DataRow row = idCategoria.Rows[0];
                    DataRow name = idCategoria.Rows[0];
                    idC = Convert.ToString(row[0]);
                }
            }
            return idC;
        }
        #endregion
        #region verificarInventario()
        public bool verificarInventario(string inventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlDataAdapter mysqlDa = new MySqlDataAdapter(string.Format("SELECT idInventario FROM inventarios WHERE nombre = '{0}'", inventario), mysqlCon);
                bool inventarioHallado = new bool();
                DataTable dt = new DataTable();
                mysqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    inventarioHallado = true;
                }
                else
                {
                    inventarioHallado = false;
                }
                return inventarioHallado;
            }
        }
        #endregion
        #region verLuis
        public DataTable verLuis(string idInventario)
        {
            //Consulta para traer los inventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', Unidad De Medida AS 'Unidad de Medida', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio', ConteoFisico AS 'Conteo Fisico', CantidadDiferencia AS 'Cantidad Diferencia', CostoDiferencia AS 'Costo Diferencia', {1}.Nombre AS 'Empresa', {2}.User AS 'Usuario', {3}.Nombre AS 'Estado', FechaActualizacion AS 'Fecha Actualizacion', CostoDiferenciaAbsoluto, ObservacionesContador AS 'Observaciones Contador', ObservacionesGerencia AS 'Observaciones Gerencia' FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado ORDER BY idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado), mysqlCon);
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT idConteo AS 'ID', CodigoSAP AS 'Codigo SAP', DescripcionSAP AS 'Descripcion SAP', CodigoBodega AS 'Codigo Bodega', NombreBodega AS 'Nombre Bodega', ExistenciaSAP AS 'Existencia SAP', CostoPromedio 'Costo Promedio' FROM {0} INNER JOIN {1} ON {0}.idEmpresa = {1}.idEmpresa LEFT JOIN {2} ON {0}.idUsuario = {2}.idUsuario INNER JOIN {3} ON {0}.idEstado = {3}.idEstado INNER JOIN {4} ON {0}.idInventario = {4}.idInventario WHERE {0}.idInventario = {5} order by idConteo", Tabla_Conteos, Tabla_Empresa, Tabla_Usuario, Tabla_Estado, Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion
        #region Muestra los Inventario Pausados
        //---------------------------------------------------------------------------------Inventarios Clausurados---------------------------------------------------------------------------------------------------------//
        public bool InventarioPausado(string idInventario)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                string id = "";
                mysqlCon.Open();
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT {0}.idEstado FROM {0} WHERE idInventario = {1}", Tabla_Inventario, idInventario), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                if (TableInventario.Rows.Count > 0)
                {
                    DataRow row = TableInventario.Rows[0];
                    DataRow name = TableInventario.Rows[0];
                    id = Convert.ToString(row[0]);
                }
                if (id == "10")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #endregion
        
        #region Productos
        public DataTable Productos(string bodega, string patrono)
        {
            DataTable table = new DataTable();
            conexion.Open();
            if (patrono == "Unhesa")
            {
              
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT(ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre de Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Unhesa' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM[" + ip + $"].unhesa.dbo.OITM a INNER JOIN[" + ip + $"].unhesa.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN[" + ip + $"].unhesa.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({ bodega}) ORDER BY b.WhsCode", conexion);
                adapter.Fill(table);
            }
            else if (patrono == "Proquima")
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre De Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Proquima' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM [" + ip + "].proquima.dbo.OITM a INNER JOIN [" + ip + "].proquima.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN [" + ip + $"].proquima.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
                adapter.Fill(table);
            }
            else if (patrono == "Ambas")
            {
                SqlDataAdapter adapterU = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre de Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Unhesa' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM [" + ip + "].unhesa.dbo.OITM a INNER JOIN [" + ip + "].unhesa.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN [" + ip + $"].unhesa.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
                SqlDataAdapter adapterP = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre De Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Proquima' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM [" + ip + "].proquima.dbo.OITM a INNER JOIN [" + ip + "].proquima.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN [" + ip + $"].proquima.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
                adapterU.Fill(table);
                adapterP.Fill(table);
            }
            else if(patrono == "test")
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT p.idProducto AS 'ID', p.descripcion AS 'Descripcion', p.unidadDeMedida AS 'Medida', CONCAT(r.idBodega, ' - ', r.idRack) AS 'ID_Bodega', CONCAT(b.nombre, ' - ', r.nombre) AS 'Nombre_Bodega', e.existencia AS 'Existencia', p.valorUnitario AS 'Costo_Promedio', ri.descripcion AS 'Riesgo' FROM existencia e INNER JOIN producto p ON e.idProducto = p.`idProducto` INNER JOIN rack r ON e.idRack = r.idRack INNER JOIN bodega b ON r.idBodega = b.idBodega INNER JOIN riesgo ri ON p.idRiesgo = ri.idRiesgo WHERE r.idRack in ({bodega})", connection);
                    adapter.Fill(table);
                }
            }
            conexion.Close();
            return table;
        }
        #endregion
        #region Productos Filtrados
        //public DataTable ProductosFiltrados(string codigos, string patrono)
        //{
        //    DataTable table = new DataTable();
        //    conexion.Open();
        //    if (patrono == "Unhesa")
        //    {
        //        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre de Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Unhesa' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM unhesa.dbo.OITM a INNER JOIN unhesa.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN unhesa.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
        //        adapter.Fill(table);
        //    }
        //    else if (patrono == "Proquima")
        //    {
        //        SqlDataAdapter adapter = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo De Bodega', c.WhsName AS 'Nombre De Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Proquima' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM proquima.dbo.OITM a INNER JOIN proquima.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN proquima.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
        //        adapter.Fill(table);
        //    }
        //    else
        //    {
        //        SqlDataAdapter adapterU = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo de Bodega', c.WhsName AS 'Nombre de Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Unhesa' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM unhesa.dbo.OITM a INNER JOIN unhesa.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN unhesa.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
        //        SqlDataAdapter adapterP = new SqlDataAdapter($"SELECT a.ItemName AS ' Descripcion ', a.ItemCode AS ' Codigo ', CONCAT( ISNULL(a.InvntryUom, ' N / A ') COLLATE SQL_Latin1_General_CP1_CI_AS, ' -- ', U_PresentaInv COLLATE SQL_Latin1_General_CP1_CI_AS ) AS 'Unidad De Medida', b.WhsCode AS 'Codigo De Bodega', c.WhsName AS 'Nombre De Bodega', b.OnHand AS 'Existencia', b.AvgPrice AS 'Costo Promedio', 'Proquima' AS 'idEmpresa', U_Riesgo AS 'Riesgo' FROM proquima.dbo.OITM a INNER JOIN proquima.dbo.OITW b ON a.ItemCode = b.ItemCode INNER JOIN proquima.dbo.OWHS c ON b.WhsCode = c.WhsCode WHERE b.OnHand > 0 AND b.WhsCode in ({bodega}) ORDER BY b.WhsCode", conexion);
        //        adapterU.Fill(table);
        //        adapterP.Fill(table);
        //    }
        //    conexion.Close();
        //    return table;
        //}
        #endregion
        #region Insert Conteos Selectivos
        public void InsertConteoSelectivos(string DescripcionSAP, string CodigoSAP, string UnidadDeMedida, string CodigoBodega, string NombreBodega, decimal ExistenciaSAP, decimal CostoPromedio, string idEmpresa, string idInventario, string riesgo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO conteos( DescripcionSAP, CodigoSAP, UnidadDeMedida, CodigoBodega, NombreBodega, ExistenciaSAP, CostoPromedio, idEmpresa, idEstado, idInventario, riesgo ) VALUES( '{DescripcionSAP}', '{CodigoSAP}', '{UnidadDeMedida}', '{CodigoBodega}', '{NombreBodega}', {ExistenciaSAP}, {CostoPromedio}, {idEmpresa}, 1, {idInventario}, '{riesgo}' )", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion
        #region ver inventarios selectivos
        public DataTable verSelectivos()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //Nombre del procedimiento "verHallazgos" que llama a todos los inventarios sin excepción
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT `idInventario` as 'ID', `nombre` as 'Nombre', `Hora_Inicio` as 'Inicia' FROM `inventarios` WHERE `idCategoria` = 4"), mysqlCon);
                DataTable table = new DataTable();
                mySqlCmd.Fill(table);
                return table;
            }
        }
        #endregion
        #region Editar Selectivos
        public DataTable editarSelectivos()
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"", connection);
                adapter.Fill(table);
            }
            return table;
        }
        #endregion
        #region Obtener Configuración
        public void obtenerConf()
        {
            
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("SELECT * FROM configuracion WHERE idConfiguracion = 1"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    ip = Convert.ToString(conf.Rows[0].Field<string>("ip"));
                    usuarioSAP = Convert.ToString(conf.Rows[0].Field<string>("usuario"));
                    PasswordSAP = Convert.ToString(conf.Rows[0].Field<string>("contrasena"));
                }
            }
        }
        #endregion
        #region Ver Racks
        public DataTable verRacks(string bodegas)
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT r.idRack AS 'ID Rack', r.nombre AS 'Nombre Rack', r.idBodega AS 'ID Bodega', b.nombre AS 'Nombre Bodega' FROM `rack` r INNER JOIN bodega b ON r.`idBodega` = b.idBodega WHERE r.idBodega IN ({bodegas})", connection);
                adapter.Fill(table);
            }
            return table;
        }
        #endregion
        #region Modificar configuración
        public void ActualizarConf(string ip, string usuario, string contrasena)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand(string.Format("UPDATE configuracion SET ip = '{0}', usuario = '{1}', contrasena = '{2}' WHERE idConfiguracion = 1", ip, usuario, contrasena), mysqlCon);
                mySqlCmd.ExecuteNonQuery();
            }
        }
        #endregion

        //categorias

        #region ObtenerCategorias
        public DataTable ObtenerCategorias()
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("Select idCategoriaP as ID, descripcion as Nombre FROM CategoriaP" ), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion
        #region Insert Categoria
        public void InsertCategoria(string nombre)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO categoriaP( descripcion) VALUES( '{nombre}' )", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region VerificarCategoria
        public bool VerificarCategoria(string nombre)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM CategoriaP WHERE descripcion = '{nombre}'"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    return false;
                }else
                {
                    return true;
                }

            }
        }
        #endregion
        #region editar Categoria
        public void EditarCategoria(string nombre, string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"UPDATE categoriaP set descripcion = '{nombre}' where idCategoriaP = {id} ", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        //productos 
        #region ObtenerProductos
        public DataTable ObtenerProductos()
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("select p.idProducto as ID, p.descripcion as Descripción, p.valorUnitario as \"Valor Unitario(Q)\", p.unidadDeMedida as \"Unidad de Medida\", r.descripcion as Riesgo, c.descripcion as Categoría from producto p inner join Riesgo r on p.idRiesgo = r.idRiesgo inner join CategoriaP c on p.idCategoriaP = c.idCategoriaP;"), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion

        #region ObtenerRiesgos
        public DataTable ObtenerRiesgos()
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("Select idRiesgo as ID, descripcion as Nombre FROM Riesgo"), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion

        #region Verificar Producto
        public string idCategoria;
        public string idRiesgo;
        public string unidad;
        public bool VerificarProducto(string nombre)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM Producto WHERE descripcion = '{nombre}'"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    return false;
                }else
                {
                    return true;
                }
            }
        }

        public void ObtenerProducto(string id)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM Producto WHERE idProducto = {id}"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    DataRow row = conf.Rows[0];
                    idCategoria = Convert.ToString(row[5]);
                    idRiesgo = Convert.ToString(row[4]);
                    unidad = Convert.ToString(row[3]);
                }
            }
        }
        #endregion
        #region Insert Producto
        public void InsertProducto(string nombre, string unidad, string valor, string idCategoria, string idRiesgo)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO Producto( descripcion, unidadDeMedida, valorUnitario, idCategoriaP, idRiesgo) VALUES( '{nombre}', '{unidad}', '{valor}', '{idCategoria}', '{idRiesgo}' )", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Editar Producto
        public void EditarProducto(string nombre, string unidad, string valor, string idCategoria, string idRiesgo, string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"UPDATE Producto set descripcion = '{nombre}', unidadDeMedida = '{unidad}',  valorUnitario = '{valor}', idCategoriaP = {idCategoria}, idRiesgo ={idRiesgo} where idProducto = {id}", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion


        //Bodegas

        #region Obtener Bodegas
        public DataTable ObtenerBodegas()
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("Select idBodega as ID, nombre as Nombre FROM Bodega"), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion
        #region Insert Bodega
        public void InsertBodega(string nombre)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO Bodega( nombre) VALUES( '{nombre}' )", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region VerificarBodega
        public bool VerificarBodega(string nombre)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM Bodega WHERE nombre = '{nombre}'"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        #endregion
        #region editar Bodega
        public void EditarBodega(string nombre, string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"UPDATE Bodega set nombre = '{nombre}' where idBodega = {id} ", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        //Existencias

        #region Obtener Existencias
        public DataTable ObtenerExistencias()
        {
            //Llama la conexión y la abre para usar un procedimiento y mostrarla en el dgvInventarios
            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();

                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format("select e.idExistencia as ID, p.descripcion as Producto, b.nombre as Bodega, p.unidadDeMedida \"Unidad de Medida\", e.existencia as Existencia, (e.existencia * p.valorUnitario) as Costo, e.fechaActualizacion as \"Fecha de Actualización\" from Existencia e inner join Producto p on e.idProducto = p.idProducto inner join Bodega b on e.idBodega = b.idBodega"), mysqlCon);
                DataTable TableInventario = new DataTable();
                mySqlCmd.Fill(TableInventario);
                return TableInventario;
            }
        }
        #endregion

        #region Verificar Existencia
        public bool VerificarExistencias(string idProducto, string idBodega)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM Existencia WHERE idProducto = '{idProducto}' AND idBodega = '{idBodega}' "), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        #endregion

        #region Insert Existencia
        public void InsertExistencia(string idProducto, string idBodega, string existencia)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"INSERT INTO Existencia( idProducto, idBodega, existencia, fechaActualizacion ) VALUES( {idProducto}, {idBodega}, {existencia}, now())", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Verificar Existencia
        public string idProducto;
        public string idBodega;
        public string existencia;
        public void ObtenerExistencia(string id)
        {

            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                mysqlCon.Open();
                //
                MySqlDataAdapter mySqlCmd = new MySqlDataAdapter(string.Format($"SELECT * FROM Existencia WHERE idExistencia = {id}"), mysqlCon);
                DataTable conf = new DataTable();
                mySqlCmd.Fill(conf);
                if (conf.Rows.Count > 0)
                {
                    DataRow row = conf.Rows[0];
                    idProducto = Convert.ToString(row[1]);
                    idBodega = Convert.ToString(row[2]);
                    existencia = Convert.ToString(row[3]);
                }
            }
        }

        #endregion

        #region Editar Existencia
        public void EditarExistencia(string idProducto, string idBodega, string existencia, string id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand($"UPDATE Existencia set idProducto = {idProducto}, idBodega = {idBodega},  existencia = {existencia}, fechaActualizacion = now() where idExistencia = {id}", connection);
                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Bodegas Locales
        public DataTable bodegas_locales()
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT idBodega as 'ID', CONCAT(idBodega, ' - ', nombre) as 'Nombre' FROM `bodega` WHERE 1", connection);
                adapter.Fill(table);
            }
            return table;
        }
        #endregion
    }
}
