namespace Dashboard_Inventarios
{
    partial class CountView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountView));
            this.dgvCount = new System.Windows.Forms.DataGridView();
            this.lbContados = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.AllowUserToOrderColumns = true;
            this.dgvCount.AllowUserToResizeRows = false;
            this.dgvCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCount.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Location = new System.Drawing.Point(12, 73);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.ReadOnly = true;
            this.dgvCount.RowHeadersVisible = false;
            this.dgvCount.Size = new System.Drawing.Size(925, 439);
            this.dgvCount.TabIndex = 0;
            this.dgvCount.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCount_CellDoubleClick);
            this.dgvCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCount_KeyDown);
            // 
            // lbContados
            // 
            this.lbContados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContados.AutoSize = true;
            this.lbContados.BackColor = System.Drawing.Color.Transparent;
            this.lbContados.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContados.Location = new System.Drawing.Point(397, 39);
            this.lbContados.Name = "lbContados";
            this.lbContados.Size = new System.Drawing.Size(180, 25);
            this.lbContados.TabIndex = 20;
            this.lbContados.Text = "Contados UNHESA";
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
            this.btnExcel.Location = new System.Drawing.Point(908, 39);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(29, 25);
            this.btnExcel.TabIndex = 21;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // CountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Dashboard_Inventarios.Properties.Resources.FONDO_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(949, 557);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lbContados);
            this.Controls.Add(this.dgvCount);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(965, 596);
            this.MinimumSize = new System.Drawing.Size(965, 596);
            this.Name = "CountView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas";
            this.Load += new System.EventHandler(this.CountView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCount;
        private System.Windows.Forms.Label lbContados;
        private System.Windows.Forms.Button btnExcel;
    }
}