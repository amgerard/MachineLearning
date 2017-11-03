namespace MachineLearning.WinformsTest
{
    partial class DemoForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.nudVariance = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVariance)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            chartArea3.Name = "ChartArea1";
            this.graph.ChartAreas.Add(chartArea3);
            this.graph.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.graph.Legends.Add(legend3);
            this.graph.Location = new System.Drawing.Point(0, 39);
            this.graph.Name = "graph";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.graph.Series.Add(series3);
            this.graph.Size = new System.Drawing.Size(589, 382);
            this.graph.TabIndex = 0;
            this.graph.Text = "chart1";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.nudVariance);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(589, 39);
            this.pnlTop.TabIndex = 1;
            // 
            // nudVariance
            // 
            this.nudVariance.DecimalPlaces = 1;
            this.nudVariance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudVariance.Location = new System.Drawing.Point(11, 10);
            this.nudVariance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudVariance.Name = "nudVariance";
            this.nudVariance.Size = new System.Drawing.Size(54, 20);
            this.nudVariance.TabIndex = 0;
            this.nudVariance.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudVariance.ValueChanged += new System.EventHandler(this.nudVariance_ValueChanged);
            // 
            // DemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 421);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.pnlTop);
            this.Name = "DemoForm";
            this.Text = "Demo";
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudVariance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.NumericUpDown nudVariance;
    }
}

