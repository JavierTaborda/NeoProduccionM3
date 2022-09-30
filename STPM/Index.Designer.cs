namespace STPM { 
    partial class IndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnturnos = new System.Windows.Forms.Button();
            this.btnprod = new System.Windows.Forms.Button();
            this.btnadmin = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnestadisti = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlbarra = new System.Windows.Forms.Panel();
            this.btnresta = new System.Windows.Forms.PictureBox();
            this.btnmin = new System.Windows.Forms.PictureBox();
            this.btnmax = new System.Windows.Forms.PictureBox();
            this.btncerrar = new System.Windows.Forms.PictureBox();
            this.pnlcontenedor = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlbarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnresta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnturnos);
            this.panel1.Controls.Add(this.btnprod);
            this.panel1.Controls.Add(this.btnadmin);
            this.panel1.Controls.Add(this.btnEstado);
            this.panel1.Controls.Add(this.btnestadisti);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 550);
            this.panel1.TabIndex = 0;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(174)))), ((int)(((byte)(43)))));
            this.pnlNav.Location = new System.Drawing.Point(3, 234);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(5, 42);
            this.pnlNav.TabIndex = 1;
            // 
            // btnturnos
            // 
            this.btnturnos.FlatAppearance.BorderSize = 0;
            this.btnturnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnturnos.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnturnos.ForeColor = System.Drawing.Color.White;
            this.btnturnos.Image = ((System.Drawing.Image)(resources.GetObject("btnturnos.Image")));
            this.btnturnos.Location = new System.Drawing.Point(0, 316);
            this.btnturnos.Name = "btnturnos";
            this.btnturnos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnturnos.Size = new System.Drawing.Size(185, 42);
            this.btnturnos.TabIndex = 1;
            this.btnturnos.Text = "  Turnos    ";
            this.btnturnos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnturnos.UseVisualStyleBackColor = true;
            this.btnturnos.Click += new System.EventHandler(this.btnturnos_Click);
            this.btnturnos.Leave += new System.EventHandler(this.btnturnos_Leave);
            // 
            // btnprod
            // 
            this.btnprod.FlatAppearance.BorderSize = 0;
            this.btnprod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprod.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprod.ForeColor = System.Drawing.Color.White;
            this.btnprod.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprod.Location = new System.Drawing.Point(0, 367);
            this.btnprod.Name = "btnprod";
            this.btnprod.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnprod.Size = new System.Drawing.Size(185, 42);
            this.btnprod.TabIndex = 1;
            this.btnprod.Text = "   Producción";
            this.btnprod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprod.UseVisualStyleBackColor = true;
            this.btnprod.Visible = false;
            this.btnprod.Click += new System.EventHandler(this.btnadmin_Click);
            this.btnprod.Leave += new System.EventHandler(this.btnadmin_Leave);
            // 
            // btnadmin
            // 
            this.btnadmin.FlatAppearance.BorderSize = 0;
            this.btnadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadmin.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadmin.ForeColor = System.Drawing.Color.White;
            this.btnadmin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadmin.Location = new System.Drawing.Point(2, 415);
            this.btnadmin.Name = "btnadmin";
            this.btnadmin.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnadmin.Size = new System.Drawing.Size(185, 42);
            this.btnadmin.TabIndex = 1;
            this.btnadmin.Text = "   Administrar";
            this.btnadmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnadmin.UseVisualStyleBackColor = true;
            this.btnadmin.Visible = false;
            this.btnadmin.Click += new System.EventHandler(this.btnadmin_Click);
            this.btnadmin.Leave += new System.EventHandler(this.btnadmin_Leave);
            // 
            // btnEstado
            // 
            this.btnEstado.FlatAppearance.BorderSize = 0;
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado.ForeColor = System.Drawing.Color.White;
            this.btnEstado.Image = ((System.Drawing.Image)(resources.GetObject("btnEstado.Image")));
            this.btnEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstado.Location = new System.Drawing.Point(0, 228);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnEstado.Size = new System.Drawing.Size(185, 42);
            this.btnEstado.TabIndex = 1;
            this.btnEstado.Text = "   Estado";
            this.btnEstado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            this.btnEstado.Leave += new System.EventHandler(this.btnEstado_Leave);
            // 
            // btnestadisti
            // 
            this.btnestadisti.FlatAppearance.BorderSize = 0;
            this.btnestadisti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnestadisti.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnestadisti.ForeColor = System.Drawing.Color.White;
            this.btnestadisti.Image = ((System.Drawing.Image)(resources.GetObject("btnestadisti.Image")));
            this.btnestadisti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnestadisti.Location = new System.Drawing.Point(0, 270);
            this.btnestadisti.Name = "btnestadisti";
            this.btnestadisti.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnestadisti.Size = new System.Drawing.Size(185, 42);
            this.btnestadisti.TabIndex = 1;
            this.btnestadisti.Text = "   Estadísticas";
            this.btnestadisti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnestadisti.UseVisualStyleBackColor = true;
            this.btnestadisti.Click += new System.EventHandler(this.btnestadisti_Click);
            this.btnestadisti.Leave += new System.EventHandler(this.btnestadisti_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 228);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cargo";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Operador";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlbarra
            // 
            this.pnlbarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.pnlbarra.Controls.Add(this.btnresta);
            this.pnlbarra.Controls.Add(this.btnmin);
            this.pnlbarra.Controls.Add(this.btnmax);
            this.pnlbarra.Controls.Add(this.btncerrar);
            this.pnlbarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlbarra.Location = new System.Drawing.Point(0, 0);
            this.pnlbarra.Name = "pnlbarra";
            this.pnlbarra.Size = new System.Drawing.Size(950, 25);
            this.pnlbarra.TabIndex = 1;
            this.pnlbarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlbarra_MouseDown);
            // 
            // btnresta
            // 
            this.btnresta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnresta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnresta.Image = ((System.Drawing.Image)(resources.GetObject("btnresta.Image")));
            this.btnresta.Location = new System.Drawing.Point(923, 5);
            this.btnresta.Name = "btnresta";
            this.btnresta.Size = new System.Drawing.Size(15, 15);
            this.btnresta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnresta.TabIndex = 0;
            this.btnresta.TabStop = false;
            this.btnresta.Visible = false;
            this.btnresta.Click += new System.EventHandler(this.btnresta_Click);
            this.btnresta.MouseLeave += new System.EventHandler(this.btnresta_MouseLeave);
            this.btnresta.MouseHover += new System.EventHandler(this.btnresta_MouseHover);
            // 
            // btnmin
            // 
            this.btnmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmin.Image = ((System.Drawing.Image)(resources.GetObject("btnmin.Image")));
            this.btnmin.Location = new System.Drawing.Point(902, 5);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(15, 15);
            this.btnmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnmin.TabIndex = 0;
            this.btnmin.TabStop = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            this.btnmin.MouseLeave += new System.EventHandler(this.btnmin_MouseLeave);
            this.btnmin.MouseHover += new System.EventHandler(this.btnmin_MouseHover);
            // 
            // btnmax
            // 
            this.btnmax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmax.Image = ((System.Drawing.Image)(resources.GetObject("btnmax.Image")));
            this.btnmax.Location = new System.Drawing.Point(923, 5);
            this.btnmax.Name = "btnmax";
            this.btnmax.Size = new System.Drawing.Size(15, 15);
            this.btnmax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnmax.TabIndex = 0;
            this.btnmax.TabStop = false;
            this.btnmax.Click += new System.EventHandler(this.btnmax_Click);
            this.btnmax.MouseLeave += new System.EventHandler(this.btnmax_MouseLeave);
            this.btnmax.MouseHover += new System.EventHandler(this.btnmax_MouseHover);
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.Image = ((System.Drawing.Image)(resources.GetObject("btncerrar.Image")));
            this.btncerrar.Location = new System.Drawing.Point(837, 5);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(15, 15);
            this.btncerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btncerrar.TabIndex = 0;
            this.btncerrar.TabStop = false;
            this.btncerrar.Visible = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            this.btncerrar.MouseLeave += new System.EventHandler(this.btncerrar_MouseLeave);
            this.btncerrar.MouseHover += new System.EventHandler(this.btncerrar_MouseHover_1);
            // 
            // pnlcontenedor
            // 
            this.pnlcontenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(71)))), ((int)(((byte)(52)))));
            this.pnlcontenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlcontenedor.Location = new System.Drawing.Point(185, 25);
            this.pnlcontenedor.Name = "pnlcontenedor";
            this.pnlcontenedor.Size = new System.Drawing.Size(765, 550);
            this.pnlcontenedor.TabIndex = 2;
            this.pnlcontenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlcontenedor_Paint);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(950, 575);
            this.Controls.Add(this.pnlcontenedor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlbarra);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IndexForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "         ";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlbarra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnresta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncerrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnadmin;
        private System.Windows.Forms.Button btnestadisti;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlbarra;
        private System.Windows.Forms.PictureBox btncerrar;
        private System.Windows.Forms.PictureBox btnmin;
        private System.Windows.Forms.PictureBox btnmax;
        private System.Windows.Forms.PictureBox btnresta;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Panel pnlcontenedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnturnos;
        private System.Windows.Forms.Button btnprod;
    }
}