using System.Windows;
using System.Threading;
using System.ComponentModel;

namespace WpfApplication7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private BackgroundWorker _worker;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            _worker = new BackgroundWorker();

            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;

            _worker.DoWork += delegate(object s, DoWorkEventArgs args)
            {
                BackgroundWorker worker = s as BackgroundWorker;

                int extracted = (int)args.Argument;

                if (extracted == 0)
                {
                    Lychrel ly = new Lychrel();
                    ly.Start(Output, worker);
                }
                else if (extracted == 1)
                {
                    PrimesWithRuns pr = new PrimesWithRuns();
                    pr.Start(Output, worker);
                }
                else if (extracted == 2)
                {
                    PalindromicSums ps = new PalindromicSums();
                    ps.Start(Output, worker);
                }
                else if (extracted == 3)
                {
                    FewRepeatedDigits ps = new FewRepeatedDigits();
                    ps.Init();
                    ps.Start(Output, worker);
                }

                

                /*for (int i = 0; i < 10; i++)
                {
                    if (worker.CancellationPending)
                    {
                        args.Cancel = true;
                        return;
                    }

                    Thread.Sleep(1000);
                    ly.Start(Output, worker);
                    worker.ReportProgress(i + 1);
                }*/

                //System.Console.Beep(1000, 1000);
            };

            _worker.ProgressChanged += delegate(object s,
                    ProgressChangedEventArgs args)
            {
                progressBar1.Value = args.ProgressPercentage;
                Output.Text += args.UserState as string;
            };

            _worker.RunWorkerCompleted += delegate(object s,
                    RunWorkerCompletedEventArgs args)
            {
                start.IsEnabled = true;
                cancel.IsEnabled = false;
                progressBar1.Value = 0;
            };

            _worker.RunWorkerAsync(listBox1.SelectedIndex);
            start.IsEnabled = false;
            cancel.IsEnabled = true;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            _worker.CancelAsync();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Lychrel ly = new Lychrel();

            ly.Test(Output);
        }
    }
}
