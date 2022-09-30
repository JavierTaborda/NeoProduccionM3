namespace STPM.FormsIndex
{
    partial class Estadisticas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadisticas));
            this.chartTurno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDura = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCantParadas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateP1 = new System.Windows.Forms.DateTimePicker();
            this.dateP2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCantParadas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTurno
            // 
            this.chartTurno.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartTurno.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chartTurno.BorderlineColor = System.Drawing.Color.DarkGreen;
            this.chartTurno.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            chartArea1.Name = "ChartArea1";
            this.chartTurno.ChartAreas.Add(chartArea1);
            this.chartTurno.IsSoftShadows = false;
            legend1.BackColor = System.Drawing.Color.DarkGray;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.chartTurno.Legends.Add(legend1);
            this.chartTurno.Location = new System.Drawing.Point(31, 12);
            this.chartTurno.Name = "chartTurno";
            this.chartTurno.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(102))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))))};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.Enabled = false;
            this.chartTurno.Series.Add(series1);
            this.chartTurno.Size = new System.Drawing.Size(493, 290);
            this.chartTurno.TabIndex = 1;
            this.chartTurno.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Tiempo de Trabajo - Turno Actual";
            title1.Text = "Tiempo de Trabajo - Último turno";
            this.chartTurno.Titles.Add(title1);
            this.chartTurno.Click += new System.EventHandler(this.chartTurno_Click);
            // 
            // chartMes
            // 
            this.chartMes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartMes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartMes.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chartMes.BorderlineColor = System.Drawing.Color.DarkGreen;
            this.chartMes.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            chartArea2.Name = "ChartArea1";
            this.chartMes.ChartAreas.Add(chartArea2);
            this.chartMes.IsSoftShadows = false;
            legend2.BackColor = System.Drawing.Color.DarkGray;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.chartMes.Legends.Add(legend2);
            this.chartMes.Location = new System.Drawing.Point(530, 12);
            this.chartMes.Name = "chartMes";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.IsXValueIndexed = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.SmartLabelStyle.Enabled = false;
            this.chartMes.Series.Add(series2);
            this.chartMes.Size = new System.Drawing.Size(451, 290);
            this.chartMes.TabIndex = 1;
            this.chartMes.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Tiempo de Trabajo - Mes Actual";
            title2.Text = "Tiempo de Trabajo - Mes Actual";
            this.chartMes.Titles.Add(title2);
            // 
            // chartDura
            // 
            this.chartDura.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartDura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartDura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartDura.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartDura.BorderlineColor = System.Drawing.Color.DarkGreen;
            this.chartDura.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisX.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorGrid.Interval = 0D;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.ScrollBar.BackColor = System.Drawing.Color.White;
            chartArea3.AxisX.ScrollBar.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea3.AxisY.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea3.AxisY2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea3.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            chartArea3.BorderColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartDura.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.DimGray;
            legend3.Enabled = false;
            legend3.ForeColor = System.Drawing.Color.White;
            legend3.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend3.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend3.Name = "Legend1";
            legend3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chartDura.Legends.Add(legend3);
            this.chartDura.Location = new System.Drawing.Point(530, 308);
            this.chartDura.Name = "chartDura";
            this.chartDura.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.EmptyPointStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series3.EmptyPointStyle.Color = System.Drawing.Color.White;
            series3.EmptyPointStyle.LabelForeColor = System.Drawing.Color.DimGray;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.IsVisibleInLegend = false;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartDura.Series.Add(series3);
            this.chartDura.Size = new System.Drawing.Size(525, 314);
            this.chartDura.TabIndex = 1;
            this.chartDura.Text = "chartDura";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.White;
            title3.Name = "Paradas  frecuentes";
            title3.Text = "Fallas con más Duración(min)";
            this.chartDura.Titles.Add(title3);
            // 
            // chartCantParadas
            // 
            this.chartCantParadas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chartCantParadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartCantParadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartCantParadas.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.chartCantParadas.BorderlineColor = System.Drawing.Color.DarkGreen;
            this.chartCantParadas.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisX.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorGrid.Interval = 0D;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.ScrollBar.BackColor = System.Drawing.Color.White;
            chartArea4.AxisX.ScrollBar.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea4.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea4.AxisY.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea4.AxisY.MinorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.None;
            chartArea4.AxisY2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY2.ScaleBreakStyle.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            chartArea4.BorderColor = System.Drawing.Color.White;
            chartArea4.Name = "ChartArea1";
            this.chartCantParadas.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.Color.DimGray;
            legend4.Enabled = false;
            legend4.ForeColor = System.Drawing.Color.White;
            legend4.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend4.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend4.Name = "Legend1";
            legend4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chartCantParadas.Legends.Add(legend4);
            this.chartCantParadas.Location = new System.Drawing.Point(31, 308);
            this.chartCantParadas.Name = "chartCantParadas";
            this.chartCantParadas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.EmptyPointStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            series4.EmptyPointStyle.Color = System.Drawing.Color.White;
            series4.EmptyPointStyle.LabelForeColor = System.Drawing.Color.DimGray;
            series4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.IsVisibleInLegend = false;
            series4.LabelForeColor = System.Drawing.Color.White;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.YValuesPerPoint = 4;
            this.chartCantParadas.Series.Add(series4);
            this.chartCantParadas.Size = new System.Drawing.Size(492, 314);
            this.chartCantParadas.TabIndex = 1;
            this.chartCantParadas.Text = "chartCantParadas";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.White;
            title4.Name = "Paradas  frecuentes";
            title4.Text = "Fallas más Ocurrentes (Cantidad)";
            this.chartCantParadas.Titles.Add(title4);
            // 
            // dateP1
            // 
            this.dateP1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP1.Location = new System.Drawing.Point(987, 12);
            this.dateP1.Name = "dateP1";
            this.dateP1.Size = new System.Drawing.Size(96, 20);
            this.dateP1.TabIndex = 2;
            // 
            // dateP2
            // 
            this.dateP2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateP2.Location = new System.Drawing.Point(987, 48);
            this.dateP2.Name = "dateP2";
            this.dateP2.Size = new System.Drawing.Size(96, 20);
            this.dateP2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(987, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "BUSCAR";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Estadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(71)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1090, 634);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateP2);
            this.Controls.Add(this.dateP1);
            this.Controls.Add(this.chartCantParadas);
            this.Controls.Add(this.chartDura);
            this.Controls.Add(this.chartMes);
            this.Controls.Add(this.chartTurno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Estadisticas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadisticas";
            this.Load += new System.EventHandler(this.Estadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCantParadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurno;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDura;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCantParadas;
        private System.Windows.Forms.DateTimePicker dateP1;
        private System.Windows.Forms.DateTimePicker dateP2;
        private System.Windows.Forms.Button button1;
    }
}