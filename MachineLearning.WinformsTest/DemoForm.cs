using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void GaussianDistributionDemo(double sigma = 1d)
        {
            // var sigma = 1d;
            var mu = 0d;
            var n_bins = 51;

            var bins = new int[n_bins];
            var r = new Random();
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

            graph.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //graph.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0.##}";
            graph.Legends.Clear();

            for (var i = 0; i < n_bins; i++)
            {
                var x = (i * 2d / n_bins - 1) * 3 * sigma + mu;
                var y = bins[i];
                f.Points.AddXY(x, y);
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
