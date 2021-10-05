namespace Dashboard_Inventarios
{
    partial class Seleccionar_Bodega
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chk = new System.Windows.Forms.Button();
            this.lbInventario = new System.Windows.Forms.Label();
            this.dgvBodega = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rbUnhesa = new System.Windows.Forms.RadioButton();
            this.rbProquima = new System.Windows.Forms.RadioButton();
            this.rbAmbas = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodega)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk
            // 
            this.chk.Location = new System.Drawing.Point(11, 131);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(26, 23);
            this.chk.TabIndex = 32;
            this.chk.Text = "✓";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Click += new System.EventHandler(this.chk_Click);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAmbas = new System.Windows.Forms.RadioButton();
            this.rbProquima = new System.Windows.Forms.RadioButton();
            this.rbUnhesa = new System.Windows.Forms.RadioButton();
            this.lbInventario = new System.Windows.Forms.Label();
            this.dgvBodega = new System.Windows.Forms.DataGridView();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.chk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodega)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chk);
            this.groupBox1.Controls.Add(this.rbAmbas);
            this.groupBox1.Controls.Add(this.rbProquima);
            this.groupBox1.Controls.Add(this.rbUnhesa);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa";
            // 
            // rbAmbas
            // 
            this.rbAmbas.AutoSize = true;
            this.rbAmbas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAmbas.Location = new System.Drawing.Point(358, 34);
            this.rbAmbas.Name = "rbAmbas";
            this.rbAmbas.Size = new System.Drawing.Size(73, 24);
            this.rbAmbas.TabIndex = 11;
            this.rbAmbas.TabStop = true;
            this.rbAmbas.Text = "Ambas";
            this.rbAmbas.UseVisualStyleBackColor = true;
            // 
            // rbProquima
            // 
            this.rbProquima.AutoSize = true;
            this.rbProquima.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProquima.Location = new System.Drawing.Point(486, 34);
            this.rbProquima.Name = "rbProquima";
            this.rbProquima.Size = new System.Drawing.Size(94, 24);
            this.rbProquima.TabIndex = 10;
            this.rbProquima.TabStop = true;
            this.rbProquima.Text = "Proquima";
            this.rbProquima.UseVisualStyleBackColor = true;
            // 
            // rbUnhesa
            // 
            this.rbUnhesa.AutoSize = true;
            this.rbUnhesa.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnhesa.Location = new System.Drawing.Point(224, 34);
            this.rbUnhesa.Name = "rbUnhesa";
            this.rbUnhesa.Size = new System.Drawing.Size(78, 24);
            this.rbUnhesa.TabIndex = 9;
            this.rbUnhesa.TabStop = true;
            this.rbUnhesa.Text = "Unhesa";
            this.rbUnhesa.UseVisualStyleBackColor = true;
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.BackColor = System.Drawing.Color.Transparent;
            this.lbInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.Location = new System.Drawing.Point(21, 18);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(100, 25);
            this.lbInventario.TabIndex = 12;
            this.lbInventario.Text = "Inventario";
            // 
            // dgvBodega
            // 
            this.dgvBodega.AllowUserToAddRows = false;
            this.dgvBodega.AllowUserToDeleteRows = false;
            this.dgvBodega.AllowUserToResizeRows = false;
            this.dgvBodega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBodega.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBodega.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBodega.EnableHeadersVisualStyles = false;
            this.dgvBodega.Location = new System.Drawing.Point(12, 162);
            this.dgvBodega.Name = "dgvBodega";
            this.dgvBodega.RowHeadersVisible = false;
            this.dgvBodega.Size = new System.Drawing.Size(804, 286);
            this.dgvBodega.TabIndex = 13;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.Transparent;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Image = global::Dashboard_Inventarios.Properties.Resources.plane;
            this.btnEnviar.Location = new System.Drawing.Point(639, 454);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(177, 60);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "  Siguiente";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rbUnhesa
            // 
            this.rbUnhesa.AutoSize = true;
            this.rbUnhesa.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnhesa.Location = new System.Drawing.Point(224, 34);
            this.rbUnhesa.Name = "rbUnhesa";
            this.rbUnhesa.Size = new System.Drawing.Size(78, 24);
            this.rbUnhesa.TabIndex = 9;
            this.rbUnhesa.TabStop = true;
            this.rbUnhesa.Text = "Unhesa";
            this.rbUnhesa.UseVisualStyleBackColor = true;
            // 
            // rbProquima
            // 
            this.rbProquima.AutoSize = true;
            this.rbProquima.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProquima.Location = new System.Drawing.Point(486, 34);
            this.rbProquima.Name = "rbProquima";
            this.rbProquima.Size = new System.Drawing.Size(94, 24);
            this.rbProquima.TabIndex = 10;
            this.rbProquima.TabStop = true;
            this.rbProquima.Text = "Proquima";
            this.rbProquima.UseVisualStyleBackColor = true;
            // 
            // rbAmbas
            // 
            this.rbAmbas.AutoSize = true;
            this.rbAmbas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAmbas.Location = new System.Drawing.Point(358, 34);
            this.rbAmbas.Name = "rbAmbas";
            this.rbAmbas.Size = new System.Drawing.Size(73, 24);
            this.rbAmbas.TabIndex = 11;
            this.rbAmbas.TabStop = true;
            this.rbAmbas.Text = "Ambas";
            this.rbAmbas.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbAmbas);
            this.groupBox1.Controls.Add(this.rbProquima);
            this.groupBox1.Controls.Add(this.rbUnhesa);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(804, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa";
            // chk
            // 
            this.chk.Location = new System.Drawing.Point(0, 69);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(26, 23);
            this.chk.TabIndex = 32;
            this.chk.Text = "✓";
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Click += new System.EventHandler(this.chk_Click);
            // 
            // Seleccionar_Bodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(828, 544);
            this.Controls.Add(this.chk);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dgvBodega);
            this.Controls.Add(this.lbInventario);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Seleccionar_Bodega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar_Bodega";
            this.Load += new System.EventHandler(this.Seleccionar_Bodega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBodega)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAmbas;
        private System.Windows.Forms.RadioButton rbProquima;
        private System.Windows.Forms.RadioButton rbUnhesa;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.DataGridView dgvBodega;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button chk;
        private System.Windows.Forms.RadioButton rbUnhesa;
        private System.Windows.Forms.RadioButton rbProquima;
        private System.Windows.Forms.RadioButton rbAmbas;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}