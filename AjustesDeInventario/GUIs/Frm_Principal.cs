﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccSettings;
using AjustesDeInventario.DAL;
using AjustesDeInventario.Modelos;
using LinqToExcel;
using Remotion.Data.Linq;
using Sofbr;
using AjustesDeInventario.DAL;

namespace AjustesDeInventario.GUIs
{
    public partial class Frm_Principal : Form
    {
        private string RutaArchivoMicrosip;
        private string RutaArchivoExcel;
        private Microsip objMicrosip;
        private bool PruebaDeConexion;
        private List<Cedula> lstDatosCedula;
 
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void btnBuscarMicrosip_Click(object sender, EventArgs e)
        {
            BuscarConfiguracionMicrosip();
        }
        private void BuscarConfiguracionMicrosip()
        {
            dialogoArchivos.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dialogoArchivos.FileName = "*.set";
            dialogoArchivos.Filter = "Archivos SET | *.set";
            DialogResult dr = dialogoArchivos.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                btnPruebaConexion.Visible = true;
                RutaArchivoMicrosip = dialogoArchivos.FileName;
                txbArchivoMicrosip.Text = dialogoArchivos.SafeFileName;
            }
        }

        private void btnPruebaConexion_Click(object sender, EventArgs e)
        {
            ProbarConexionMicrosip();
        }
        private void ProbarConexionMicrosip()
        {
            lblEstadoMicrosip.Visible = true;
            lblEstadoMicrosip.ForeColor = System.Drawing.Color.Black;
            lblEstadoMicrosip.Text = string.Empty;

            bool carga_de_configuraciones = CargarConfiguraciones();
            if (carga_de_configuraciones == true)
            {
                Firebird_DAL FbDal = new Firebird_DAL(objMicrosip);
                bool prueba_de_conexion = FbDal.ProbarConexion();
                if (prueba_de_conexion == true)
                {
                    MessageBox.Show("La conexión se ha realizado con exito!!!");
                    lblEstadoMicrosip.Text = "Sucursal: " + objMicrosip.Sucusal;
                    lblEstadoMicrosip.ForeColor = System.Drawing.Color.Green;
                    PruebaDeConexion = true;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Ocurrio un error al realizar la conexión a Microsip.");
                    sb.AppendLine(FbDal.FbError);
                    MessageBox.Show(sb.ToString());

                    lblEstadoMicrosip.Text = "Error: " + FbDal.FbError;
                    lblEstadoMicrosip.ForeColor = System.Drawing.Color.Red;
                    PruebaDeConexion = false;
                }
            }
        }
        private bool CargarConfiguraciones()
        {
            MicroSipSettings MicrosipSettings = new MicroSipSettings();
            MicrosipSettings.FileName = this.RutaArchivoMicrosip;
            MicrosipSettings.Key = "C0RR4L35";

            try
            {
                lblEstadoMicrosip.Text = "Descifrando el archivo Microsip.set...";
                Application.DoEvents();

                MicrosipSettings = MicrosipSettings.Deserialize<MicroSipSettings>(true);

                lblEstadoMicrosip.Text = "Cargando Configuraciones...";
                Application.DoEvents();

                objMicrosip = new Microsip();
                objMicrosip.Sucusal = MicrosipSettings.Conexiones[0].Empresa;
                objMicrosip.BaseDeDatos = MicrosipSettings.Conexiones[0].Host;
                objMicrosip.Usuario = MicrosipSettings.Conexiones[0].Usuario;
                objMicrosip.Contraseña = MicrosipSettings.Conexiones[0].PassWord;
                objMicrosip.Puerto = MicrosipSettings.Conexiones[0].Puerto;
                return true;
            }
            catch (Exception ex)
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.AppendLine("Ocurrio un error al cargar los archivos de configuración.");
                sbMensaje.Append(string.Format("Exception: {0}", ex.Message));

                MessageBox.Show(sbMensaje.ToString());
                return false;
            }
        }

        private void btnBuscarExcel_Click(object sender, EventArgs e)
        {
            if (BuscarExcelResulados() == true)
            {
                var excel = new ExcelQueryFactory("Resultados de Inventario.xls");
                var ValoresCedula = from cedula in excel.Worksheet<Cedula>("Resultados")
                                    select cedula;

                lstDatosCedula = ValoresCedula.ToList();
                gridResultados.DataSource = lstDatosCedula;
                gvResultados.BestFitColumns();
            }
        }
        private bool BuscarExcelResulados()
        {
            dialogoArchivos.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            dialogoArchivos.FileName = "*.xls";
            dialogoArchivos.Filter = "Archivos Excel | *.xls";
            DialogResult dr = dialogoArchivos.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                btnPruebaConexion.Visible = true;
                RutaArchivoExcel = dialogoArchivos.FileName;
                txbArchivoExcel.Text = dialogoArchivos.SafeFileName;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Procesar();
        }
        private void Procesar()
        {
            if (PruebaDeConexion == true)
            {
                if (lstDatosCedula.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Este proceso actualizará la informacion de Microsip para la Empresa: " + objMicrosip.Sucusal);
                    sb.AppendLine("(Una vez realizado el proceso no puede ser deshecho)");
                    sb.AppendLine("¿La información es correcta?");
                    DialogResult dr = MessageBox.Show(sb.ToString(), "Validar", 
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ExportarResultados();
                    }
                }
                else
                {
                    MessageBox.Show("No se han cargado los resultados del inventario...", "Error", 
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Primero debe realizar una prueba de conexión a Microsip...", "Error", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportarResultados()
        {
            MessageBox.Show("Exportar Resultados");
            Logger.AgregarLog("****************************** Inicio ******************************"); 
            Logger.AgregarLog("Inicia el proceso para la empresa " + objMicrosip.Sucusal);
            
            //Obtenemos los faltantes y los sobrantes
            List<Cedula> lstFaltantes = lstDatosCedula.FindAll(o => o.Faltante != 0);
            List<Cedula> lstSobrantes = lstDatosCedula.FindAll(o => o.Sobrante != 0);
            List<Cedula> lstSinCambios = lstDatosCedula.FindAll(o => o.Faltante == 0 && o.Sobrante == 0);

            //Reportamos en el Log
            Logger.AgregarLog("... Ajustes de Salida: " + lstFaltantes.Count);
            Logger.AgregarLog("... Ajustes de Entrada: " + lstSobrantes.Count);
            Logger.AgregarLog("... Sin cambios: " + lstSinCambios.Count);

            //Creamos una instancia a la capa de acceso a datos
            Firebird_DAL FbDal = new Firebird_DAL(objMicrosip);

            //Obtener todos los articulos de Microsip con su clave principal

            //Ejecutar el proceso para actualizar los detos de Microsip


            Logger.AgregarLog("******************************* Final ******************************");
            Logger.AgregarLog(); 
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            lstDatosCedula = new List<Cedula>();
        }
    }
}
