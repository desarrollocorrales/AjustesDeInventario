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

        public bool ExportarResultadosAMicrosip()
        {
            bool bExito = false;

            Conexion.ConnectionString = getStringConnection();
            Conexion.Open();
            FbTransaction transaccion =  Conexion.BeginTransaction();
            try
            {
                //Crear Encabezado

                //Insertar Faltantes

                //Insertar Sobrantes


                transaccion.Commit();
                bExito = true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                bExito = false;
                FbError = ex.Message;
            }
            finally
            {
                if (Conexion.State != ConnectionState.Closed)
                    Conexion.Close();
            }

            return bExito;
        }
        private void CrearEncabezado(FbConnection objConexion)
        {
            Comando.Connection = objConexion;
            Comando.CommandText = "";
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
