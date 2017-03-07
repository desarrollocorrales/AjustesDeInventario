using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AjustesDeInventario
{
    public static class Logger
    {
        public static void BorrarLog()
        {
            string sFileName = "Inventario_" + DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamWriter swFile = new StreamWriter(Environment.CurrentDirectory + "\\Logs\\" + sFileName, false);
            swFile.Close();
        }

        public static void AgregarLog(string Mensaje)
        {
            string sFileName = "Inventario_" + DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamWriter swFile = new StreamWriter(Environment.CurrentDirectory + "\\Logs\\" + sFileName, true);
            swFile.WriteLine(DateTime.Now + ": " + Mensaje);
            swFile.Close();
        }

        public static void AgregarLog()
        {
            string sFileName = "Inventario_" + DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamWriter swFile = new StreamWriter(Environment.CurrentDirectory + "\\Logs\\" + sFileName, true);
            swFile.WriteLine();
            swFile.Close();
        }
    }
}
