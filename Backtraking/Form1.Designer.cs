namespace BackTracking
{
    partial class Form1
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
            this.textRecorrido = new System.Windows.Forms.TextBox();
            this.panelTablero = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAceptaConfig = new System.Windows.Forms.Button();
            this.txtAviso = new System.Windows.Forms.TextBox();
            this.numDimensionN = new System.Windows.Forms.NumericUpDown();
            this.numOrigenX = new System.Windows.Forms.NumericUpDown();
            this.numOrigenY = new System.Windows.Forms.NumericUpDown();
            this.btnResolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimensionN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrigenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrigenY)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textRecorrido
            // 
            this.textRecorrido.Location = new System.Drawing.Point(308, 180);
            this.textRecorrido.Multiline = true;
            this.textRecorrido.Name = "textRecorrido";
            this.textRecorrido.ReadOnly = true;
            this.textRecorrido.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textRecorrido.Size = new System.Drawing.Size(339, 90);
            this.textRecorrido.TabIndex = 0;
            this.textRecorrido.TabStop = false;
            // 
            // panelTablero
            // 
            this.panelTablero.BackColor = System.Drawing.SystemColors.Control;
            this.panelTablero.Location = new System.Drawing.Point(10, 12);
            this.panelTablero.Name = "panelTablero";
            this.panelTablero.Size = new System.Drawing.Size(285, 285);
            this.panelTablero.TabIndex = 1;
            this.panelTablero.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTablero_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BackTracking.Properties.Resources.caballo;
            this.pictureBox1.Location = new System.Drawing.Point(313, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnComenzar
            // 
            this.btnComenzar.Enabled = false;
            this.btnComenzar.Location = new System.Drawing.Point(511, 276);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(136, 20);
            this.btnComenzar.TabIndex = 7;
            this.btnComenzar.Text = "Comenzar recorrido...";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(383, 276);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Velocidad (ms)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Recorrido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(305, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dimensiones tablero ( NxN ):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Celda de salida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Y";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BackTracking.Properties.Resources.caballo;
            this.pictureBox2.Location = new System.Drawing.Point(511, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 136);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnAceptaConfig
            // 
            this.btnAceptaConfig.Enabled = false;
            this.btnAceptaConfig.Location = new System.Drawing.Point(369, 66);
            this.btnAceptaConfig.Name = "btnAceptaConfig";
            this.btnAceptaConfig.Size = new System.Drawing.Size(136, 20);
            this.btnAceptaConfig.TabIndex = 4;
            this.btnAceptaConfig.Text = "Aceptar configuración";
            this.btnAceptaConfig.UseVisualStyleBackColor = true;
            this.btnAceptaConfig.Click += new System.EventHandler(this.btnAceptaConfig_Click);
            // 
            // txtAviso
            // 
            this.txtAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAviso.BackColor = System.Drawing.Color.Black;
            this.txtAviso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAviso.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAviso.ForeColor = System.Drawing.Color.White;
            this.txtAviso.Location = new System.Drawing.Point(0, 0);
            this.txtAviso.Margin = new System.Windows.Forms.Padding(0);
            this.txtAviso.Name = "txtAviso";
            this.txtAviso.ReadOnly = true;
            this.txtAviso.Size = new System.Drawing.Size(338, 21);
            this.txtAviso.TabIndex = 0;
            this.txtAviso.TabStop = false;
            this.txtAviso.Text = "Generando solución...";
            this.txtAviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAviso.Visible = false;
            // 
            // numDimensionN
            // 
            this.numDimensionN.Location = new System.Drawing.Point(470, 12);
            this.numDimensionN.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numDimensionN.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDimensionN.Name = "numDimensionN";
            this.numDimensionN.Size = new System.Drawing.Size(35, 20);
            this.numDimensionN.TabIndex = 1;
            this.numDimensionN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDimensionN.ValueChanged += new System.EventHandler(this.numDimensionN_ValueChanged);
            // 
            // numOrigenX
            // 
            this.numOrigenX.Location = new System.Drawing.Point(413, 40);
            this.numOrigenX.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numOrigenX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrigenX.Name = "numOrigenX";
            this.numOrigenX.Size = new System.Drawing.Size(35, 20);
            this.numOrigenX.TabIndex = 2;
            this.numOrigenX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrigenX.ValueChanged += new System.EventHandler(this.numOrigenX_ValueChanged);
            // 
            // numOrigenY
            // 
            this.numOrigenY.Location = new System.Drawing.Point(470, 40);
            this.numOrigenY.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numOrigenY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrigenY.Name = "numOrigenY";
            this.numOrigenY.Size = new System.Drawing.Size(35, 20);
            this.numOrigenY.TabIndex = 3;
            this.numOrigenY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOrigenY.ValueChanged += new System.EventHandler(this.numOrigenY_ValueChanged);
            // 
            // btnResolver
            // 
            this.btnResolver.Location = new System.Drawing.Point(369, 92);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(136, 20);
            this.btnResolver.TabIndex = 5;
            this.btnResolver.Text = "Generar Solución";
            this.btnResolver.UseVisualStyleBackColor = true;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.txtAviso);
            this.panel2.Location = new System.Drawing.Point(308, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 19);
            this.panel2.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 306);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnResolver);
            this.Controls.Add(this.numOrigenY);
            this.Controls.Add(this.numOrigenX);
            this.Controls.Add(this.numDimensionN);
            this.Controls.Add(this.btnAceptaConfig);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.textRecorrido);
            this.Controls.Add(this.panelTablero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Recorrido de tablero con caballo (Backtracking)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDimensionN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrigenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOrigenY)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textRecorrido;
        private System.Windows.Forms.Panel panelTablero;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAceptaConfig;
        private System.Windows.Forms.TextBox txtAviso;
        private System.Windows.Forms.NumericUpDown numDimensionN;
        private System.Windows.Forms.NumericUpDown numOrigenX;
        private System.Windows.Forms.NumericUpDown numOrigenY;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Panel panel2;
    }
}