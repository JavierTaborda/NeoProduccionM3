namespace STPM.FormsIndex
{
    partial class Turnos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Turnos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateP2 = new System.Windows.Forms.DateTimePicker();
            this.dateP1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnrango = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbldia = new System.Windows.Forms.Label();
            this.btncerrar = new System.Windows.Forms.Button();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.lbldetalles = new System.Windows.Forms.Label();
            this.btnsele = new System.Windows.Forms.Button();
            this.dtgTurnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgParadas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParadas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(71)))), ((int)(((byte)(52)))));
            this.panel1.Controls.Add(this.dateP2);
            this.panel1.Controls.Add(this.dateP1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnrango);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbldia);
            this.panel1.Controls.Add(this.btncerrar);
            this.panel1.Controls.Add(this.btnaceptar);
            this.panel1.Controls.Add(this.lbldetalles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(657, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 521);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // dateP2
            // 
            this.dateP2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP2.Location = new System.Drawing.Point(107, 102);
            this.dateP2.Name = "dateP2";
            this.dateP2.Size = new System.Drawing.Size(95, 20);
            this.dateP2.TabIndex = 12;
            this.dateP2.Visible = false;
            // 
            // dateP1
            // 
            this.dateP1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP1.Location = new System.Drawing.Point(107, 58);
            this.dateP1.Name = "dateP1";
            this.dateP1.Size = new System.Drawing.Size(95, 20);
            this.dateP1.TabIndex = 12;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(107, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 27);
            this.comboBox1.TabIndex = 11;
            // 
            // btnrango
            // 
            this.btnrango.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnrango.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrango.FlatAppearance.BorderSize = 0;
            this.btnrango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrango.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrango.ForeColor = System.Drawing.Color.White;
            this.btnrango.Location = new System.Drawing.Point(234, 56);
            this.btnrango.Name = "btnrango";
            this.btnrango.Size = new System.Drawing.Size(96, 28);
            this.btnrango.TabIndex = 4;
            this.btnrango.Text = "Por Rango";
            this.btnrango.UseVisualStyleBackColor = false;
            this.btnrango.Click += new System.EventHandler(this.btnrango_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta:";
            this.label2.Visible = false;
            // 
            // lbldia
            // 
            this.lbldia.AutoSize = true;
            this.lbldia.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldia.ForeColor = System.Drawing.Color.White;
            this.lbldia.Location = new System.Drawing.Point(19, 51);
            this.lbldia.Name = "lbldia";
            this.lbldia.Size = new System.Drawing.Size(53, 28);
            this.lbldia.TabIndex = 8;
            this.lbldia.Text = "Día:";
            this.lbldia.Click += new System.EventHandler(this.lblcod_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.Firebrick;
            this.btncerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncerrar.FlatAppearance.BorderSize = 0;
            this.btncerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.btncerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btncerrar.Location = new System.Drawing.Point(189, 433);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(128, 50);
            this.btncerrar.TabIndex = 6;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnaceptar
            // 
            this.btnaceptar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnaceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnaceptar.FlatAppearance.BorderSize = 0;
            this.btnaceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnaceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaceptar.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaceptar.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnaceptar.Location = new System.Drawing.Point(24, 433);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(128, 50);
            this.btnaceptar.TabIndex = 5;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = false;
            this.btnaceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbldetalles
            // 
            this.lbldetalles.AutoSize = true;
            this.lbldetalles.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldetalles.ForeColor = System.Drawing.Color.White;
            this.lbldetalles.Location = new System.Drawing.Point(15, 143);
            this.lbldetalles.Name = "lbldetalles";
            this.lbldetalles.Size = new System.Drawing.Size(82, 28);
            this.lbldetalles.TabIndex = 9;
            this.lbldetalles.Text = "Turno:";
            // 
            // btnsele
            // 
            this.btnsele.BackColor = System.Drawing.Color.DarkOrange;
            this.btnsele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsele.FlatAppearance.BorderSize = 0;
            this.btnsele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsele.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsele.ForeColor = System.Drawing.Color.White;
            this.btnsele.Location = new System.Drawing.Point(17, 433);
            this.btnsele.Name = "btnsele";
            this.btnsele.Size = new System.Drawing.Size(128, 50);
            this.btnsele.TabIndex = 4;
            this.btnsele.Text = "Ver Paradas";
            this.btnsele.UseVisualStyleBackColor = false;
            this.btnsele.Click += new System.EventHandler(this.btnsele_Click);
            // 
            // dtgTurnos
            // 
            this.dtgTurnos.AllowUserToAddRows = false;
            this.dtgTurnos.AllowUserToDeleteRows = false;
            this.dtgTurnos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.dtgTurnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTurnos.EnableHeadersVisualStyles = false;
            this.dtgTurnos.GridColor = System.Drawing.Color.LightGray;
            this.dtgTurnos.Location = new System.Drawing.Point(17, 53);
            this.dtgTurnos.MultiSelect = false;
            this.dtgTurnos.Name = "dtgTurnos";
            this.dtgTurnos.ReadOnly = true;
            this.dtgTurnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(174)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTurnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgTurnos.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(71)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(174)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dtgTurnos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTurnos.Size = new System.Drawing.Size(621, 374);
            this.dtgTurnos.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "TURNOS:";
            // 
            // dtgParadas
            // 
            this.dtgParadas.AllowUserToAddRows = false;
            this.dtgParadas.AllowUserToDeleteRows = false;
            this.dtgParadas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.dtgParadas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParadas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgParadas.ColumnHeadersHeight = 25;
            this.dtgParadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgParadas.EnableHeadersVisualStyles = false;
            this.dtgParadas.GridColor = System.Drawing.Color.LightGray;
            this.dtgParadas.Location = new System.Drawing.Point(17, 53);
            this.dtgParadas.MultiSelect = false;
            this.dtgParadas.Name = "dtgParadas";
            this.dtgParadas.ReadOnly = true;
            this.dtgParadas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(174)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgParadas.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgParadas.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(71)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(174)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dtgParadas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgParadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgParadas.Size = new System.Drawing.Size(621, 357);
            this.dtgParadas.TabIndex = 11;
            this.dtgParadas.Visible = false;
            // 
            // Turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(995, 521);
            this.Controls.Add(this.dtgParadas);
            this.Controls.Add(this.btnsele);
            this.Controls.Add(this.dtgTurnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Turnos";
            this.Opacity = 0.97D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Turnos_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgParadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbldia;
        private System.Windows.Forms.Label lbldetalles;
        private System.Windows.Forms.Button btnsele;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.DataGridView dtgTurnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnrango;
        private System.Windows.Forms.DataGridView dtgParadas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateP2;
        private System.Windows.Forms.DateTimePicker dateP1;
    }
}