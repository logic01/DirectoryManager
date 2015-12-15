using DirectoryManager.BusinessDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemWrapper.IO;

namespace DirectoryManager.Desktop
{
    public partial class Form1 : Form
    {
        public class WorkerResultData
        {
            public WorkerResultData(string path, Label label)
            {
                this.Path = path;
                this.ResultLabel = label;
            }

            // I want to track what label to update after my async process
            public Label ResultLabel { get; set; }
            public decimal Size { get; set; }
            public string Path { get; set; }
        }

        BackgroundWorker singleDirectoryWorker;
        BackgroundWorker multiDirectoryWorker;

        private IDirectoryBusiness _business = new DirectoryBusiness();

        public Form1()
        {
            InitializeComponent();
            InitBackgroundWorker();
        }

        private void InitBackgroundWorker()
        {
            singleDirectoryWorker = new BackgroundWorker();
            singleDirectoryWorker.DoWork += new DoWorkEventHandler(singleDirectoryWorker_DoWork);
            singleDirectoryWorker.ProgressChanged += new ProgressChangedEventHandler
                    (backgroundWorker_ProgressChanged);
            singleDirectoryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (singleDirectoryWorker_RunWorkerCompleted);
            singleDirectoryWorker.WorkerReportsProgress = true;
            singleDirectoryWorker.WorkerSupportsCancellation = true;

            multiDirectoryWorker = new BackgroundWorker();
            multiDirectoryWorker.DoWork += new DoWorkEventHandler(multiDirectoryWorker_DoWork);
            multiDirectoryWorker.ProgressChanged += new ProgressChangedEventHandler
                    (backgroundWorker_ProgressChanged);
            multiDirectoryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (multiDirectoryWorker_RunWorkerCompleted);
            multiDirectoryWorker.WorkerReportsProgress = true;
            multiDirectoryWorker.WorkerSupportsCancellation = true;
        }

        void singleDirectoryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
               // the msdn spec says this will be any unhandled exception.
               // that doesn't appear to be the case at the moment.
            }
            else if (e.Cancelled)
            {
                // probably cancelled due to an exception
            }
            else
            {
                // Everything completed normally.
                var data = (WorkerResultData)e.Result;
                label_log.Text = "Task Completed...";
                data.ResultLabel.Text = data.Size.ToString();
            }

            //Change the status of the buttons on the UI accordingly
            button_calc.Enabled = true;
        }

        void multiDirectoryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // probably cancelled due to an exception
            }
            else if (e.Error != null)
            {
                label_log.Text = "Error while performing background operation.";
            }
            else
            {
                // Everything completed normally.
                label_log.Text = "Task Completed...";
                label_tot.Text = e.Result.ToString();
            }

            //Change the status of the buttons on the UI accordingly
            button_calc.Enabled = true;
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is Exception)
            {
                label_log.Text = String.Format("An issue has occured: {0}", ((Exception)e.UserState).Message);
            }
        }

        async void singleDirectoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var data = (WorkerResultData)e.Argument;

                data.Size = await CalculateSizeAsync(data.Path);

                e.Result = data;
            }
            catch (Exception ex)
            {
                // The speck for BackgroundWorker states that they will catch any unhandled exceptions 
                // that data should be surficed in the e.Error under RunWorkerComplete event.
                // It doesn't seem to be working in that fashion so I have used a work around here to produced similar results.
                e.Cancel = true;
                singleDirectoryWorker.ReportProgress(0, ex);
            }
        }

        async void multiDirectoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var paths = (List<string>)e.Argument;

                var tasks = paths.Select(CalculateSizeAsync).ToList();

                var size = (await Task.WhenAll(tasks)).Sum();

                e.Result = size;
            }
            catch (Exception ex)
            {
                // The speck for BackgroundWorker states that they will catch any unhandled exceptions 
                // that data should be surficed in the e.Error under RunWorkerComplete event.
                // It doesn't seem to be working in that fashion so I have used a work around here to produced similar results.
                e.Cancel = true;
                singleDirectoryWorker.ReportProgress(0, ex);
            }
        }

        private void button_dirPath1_Click(object sender, EventArgs e)
        {
            SelectDirectory(textBox_dirPath1, label_dirPath1);
        }

        private void button_dirPath2_Click(object sender, EventArgs e)
        {
            SelectDirectory(textBox_dirPath2, label_dirPath2);
        }

        private void button_dirPath3_Click(object sender, EventArgs e)
        {
            SelectDirectory(textBox_dirPath3, label_dirPath3);
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            label_log.Text = "";
            button_calc.Enabled = false;

            var paths = new List<string>();
            paths.Add(textBox_dirPath1.Text);
            paths.Add(textBox_dirPath2.Text);
            paths.Add(textBox_dirPath3.Text);

            if (!IsInputValid(paths))
            {
                label_log.Text = "Invalid input";
            }
            else
            {
                multiDirectoryWorker.RunWorkerAsync(paths);
            }
        }

        private void SelectDirectory(TextBox textBox, Label label)
        {
            label_log.Text = "";

            folderBrowserDialog1.SelectedPath = textBox.Text;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;

                if (!Directory.Exists(path))
                {
                    label_log.Text = "Invalid input";
                }
                else
                {
                    textBox.Text = path;
                    textBox.Enabled = false;
                    button_calc.Enabled = false;

                    singleDirectoryWorker.RunWorkerAsync(new WorkerResultData(path, label));
                }
            }
        }

        private async Task<decimal> CalculateSizeAsync(string path)
        {
            var dirInfo = new DirectoryInfoWrap(path);

            var size = await _business.MeasureDirectoryAsync(dirInfo);

            return size;
        }

        private bool IsInputValid(List<string> paths)
        {
            foreach (var path in paths)
            {
                if (!Directory.Exists(path))
                {
                    return false;
                }
            }

            return true;
        }
    }
}