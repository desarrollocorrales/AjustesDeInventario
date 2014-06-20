using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using AjustesDeInventario.Modelos;
using System.Data;
namespace AjustesDeInventario.DAL
{
    public class Firebird_DAL
    {
        private uint DoctoID;
        private Microsip objMicrosip;
        private FbConnection Conexion;
        private FbCommand Comando;
        private FbDataAdapter Adapter;

        public string FbError;
        public string Empresa;

        public Firebird_DAL(Microsip objMicrosip)
        {
            this.objMicrosip = objMicrosip;
            Conexion = new FbConnection();
            Comando = new FbCommand();
            Adapter = new FbDataAdapter();
        }

        public bool ProbarConexion()
        {
            try
            {
                Conexion.ConnectionString = getStringConnection();
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandText = 
                    @"SELECT 
                      R2.VALOR
                    FROM
                      REGISTRY R1
                      INNER JOIN REGISTRY R2 ON (R1.ELEMENTO_ID = R2.PADRE_ID)
                    WHERE
                      R1.NOMBRE LIKE 'DatosEmpresa' AND 
                      R2.NOMBRE LIKE 'Nombre'";

                object obj = Comando.ExecuteScalar();
                Empresa = Convert.ToString(obj);

                Conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                FbError = ex.Message;
                return false;
            }
        }

        public List<Articulo> ObtenerArticulos()
        {
            List<Articulo> lstArticulos = new List<Articulo>();

            try
            {
                Comando.Connection = Conexion;
                Conexion.ConnectionString = getStringConnection();
                Conexion.Open();

                Comando.CommandText = 
                        @"SELECT 
                          ARTICULO_ID, CLAVE_ARTICULO
                        FROM
                          CLAVES_ARTICULOS
                        WHERE
                          ROL_CLAVE_ART_ID = 17";
                
                Adapter.SelectCommand = Comando;
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                Articulo articulo;
                foreach (DataRow row in dt.Rows)
                {
                    articulo = new Articulo();
                    articulo.Articulo_ID = Convert.ToInt32(row["ARTICULO_ID"]);
                    articulo.Clave = Convert.ToString(row["CLAVE_ARTICULO"]);

                    lstArticulos.Add(articulo);
                }

                Logger.AgregarLog(string.Format("......Se obtuvieron {0} articulos de Microsip", lstArticulos.Count));
            }
            catch (Exception ex)
            {
                Logger.AgregarLog("......" + ex.Message);
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return lstArticulos;
        }

        public List<Almacen> ObtenerAlmacenes()
        {
            List<Almacen> lstAlmacenes = new List<Almacen>();

            try
            {
                Comando.Connection = Conexion;
                Conexion.ConnectionString = getStringConnection();
                Conexion.Open();

                Comando.CommandText = "SELECT ALMACEN_ID, NOMBRE FROM ALMACENES";

                Adapter.SelectCommand = Comando;
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                Almacen almacen;
                foreach (DataRow row in dt.Rows)
                {
                    almacen = new Almacen();
                    almacen.ID = Convert.ToInt32(row["ALMACEN_ID"]);
                    almacen.Nombre = Convert.ToString(row["NOMBRE"]);

                    lstAlmacenes.Add(almacen);
                }
            }
            catch (Exception ex)
            {
                Logger.AgregarLog("......" + ex.Message);
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return lstAlmacenes;
        }

        public List<ConceptoInventario> ObtenerConceptosInventario()
        {
            List<ConceptoInventario> lstConceptosInventario = new List<ConceptoInventario>();

            try
            {
                Comando.Connection = Conexion;
                Conexion.ConnectionString = getStringConnection();
                Conexion.Open();

                Comando.CommandText = "SELECT CONCEPTO_IN_ID, NOMBRE FROM CONCEPTOS_IN";

                Adapter.SelectCommand = Comando;
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                ConceptoInventario conceptoInventario;
                foreach (DataRow row in dt.Rows)
                {
                    conceptoInventario = new ConceptoInventario();
                    conceptoInventario.ID = Convert.ToInt32(row["CONCEPTO_IN_ID"]);
                    conceptoInventario.Nombre = Convert.ToString(row["NOMBRE"]);

                    lstConceptosInventario.Add(conceptoInventario);
                }
            }
            catch (Exception ex)
            {
                Logger.AgregarLog("......" + ex.Message);
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return lstConceptosInventario;
        }

        public DateTime obtenerFechaDelServidor()
        {
            DateTime fecha = new DateTime();

            try
            {
                Comando.Connection = Conexion;
                Conexion.ConnectionString = getStringConnection();
                Conexion.Open();

                Comando.CommandText = "Select Cast('Now' As Date) From rdb$database";
                object obj = Comando.ExecuteScalar();

                fecha = Convert.ToDateTime(obj);
            }
            catch (Exception ex)
            {
                Logger.AgregarLog("......" + ex.Message);
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return fecha;
        }

        public bool ExportarResultadosAMicrosip(List<Cedula> lstResultados, List<Articulo> lstArticulos)
        {
            bool bExito = false;

            Conexion.ConnectionString = getStringConnection();
            Conexion.Open();
            FbTransaction Transaccion =  Conexion.BeginTransaction();
            try
            {
                //Crear encabezado entradas
                CrearEncabezado(Conexion, Transaccion, "E");
                //Insertar Sobrantes
                List<Cedula> lstSobrantes = lstResultados.FindAll(o => o.Sobrante != 0);
                InsertarDetalles(Conexion, Transaccion, "E", lstSobrantes, lstArticulos);

                //Crear encabezado salidas
                CrearEncabezado(Conexion, Transaccion, "S");
                //Insertar Falantes
                List<Cedula> lstFaltantes = lstResultados.FindAll(o => o.Faltante != 0);
                InsertarDetalles(Conexion, Transaccion, "S", lstFaltantes, lstArticulos);

                Transaccion.Commit();
                bExito = true;
            }
            catch (Exception ex)
            {
                Transaccion.Rollback();
                bExito = false;
                FbError = ex.Message;
                Logger.AgregarLog("............ Error: " + ex.Message);
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return bExito;
        }
        private uint ObtenerID_Docto(FbConnection objConexion, FbTransaction objTransaccion)
        {
            uint IdDocto = 0;
            Comando.Connection = objConexion;
            Comando.Transaction = objTransaccion;
            Comando.CommandText = "SELECT GEN_ID(ID_DOCTOS, 1) FROM rdb$database";

            object obj = Comando.ExecuteScalar();
            IdDocto = Convert.ToUInt32(obj);

            return IdDocto;
        }
        private void CrearEncabezado(FbConnection objConexion, FbTransaction objTransaccion, string Naturaleza)
        {
            int ConceptoID = 0;
            string Descripcion = string.Empty;

            if (Naturaleza == "E") 
            { 
                ConceptoID = FiltrosInventario.ConceptoEntradaID;
                Descripcion = "Sobrantes. Resultado de inventario físico";

            }
            else if (Naturaleza == "S") 
            { 
                ConceptoID = FiltrosInventario.ConceptoSalidaID;
                Descripcion = "Faltantes. Resultado de inventario físico";
            }

            Comando.Connection = objConexion;
            Comando.Transaction = objTransaccion;
            Comando.CommandText =
                String.Format(@"INSERT INTO 
                                  DOCTOS_IN (DOCTO_IN_ID, ALMACEN_ID, CONCEPTO_IN_ID, 
                                             FOLIO, NATURALEZA_CONCEPTO, FECHA, SISTEMA_ORIGEN, DESCRIPCION) 
                                VALUES
                                  (-1, {0}, {1}, '{3}{2}', '{3}', '{4}', 'IN', '{5}')
                                RETURNING DOCTO_IN_ID", 
                                  FiltrosInventario.AlmacenID,
                                  ConceptoID,
                                  FiltrosInventario.FechaServer.ToString("ddMMyyyy"),
                                  Naturaleza,
                                  FiltrosInventario.FechaServer.ToString("yyyy-MM-dd"),
                                  Descripcion);

            object obj = Comando.ExecuteScalar();

            //Obtenemos el Id de la insercion
            DoctoID = Convert.ToUInt32(obj);

            if (Naturaleza == "E")
            {
                Logger.AgregarLog("......... Se a creado encabezado para las entradas con ID: " + DoctoID +
                                  " y Folio: " + Naturaleza + FiltrosInventario.FechaServer.ToString("ddMMyyyy"));
            }
            else if (Naturaleza == "S")
            {
                Logger.AgregarLog("......... Se a creado encabezado para las salidas con ID: " + DoctoID +
                                  " y Folio: " + Naturaleza + FiltrosInventario.FechaServer.ToString("ddMMyyyy"));
            }
        }
        private void InsertarDetalles(FbConnection objConexion, FbTransaction objTransaccion, 
                                      string Naturaleza, List<Cedula> lstDetalles, List<Articulo> lstArticulos)
        {
            int ConceptoID = 0, NoEncontrados = 0;
            if (Naturaleza == "E") { ConceptoID = FiltrosInventario.ConceptoEntradaID; }
            else if (Naturaleza == "S") { ConceptoID = FiltrosInventario.ConceptoSalidaID; }

            Comando.Connection = objConexion;
            Comando.Transaction = objTransaccion;

            foreach (Cedula Movimiento in lstDetalles)
            {
                double Unidades = 0;
                if (Naturaleza == "E") { Unidades = Math.Abs(Movimiento.Sobrante); }
                else if (Naturaleza == "S") { Unidades = Math.Abs(Movimiento.Faltante); }

                Articulo objArticulo = lstArticulos.Find(o => o.Clave == Movimiento.Clave);
                if (objArticulo == null)
                {
                    Logger.AgregarLog("............ No se encontro el artículo con clave: " + Movimiento.Clave);
                    NoEncontrados++;
                    continue;                    
                }

                Comando.CommandText =
                    String.Format(@"INSERT INTO DOCTOS_IN_DET
                                        (DOCTO_IN_DET_ID, DOCTO_IN_ID, ALMACEN_ID, CONCEPTO_IN_ID, 
                                         CLAVE_ARTICULO, ARTICULO_ID, TIPO_MOVTO, UNIDADES, COSTO_UNITARIO, 
                                         COSTO_TOTAL, APLICADO, METODO_COSTEO, FECHA)
                                    VALUES
                                        (-1, {0}, {1}, {2}, 
                                         '{3}', {4}, '{5}', {6}, {7}, ({6}*{7}),
                                         'S', 'C', '{8}')",
                                      DoctoID, 
                                      FiltrosInventario.AlmacenID, 
                                      ConceptoID,
                                      objArticulo.Clave,
                                      objArticulo.Articulo_ID,
                                      Naturaleza,
                                      Unidades,
                                      Math.Abs(Movimiento.CostoUnitario),
                                      FiltrosInventario.FechaServer.ToString("yyyy-MM-dd"));

                Comando.ExecuteNonQuery();

                Logger.AgregarLog("............ Insertado movimiento con naturaleza '" + Naturaleza + "'" +
                                  " | Clave Articulo: " + objArticulo.Clave + " | Unidades: " + Unidades + 
                                  " | Costo Unitario: " + Movimiento.CostoUnitario);
            }

            Logger.AgregarLog("............ No se encontraron " + NoEncontrados + " artículos");
        }

        private string getStringConnection()
        {
            FbConnectionStringBuilder fcsb = new FbConnectionStringBuilder();
            fcsb.UserID = objMicrosip.Usuario;
            fcsb.Password = objMicrosip.Contraseña;
            fcsb.Port = objMicrosip.Puerto;
            fcsb.Database = objMicrosip.BaseDeDatos;

            return fcsb.ToString();
        }
    }
}
