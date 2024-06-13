namespace SRGA_GUIAS
{
    partial class FrmExportacion
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnMostrardatos = new System.Windows.Forms.Button();
            this.grillaromaneo = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.etitotal = new System.Windows.Forms.Label();
            this.tromaneo = new System.Windows.Forms.TextBox();
            this.btnenviarcarga = new System.Windows.Forms.Button();
            this.comboaduanas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tmatricula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaromaneo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nro. Romaneo:";
            // 
            // btnMostrardatos
            // 
            this.btnMostrardatos.Location = new System.Drawing.Point(323, 26);
            this.btnMostrardatos.Name = "btnMostrardatos";
            this.btnMostrardatos.Size = new System.Drawing.Size(110, 33);
            this.btnMostrardatos.TabIndex = 4;
            this.btnMostrardatos.Text = "Mostrar Datos";
            this.btnMostrardatos.UseVisualStyleBackColor = true;
            this.btnMostrardatos.Click += new System.EventHandler(this.btnMostrardatos_Click);
            // 
            // grillaromaneo
            // 
            this.grillaromaneo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaromaneo.Location = new System.Drawing.Point(10, 102);
            this.grillaromaneo.Name = "grillaromaneo";
            this.grillaromaneo.RowTemplate.Height = 25;
            this.grillaromaneo.Size = new System.Drawing.Size(587, 190);
            this.grillaromaneo.TabIndex = 5;
            this.grillaromaneo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaromaneo_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Datos del Romaneo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total de Kilos";
            // 
            // etitotal
            // 
            this.etitotal.AutoSize = true;
            this.etitotal.Location = new System.Drawing.Point(544, 305);
            this.etitotal.Name = "etitotal";
            this.etitotal.Size = new System.Drawing.Size(13, 15);
            this.etitotal.TabIndex = 8;
            this.etitotal.Text = "0";
            // 
            // tromaneo
            // 
            this.tromaneo.Location = new System.Drawing.Point(170, 26);
            this.tromaneo.Name = "tromaneo";
            this.tromaneo.Size = new System.Drawing.Size(121, 23);
            this.tromaneo.TabIndex = 9;
            // 
            // btnenviarcarga
            // 
            this.btnenviarcarga.Location = new System.Drawing.Point(714, 319);
            this.btnenviarcarga.Name = "btnenviarcarga";
            this.btnenviarcarga.Size = new System.Drawing.Size(127, 42);
            this.btnenviarcarga.TabIndex = 10;
            this.btnenviarcarga.Text = "Enviar Carga";
            this.btnenviarcarga.UseVisualStyleBackColor = true;
            this.btnenviarcarga.Click += new System.EventHandler(this.btnenviarcarga_Click);
            // 
            // comboaduanas
            // 
            this.comboaduanas.FormattingEnabled = true;
            this.comboaduanas.Location = new System.Drawing.Point(714, 232);
            this.comboaduanas.Name = "comboaduanas";
            this.comboaduanas.Size = new System.Drawing.Size(270, 23);
            this.comboaduanas.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Elegir Aduana";
            // 
            // tmatricula
            // 
            this.tmatricula.Location = new System.Drawing.Point(714, 269);
            this.tmatricula.Name = "tmatricula";
            this.tmatricula.Size = new System.Drawing.Size(121, 23);
            this.tmatricula.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Matrícula Camión:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(621, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(363, 169);
            this.listBox1.TabIndex = 16;
            // 
            // FrmExportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 569);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tmatricula);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboaduanas);
            this.Controls.Add(this.btnenviarcarga);
            this.Controls.Add(this.tromaneo);
            this.Controls.Add(this.etitotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grillaromaneo);
            this.Controls.Add(this.btnMostrardatos);
            this.Controls.Add(this.label2);
            this.Name = "FrmExportacion";
            this.Text = "Frormulario Enviar Guía de Exportación.";
            this.Load += new System.EventHandler(this.FrmExportacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaromaneo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private Button btnMostrardatos;
        private DataGridView grillaromaneo;
        private Label label3;
        private Label label4;
        private Label etitotal;
        private TextBox tromaneo;
        private Button btnenviarcarga;
        private ComboBox comboaduanas;
        private Label label1;
        private TextBox tmatricula;
        private Label label5;
        private ListBox listBox1;
    }
}