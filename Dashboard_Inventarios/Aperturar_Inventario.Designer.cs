namespace Dashboard_Inventarios
{
    partial class Aperturar_Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aperturar_Inventario));
            this.label1 = new System.Windows.Forms.Label();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnUna = new System.Windows.Forms.Button();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAperturar = new System.Windows.Forms.Button();
            this.btnCategoria = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.txtInventario = new System.Windows.Forms.TextBox();
            this.lbInventario = new System.Windows.Forms.Label();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnBodega = new System.Windows.Forms.Button();
            this.lbBodega = new System.Windows.Forms.Label();
            this.cmbBodega = new System.Windows.Forms.ComboBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(283, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Aperturar Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMas
            // 
            this.btnMas.BackColor = System.Drawing.Color.Transparent;
            this.btnMas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMas.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMas.Image = global::Dashboard_Inventarios.Properties.Resources.Econsa__3_;
            this.btnMas.Location = new System.Drawing.Point(338, 114);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(147, 163);
            this.btnMas.TabIndex = 14;
            this.btnMas.Text = "Aperturar todas las empresas";
            this.btnMas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMas.UseVisualStyleBackColor = false;
            this.btnMas.Visible = false;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnUna
            // 
            this.btnUna.BackColor = System.Drawing.Color.Transparent;
            this.btnUna.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUna.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUna.Image = global::Dashboard_Inventarios.Properties.Resources.unhesa__1_;
            this.btnUna.Location = new System.Drawing.Point(186, 114);
            this.btnUna.Name = "btnUna";
            this.btnUna.Size = new System.Drawing.Size(147, 163);
            this.btnUna.TabIndex = 13;
            this.btnUna.Text = "Aperturar una Empresa";
            this.btnUna.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUna.UseVisualStyleBackColor = false;
            this.btnUna.Visible = false;
            this.btnUna.Click += new System.EventHandler(this.btnUna_Click);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmpresa.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(216, 313);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(361, 23);
            this.cmbEmpresa.TabIndex = 28;
            this.cmbEmpresa.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(230, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(335, 21);
            this.label10.TabIndex = 29;
            this.label10.Text = "Seleccione la empresa que desea aperturar";
            this.label10.Visible = false;
            // 
            // btnAperturar
            // 
            this.btnAperturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAperturar.BackColor = System.Drawing.Color.Transparent;
            this.btnAperturar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAperturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAperturar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAperturar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturar.ForeColor = System.Drawing.Color.Black;
            this.btnAperturar.Location = new System.Drawing.Point(343, 342);
            this.btnAperturar.Name = "btnAperturar";
            this.btnAperturar.Size = new System.Drawing.Size(106, 32);
            this.btnAperturar.TabIndex = 30;
            this.btnAperturar.Text = "Aperturar";
            this.btnAperturar.UseVisualStyleBackColor = false;
            this.btnAperturar.Visible = false;
            this.btnAperturar.Click += new System.EventHandler(this.btnAperturar_Click);
            // 
            // btnCategoria
            // 
            this.btnCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoria.BackColor = System.Drawing.Color.Transparent;
            this.btnCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoria.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoria.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoria.ForeColor = System.Drawing.Color.Black;
            this.btnCategoria.Location = new System.Drawing.Point(343, 209);
            this.btnCategoria.Name = "btnCategoria";
            this.btnCategoria.Size = new System.Drawing.Size(106, 32);
            this.btnCategoria.TabIndex = 33;
            this.btnCategoria.Text = "Seleccionar";
            this.btnCategoria.UseVisualStyleBackColor = false;
            this.btnCategoria.Click += new System.EventHandler(this.btnCategoria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "Seleccione la categoria que desea aperturar";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategoria.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(216, 180);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(361, 23);
            this.cmbCategoria.TabIndex = 31;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.left_arrow;
            this.btnAtras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(2, 2);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(34, 32);
            this.btnAtras.TabIndex = 34;
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // txtInventario
            // 
            this.txtInventario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventario.Location = new System.Drawing.Point(216, 180);
            this.txtInventario.Name = "txtInventario";
            this.txtInventario.Size = new System.Drawing.Size(361, 25);
            this.txtInventario.TabIndex = 35;
            this.txtInventario.Visible = false;
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.BackColor = System.Drawing.Color.Transparent;
            this.lbInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.Location = new System.Drawing.Point(244, 156);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(309, 21);
            this.lbInventario.TabIndex = 36;
            this.lbInventario.Text = "Escriba el nombre del nuevo Inventario";
            this.lbInventario.Visible = false;
            // 
            // btnInventario
            // 
            this.btnInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInventario.BackColor = System.Drawing.Color.Transparent;
            this.btnInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInventario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventario.ForeColor = System.Drawing.Color.Black;
            this.btnInventario.Location = new System.Drawing.Point(343, 209);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(106, 32);
            this.btnInventario.TabIndex = 37;
            this.btnInventario.Text = "Seleccionar";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Visible = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnBodega
            // 
            this.btnBodega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBodega.BackColor = System.Drawing.Color.Transparent;
            this.btnBodega.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBodega.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBodega.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBodega.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBodega.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBodega.ForeColor = System.Drawing.Color.Black;
            this.btnBodega.Location = new System.Drawing.Point(343, 209);
            this.btnBodega.Name = "btnBodega";
            this.btnBodega.Size = new System.Drawing.Size(106, 32);
            this.btnBodega.TabIndex = 40;
            this.btnBodega.Text = "Seleccionar";
            this.btnBodega.UseVisualStyleBackColor = false;
            this.btnBodega.Visible = false;
            this.btnBodega.Click += new System.EventHandler(this.btnBodega_Click);
            // 
            // lbBodega
            // 
            this.lbBodega.AutoSize = true;
            this.lbBodega.BackColor = System.Drawing.Color.Transparent;
            this.lbBodega.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBodega.Location = new System.Drawing.Point(230, 156);
            this.lbBodega.Name = "lbBodega";
            this.lbBodega.Size = new System.Drawing.Size(328, 21);
            this.lbBodega.TabIndex = 39;
            this.lbBodega.Text = "Seleccione la bodega que desea aperturar";
            this.lbBodega.Visible = false;
            // 
            // cmbBodega
            // 
            this.cmbBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBodega.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBodega.FormattingEnabled = true;
            this.cmbBodega.Location = new System.Drawing.Point(216, 181);
            this.cmbBodega.Name = "cmbBodega";
            this.cmbBodega.Size = new System.Drawing.Size(361, 23);
            this.cmbBodega.TabIndex = 38;
            this.cmbBodega.Visible = false;
            // 
            // btnLocal
            // 
            this.btnLocal.BackColor = System.Drawing.Color.Transparent;
            this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocal.Image = global::Dashboard_Inventarios.Properties.Resources.embalaje;
            this.btnLocal.Location = new System.Drawing.Point(490, 114);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(147, 163);
            this.btnLocal.TabIndex = 41;
            this.btnLocal.Text = "Vista previa inventario";
            this.btnLocal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLocal.UseVisualStyleBackColor = false;
            this.btnLocal.Visible = false;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // Aperturar_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.FONDO_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBodega);
            this.Controls.Add(this.lbBodega);
            this.Controls.Add(this.cmbBodega);
            this.Controls.Add(this.btnInventario);
            this.Controls.Add(this.lbInventario);
            this.Controls.Add(this.txtInventario);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnAperturar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbEmpresa);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnUna);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLocal);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 486);
            this.Name = "Aperturar_Inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aperturar Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Aperturar_Inventario_FormClosing);
            this.Load += new System.EventHandler(this.Aperturar_Inventario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnUna;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAperturar;
        private System.Windows.Forms.Button btnCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.TextBox txtInventario;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnBodega;
        private System.Windows.Forms.Label lbBodega;
        private System.Windows.Forms.ComboBox cmbBodega;
        private System.Windows.Forms.Button btnLocal;
    }
}