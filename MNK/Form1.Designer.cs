namespace MNK
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this._dgw_xy = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._bt_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._bt_culc = new System.Windows.Forms.Button();
            this._picb_graphic = new System.Windows.Forms.PictureBox();
            this._bt_drawG = new System.Windows.Forms.Button();
            this._tb_eps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this._bt_approx = new System.Windows.Forms.Button();
            this._bt_drawChart = new System.Windows.Forms.Button();
            this._tb_MovingAverageWidth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dgw_xy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picb_graphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgw_xy
            // 
            this._dgw_xy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._dgw_xy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgw_xy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgw_xy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this._dgw_xy.Location = new System.Drawing.Point(3, 76);
            this._dgw_xy.Name = "_dgw_xy";
            this._dgw_xy.RowHeadersVisible = false;
            this._dgw_xy.RowHeadersWidth = 80;
            this._dgw_xy.Size = new System.Drawing.Size(355, 362);
            this._dgw_xy.TabIndex = 0;
            this._dgw_xy.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this._dgw_xy_RowsAdded);
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // _bt_open
            // 
            this._bt_open.Location = new System.Drawing.Point(2, 3);
            this._bt_open.Name = "_bt_open";
            this._bt_open.Size = new System.Drawing.Size(90, 52);
            this._bt_open.TabIndex = 1;
            this._bt_open.Text = "Открыть файл";
            this._bt_open.UseVisualStyleBackColor = true;
            this._bt_open.Click += new System.EventHandler(this._bt_open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(364, 382);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(612, 51);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // _bt_culc
            // 
            this._bt_culc.Enabled = false;
            this._bt_culc.Location = new System.Drawing.Point(95, 3);
            this._bt_culc.Name = "_bt_culc";
            this._bt_culc.Size = new System.Drawing.Size(96, 25);
            this._bt_culc.TabIndex = 4;
            this._bt_culc.Text = "Расчет";
            this._bt_culc.UseVisualStyleBackColor = true;
            this._bt_culc.Click += new System.EventHandler(this._bt_culc_Click);
            // 
            // _picb_graphic
            // 
            this._picb_graphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._picb_graphic.Location = new System.Drawing.Point(656, 3);
            this._picb_graphic.Name = "_picb_graphic";
            this._picb_graphic.Size = new System.Drawing.Size(297, 373);
            this._picb_graphic.TabIndex = 5;
            this._picb_graphic.TabStop = false;
            // 
            // _bt_drawG
            // 
            this._bt_drawG.Enabled = false;
            this._bt_drawG.Location = new System.Drawing.Point(283, 3);
            this._bt_drawG.Name = "_bt_drawG";
            this._bt_drawG.Size = new System.Drawing.Size(80, 25);
            this._bt_drawG.TabIndex = 6;
            this._bt_drawG.Text = "График";
            this._bt_drawG.UseVisualStyleBackColor = true;
            this._bt_drawG.Visible = false;
            this._bt_drawG.Click += new System.EventHandler(this._bt_drawG_Click);
            // 
            // _tb_eps
            // 
            this._tb_eps.Enabled = false;
            this._tb_eps.Location = new System.Drawing.Point(268, 55);
            this._tb_eps.Name = "_tb_eps";
            this._tb_eps.Size = new System.Drawing.Size(90, 20);
            this._tb_eps.TabIndex = 7;
            this._tb_eps.Text = "0,000007";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(220, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "eps =";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(6, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(220, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "[Авто] Параметр фильтрации";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(364, 3);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series2";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(589, 435);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            title2.Name = "Title1";
            this.chart1.Titles.Add(title2);
            this.chart1.AnnotationPositionChanged += new System.EventHandler(this.chart1_AnnotationPositionChanged);
            this.chart1.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.chart1_AnnotationPositionChanging);
            // 
            // _bt_approx
            // 
            this._bt_approx.Enabled = false;
            this._bt_approx.Location = new System.Drawing.Point(95, 30);
            this._bt_approx.Name = "_bt_approx";
            this._bt_approx.Size = new System.Drawing.Size(96, 25);
            this._bt_approx.TabIndex = 11;
            this._bt_approx.Text = "Аппроксимация";
            this._bt_approx.UseVisualStyleBackColor = true;
            this._bt_approx.Visible = false;
            this._bt_approx.Click += new System.EventHandler(this._bt_approx_Click);
            // 
            // _bt_drawChart
            // 
            this._bt_drawChart.Enabled = false;
            this._bt_drawChart.Location = new System.Drawing.Point(197, 3);
            this._bt_drawChart.Name = "_bt_drawChart";
            this._bt_drawChart.Size = new System.Drawing.Size(80, 25);
            this._bt_drawChart.TabIndex = 12;
            this._bt_drawChart.Text = "График";
            this._bt_drawChart.UseVisualStyleBackColor = true;
            this._bt_drawChart.Click += new System.EventHandler(this._bt_drawChart_Click);
            // 
            // _tb_MovingAverageWidth
            // 
            this._tb_MovingAverageWidth.Location = new System.Drawing.Point(197, 33);
            this._tb_MovingAverageWidth.Name = "_tb_MovingAverageWidth";
            this._tb_MovingAverageWidth.Size = new System.Drawing.Size(90, 20);
            this._tb_MovingAverageWidth.TabIndex = 13;
            this._tb_MovingAverageWidth.Text = "15";
            this._tb_MovingAverageWidth.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tb_MovingAverageWidth);
            this.Controls.Add(this._bt_drawChart);
            this.Controls.Add(this._bt_approx);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this._tb_eps);
            this.Controls.Add(this._bt_drawG);
            this.Controls.Add(this._picb_graphic);
            this.Controls.Add(this._bt_culc);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this._bt_open);
            this.Controls.Add(this._dgw_xy);
            this.Name = "Form1";
            this.Text = "Определение интервалов и сегментов ЭКГ";
            ((System.ComponentModel.ISupportInitialize)(this._dgw_xy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picb_graphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _dgw_xy;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Button _bt_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button _bt_culc;
        private System.Windows.Forms.PictureBox _picb_graphic;
        private System.Windows.Forms.Button _bt_drawG;
        private System.Windows.Forms.TextBox _tb_eps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button _bt_approx;
        private System.Windows.Forms.Button _bt_drawChart;
        private System.Windows.Forms.TextBox _tb_MovingAverageWidth;
    }
}

