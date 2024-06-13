namespace SRGA_GUIAS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label2 = new Label();
            combocargas = new ComboBox();
            combodestino = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            GRILLA = new DataGridView();
            button7 = new Button();
            button8 = new Button();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            button10 = new Button();
            label1 = new Label();
            grillacarga = new DataGridView();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)GRILLA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grillacarga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(357, 231);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(462, 229);
            listBox1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(209, 469);
            button2.Name = "button2";
            button2.Size = new Size(119, 31);
            button2.TabIndex = 3;
            button2.Text = "aduanas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(545, 381);
            button3.Name = "button3";
            button3.Size = new Size(119, 34);
            button3.TabIndex = 5;
            button3.Text = "Mandar a excel";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(135, 119);
            button4.Name = "button4";
            button4.Size = new Size(152, 49);
            button4.TabIndex = 6;
            button4.Text = "Enviar Carga";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(385, 460);
            button5.Name = "button5";
            button5.Size = new Size(128, 49);
            button5.TabIndex = 7;
            button5.Text = "exportaciones";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(545, 421);
            button6.Name = "button6";
            button6.Size = new Size(119, 51);
            button6.TabIndex = 8;
            button6.Text = "prueba sql";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 41);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 9;
            label2.Text = "Cargas enviar";
            // 
            // combocargas
            // 
            combocargas.FormattingEnabled = true;
            combocargas.Location = new Point(135, 38);
            combocargas.Name = "combocargas";
            combocargas.Size = new Size(152, 23);
            combocargas.TabIndex = 10;
            combocargas.SelectedIndexChanged += combocargas_SelectedIndexChanged;
            // 
            // combodestino
            // 
            combodestino.FormattingEnabled = true;
            combodestino.Location = new Point(135, 78);
            combodestino.Name = "combodestino";
            combodestino.Size = new Size(152, 23);
            combodestino.TabIndex = 12;
            combodestino.SelectedIndexChanged += combodestino_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 81);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 11;
            label3.Text = "Destino";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(357, 213);
            label4.Name = "label4";
            label4.Size = new Size(141, 15);
            label4.TabIndex = 13;
            label4.Text = "Detalles de la Transacción";
            // 
            // button1
            // 
            button1.Location = new Point(135, 184);
            button1.Name = "button1";
            button1.Size = new Size(152, 49);
            button1.TabIndex = 14;
            button1.Text = "Imprimir QR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GRILLA
            // 
            GRILLA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GRILLA.Location = new Point(385, 48);
            GRILLA.Name = "GRILLA";
            GRILLA.RowTemplate.Height = 25;
            GRILLA.Size = new Size(476, 177);
            GRILLA.TabIndex = 15;
            // 
            // button7
            // 
            button7.Location = new Point(691, 475);
            button7.Name = "button7";
            button7.Size = new Size(128, 34);
            button7.TabIndex = 16;
            button7.Text = "para pruebas vdirecta";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(691, 423);
            button8.Name = "button8";
            button8.Size = new Size(128, 46);
            button8.TabIndex = 17;
            button8.Text = "pruebas aduana";
            button8.UseVisualStyleBackColor = true;
            button8.Visible = false;
            button8.Click += button8_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += imprimir;
            // 
            // button10
            // 
            button10.Location = new Point(135, 248);
            button10.Name = "button10";
            button10.Size = new Size(152, 49);
            button10.TabIndex = 19;
            button10.Text = "Descargar 1";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(357, 9);
            label1.Name = "label1";
            label1.Size = new Size(138, 15);
            label1.TabIndex = 20;
            label1.Text = "Datos de la carga Elegida";
            // 
            // grillacarga
            // 
            grillacarga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grillacarga.Location = new Point(360, 35);
            grillacarga.Name = "grillacarga";
            grillacarga.RowTemplate.Height = 25;
            grillacarga.Size = new Size(492, 133);
            grillacarga.TabIndex = 21;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(107, 329);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 131);
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 514);
            Controls.Add(pictureBox1);
            Controls.Add(grillacarga);
            Controls.Add(label1);
            Controls.Add(button10);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(GRILLA);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(combodestino);
            Controls.Add(label3);
            Controls.Add(combocargas);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Envio de Guias de Carga";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)GRILLA).EndInit();
            ((System.ComponentModel.ISupportInitialize)grillacarga).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label2;
        private ComboBox combocargas;
        private ComboBox combodestino;
        private Label label3;
        private Label label4;
        private Button button1;
        private DataGridView GRILLA;
        private Button button7;
        private Button button8;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button10;
        private Label label1;
        private DataGridView grillacarga;
        private PictureBox pictureBox1;
    }
}