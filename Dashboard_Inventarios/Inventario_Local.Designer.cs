
namespace Dashboard_Inventarios
{
    partial class Inventario_Local
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.btnPausa = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lbFecha = new System.Windows.Forms.Label();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbPorcentajeDN = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbPorcentajeDP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPorcentajeSD = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNoCountProquima = new System.Windows.Forms.Label();
            this.lbCountProquima = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbProquima = new System.Windows.Forms.Label();
            this.chtProquima = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCantidadDN = new System.Windows.Forms.Label();
            this.lbCantidadDP = new System.Windows.Forms.Label();
            this.lbCantidadSD = new System.Windows.Forms.Label();
            this.lbCantidadCD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chtDiferencias = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRack = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBuscarId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBodega = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.lbInventario = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnNuevoInventario = new System.Windows.Forms.Button();
            this.btnExtraordinarios = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelFondo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtProquima)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDiferencias)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.previous;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(8, 4);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(36, 32);
            this.btnAtras.TabIndex = 10;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.BackColor = System.Drawing.Color.Transparent;
            this.lbUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.ForeColor = System.Drawing.Color.White;
            this.lbUser.Location = new System.Drawing.Point(50, 5);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(186, 25);
            this.lbUser.TabIndex = 11;
            this.lbUser.Text = "Bienvenido Usuario";
            // 
            // btnPausa
            // 
            this.btnPausa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPausa.BackColor = System.Drawing.Color.Transparent;
            this.btnPausa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPausa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPausa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPausa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPausa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausa.ForeColor = System.Drawing.Color.White;
            this.btnPausa.Location = new System.Drawing.Point(757, 4);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(82, 32);
            this.btnPausa.TabIndex = 22;
            this.btnPausa.Text = "Pausar";
            this.btnPausa.UseVisualStyleBackColor = false;
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExcel.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.Logo_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(845, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(29, 25);
            this.btnExcel.TabIndex = 20;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.BackColor = System.Drawing.Color.Transparent;
            this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(880, 3);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(82, 32);
            this.btnRefrescar.TabIndex = 19;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lbFecha
            // 
            this.lbFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFecha.AutoSize = true;
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.White;
            this.lbFecha.Location = new System.Drawing.Point(968, 8);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(49, 20);
            this.lbFecha.TabIndex = 18;
            this.lbFecha.Text = "Fecha";
            this.lbFecha.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // panelFondo
            // 
            this.panelFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFondo.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFondo.Controls.Add(this.panel3);
            this.panelFondo.Controls.Add(this.panel2);
            this.panelFondo.Controls.Add(this.panel1);
            this.panelFondo.Location = new System.Drawing.Point(12, 45);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(1283, 134);
            this.panelFondo.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lbPorcentajeDN);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbPorcentajeDP);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbPorcentajeSD);
            this.panel3.Location = new System.Drawing.Point(843, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 128);
            this.panel3.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(253, 25);
            this.label20.TabIndex = 39;
            this.label20.Text = "PORCENTAJE DIFERENCIAS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(308, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 21);
            this.label14.TabIndex = 29;
            this.label14.Text = "Dif. Negativa";
            // 
            // lbPorcentajeDN
            // 
            this.lbPorcentajeDN.AutoSize = true;
            this.lbPorcentajeDN.BackColor = System.Drawing.Color.Transparent;
            this.lbPorcentajeDN.Font = new System.Drawing.Font("Segoe UI Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPorcentajeDN.Location = new System.Drawing.Point(318, 37);
            this.lbPorcentajeDN.Name = "lbPorcentajeDN";
            this.lbPorcentajeDN.Size = new System.Drawing.Size(91, 40);
            this.lbPorcentajeDN.TabIndex = 28;
            this.lbPorcentajeDN.Text = "100%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(161, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "Dif. Positiva";
            // 
            // lbPorcentajeDP
            // 
            this.lbPorcentajeDP.AutoSize = true;
            this.lbPorcentajeDP.BackColor = System.Drawing.Color.Transparent;
            this.lbPorcentajeDP.Font = new System.Drawing.Font("Segoe UI Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPorcentajeDP.Location = new System.Drawing.Point(171, 37);
            this.lbPorcentajeDP.Name = "lbPorcentajeDP";
            this.lbPorcentajeDP.Size = new System.Drawing.Size(91, 40);
            this.lbPorcentajeDP.TabIndex = 26;
            this.lbPorcentajeDP.Text = "100%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Sin Dif.";
            // 
            // lbPorcentajeSD
            // 
            this.lbPorcentajeSD.AutoSize = true;
            this.lbPorcentajeSD.BackColor = System.Drawing.Color.Transparent;
            this.lbPorcentajeSD.Font = new System.Drawing.Font("Segoe UI Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPorcentajeSD.Location = new System.Drawing.Point(16, 37);
            this.lbPorcentajeSD.Name = "lbPorcentajeSD";
            this.lbPorcentajeSD.Size = new System.Drawing.Size(91, 40);
            this.lbPorcentajeSD.TabIndex = 24;
            this.lbPorcentajeSD.Text = "100%";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbNoCountProquima);
            this.panel2.Controls.Add(this.lbCountProquima);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbProquima);
            this.panel2.Controls.Add(this.chtProquima);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 129);
            this.panel2.TabIndex = 1;
            // 
            // lbNoCountProquima
            // 
            this.lbNoCountProquima.AutoSize = true;
            this.lbNoCountProquima.BackColor = System.Drawing.Color.Transparent;
            this.lbNoCountProquima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNoCountProquima.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoCountProquima.Location = new System.Drawing.Point(3, 68);
            this.lbNoCountProquima.Name = "lbNoCountProquima";
            this.lbNoCountProquima.Size = new System.Drawing.Size(124, 17);
            this.lbNoCountProquima.TabIndex = 34;
            this.lbNoCountProquima.Text = "No Contados: 1000";
            this.lbNoCountProquima.Click += new System.EventHandler(this.lbNoCountProquima_Click);
            // 
            // lbCountProquima
            // 
            this.lbCountProquima.AutoSize = true;
            this.lbCountProquima.BackColor = System.Drawing.Color.Transparent;
            this.lbCountProquima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCountProquima.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCountProquima.Location = new System.Drawing.Point(3, 39);
            this.lbCountProquima.Name = "lbCountProquima";
            this.lbCountProquima.Size = new System.Drawing.Size(102, 17);
            this.lbCountProquima.TabIndex = 33;
            this.lbCountProquima.Text = "Contados: 1000";
            this.lbCountProquima.Click += new System.EventHandler(this.lbCountProquima_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(322, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Contados";
            // 
            // lbProquima
            // 
            this.lbProquima.AutoSize = true;
            this.lbProquima.BackColor = System.Drawing.Color.Transparent;
            this.lbProquima.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProquima.Location = new System.Drawing.Point(327, 27);
            this.lbProquima.Name = "lbProquima";
            this.lbProquima.Size = new System.Drawing.Size(102, 45);
            this.lbProquima.TabIndex = 22;
            this.lbProquima.Text = "100%";
            // 
            // chtProquima
            // 
            this.chtProquima.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chtProquima.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chtProquima.Legends.Add(legend3);
            this.chtProquima.Location = new System.Drawing.Point(141, 3);
            this.chtProquima.Name = "chtProquima";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.LabelForeColor = System.Drawing.Color.Empty;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chtProquima.Series.Add(series3);
            this.chtProquima.Size = new System.Drawing.Size(193, 120);
            this.chtProquima.TabIndex = 21;
            this.chtProquima.Text = "chart2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "TEST";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbCantidadDN);
            this.panel1.Controls.Add(this.lbCantidadDP);
            this.panel1.Controls.Add(this.lbCantidadSD);
            this.panel1.Controls.Add(this.lbCantidadCD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chtDiferencias);
            this.panel1.Location = new System.Drawing.Point(439, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 129);
            this.panel1.TabIndex = 0;
            // 
            // lbCantidadDN
            // 
            this.lbCantidadDN.AutoSize = true;
            this.lbCantidadDN.BackColor = System.Drawing.Color.Transparent;
            this.lbCantidadDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCantidadDN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadDN.Location = new System.Drawing.Point(9, 100);
            this.lbCantidadDN.Name = "lbCantidadDN";
            this.lbCantidadDN.Size = new System.Drawing.Size(125, 17);
            this.lbCantidadDN.TabIndex = 38;
            this.lbCantidadDN.Text = "Dif. Negativa: 1000";
            // 
            // lbCantidadDP
            // 
            this.lbCantidadDP.AutoSize = true;
            this.lbCantidadDP.BackColor = System.Drawing.Color.Transparent;
            this.lbCantidadDP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCantidadDP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadDP.Location = new System.Drawing.Point(9, 81);
            this.lbCantidadDP.Name = "lbCantidadDP";
            this.lbCantidadDP.Size = new System.Drawing.Size(119, 17);
            this.lbCantidadDP.TabIndex = 37;
            this.lbCantidadDP.Text = "Dif. Positiva: 1000";
            // 
            // lbCantidadSD
            // 
            this.lbCantidadSD.AutoSize = true;
            this.lbCantidadSD.BackColor = System.Drawing.Color.Transparent;
            this.lbCantidadSD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCantidadSD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadSD.Location = new System.Drawing.Point(9, 60);
            this.lbCantidadSD.Name = "lbCantidadSD";
            this.lbCantidadSD.Size = new System.Drawing.Size(87, 17);
            this.lbCantidadSD.TabIndex = 36;
            this.lbCantidadSD.Text = "Sin Dif: 1000";
            // 
            // lbCantidadCD
            // 
            this.lbCantidadCD.AutoSize = true;
            this.lbCantidadCD.BackColor = System.Drawing.Color.Transparent;
            this.lbCantidadCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCantidadCD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCantidadCD.Location = new System.Drawing.Point(9, 39);
            this.lbCantidadCD.Name = "lbCantidadCD";
            this.lbCantidadCD.Size = new System.Drawing.Size(92, 17);
            this.lbCantidadCD.TabIndex = 35;
            this.lbCantidadCD.Text = "Con Dif: 1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "DIFERENCIAS";
            // 
            // chtDiferencias
            // 
            this.chtDiferencias.BackColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chtDiferencias.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chtDiferencias.Legends.Add(legend4);
            this.chtDiferencias.Location = new System.Drawing.Point(178, 3);
            this.chtDiferencias.Name = "chtDiferencias";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.LabelForeColor = System.Drawing.Color.Empty;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chtDiferencias.Series.Add(series4);
            this.chtDiferencias.Size = new System.Drawing.Size(193, 120);
            this.chtDiferencias.TabIndex = 22;
            this.chtDiferencias.Text = "chart2";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cmbRack);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtBuscarId);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.cmbEstado);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.cmbBodega);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(15, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1280, 75);
            this.panel4.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(395, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 34;
            this.label5.Text = "Rack";
            // 
            // cmbRack
            // 
            this.cmbRack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRack.FormattingEnabled = true;
            this.cmbRack.Location = new System.Drawing.Point(266, 39);
            this.cmbRack.Name = "cmbRack";
            this.cmbRack.Size = new System.Drawing.Size(304, 23);
            this.cmbRack.TabIndex = 33;
            this.cmbRack.TextChanged += new System.EventHandler(this.cmbRack_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(171, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 21);
            this.label12.TabIndex = 32;
            this.label12.Text = "ID";
            // 
            // txtBuscarId
            // 
            this.txtBuscarId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarId.Location = new System.Drawing.Point(131, 39);
            this.txtBuscarId.Name = "txtBuscarId";
            this.txtBuscarId.Size = new System.Drawing.Size(107, 23);
            this.txtBuscarId.TabIndex = 31;
            this.txtBuscarId.TextChanged += new System.EventHandler(this.txtBuscarId_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1073, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(935, 39);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(327, 23);
            this.cmbEstado.TabIndex = 29;
            this.cmbEstado.TextChanged += new System.EventHandler(this.cmbEstado_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(722, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 21);
            this.label10.TabIndex = 28;
            this.label10.Text = "Bodega";
            // 
            // cmbBodega
            // 
            this.cmbBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBodega.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBodega.FormattingEnabled = true;
            this.cmbBodega.Location = new System.Drawing.Point(601, 39);
            this.cmbBodega.Name = "cmbBodega";
            this.cmbBodega.Size = new System.Drawing.Size(304, 23);
            this.cmbBodega.TabIndex = 27;
            this.cmbBodega.TextChanged += new System.EventHandler(this.cmbBodega_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 25);
            this.label7.TabIndex = 25;
            this.label7.Text = "Buscar Por:";
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            this.dgvInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventario.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInventario.EnableHeadersVisualStyles = false;
            this.dgvInventario.Location = new System.Drawing.Point(16, 267);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(1279, 373);
            this.dgvInventario.TabIndex = 25;
            this.dgvInventario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellDoubleClick);
            this.dgvInventario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInventario_KeyDown);
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.BackColor = System.Drawing.Color.Transparent;
            this.lbInventario.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.ForeColor = System.Drawing.Color.White;
            this.lbInventario.Location = new System.Drawing.Point(668, 654);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(156, 25);
            this.lbInventario.TabIndex = 31;
            this.lbInventario.Text = "Inventario_2019";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.BackColor = System.Drawing.Color.Transparent;
            this.btnFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinalizar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(515, 651);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(147, 32);
            this.btnFinalizar.TabIndex = 30;
            this.btnFinalizar.Text = "Finalizar Inventario";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Visible = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnNuevoInventario
            // 
            this.btnNuevoInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevoInventario.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevoInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNuevoInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoInventario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNuevoInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevoInventario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoInventario.ForeColor = System.Drawing.Color.White;
            this.btnNuevoInventario.Location = new System.Drawing.Point(405, 651);
            this.btnNuevoInventario.Name = "btnNuevoInventario";
            this.btnNuevoInventario.Size = new System.Drawing.Size(104, 32);
            this.btnNuevoInventario.TabIndex = 29;
            this.btnNuevoInventario.Text = "Inventario";
            this.btnNuevoInventario.UseVisualStyleBackColor = false;
            this.btnNuevoInventario.Click += new System.EventHandler(this.btnNuevoInventario_Click);
            // 
            // btnExtraordinarios
            // 
            this.btnExtraordinarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtraordinarios.BackColor = System.Drawing.Color.Transparent;
            this.btnExtraordinarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExtraordinarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtraordinarios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExtraordinarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtraordinarios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtraordinarios.ForeColor = System.Drawing.Color.White;
            this.btnExtraordinarios.Location = new System.Drawing.Point(1044, 651);
            this.btnExtraordinarios.Name = "btnExtraordinarios";
            this.btnExtraordinarios.Size = new System.Drawing.Size(134, 32);
            this.btnExtraordinarios.TabIndex = 28;
            this.btnExtraordinarios.Text = "Ver Extraordinarios";
            this.btnExtraordinarios.UseVisualStyleBackColor = false;
            this.btnExtraordinarios.Click += new System.EventHandler(this.btnExtraordinarios_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1182, 651);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 32);
            this.button2.TabIndex = 27;
            this.button2.Text = "Ver Hallazgos";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Help;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 655);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(347, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Departamento de Informática 2020 Version 1.0";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            // 
            // Inventario_Local
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.fondo6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1307, 688);
            this.Controls.Add(this.lbInventario);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnNuevoInventario);
            this.Controls.Add(this.btnExtraordinarios);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.btnAtras);
            this.DoubleBuffered = true;
            this.Name = "Inventario_Local";
            this.Text = "Inventario_Local";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Inventario_Local_Load);
            this.Click += new System.EventHandler(this.btnRefrescar_Click);
            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtProquima)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtDiferencias)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnPausa;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbNoCountProquima;
        private System.Windows.Forms.Label lbCountProquima;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbProquima;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtProquima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBuscarId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbBodega;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnNuevoInventario;
        private System.Windows.Forms.Button btnExtraordinarios;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtDiferencias;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbPorcentajeDN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbPorcentajeDP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPorcentajeSD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbCantidadDN;
        private System.Windows.Forms.Label lbCantidadDP;
        private System.Windows.Forms.Label lbCantidadSD;
        private System.Windows.Forms.Label lbCantidadCD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRack;
    }
}