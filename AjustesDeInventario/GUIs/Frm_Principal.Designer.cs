namespace AjustesDeInventario.GUIs
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.btnProcesar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMicrosip = new System.Windows.Forms.GroupBox();
            this.btnPruebaConexion = new System.Windows.Forms.Button();
            this.lblEstadoMicrosip = new System.Windows.Forms.Label();
            this.btnBuscarMicrosip = new System.Windows.Forms.Button();
            this.txbArchivoMicrosip = new System.Windows.Forms.TextBox();
            this.pnFiltros = new System.Windows.Forms.Panel();
            this.cbConceptoSalida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbConceptoEntrada = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAlmacenes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbInventario = new System.Windows.Forms.GroupBox();
            this.btnBuscarExcel = new System.Windows.Forms.Button();
            this.txbArchivoExcel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.gridResultados = new DevExpress.XtraGrid.GridControl();
            this.cedulaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvResultados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostoUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaltante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSobrante = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dialogoArchivos = new System.Windows.Forms.OpenFileDialog();
            this.bgwProceso = new System.ComponentModel.BackgroundWorker();
            this.pbCargando = new System.Windows.Forms.PictureBox();
            this.gbMicrosip.SuspendLayout();
            this.pnFiltros.SuspendLayout();
            this.gbInventario.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedulaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnProcesar.Location = new System.Drawing.Point(302, 618);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(181, 31);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "Exportar a Microsip";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Archivo .SET:";
            // 
            // gbMicrosip
            // 
            this.gbMicrosip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMicrosip.Controls.Add(this.btnPruebaConexion);
            this.gbMicrosip.Controls.Add(this.lblEstadoMicrosip);
            this.gbMicrosip.Controls.Add(this.btnBuscarMicrosip);
            this.gbMicrosip.Controls.Add(this.txbArchivoMicrosip);
            this.gbMicrosip.Controls.Add(this.label1);
            this.gbMicrosip.Controls.Add(this.pnFiltros);
            this.gbMicrosip.Location = new System.Drawing.Point(12, 38);
            this.gbMicrosip.Name = "gbMicrosip";
            this.gbMicrosip.Size = new System.Drawing.Size(760, 190);
            this.gbMicrosip.TabIndex = 3;
            this.gbMicrosip.TabStop = false;
            this.gbMicrosip.Text = "(1) Datos Microsip";
            // 
            // btnPruebaConexion
            // 
            this.btnPruebaConexion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPruebaConexion.Location = new System.Drawing.Point(666, 19);
            this.btnPruebaConexion.Name = "btnPruebaConexion";
            this.btnPruebaConexion.Size = new System.Drawing.Size(88, 134);
            this.btnPruebaConexion.TabIndex = 6;
            this.btnPruebaConexion.Text = "Probar Conexion";
            this.btnPruebaConexion.UseVisualStyleBackColor = true;
            this.btnPruebaConexion.Visible = false;
            this.btnPruebaConexion.Click += new System.EventHandler(this.btnPruebaConexion_Click);
            // 
            // lblEstadoMicrosip
            // 
            this.lblEstadoMicrosip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstadoMicrosip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoMicrosip.Location = new System.Drawing.Point(7, 156);
            this.lblEstadoMicrosip.Name = "lblEstadoMicrosip";
            this.lblEstadoMicrosip.Size = new System.Drawing.Size(746, 31);
            this.lblEstadoMicrosip.TabIndex = 5;
            this.lblEstadoMicrosip.Text = "lblEstadoMicrosip";
            this.lblEstadoMicrosip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEstadoMicrosip.Visible = false;
            // 
            // btnBuscarMicrosip
            // 
            this.btnBuscarMicrosip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarMicrosip.Location = new System.Drawing.Point(590, 19);
            this.btnBuscarMicrosip.Name = "btnBuscarMicrosip";
            this.btnBuscarMicrosip.Size = new System.Drawing.Size(67, 26);
            this.btnBuscarMicrosip.TabIndex = 4;
            this.btnBuscarMicrosip.Text = "Buscar";
            this.btnBuscarMicrosip.UseVisualStyleBackColor = true;
            this.btnBuscarMicrosip.Click += new System.EventHandler(this.btnBuscarMicrosip_Click);
            // 
            // txbArchivoMicrosip
            // 
            this.txbArchivoMicrosip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbArchivoMicrosip.Enabled = false;
            this.txbArchivoMicrosip.Location = new System.Drawing.Point(202, 19);
            this.txbArchivoMicrosip.Name = "txbArchivoMicrosip";
            this.txbArchivoMicrosip.Size = new System.Drawing.Size(382, 26);
            this.txbArchivoMicrosip.TabIndex = 3;
            // 
            // pnFiltros
            // 
            this.pnFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFiltros.Controls.Add(this.cbConceptoSalida);
            this.pnFiltros.Controls.Add(this.label6);
            this.pnFiltros.Controls.Add(this.cbConceptoEntrada);
            this.pnFiltros.Controls.Add(this.label3);
            this.pnFiltros.Controls.Add(this.cbAlmacenes);
            this.pnFiltros.Controls.Add(this.label5);
            this.pnFiltros.Location = new System.Drawing.Point(10, 51);
            this.pnFiltros.Name = "pnFiltros";
            this.pnFiltros.Size = new System.Drawing.Size(650, 102);
            this.pnFiltros.TabIndex = 13;
            this.pnFiltros.Visible = false;
            // 
            // cbConceptoSalida
            // 
            this.cbConceptoSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConceptoSalida.BackColor = System.Drawing.Color.White;
            this.cbConceptoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbConceptoSalida.Enabled = false;
            this.cbConceptoSalida.FormattingEnabled = true;
            this.cbConceptoSalida.Location = new System.Drawing.Point(192, 70);
            this.cbConceptoSalida.Name = "cbConceptoSalida";
            this.cbConceptoSalida.Size = new System.Drawing.Size(455, 26);
            this.cbConceptoSalida.TabIndex = 11;
            this.cbConceptoSalida.SelectedIndexChanged += new System.EventHandler(this.cbConceptoSalida_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Concepto de salida:";
            // 
            // cbConceptoEntrada
            // 
            this.cbConceptoEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbConceptoEntrada.BackColor = System.Drawing.Color.White;
            this.cbConceptoEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbConceptoEntrada.Enabled = false;
            this.cbConceptoEntrada.FormattingEnabled = true;
            this.cbConceptoEntrada.Location = new System.Drawing.Point(192, 38);
            this.cbConceptoEntrada.Name = "cbConceptoEntrada";
            this.cbConceptoEntrada.Size = new System.Drawing.Size(455, 26);
            this.cbConceptoEntrada.TabIndex = 8;
            this.cbConceptoEntrada.SelectedIndexChanged += new System.EventHandler(this.cbConceptoEntrada_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Almacen:";
            // 
            // cbAlmacenes
            // 
            this.cbAlmacenes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlmacenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacenes.FormattingEnabled = true;
            this.cbAlmacenes.Location = new System.Drawing.Point(192, 6);
            this.cbAlmacenes.Name = "cbAlmacenes";
            this.cbAlmacenes.Size = new System.Drawing.Size(455, 26);
            this.cbAlmacenes.TabIndex = 7;
            this.cbAlmacenes.SelectedIndexChanged += new System.EventHandler(this.cbAlmacenes_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Concepto de entrada:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(784, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exportar resultados de inventario a Microsip";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbInventario
            // 
            this.gbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInventario.Controls.Add(this.btnBuscarExcel);
            this.gbInventario.Controls.Add(this.txbArchivoExcel);
            this.gbInventario.Controls.Add(this.label4);
            this.gbInventario.Location = new System.Drawing.Point(12, 234);
            this.gbInventario.Name = "gbInventario";
            this.gbInventario.Size = new System.Drawing.Size(760, 72);
            this.gbInventario.TabIndex = 5;
            this.gbInventario.TabStop = false;
            this.gbInventario.Text = "(2) Archivo de resultados";
            // 
            // btnBuscarExcel
            // 
            this.btnBuscarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarExcel.Location = new System.Drawing.Point(637, 28);
            this.btnBuscarExcel.Name = "btnBuscarExcel";
            this.btnBuscarExcel.Size = new System.Drawing.Size(70, 26);
            this.btnBuscarExcel.TabIndex = 4;
            this.btnBuscarExcel.Text = "Buscar";
            this.btnBuscarExcel.UseVisualStyleBackColor = true;
            this.btnBuscarExcel.Click += new System.EventHandler(this.btnBuscarExcel_Click);
            // 
            // txbArchivoExcel
            // 
            this.txbArchivoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbArchivoExcel.Enabled = false;
            this.txbArchivoExcel.Location = new System.Drawing.Point(254, 28);
            this.txbArchivoExcel.Name = "txbArchivoExcel";
            this.txbArchivoExcel.Size = new System.Drawing.Size(377, 26);
            this.txbArchivoExcel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Archivo Excel de Resultados:";
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.Controls.Add(this.gridResultados);
            this.gbAcciones.Location = new System.Drawing.Point(12, 312);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(760, 299);
            this.gbAcciones.TabIndex = 6;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "(3) Resultados del inventario";
            // 
            // gridResultados
            // 
            this.gridResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridResultados.DataSource = this.cedulaBindingSource;
            this.gridResultados.Location = new System.Drawing.Point(6, 25);
            this.gridResultados.MainView = this.gvResultados;
            this.gridResultados.Name = "gridResultados";
            this.gridResultados.Size = new System.Drawing.Size(748, 268);
            this.gridResultados.TabIndex = 0;
            this.gridResultados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvResultados});
            // 
            // cedulaBindingSource
            // 
            this.cedulaBindingSource.DataSource = typeof(AjustesDeInventario.Modelos.Cedula);
            // 
            // gvResultados
            // 
            this.gvResultados.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gvResultados.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gvResultados.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gvResultados.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gvResultados.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gvResultados.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(215)))));
            this.gvResultados.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gvResultados.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gvResultados.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gvResultados.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gvResultados.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.Empty.Options.UseBackColor = true;
            this.gvResultados.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.EvenRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gvResultados.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gvResultados.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gvResultados.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gvResultados.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gvResultados.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gvResultados.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gvResultados.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(148)))));
            this.gvResultados.Appearance.FixedLine.Options.UseBackColor = true;
            this.gvResultados.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(180)))), ((int)(((byte)(191)))));
            this.gvResultados.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gvResultados.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gvResultados.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gvResultados.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gvResultados.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.GroupButton.Options.UseBackColor = true;
            this.gvResultados.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gvResultados.Appearance.GroupButton.Options.UseForeColor = true;
            this.gvResultados.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvResultados.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvResultados.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gvResultados.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gvResultados.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvResultados.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gvResultados.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gvResultados.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gvResultados.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gvResultados.Appearance.GroupRow.Options.UseFont = true;
            this.gvResultados.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gvResultados.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gvResultados.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gvResultados.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvResultados.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvResultados.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gvResultados.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(226)))));
            this.gvResultados.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gvResultados.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gvResultados.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvResultados.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.OddRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.OddRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.gvResultados.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.gvResultados.Appearance.Preview.Options.UseBackColor = true;
            this.gvResultados.Appearance.Preview.Options.UseForeColor = true;
            this.gvResultados.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.Row.Options.UseBackColor = true;
            this.gvResultados.Appearance.Row.Options.UseForeColor = true;
            this.gvResultados.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gvResultados.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvResultados.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.gvResultados.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvResultados.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvResultados.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvResultados.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gvResultados.Appearance.VertLine.Options.UseBackColor = true;
            this.gvResultados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClave,
            this.colDescripcion,
            this.colCostoUnitario,
            this.colFaltante,
            this.colSobrante});
            this.gvResultados.GridControl = this.gridResultados;
            this.gvResultados.Name = "gvResultados";
            this.gvResultados.OptionsBehavior.Editable = false;
            this.gvResultados.OptionsCustomization.AllowFilter = false;
            this.gvResultados.OptionsView.EnableAppearanceEvenRow = true;
            this.gvResultados.OptionsView.EnableAppearanceOddRow = true;
            this.gvResultados.OptionsView.ShowFooter = true;
            this.gvResultados.OptionsView.ShowGroupPanel = false;
            // 
            // colClave
            // 
            this.colClave.AppearanceCell.Options.UseTextOptions = true;
            this.colClave.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClave.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colClave.AppearanceHeader.Options.UseFont = true;
            this.colClave.AppearanceHeader.Options.UseTextOptions = true;
            this.colClave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colClave.FieldName = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDescripcion.AppearanceHeader.Options.UseFont = true;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colCostoUnitario
            // 
            this.colCostoUnitario.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCostoUnitario.AppearanceHeader.Options.UseFont = true;
            this.colCostoUnitario.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostoUnitario.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCostoUnitario.DisplayFormat.FormatString = "n";
            this.colCostoUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostoUnitario.FieldName = "CostoUnitario";
            this.colCostoUnitario.Name = "colCostoUnitario";
            this.colCostoUnitario.Visible = true;
            this.colCostoUnitario.VisibleIndex = 2;
            // 
            // colFaltante
            // 
            this.colFaltante.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFaltante.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colFaltante.AppearanceCell.Options.UseFont = true;
            this.colFaltante.AppearanceCell.Options.UseForeColor = true;
            this.colFaltante.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFaltante.AppearanceHeader.ForeColor = System.Drawing.Color.Red;
            this.colFaltante.AppearanceHeader.Options.UseFont = true;
            this.colFaltante.AppearanceHeader.Options.UseForeColor = true;
            this.colFaltante.AppearanceHeader.Options.UseTextOptions = true;
            this.colFaltante.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colFaltante.DisplayFormat.FormatString = "n";
            this.colFaltante.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFaltante.FieldName = "Faltante";
            this.colFaltante.Name = "colFaltante";
            this.colFaltante.Visible = true;
            this.colFaltante.VisibleIndex = 3;
            // 
            // colSobrante
            // 
            this.colSobrante.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSobrante.AppearanceCell.Options.UseFont = true;
            this.colSobrante.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSobrante.AppearanceHeader.Options.UseFont = true;
            this.colSobrante.AppearanceHeader.Options.UseTextOptions = true;
            this.colSobrante.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSobrante.DisplayFormat.FormatString = "n";
            this.colSobrante.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSobrante.FieldName = "Sobrante";
            this.colSobrante.Name = "colSobrante";
            this.colSobrante.Visible = true;
            this.colSobrante.VisibleIndex = 4;
            // 
            // dialogoArchivos
            // 
            this.dialogoArchivos.FileName = "*.set";
            this.dialogoArchivos.Filter = "Archivos .SET | *.set";
            // 
            // bgwProceso
            // 
            this.bgwProceso.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwProceso_DoWork);
            this.bgwProceso.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwProceso_RunWorkerCompleted);
            // 
            // pbCargando
            // 
            this.pbCargando.BackColor = System.Drawing.SystemColors.Control;
            this.pbCargando.Image = global::AjustesDeInventario.Properties.Resources.LoadingCircle_firstani;
            this.pbCargando.Location = new System.Drawing.Point(204, 156);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(376, 351);
            this.pbCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCargando.TabIndex = 7;
            this.pbCargando.TabStop = false;
            this.pbCargando.Visible = false;
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 662);
            this.Controls.Add(this.pbCargando);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbInventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbMicrosip);
            this.Controls.Add(this.btnProcesar);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Exportar resultados de inventario a Microsip";
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            this.gbMicrosip.ResumeLayout(false);
            this.gbMicrosip.PerformLayout();
            this.pnFiltros.ResumeLayout(false);
            this.pnFiltros.PerformLayout();
            this.gbInventario.ResumeLayout(false);
            this.gbInventario.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cedulaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbMicrosip;
        private System.Windows.Forms.Button btnPruebaConexion;
        private System.Windows.Forms.Label lblEstadoMicrosip;
        private System.Windows.Forms.Button btnBuscarMicrosip;
        private System.Windows.Forms.TextBox txbArchivoMicrosip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbInventario;
        private System.Windows.Forms.Button btnBuscarExcel;
        private System.Windows.Forms.TextBox txbArchivoExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.OpenFileDialog dialogoArchivos;
        private DevExpress.XtraGrid.GridControl gridResultados;
        private DevExpress.XtraGrid.Views.Grid.GridView gvResultados;
        private System.Windows.Forms.BindingSource cedulaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colCostoUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colFaltante;
        private DevExpress.XtraGrid.Columns.GridColumn colSobrante;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private System.Windows.Forms.Panel pnFiltros;
        private System.Windows.Forms.ComboBox cbConceptoSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbConceptoEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAlmacenes;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bgwProceso;
        private System.Windows.Forms.PictureBox pbCargando;
    }
}