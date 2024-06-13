namespace SRGA_GUIAS
{
    partial class FrmDescarga
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
            this.grillaTramsacciones = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Combodonde = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tfactura = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarDespositosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grillaTramsacciones)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaTramsacciones
            // 
            this.grillaTramsacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaTramsacciones.Location = new System.Drawing.Point(30, 61);
            this.grillaTramsacciones.Name = "grillaTramsacciones";
            this.grillaTramsacciones.RowTemplate.Height = 25;
            this.grillaTramsacciones.Size = new System.Drawing.Size(599, 141);
            this.grillaTramsacciones.TabIndex = 0;
            this.grillaTramsacciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillaTramsacciones_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Descargar elegida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Transacciones en curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Donde Descargar";
            // 
            // Combodonde
            // 
            this.Combodonde.FormattingEnabled = true;
            this.Combodonde.Location = new System.Drawing.Point(133, 226);
            this.Combodonde.Name = "Combodonde";
            this.Combodonde.Size = new System.Drawing.Size(321, 23);
            this.Combodonde.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro. Factura/Remito";
            // 
            // tfactura
            // 
            this.tfactura.Location = new System.Drawing.Point(133, 268);
            this.tfactura.Name = "tfactura";
            this.tfactura.Size = new System.Drawing.Size(107, 23);
            this.tfactura.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(386, 271);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 139);
            this.listBox1.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenimientoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarDespositosToolStripMenuItem});
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // actualizarDespositosToolStripMenuItem
            // 
            this.actualizarDespositosToolStripMenuItem.Name = "actualizarDespositosToolStripMenuItem";
            this.actualizarDespositosToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.actualizarDespositosToolStripMenuItem.Text = "Actualizar Despositos";
            this.actualizarDespositosToolStripMenuItem.Click += new System.EventHandler(this.actualizarDespositosToolStripMenuItem_Click);
            // 
            // FrmDescarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tfactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Combodonde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grillaTramsacciones);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmDescarga";
            this.Text = "Enviar una descarga";
            this.Load += new System.EventHandler(this.FrmDescarga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaTramsacciones)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView grillaTramsacciones;
        private Button button1;
        private Label label1;
        private Label label2;
        private ComboBox Combodonde;
        private Label label3;
        private TextBox tfactura;
        private ListBox listBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem actualizarDespositosToolStripMenuItem;
    }
}