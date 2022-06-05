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
using System.Windows.Forms.DataVisualization.Charting;

namespace MNK
{
    public partial class Form1 : Form
    {
        float Xmin, Xmax, Ymin, Ymax;
        List<float> draw_points = new List<float>(4);
        int establishedRequirement = 10;
        double[] movingAverage = new double[0];
        VerticalLineAnnotation VLA;
        RectangleAnnotation RA;
        Series S1;
        ChartArea CA;
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
                var rand = new Random();
                double randEps = rand.NextDouble();
                richTextBox1.Text += "randEps=" + randEps + "\n";
                double testEps = y_teoretic[2] - y[2];
                richTextBox1.Text += testEps.ToString("0.00000000\n");
                int phase_transition_count = 0;
                int excessFlag = 0;
                bool decrementFlag = true;
                double decrementStep = 0.0000005;
                //draw_points.Add((float)x[0]);
                //draw_points.Add((float)y[0]);
                System.Diagnostics.Stopwatch my_timer = new Stopwatch();
                my_timer.Start();
                //Parallel.ForEach
                if (checkBox1.Checked)
                {
                    do {
                        phase_transition_count = 0;
                        draw_points.Clear();
                        for (int i = 0; i < num.GetLength(0) - 2; i++)
                        {
                            y_teoretic[i + 2] = (x[i + 2] * (y[i + 1] - y[i]) + x[i + 1] * y[i] - x[i] * y[i + 1]) / (x[i + 1] - x[i]);
                            m_diff = Math.Abs(y_teoretic[i + 2] - y[i + 2]);
                            if (m_diff > testEps)
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
                        if (testEps - decrementStep <= 0)
                            decrementFlag = false;
                        testEps = Math.Abs(testEps - decrementStep);
                        excessFlag++;
                        richTextBox1.Text += testEps.ToString("0.00000000\n");
                        richTextBox1.Text += "testEps=" + testEps + "\n" + "phase_transition_count=" + phase_transition_count + "\n" + "excessFlag=" + excessFlag + "\n";
                        if (excessFlag == 1000 || decrementFlag == false) break;
                        //} while (((phase_transition_count >= 8) && (phase_transition_count <= 15)) || excessFlag < 1000 && decrementFlag);
                    } while (phase_transition_count <= establishedRequirement);
                    _tb_eps.Clear();
                    _tb_eps.AppendText(testEps.ToString("0.00000000"));
                }
                else
                {
                    double eps = Convert.ToDouble(_tb_eps.Text);
                    phase_transition_count = 0;
                    draw_points.Clear();
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

                List<double> yList = y.ToList();
                //List<double> yList = new List<double>();
                //yList.AddRange(y[]);
                var rollingAgerage = RollingAverage(yList, x.Length);
                for (int i = 0; i < rollingAgerage.Count; i++)
                    richTextBox1.Text+=("rollingAgerage="+rollingAgerage[i].ToString()+"\n");
                movingAverage = GetMovingAverage(50, y);
                for (int i = 0; i < movingAverage.Length; i++)
                    richTextBox1.Text += ("movingAverage=" + movingAverage[i].ToString() + "\n");

            }
            _bt_drawG.Enabled = true;
        }

        private void _bt_drawG_Click(object sender, EventArgs e)
        {
            DrawGraphic();
            DrawChart();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                _tb_eps.Enabled = false;
            }
            if (checkBox1.Checked == false)
                _tb_eps.Enabled = true;
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

        public void DrawChart()
        {
            double[,] num = new double[_dgw_xy.RowCount, 2];
            for (int i = 0; i < _dgw_xy.RowCount; i++)
            {
                for (int j = 0; j < _dgw_xy.ColumnCount; j++)
                {
                    num[i, j] = Convert.ToDouble(_dgw_xy.Rows[i].Cells[j].Value);
                }
            }

            /// SETUP the chart area:  
            S1 = chart1.Series[0];
            CA = chart1.ChartAreas[0];
            chart1.Series[0].Points.Clear();
            chart1.Annotations.Clear();
            chart1.ChartAreas[0].AxisX.StripLines.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = num[0, 0];
            chart1.ChartAreas[0].AxisX.Maximum = num[_dgw_xy.RowCount - 1, 0];
            //chart1.ChartAreas[0].AxisY.Minimum = num[0, 1];
            //chart1.ChartAreas[0].AxisY.Maximum = num[_dgw_xy.RowCount - 1, 1];

            /// STRIPLINES
            List<Color> colors = new List<Color>()  { Color.FromArgb(64, Color.LightBlue), Color.FromArgb(64, Color.LightSeaGreen),
                Color.FromArgb(64, Color.LightCoral), Color.FromArgb(64, Color.LightSalmon), Color.FromArgb(64, Color.LightPink)};
            List<double> pqrstCoords = new List<double>(10);
            if(draw_points.Count >= establishedRequirement)
            {
                for(int i=0; i <draw_points.Count - 1; i++)
                {
                    //pqrstCoords[i] = draw_points[i];
                    pqrstCoords.Add(draw_points[i]);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                StripLine sl = new StripLine();
                switch (i)
                {
                    case 0: sl.Text = "P"; break;
                    case 1: sl.Text = "PQ"; break;
                    case 2: sl.Text = "QRS"; break;
                    case 3: sl.Text = "ST"; break;
                    case 4: sl.Text = "T"; break;
                    default: sl.Text = "undefined"; break;
                }
                sl.TextAlignment = StringAlignment.Center;
                sl.TextOrientation = TextOrientation.Horizontal;
                sl.StripWidth = pqrstCoords[i*2+2] - pqrstCoords[i*2];
                sl.IntervalOffset = pqrstCoords[i*2];  //This is where the stripline starts (x-position)
                //sl.StripWidth = pqrstCoords[i*2];
                //sl.IntervalOffset = sl.StripWidth * (i*2);
                sl.BackColor = colors[i];
                chart1.ChartAreas[0].AxisX.StripLines.Add(sl);
            }
            ///DRAW chart
            for (int i = 0; i < _dgw_xy.RowCount; i++)
            {
                this.chart1.Series[0].Points.AddXY(num[i, 0], num[i, 1]);
            }
            for (int j=0; j<movingAverage.Length;j++)
            {
                chart1.Series[1].Points.AddXY(j, movingAverage[j]);
            }

            // TEXT ANNOTATION
            //List<TextAnnotation> TAs = new List<TextAnnotation>() {
            //    TextAnnotation P = new TextAnnotation();
            //};
            //TextAnnotation taP = new TextAnnotation(), taPQ = new TextAnnotation(), taQRS = new TextAnnotation(), taST = new TextAnnotation(), taT = new TextAnnotation();
            //taP.Text = "P"; taPQ.Text = "PQ"; taQRS.Text = "QRS"; taST.Text = "ST"; taT.Text = "T";
            //taP.AnchorX = draw_points[0];
            //taP.AnchorY = draw_points[1];
            //taP.AnchorDataPoint = chart1.Series[0].Points[(int)draw_points[0]];//???
            //chart1.Annotations.Add(taP);

            /// MOVABLE VERTICAL LINE ANNOTATION
            //the VERTICAL LINE
            VLA = new VerticalLineAnnotation();
            VLA.LineColor = Color.Red;
            VLA.AllowMoving = true;
            VLA.IsInfinitive = true;
            VLA.LineWidth = 2;
            VLA.AxisX = chart1.ChartAreas[0].AxisX;
            VLA.X = draw_points[0];
            VLA.ClipToChartArea = chart1.ChartAreas[0].Name;
            chart1.Annotations.Add(VLA);

            // the RECTANGLE
            //RA = new RectangleAnnotation();
            //RA.AxisX = chart1.ChartAreas[0].AxisX;
            //RA.IsSizeAlwaysRelative = false;
            //RA.Width = 10;
            //RA.Height = 5;
            //RA.LineColor = Color.Red;
            //RA.BackColor = Color.Red;
            //RA.Y = 0;
            //RA.X = VLA.X - RA.Width / 2;
            //RA.ForeColor = Color.Black;
            //RA.Font = new System.Drawing.Font("Arial", 8f);
            //chart1.Annotations.Add(RA);
        }

        private void chart1_AnnotationPositionChanging(object sender,
                    AnnotationPositionChangingEventArgs e)
        {
            // move the rectangle with the line
            //if (sender == VLA) RA.X = VLA.X - RA.Width / 2;

            // display the current Y-value
            int pt1 = (int)e.NewLocationX;
            double step = (S1.Points[pt1 + 1].YValues[0] - S1.Points[pt1].YValues[0]);
            double deltaX = e.NewLocationX - S1.Points[pt1].XValue;
            double val = S1.Points[pt1].YValues[0] + step * deltaX;
            chart1.Titles[0].Text = String.Format(
                                    "X = {0:0.00}   Y = {1:0.00000000}", e.NewLocationX, val);
            //RA.Text = String.Format("{0:0.00000000}", val);
            chart1.Update();
        }

        private void chart1_AnnotationPositionChanged(object sender, EventArgs e)
        {
            VLA.X = (int)(VLA.X + 0.5);
            //RA.X = VLA.X - RA.Width / 2;
        }

        public List<double> RollingAverage(List<double> source, int width)
        {
            return Enumerable.Range(0, 1 + source.Count - width).
                                      Select(i => source.Skip(i).Take(width).Average()).
                                      ToList();
        }

        private static double[] GetMovingAverage(int width, double[] data)
        {
            double sum = 0;
            double[] avgPoints = new double[data.Length - width + 1];
            for (int counter = 0; counter <= data.Length - width; counter++)
            {
                int innerLoopCounter = 0;
                int index = counter;
                while (innerLoopCounter < width)
                {
                    sum = sum + data[index];

                    innerLoopCounter += 1;

                    index += 1;

                }
                avgPoints[counter] = sum / width;
                sum = 0;
            }
            return avgPoints;
        }

    }
}
