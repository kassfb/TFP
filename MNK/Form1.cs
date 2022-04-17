using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MNK
{
    public partial class Form1 : Form
    {
        float Xmin, Xmax, Ymin, Ymax;
        List<float> draw_points = new List<float>(4);
        public Form1()
        {
            InitializeComponent();
        }

        private void _bt_open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            StreamReader str = new StreamReader(filename);
            string[] lines = File.ReadAllLines(filename);
            string buffer;
            double[,] num = new double[lines.Length / 2, 2];
            for (int x = 0; x < num.GetLength(0); x++)
            {
                for (int y = 0; y < num.GetLength(1); y++)
                {
                    buffer = str.ReadLine();
                    num[x, y] = Convert.ToDouble(buffer);
                }
            }

            _dgw_xy.RowCount = num.GetLength(0);
            _dgw_xy.ColumnCount = num.GetLength(1);
            for (int i = 0; i < num.GetLength(0); i++)
                for (int j = 0; j < num.GetLength(1); j++)
                    _dgw_xy.Rows[i].Cells[j].Value = num[i, j];

            //// проверяем выводом в RTB
            //for (int i = 0; i < num.GetLength(0); i++)
            //    for (int j = 0; j < num.GetLength(1); j++)
            //        richTextBox1.Text+="num["+i+"]["+j+"]="+ num[i, j].ToString() + "\n";
        }
        private void _bt_culc_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("num_test.txt", false, System.Text.Encoding.Default))
            {
                double[,] num = new double[_dgw_xy.RowCount, 2];
                for (int i = 0; i < _dgw_xy.RowCount; i++)
                {
                    for (int j = 0; j < _dgw_xy.ColumnCount; j++)
                    {
                            num[i, j] = Convert.ToDouble(_dgw_xy.Rows[i].Cells[j].Value);
                            sw.WriteLine(num[i, j]);
                    }
                }
                culc(num);
            }
        }

        public void culc(double[,] num)
        {
            using (StreamWriter sw = new StreamWriter("result_TFP.txt", false, System.Text.Encoding.Default))
            {
                double[] x = new double[num.GetLength(0)];
                double[] y = new double[num.GetLength(0)];
                double[] y_teoretic = new double[num.GetLength(0)];
                //PointF[] draw_points = new PointF[num.GetLength(0)];
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    x[i] = num[i, 0];
                    y[i] = num[i, 1];
                }
                Xmin = (float)x.Min();
                Xmax = (float)x.Max();
                Ymin = (float)y.Min();
                Ymax = (float)y.Max();
                double m_diff = 0;
                double eps = Convert.ToDouble(_tb_eps.Text);
                int phase_transition_count = 0;
                draw_points.Clear();
                //draw_points.Add((float)x[0]);
                //draw_points.Add((float)y[0]);
                System.Diagnostics.Stopwatch my_timer = new Stopwatch();
                my_timer.Start();
                for (int i = 0; i < num.GetLength(0) - 2; i++)
                {
                    y_teoretic[i + 2] = (x[i + 2] * (y[i + 1] - y[i]) + x[i + 1] * y[i] - x[i] * y[i + 1]) / (x[i + 1] - x[i]);
                    m_diff = Math.Abs(y_teoretic[i + 2] - y[i + 2]);
                    if (m_diff > eps)
                    {
                        phase_transition_count++;
                        sw.WriteLine(/*" m_diff= " + m_diff + " phase_transition*/" X= " + x[i + 1] + " Y= " + y[i + 1]);
                        draw_points.Add((float)x[i + 1]);
                        draw_points.Add((float)y[i + 1]/*y_teoretic[i + 1]*/);
                    }
                }
                my_timer.Stop();
                sw.WriteLine("TIME = " + my_timer.Elapsed.TotalMilliseconds / 1000.0 + " sec");
                //sw.WriteLine("phase_transition_count= " + phase_transition_count);
                //sw.WriteLine("END");
                draw_points.Add((float)x.Last());
                draw_points.Add((float)/*y_teoretic*/y.Last());
            }
            _bt_drawG.Enabled = true;
        }

        private void _bt_drawG_Click(object sender, EventArgs e)
        {
            DrawGraphic();
        }

        float Xe(float X)
        {
            return (float)_picb_graphic.Size.Width * (X - Convert.ToSingle(Xmin)) / (Convert.ToSingle(Xmax) - Convert.ToSingle(Xmin));
        }

        float Ye(float Y)
        {
            return (float)_picb_graphic.Size.Height * (1 - (Y - Convert.ToSingle(Ymin)) / (Convert.ToSingle(Ymax) - Convert.ToSingle(Ymin)));
        }

        public void DrawGraphic()
        {
            Graphics g = _picb_graphic.CreateGraphics();

            Pen my_pen = new Pen(Color.Black, 2);
            Pen red_pen = new Pen(Color.Red, 1);
            Pen blue_pen = new Pen(Color.Blue, 1);
            //размеры PictureBox
            int pb_width = _picb_graphic.Width;
            int pb_height = _picb_graphic.Height;
            g.Clear(Color.White);

            double[,] num = new double[_dgw_xy.RowCount, 2];
            for (int i = 0; i < _dgw_xy.RowCount; i++)
            {
                for (int j = 0; j < _dgw_xy.ColumnCount; j++)
                {
                        num[i, j] = Convert.ToDouble(_dgw_xy.Rows[i].Cells[j].Value);
                }
            }
            //Экспериментальные точки (черные)
            PointF[] all_points = new PointF[num.GetLength(0)];
            for (int i = 0; i < num.GetLength(0); i++)
            {
                all_points[i].X = (float)num[i, 0];
                all_points[i].Y = (float)num[i, 1];
                g.FillRectangle(new SolidBrush(Color.Black), new RectangleF(Xe(all_points[i].X), Ye(all_points[i].Y), 2, 2));
                //g.FillRectangle(new SolidBrush(Color.Black), all_points[i].X, all_points[i].Y, 2, 2);
                //_bm_grap.SetPixel(Convert.ToInt32(all_points[i].X),Convert.ToInt32(all_points[i].Y), Color.Black);
            }

            //отрисовка линий по экспериментальным точкам
            for (int i = 0; i < num.GetLength(0) - 1; i++)
            {
                g.DrawLine(my_pen, Xe(all_points[i].X), Ye(all_points[i].Y), Xe(all_points[i + 1].X), Ye(all_points[i + 1].Y));
            }

            //Теоретические точки(красные)
            //for (int i = 0; i < draw_points.Count - 1; i += 2)
            //{
            //    g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(Xe(draw_points[i]), Ye(draw_points[i + 1]), 4, 4));
            //}

            //Красне вертикальныые линии
            for (int i = 0; i < draw_points.Count - 1; i += 2)
            {
                g.DrawLine(red_pen, Xe(draw_points[i]), Ye(draw_points[i + 1]), Xe(draw_points[i]), Ye(Ymax));
                g.DrawLine(red_pen, Xe(draw_points[i]), Ye(draw_points[i + 1]), Xe(draw_points[i]), Ye(Ymin));
            }

            //отрисовка линий по текущим Y в коридоре < eps
            //for (int i = 0; i <= draw_points.Count - 4; i += 2)
            //{
            //    g.DrawLine(red_pen, Xe(draw_points[i]), Ye(draw_points[i + 1]), Xe(draw_points[i + 2]), Ye(draw_points[i + 3]));
            //}

            //Начало координат у PictureBox слева сверху [ (0,0 - левый верхний угол) (width,height - правый нижний) (width,0 - правый верхний) (0, height - левый нижний)]
        }
    }
}
