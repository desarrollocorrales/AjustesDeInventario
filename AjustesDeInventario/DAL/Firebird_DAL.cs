using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using AjustesDeInventario.Modelos;

namespace AjustesDeInventario.DAL
{
    public class Firebird_DAL
    {
        private Microsip objMicrosip;
        private FbConnection Conexion;
        private FbCommand Comando;
        private FbDataAdapter Adapter;

        public string FbError;

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
                Conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                FbError = ex.Message;
                return false;
            }
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
