using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AjustesDeInventario.GUIs
{
    public partial class FrmLog : Form
    {
        public FrmLog()
        {
            InitializeComponent();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            CargarLog();
        }
        private void CargarLog()
        {
            string sFileName = "Inventario_" + DateTime.Now.ToString("ddMMyyyy") + ".log";
            StreamReader swFile = new StreamReader(Environment.CurrentDirectory + "\\Logs\\" + sFileName);
            txbLog.Text = swFile.ReadToEnd();
            swFile.Close();
        }
    }
}
