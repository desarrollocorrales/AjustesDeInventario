using System;
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
using ApiBas = ApisMicrosip.ApiMspBasicaExt;
using ApiInv = ApisMicrosip.ApiMspInventExt;

namespace AjustesDeInventario.GUIs
{
    public partial class Frm_Principal : Form
    {
        private enum TipoExportacion
        {
            Entradas = 0,
            Salidas = 1
        }
        //************************** Variables para la aplicación ******************************
        private bool Success;
        private string Empresa;
        private string RutaArchivoMicrosip;
        private string RutaArchivoExcel;
        private Microsip objMicrosip;
        private bool PruebaDeConexion;
        private List<Cedula> lstDatosCedula;
        //**************************************************************************************
        //*********************** Variables para la Api de Microsip ****************************
        private int HandlerDatabase = 0, HandlerMetadatos = 0;
        private bool bConexion = false, esCompatible = false;
        private StringBuilder MensajeError;
        //**************************************************************************************

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
            ChecarCompatibilidadAPI();
        }
        private void ProbarConexionMicrosip()
        {
            lblEstadoMicrosip.Visible = true;
            lblEstadoMicrosip.ForeColor = System.Drawing.Color.Black;
            lblEstadoMicrosip.Text = string.Empty;

            bool carga_de_configuraciones = CargarConfiguraciones();
            bConexion = carga_de_configuraciones;
            if (carga_de_configuraciones == true)
            {
                Firebird_DAL FbDal = new Firebird_DAL(objMicrosip);
                bool prueba_de_conexion = FbDal.ProbarConexion();
                if (prueba_de_conexion == true)
                {
                    //MessageBox.Show("La conexión se ha realizado con exito!!!");

                    Empresa = FbDal.Empresa;
                    lblEstadoMicrosip.Text = "Sucursal: " + FbDal.Empresa;
                    lblEstadoMicrosip.ForeColor = System.Drawing.Color.Green;
                    PruebaDeConexion = true;

                    cbAlmacenes.DataSource = FbDal.ObtenerAlmacenes();
                    cbAlmacenes.DisplayMember = "Nombre";
                    cbAlmacenes.ValueMember = "ID";
                    cbConceptoEntrada.DataSource = FbDal.ObtenerConceptosInventario().FindAll(o => o.ID == 26);
                    cbConceptoEntrada.DisplayMember = "Nombre";
                    cbConceptoEntrada.ValueMember = "ID";
                    cbConceptoSalida.DataSource = FbDal.ObtenerConceptosInventario().FindAll(o => o.ID == 37);
                    cbConceptoSalida.DisplayMember = "Nombre";
                    cbConceptoSalida.ValueMember = "ID";
                    FiltrosInventario.FechaServer = FbDal.obtenerFechaDelServidor();
                    pnFiltros.Visible = true;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Ocurrio un error al realizar la conexión a Microsip.");
                    sb.AppendLine("Error: " + FbDal.FbError);
                    lblEstadoMicrosip.Text = sb.ToString();
                    lblEstadoMicrosip.ForeColor = System.Drawing.Color.Red;
                    PruebaDeConexion = false;

                    cbAlmacenes.DataSource = null;
                    cbConceptoEntrada.DataSource = null;
                    cbConceptoSalida.DataSource = null;
                    pnFiltros.Visible = false;
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
                objMicrosip.Sucusal = "ABASTECEDORA LOCAL"; //MicrosipSettings.Conexiones[0].Empresa;
                objMicrosip.BaseDeDatos = @"G:\Microsip datos\Microsip_datos_LIBERTAD\HCONUEVA.FDB"; //MicrosipSettings.Conexiones[0].Host;
                objMicrosip.Usuario = "SYSDBA"; // MicrosipSettings.Conexiones[0].Usuario;
                objMicrosip.Contraseña = "masterkey"; // MicrosipSettings.Conexiones[0].PassWord;
                objMicrosip.Puerto = 3050; // MicrosipSettings.Conexiones[0].Puerto;


                //objMicrosip.Sucusal = MicrosipSettings.Conexiones[0].Empresa;
                //objMicrosip.BaseDeDatos = MicrosipSettings.Conexiones[0].Host;
                //objMicrosip.Usuario = MicrosipSettings.Conexiones[0].Usuario;
                //objMicrosip.Contraseña = MicrosipSettings.Conexiones[0].PassWord;
                //objMicrosip.Puerto = MicrosipSettings.Conexiones[0].Puerto;

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
            try
            {
                if (BuscarExcelResulados() == true)
                {
                    var excel = new ExcelQueryFactory(RutaArchivoExcel);
                    var ValoresCedula = from cedula in excel.Worksheet<Cedula>("Resultados")
                                        select cedula;
                    lstDatosCedula = ValoresCedula.ToList();
                    if (lstDatosCedula.Count == 0)
                    {
                        MessageBox.Show("El archivo de resultados de inventario esta vacio...", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        gridResultados.DataSource = lstDatosCedula;
                        gvResultados.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Procesar(TipoExportacion.Entradas);
        }
        private void Procesar(TipoExportacion tipoExportacion)
        {
            if (PruebaDeConexion == true && esCompatible == true)
            {
                if (lstDatosCedula.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Este proceso actualizará la informacion de Microsip para la Empresa: " + Empresa);
                    sb.AppendLine("(Una vez realizado el proceso no puede ser deshecho)");
                    sb.AppendLine();
                    sb.AppendLine("Almacen: " + ((Almacen)(cbAlmacenes.SelectedItem)).Nombre);
                    sb.AppendLine("Concepto de entrada: " + ((ConceptoInventario)(cbConceptoEntrada.SelectedItem)).Nombre);
                    sb.AppendLine("Concepto de salida: " + ((ConceptoInventario)(cbConceptoSalida.SelectedItem)).Nombre);
                    sb.AppendLine();
                    sb.AppendLine("¿La información es correcta?");
                    DialogResult dr = MessageBox.Show(sb.ToString(), "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        switch (tipoExportacion)
                        {
                            case TipoExportacion.Entradas:
                                bgwProceso.RunWorkerAsync();  
                                break;
                            case TipoExportacion.Salidas:
                                bgwSalidas.RunWorkerAsync();
                                break;
                        }

                        pbCargando.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("No se han cargado los resultados del inventario...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Primero debe realizar una prueba de conexión a Microsip...");
                sb.AppendLine("Seleccione un archivo de configuración y presione el boton 'Probar Conexión'");
                MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ExportarResultados(TipoExportacion tipoExportacion)
        {
            //Obtenemos los faltantes y los sobrantes
            List<Cedula> lstFaltantes = lstDatosCedula.FindAll(o => o.Faltante != 0);
            List<Cedula> lstSobrantes = lstDatosCedula.FindAll(o => o.Sobrante != 0);
            List<Cedula> lstSinCambios = lstDatosCedula.FindAll(o => o.Faltante == 0 && o.Sobrante == 0);

            //Creamos una instancia a la capa de acceso a datos
            Firebird_DAL FbDal = new Firebird_DAL(objMicrosip);

            //Obtener todos los articulos de Microsip con su clave principal
            List<Articulo> lstArticulos = FbDal.ObtenerArticulos();

            Logger.AgregarLog("****************************** Inicio ******************************");
            Logger.AgregarLog("Inicia el proceso para la empresa " + objMicrosip.Sucusal);

            switch (tipoExportacion)
            {
                case TipoExportacion.Entradas:
                    Logger.AgregarLog("... Ajustes de Entrada: " + lstSobrantes.Count);
                    ImportarEntradas(lstSobrantes, lstArticulos);
                    break;

                case TipoExportacion.Salidas:
                    Logger.AgregarLog("... Ajustes de Salida: " + lstFaltantes.Count);
                    ImportarSalidas(lstFaltantes, lstArticulos);
                    break;
            }

            Logger.AgregarLog("... Sin cambios: " + lstSinCambios.Count);

            Logger.AgregarLog("******************************* Final ******************************");
            Logger.AgregarLog();

            return Success;
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            lstDatosCedula = new List<Cedula>();
            lblEstadoMicrosip.Text = "Sin conexion a Microsip";
            FiltrosInventario.AlmacenID = 0;
            FiltrosInventario.ConceptoEntradaID = 0;
            FiltrosInventario.ConceptoSalidaID = 0;
            
            Logger.BorrarLog();

            InicializarHandlers();            
        }

        private void cbAlmacenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cbAlmacenes.SelectedItem;
            if (obj != null)
                FiltrosInventario.AlmacenID = ((Almacen)(cbAlmacenes.SelectedItem)).ID;
            else
                FiltrosInventario.AlmacenID = 0;
        }

        private void cbConceptoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cbAlmacenes.SelectedItem;
            if (obj != null)
                FiltrosInventario.ConceptoEntradaID = ((ConceptoInventario)(cbConceptoEntrada.SelectedItem)).ID;
            else
                FiltrosInventario.ConceptoEntradaID = 0;
        }

        private void cbConceptoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj = cbAlmacenes.SelectedItem;
            if (obj != null)
                FiltrosInventario.ConceptoSalidaID = ((ConceptoInventario)(cbConceptoSalida.SelectedItem)).ID;
            else
                FiltrosInventario.ConceptoSalidaID = 0;
        }

        private void bgwProceso_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Success = ExportarResultados(TipoExportacion.Entradas);
        }

        private void bgwProceso_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pbCargando.Visible = false;
            if (Success == true)
            {
                MessageBox.Show("El proceso ha terminado con exito!!!", "OK",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un error, por favor revise el Log...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new FrmLog().ShowDialog();
            }
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApiBas.DBDisconnect(-1);
            Logger.AgregarLog(" Se desconectan todas las bases de datos...");
        }

        private void btnExportarSalidas_Click(object sender, EventArgs e)
        {
            Procesar(TipoExportacion.Salidas);
        }

        private void bgwSalidas_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Success = ExportarResultados(TipoExportacion.Salidas);
        }

        private void bgwSalidas_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pbCargando.Visible = false;
            if (Success == true)
            {
                MessageBox.Show("El proceso ha terminado con exito!!!", "OK",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio un error, por favor revise el Log...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new FrmLog().ShowDialog();
            }
        }

        #region ***** API Microsip *****

        private string obtenerMetadatos()
        {
            string sMetadatos = sMetadatos = System.IO.Path.GetDirectoryName(objMicrosip.BaseDeDatos) + "\\System\\Metadatos.fdb";
            return sMetadatos;
        }

        private void InicializarHandlers()
        {
            //*** Inicializar el handler para la base de datos de Microsip
            HandlerDatabase = ApiBas.NewDB();
            ApiBas.SetErrorHandling(1, 1);

            //*** Inicializar el handler para el Metadatos
            HandlerMetadatos = ApiBas.NewDB();
            ApiInv.inSetErrorHandling(1, 1);
        }

        private void ChecarCompatibilidadAPI()
        {
            MensajeError = new StringBuilder();
            ApiBas.NewTrn(HandlerDatabase, 3);
            Logger.AgregarLog("Se crea una transacción para la base de datos de la empresa");

            var respCnct = ApiBas.DBConnect(HandlerDatabase, objMicrosip.BaseDeDatos, objMicrosip.Usuario, objMicrosip.Contraseña);
            if (respCnct == 0)
            {
                Logger.AgregarLog("Se realiza la conexión a la base de datos de la empresa correctamente...");

                ApiInv.SetDBInventarios(HandlerDatabase);
                Logger.AgregarLog("  Se asigna la base de datos de la empresa al modulo de inventarios...");

                ApiBas.NewTrn(HandlerMetadatos, 3);
                Logger.AgregarLog("  Se crea una transacción para el Metadatos");

                respCnct = ApiBas.DBConnect(HandlerMetadatos, obtenerMetadatos(), objMicrosip.Usuario, objMicrosip.Contraseña);
                if (respCnct == 0)
                {
                    Logger.AgregarLog("  Se realiza la conexión al Metadatos...");

                    var respMetadatos = ApiInv.ChecaCompatibilidadInventarios(HandlerMetadatos);
                    Logger.AgregarLog("    Se revisa la compatibilidad del Metadatos...");

                    if (respMetadatos == 0)
                    {
                        esCompatible = true;
                        Logger.AgregarLog("     Es Compatible, continuamos...");

                        ApiBas.DBDisconnect(-1);
                        Logger.AgregarLog("Se desconectaron todas las bases de datos...");
                    }
                    else
                    {
                        MessageBox.Show("La API y el Metadatos no son compatibles...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.AgregarLog("     No es compatible, termina el programa...");
                        ApiBas.DBDisconnect(-1);
                        Application.Exit();
                    }
                }
                else
                {
                    ApiBas.DBDisconnect(-1);
                    Logger.AgregarLog("Ocurrio un error, Se desconectaron todas las bases de datos...");
                    Application.Exit();
                }
            }
            else
            {
                ApiBas.DBDisconnect(-1);
                Logger.AgregarLog("Ocurrio un error, Se desconectaron todas las bases de datos...");
                Application.Exit();
            }
        }

        private void ImportarEntradas(List<Cedula> lstEntradas, List<Articulo> lstArticulos)
        {
            try
            {
                Success = false;
                int indexEntradas = 1;
                int totalDeEntradas = lstEntradas.Count;

                var almacen = (Almacen)cbAlmacenes.SelectedItem;
                var conceptoEntrada = (ConceptoInventario)cbConceptoEntrada.SelectedItem;

                Logger.AgregarLog();
                ApiBas.NewTrn(HandlerDatabase, 3);
                Logger.AgregarLog("Inicia transacción para importar las entradas...");

                var respCnct = ApiBas.DBConnect(HandlerDatabase, objMicrosip.BaseDeDatos, objMicrosip.Usuario, objMicrosip.Contraseña);
                if (respCnct == 0)
                {
                    //****** Connexión exitosa *******                    
                    Logger.AgregarLog(" Se conecta a la base de datos...");

                    var encabezadoEntrada =
                        ApiInv.NuevaEntrada(conceptoEntrada.ID,
                                            almacen.ID,
                                            DateTime.Today.ToString("dd/MM/yyyy"),
                                            "E" + DateTime.Today.ToString("ddMMyyyy"),
                                            "Sobrantes. Resultado de inventario físico",
                                            0);

                    if (encabezadoEntrada == 0)
                    {
                        //****** Encabezado creado exitosamente *******
                        Logger.AgregarLog("  Se creó el encabezado para entrada");

                        foreach (Cedula entrada in lstEntradas)
                        {
                            //********** Buscar artículo **********
                            Articulo arti = lstArticulos.FirstOrDefault(o => o.Clave == entrada.Clave);

                            if (arti != null)
                            {
                                /******** Articulo Encontrado ********/

                                var renglon = ApiInv.RenglonEntrada(arti.Articulo_ID, entrada.Sobrante, entrada.CostoUnitario, 0);
                                if (renglon == 0)
                                {
                                    //****** Renglon creado exitosamente *******
                                    Logger.AgregarLog(string.Format("    Artículo: {0} de {1}: Se creó la partida para el articulo: {2} {3} {4}",
                                                                     indexEntradas.ToString().PadLeft(4),
                                                                     totalDeEntradas.ToString().PadLeft(4),
                                                                     entrada.Clave, entrada.Descripcion, entrada.Sobrante));
                                    indexEntradas++;
                                }
                                else
                                {
                                    //****** Error al crear el renglon *******
                                    Logger.AgregarLog(string.Format("    {0} {1} {2}", entrada.Clave, entrada.Descripcion, entrada.Sobrante));
                                    OcurreError("   Ocurrio un error al crear un renglon de entrada. Error número: " + renglon);
                                    return;
                                }
                            }
                            else
                            {
                                /******** No se encontró el articulo ********/
                                OcurreError(" No se encontró el articulo con clave: " + entrada.Clave);
                                return;
                            }
                        }

                        //******** Termina la inserción de las partidas ********//
                        var aplicarEntrada = ApiInv.AplicaEntrada();

                        if (aplicarEntrada == 0)
                        {
                            Logger.AgregarLog("  Se aplicó la entrada");

                            //****** Entrada y Salida Exitosamente *******                       
                            //****** Termina la transaccion en commit aplicada exitosamente *******                            
                            ApiBas.DBDisconnect(-1);
                            Logger.AgregarLog("  Termina la importación de entradas con exito...");
                            Logger.AgregarLog(" Se conecta a la base de datos...");

                            Success = true;
                        }
                        else
                        {
                            /********** Error al caplicar la entrada **********/
                            OcurreError("   Ocurrio un error al aplicar la entrada. Error número: " + aplicarEntrada);
                            return;
                        }
                    }
                    else
                    {
                        /********** Error al crear el encabezado **********/
                        OcurreError("   Ocurrio un error al crear el encabezado de entrada. Error número: " + encabezadoEntrada);
                        return;
                    }
                }
                else
                {
                    /********** Error al conectar a la base de datos **********/
                    OcurreError("   Ocurrio un error al intentar conectar con la base de datos. Error número: " + respCnct);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ImportarSalidas(List<Cedula> lstSalidas, List<Articulo> lstArticulos)
        {
            try
            {
                Success = false;
                int indexSalidas = 1;
                int totalDeSalidas = lstSalidas.Count;

                var almacen = (Almacen)cbAlmacenes.SelectedItem;
                var conceptoSalida = (ConceptoInventario)cbConceptoSalida.SelectedItem;

                Logger.AgregarLog();
                ApiBas.NewTrn(HandlerDatabase, 3);
                Logger.AgregarLog("Inicia transacción para importar las salidas...");

                var respCnct = ApiBas.DBConnect(HandlerDatabase, objMicrosip.BaseDeDatos, objMicrosip.Usuario, objMicrosip.Contraseña);
                if (respCnct == 0)
                {
                    //****** Connexión exitosa *******                    
                    Logger.AgregarLog(" Se conecta a la base de datos...");

                    var encabezadoSalidas =
                    ApiInv.NuevaSalida(conceptoSalida.ID,
                                       almacen.ID,
                                       0,
                                       DateTime.Today.ToString("dd/MM/yyyy"),
                                       "S" + DateTime.Today.ToString("ddMMyyyy"),
                                       "Sobrantes. Resultado de inventario físico",
                                       0);

                    if (encabezadoSalidas == 0)
                    {
                        //****** Encabezado creado exitosamente *******
                        Logger.AgregarLog("  Se creó el encabezado para las salidas");

                        foreach (Cedula salida in lstSalidas)
                        {
                            Articulo arti = lstArticulos.FirstOrDefault(o => o.Clave == salida.Clave);
                            if (arti != null)
                            {
                                //********** Articulo encontrado **********//

                                var renglon = ApiInv.RenglonSalida(arti.Articulo_ID, Math.Abs(salida.Faltante), 0, 0);
                                if (renglon == 0)
                                {
                                    //****** Renglon creado exitosamente *******
                                    Logger.AgregarLog(string.Format("   Artículo: {0} de {1}: Se creó la partida para el articulo: {2} {3} {4}",
                                        indexSalidas, totalDeSalidas, salida.Clave, salida.Descripcion, salida.Faltante));
                                    indexSalidas++;
                                }
                                else
                                {
                                    //********** Error al crear un renglon para la salida **********//
                                    Logger.AgregarLog(string.Format("    {0} {1} {2}", salida.Clave, salida.Descripcion, salida.Faltante));
                                    OcurreError("   Ocurrio un error al crear un renglon de salida. Error número: " + renglon);
                                    return;
                                }
                            }
                            else
                            {
                                //********** Articulo NO Encontrado **********//
                                OcurreError(" No se encontró el articulo con clave: " + salida.Clave);
                                return;
                            }                            
                        }

                        var aplicarSalida = ApiInv.AplicaSalida();
                        
                        if (aplicarSalida == 0)
                        {
                            //****** Salida Exitosa *******   
                            Logger.AgregarLog("  Se aplicó la salida...");
                            Logger.AgregarLog(" Termina la importacion de salidas con exito...");

                            ApiBas.DBDisconnect(-1);
                            Logger.AgregarLog(" Se conecta a la base de datos...");
                            Success = true;
                        }
                        else
                        {
                            //********** Error al crear el encabezado para la salida **********//
                            OcurreError("   Ocurrio un error al aplicar la salida.  Error num: " + aplicarSalida);
                            return;
                        }
                    }
                    else
                    {
                        //********** Error al crear el encabezado para la salida **********//
                        OcurreError("   Ocurrio un error al crear el encabezado de salida. Error num: " + encabezadoSalidas);
                        return;
                    }                                        
                }
                else
                {
                    //****************** No se pudó realizar la conexion a la base de datos ******************
                    OcurreError("No se pudo realizar la conexión al base de datos. Error num: " + respCnct);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OcurreError(string mensaje)
        {
            Logger.AgregarLog(mensaje);

            ApiBas.DBDisconnect(-1);
            Logger.AgregarLog(" Se desconectan todas las bases de datos...");
        }

        #endregion
       
    }
}
