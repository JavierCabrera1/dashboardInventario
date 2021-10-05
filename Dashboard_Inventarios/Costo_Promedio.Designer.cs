namespace Dashboard_Inventarios
{
    partial class Costo_Promedio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Costo_Promedio));
            this.label15 = new System.Windows.Forms.Label();
            this.nudCostoPromedio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoPromedio)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(58, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 25);
            this.label15.TabIndex = 27;
            this.label15.Text = "Costo Promedio";
            // 
            // nudCostoPromedio
            // 
            this.nudCostoPromedio.DecimalPlaces = 6;
            this.nudCostoPromedio.Location = new System.Drawing.Point(71, 126);
            this.nudCostoPromedio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudCostoPromedio.Name = "nudCostoPromedio";
            this.nudCostoPromedio.Size = new System.Drawing.Size(120, 20);
            this.nudCostoPromedio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ingrese el costo promedio";
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackColor = System.Drawing.Color.Transparent;
            this.btnHabilitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHabilitar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.Location = new System.Drawing.Point(95, 192);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(74, 28);
            this.btnHabilitar.TabIndex = 2;
            this.btnHabilitar.Text = "Agregar";
            this.btnHabilitar.UseVisualStyleBackColor = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // Costo_Promedio
            // 
            this.AcceptButton = this.btnHabilitar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(264, 304);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudCostoPromedio);
            this.Controls.Add(this.label15);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 343);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 343);
            this.Name = "Costo_Promedio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Costo Promedio";
            this.Load += new System.EventHandler(this.Costo_Promedio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCostoPromedio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nudCostoPromedio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHabilitar;
    }
}