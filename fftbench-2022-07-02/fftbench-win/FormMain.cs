using fftbench.Benchmark;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fftbench
{
    public partial class FormMain : Form
    {
        PlotView plot;

        CancellationTokenSource cts;

        bool busy;

        List<ITest> tests;

        Report report;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOxyPlot();

            comboSize1.SelectedIndex = 2;
            comboSize2.SelectedIndex = comboSize2.Items.Count - 2;
            comboRepeat.SelectedIndex = 1;

            tests = Util.LoadTests();
        }

        private void InitializeOxyPlot()
        {
            this.plot = new OxyPlot.WindowsForms.PlotView();

            this.plot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plot.Location = new System.Drawing.Point(0, 0);
            this.plot.Margin = new System.Windows.Forms.Padding(0);
            this.plot.Name = "plot";
            this.plot.BackColor = Color.White;
            this.plot.Size = new System.Drawing.Size(500, 250);
            this.plot.TabIndex = 0;

            this.panel1.Controls.Add(this.plot);
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            if (busy)
            {
                if (cts != null)
                {
                    statusLabel.Text = "Cancelling ...";
                    btnRun.Enabled = false;

                    cts.Cancel();
                }

                return;
            }

            busy = true;

            btnRun.Image = Properties.Resources.stop;

            int start = comboSize1.SelectedIndex + 7;
            int end = comboSize2.SelectedIndex + 7;

            int i = Math.Min(start, end);
            int length = Math.Max(start, end);

            int repeat = int.Parse(comboRepeat.SelectedItem.ToString());

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = tests.Count * (length - i);

            cts = new CancellationTokenSource();

            var progress = new Progress<Tuple<int, string>>(t =>
                {
                    string status = t.Item2;

                    if (status != null)
                    {
                        statusLabel.Text = "Testing " + status + " ...";
                    }

                    int k = t.Item1;

                    if (k < progressBar.Maximum)
                    {
                        progressBar.Value = k;
                    }
                });

            try
            {
                var results = await RunBenchmark(i, length, repeat, tests, progress, cts.Token);

                this.plot.Model = CreatePlotModel(results);

                report = new Report(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnRun.Image = Properties.Resources.play;
                btnRun.Enabled = true;

                statusLabel.Text = string.Empty;

                progressBar.Value = 0;
                busy = false;
            }
        }

        private async Task<Dictionary<int, TestResult>> RunBenchmark(int start, int length,
            int repeat, List<ITest> tests, IProgress<Tuple<int, string>> progress,
            CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                // Group by FFT size.
                var results = new Dictionary<int, TestResult>();

                var benchmark = new BenchmarkRunner();

                int k = 0;

                foreach (var test in tests)
                {
                    if (!test.Enabled)
                    {
                        continue;
                    }

                    var name = test.ToString();

                    progress.Report(new Tuple<int, string>(k, name));

                    for (int i = start; i <= length; i++)
                    {
                        int size = Util.Pow(2, i);

                        var data = SignalGenerator.Sawtooth(size);

                        var result = benchmark.Run(test, data, repeat);

                        if (results.ContainsKey(size))
                        {
                            results[size].Add(name, result);
                        }
                        else
                        {
                            // TestResult will group by name.
                            results.Add(size, new TestResult(name, result));
                        }

                        progress.Report(new Tuple<int, string>(k++, null));

                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }

                return results;
            });
        }

        private static PlotModel CreatePlotModel(Dictionary<int, TestResult> results)
        {
            var model = new PlotModel
            {
                Title = "Benchmark Result"
            };

            model.Legends.Add(new Legend()
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.RightMiddle,
                LegendOrientation = LegendOrientation.Vertical,
                LegendBorderThickness = 0
            });

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom, Key = "Category" };

            var series = new Dictionary<string, BarSeries>();

            BarSeries s;

            foreach (var item in results)
            {
                int size = item.Key;
                var benchmark = item.Value;

                foreach (var result in benchmark.Results)
                {
                    var name = result.Key;

                    if (!series.TryGetValue(name, out s))
                    {
                        s = new BarSeries()
                        {
                            Title = name,
                            IsStacked = false,
                            StrokeColor = OxyColors.Black,
                            StrokeThickness = 1,
                            XAxisKey = "Value",
                            YAxisKey = "Category"
                        };

                        series[name] = s;
                    }

                    s.Items.Add(new BarItem { Value = result.Value.Total });
                }

                categoryAxis.Labels.Add(size.ToString());
            }

            var valueAxis = new LinearAxis { Position = AxisPosition.Left, Key = "Value", MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };

            foreach (var item in series.Values)
            {
                model.Series.Add(item);
            }

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            return model;
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            var form = new FormExplorer();

            form.ShowDialog();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            var form = new FormChoose();

            form.SetDataContext(tests);
            form.ShowDialog();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            btnCopy.Enabled = false;

            string r = report.CreateText();

            Clipboard.SetText(r);

            btnCopy.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();

            sfd.FileName = "benchmark.png";
            sfd.Filter = "PNG file (*.png)|*.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (plot.Model != null)
                {
                    PngExporter.Export(plot.Model, sfd.FileName, 600, 400);
                }
            }
        }
    }
}
