namespace Dashboard_Inventarios
{
    partial class ver_selectivos
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
            this.dgvSelectivos = new System.Windows.Forms.DataGridView();
            this.lbInventario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectivos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectivos
            // 
            this.dgvSelectivos.AllowUserToAddRows = false;
            this.dgvSelectivos.AllowUserToDeleteRows = false;
            this.dgvSelectivos.AllowUserToResizeRows = false;
            this.dgvSelectivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectivos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectivos.EnableHeadersVisualStyles = false;
            this.dgvSelectivos.Location = new System.Drawing.Point(22, 51);
            this.dgvSelectivos.Name = "dgvSelectivos";
            this.dgvSelectivos.ReadOnly = true;
            this.dgvSelectivos.RowHeadersVisible = false;
            this.dgvSelectivos.Size = new System.Drawing.Size(574, 349);
            this.dgvSelectivos.TabIndex = 19;
            this.dgvSelectivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectivos_CellDoubleClick);
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.BackColor = System.Drawing.Color.Transparent;
            this.lbInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.Location = new System.Drawing.Point(17, 23);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(198, 25);
            this.lbInventario.TabIndex = 20;
            this.lbInventario.Text = "Inventarios Selectivos";
            // 
            // ver_selectivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(618, 450);
            this.Controls.Add(this.lbInventario);
            this.Controls.Add(this.dgvSelectivos);
            this.DoubleBuffered = true;
            this.Name = "ver_selectivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ver_selectivos";
            this.Load += new System.EventHandler(this.ver_selectivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSelectivos;
        private System.Windows.Forms.Label lbInventario;
    }
}