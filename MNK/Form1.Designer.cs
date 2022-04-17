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
            ((System.ComponentModel.ISupportInitialize)(this._dgw_xy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picb_graphic)).BeginInit();
            this.SuspendLayout();
            // 
            // _dgw_xy
            // 
            this._dgw_xy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgw_xy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgw_xy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this._dgw_xy.Location = new System.Drawing.Point(3, 59);
            this._dgw_xy.Name = "_dgw_xy";
            this._dgw_xy.RowHeadersVisible = false;
            this._dgw_xy.RowHeadersWidth = 80;
            this._dgw_xy.Size = new System.Drawing.Size(281, 379);
            this._dgw_xy.TabIndex = 0;
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
            this._bt_open.Size = new System.Drawing.Size(90, 25);
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
            this.richTextBox1.Location = new System.Drawing.Point(290, 382);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(666, 51);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // _bt_culc
            // 
            this._bt_culc.Location = new System.Drawing.Point(98, 3);
            this._bt_culc.Name = "_bt_culc";
            this._bt_culc.Size = new System.Drawing.Size(90, 25);
            this._bt_culc.TabIndex = 4;
            this._bt_culc.Text = "Расчет";
            this._bt_culc.UseVisualStyleBackColor = true;
            this._bt_culc.Click += new System.EventHandler(this._bt_culc_Click);
            // 
            // _picb_graphic
            // 
            this._picb_graphic.Location = new System.Drawing.Point(290, 3);
            this._picb_graphic.Name = "_picb_graphic";
            this._picb_graphic.Size = new System.Drawing.Size(675, 435);
            this._picb_graphic.TabIndex = 5;
            this._picb_graphic.TabStop = false;
            // 
            // _bt_drawG
            // 
            this._bt_drawG.Enabled = false;
            this._bt_drawG.Location = new System.Drawing.Point(194, 3);
            this._bt_drawG.Name = "_bt_drawG";
            this._bt_drawG.Size = new System.Drawing.Size(90, 25);
            this._bt_drawG.TabIndex = 6;
            this._bt_drawG.Text = "График";
            this._bt_drawG.UseVisualStyleBackColor = true;
            this._bt_drawG.Click += new System.EventHandler(this._bt_drawG_Click);
            // 
            // _tb_eps
            // 
            this._tb_eps.Location = new System.Drawing.Point(194, 33);
            this._tb_eps.Name = "_tb_eps";
            this._tb_eps.Size = new System.Drawing.Size(90, 20);
            this._tb_eps.TabIndex = 7;
            this._tb_eps.Text = "0,000007";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Параметр фильтрации eps =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tb_eps);
            this.Controls.Add(this._bt_drawG);
            this.Controls.Add(this._picb_graphic);
            this.Controls.Add(this._bt_culc);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this._bt_open);
            this.Controls.Add(this._dgw_xy);
            this.Name = "Form1";
            this.Text = "Поиск и фильтрация точек фазового перехода";
            ((System.ComponentModel.ISupportInitialize)(this._dgw_xy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picb_graphic)).EndInit();
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
    }
}

