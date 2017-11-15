using System;
using System.Windows.Forms;
using MachineLearning.LinearAlgebra;
using MachineLearning.Probability;
using System.Windows.Forms.DataVisualization.Charting;


namespace MachineLearning.WinformsTest
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();

            var a = new Matrix<double>(5, 5, 1.1);
            var b = new Matrix<double>(5, 5, 3.4);
            var c = a + b;
            Console.Write(c.ToString());

            var d = c - a;
            Console.Write(d.ToString());

            d = d - 10;
            Console.Write(d.ToString());

            var e = new Matrix<double>(2, 1, 2);
            var f = new Matrix<double>(1, 2, 3);
            Console.Write((e*f).ToString());

            e = new Matrix<double>(1, 2, 2);
            f = new Matrix<double>(2, 1, 3);
            Console.Write((e * f).ToString());

            var g = new Matrix<double>(2, 1, 1.1);
            Console.Write(g.ToString());
            Console.Write(g.Transpose.ToString());

            // test equals
            Console.Write("Should be true: " + (a + b == b + a));
            Console.Write("Should be false: " + (a + b != b + a));

            GaussianDistributionDemo();
        }

        private Matrix<double> BinLogitReg(Matrix<double> X, Matrix<double> y)
        {
            var w = new Matrix<double>(1, X.Shape.D, 0d);

            for (int i = 0; i < 100; i++)
            {
                var s1 = X * w.Transpose;
                var s2 = MatrixExtensions.DoOperation(s1, x => 1 / (1 + Math.Exp(-x)));
                w = w - 10e-3 * (X.Transpose * (s2 - y)).Transpose;
            }

            return w;
        }

        private void GaussianDistributionDemo(double sigma = 1d)
        {
            // var sigma = 1d;
            var mu = 0d;
            var n_bins = 51;

            var bins = new int[n_bins];
            var r = new Random();

            // ===================

            var mu_b = 1d;
            var mu_r = 4d;

            graph.Series.Clear();
            Series S1 = graph.Series.Add("Blue");
            S1.ChartType = SeriesChartType.Point;

            Series S2 = graph.Series.Add("Red");
            S2.ChartType = SeriesChartType.Point;

            Series S3 = graph.Series.Add("Dec");
            S3.ChartType = SeriesChartType.Line;

            var X = new Matrix<double>(200, 3);
            var y = new Matrix<double>(200, 1);

            for (var i = 0; i < 100; i++)
            {
                X[i, 0] = 1;
                X[i, 1] = r.NextGaussian(mu_b, sigma);
                X[i, 2] = r.NextGaussian(mu_b, sigma);
                X[100 + i, 0] = 1;
                X[100 + i, 1] = r.NextGaussian(mu_r, sigma);
                X[100 + i, 2] = r.NextGaussian(mu_r, sigma);
                y[i, 0] = 0;
                y[100 + i, 0] = 1;

                S1.Points.AddXY(X[i, 1], X[i, 2]);
                S2.Points.AddXY(X[i + 100, 1], X[i + 100, 2]);
            }

            // S1.Points.Select(p => p)

            // 
            var w = BinLogitReg(X, y);

            //S3.Points.AddXY(0, 0);
            //S3.Points.AddXY(1, 1);

            for (int i = -1; i < 7; i++)
            {
                var slope = -w[0,1] / w[0,2];
                var intercept = -w[0,0] / w[0,2];
                var xx = i;
                var yy = slope * xx + intercept;
                S3.Points.AddXY(i, yy);
            }

            return;
           
            for (var i = 0; i < n_bins * 10000; i++)
            {
                var g = r.NextGaussian(mu, sigma);

                // Below code is for generating the histogram on the fly
                var z = (g - mu) / sigma;

                if (z > 3 || z < -3) continue;

                var b = (int)((z + 3) * n_bins / 6d);
                bins[b]++;
            }

            var f = new Series("Histogram");
            graph.Series.Clear();
            graph.Series.Add(f);
            graph.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            graph.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            graph.ChartAreas[0].AxisX.Minimum = mu - 3 * sigma;
            graph.ChartAreas[0].AxisX.Maximum = mu + 3 * sigma;
            graph.ChartAreas[0].AxisX.Title = "Value";
            graph.ChartAreas[0].AxisY.Title = "Count";

            // graph.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //graph.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.##}";
            graph.Legends.Clear();

            for (var i = 0; i < n_bins; i++)
            {
                var x = (i * 2d / n_bins - 1) * 3 * sigma + mu;
                var yy = bins[i];
                f.Points.AddXY(x, yy);
            }

            //demo_picker.Enabled = true;
            //btn_execute.Enabled = true;
        }

        private void nudVariance_ValueChanged(object sender, EventArgs e)
        {
            GaussianDistributionDemo((double)nudVariance.Value);
        }
    }
}
