using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SimpleWebStressTool
{
    public partial class SimpleWebStressTool : Form
    {

        private static long RequestsPerSeconds = 0;
        private static long RequestsDropped = 0;
        private static long TotalRequestsSent = 0;
        private static long TotalBytesRecieved = 0;
        private static System.Timers.Timer aTimer;
        private static string Url { set; get; }
        private DateTime StartTime { get; set; }
        private DateTime EndTime { get; set; }
        CancellationTokenSource cts = new CancellationTokenSource();
        ParallelOptions po = new ParallelOptions();

        private void RunTests()
        {
            HttpClient client = new HttpClient();
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            try
            {
                //CancellationToken should be inserted here but can not add because
                //Only single thread gets cancelled and then cts.Dispose  throws error
                //Parallel.For(0, Int32.Parse(ThreadsToUseUpDown.Value.ToString()),po, async ctr =>
                Parallel.For(0, Int32.Parse(ThreadsToUseUpDown.Value.ToString()), async ctr =>
                {
                    while(true)
                    {
                        Task<bool> dwnld = ProcessUrl(client);
                        bool z = await dwnld;
                    }
                });
            }
            catch(OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cts.Dispose();
            }

        }

        private async Task<bool> ProcessUrl(HttpClient client)
        {
            try
            {
                RequestsPerSeconds++;
                TotalRequestsSent++;
                var xyz = await client.GetAsync(Url);
                if(xyz.IsSuccessStatusCode)
                {
                    var conten = await xyz.Content.ReadAsStringAsync();
                    TotalBytesRecieved += conten.Length;
                }
                else
                {
                    Console.WriteLine("Status Code: "+xyz.StatusCode);
                    RequestsDropped++;
                }
                return true;
            }
            catch(Exception ex)
            {
                RequestsDropped++;
                return false;
            }
        }

        delegate void StringArgReturningVoidDelegate(string text);

        private void SetText(string text)
        {
            if (this.RequestsPerSecondLabel.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.RequestsPerSecondLabel.Text = text;
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.SetText("Sending at the rate of " + RequestsPerSeconds + " requests per second");
            RequestsPerSeconds = 0;
        }

        public SimpleWebStressTool()
        {
            InitializeComponent();
        }

        private void ResetApp()
        {
            RequestsPerSecondLabel.Text = "Sending at the rate of 0 requests per second";
            RequestsPerSecondLabel.Visible = false;
            TotalRequestsLabel.Text = "Total Requests Sent: 0";
            TotalRequestsLabel.Visible = false;
            TotalTimeLabel.Text = "Total Time Taken: 0s";
            TotalTimeLabel.Visible = false;
            RequestsDroppedLabel.Text = "Total Requests Dropped By Server: 0";
            RequestsDroppedLabel.Visible = false;
            TotalDataLabel.Text = "Total Data Recieved: 0 MB";
            TotalDataLabel.Visible = false;
            AverageSpeedLabel.Text = "Average Speed of Transmission: 0 MB/s";
            AverageSpeedLabel.Visible = false;
            AverageRequestsLabel.Text = "Average Requests per second: 0";
            AverageRequestsLabel.Visible = false;
            StartStressTestButton.Visible = true;
            StartStressTestButton.Enabled = true;
            EndStressTestButton.Visible = true;
            EndStressTestButton.Enabled = false;
            ResetButton.Visible = true;
            ResetButton.Enabled = true;
            //Cancellation Token Config
            cts = new CancellationTokenSource();
            po = new ParallelOptions
            {
                CancellationToken = cts.Token
            };
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount * 2;
            
            Url = "";
            RequestsDropped = 0;
            RequestsPerSeconds = 0;
            TotalBytesRecieved = 0;
            TotalRequestsSent = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetApp();
        }

        private void StartStressTestButton_ClickAsync(object sender, EventArgs e)
        {
            StartStressTestButton.Enabled = false;
            ResetButton.Enabled = false;
            bool result = Uri.TryCreate(URLInputBox.Text, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                System.Windows.Forms.MessageBox.Show("URL syntax is: http://www.FullDomainName or https://www.FullDomainName");
                StartStressTestButton.Enabled = true;
                ResetButton.Enabled = true;
                return;
            }
            if(ThreadsToUseUpDown.Value<1 || ThreadsToUseUpDown.Value>500)
            {
                System.Windows.Forms.MessageBox.Show("Number of threads can be between (0,501)"+ThreadsToUseUpDown.Value);
                StartStressTestButton.Enabled = true;
                ResetButton.Enabled = true;
                return;
            }
            Url = URLInputBox.Text;
            RequestsDropped = 0;
            RequestsPerSeconds = 0;
            RequestsPerSecondLabel.Visible = true;
            EndStressTestButton.Enabled = true;
            StartTime = DateTime.Now;
            RunTests();
        }

        private void EndStressTestButton_Click(object sender, EventArgs e)
        {
            EndStressTestButton.Enabled = false;

            //Cancel Command
            //cts.Cancel(true);

            EndTime = DateTime.Now;
            var TimeTaken = (EndTime.Subtract(StartTime)).Seconds;
            RequestsPerSecondLabel.Visible = false;
            TotalRequestsLabel.Text = "Total Requests Sent: "+TotalRequestsSent;
            TotalRequestsLabel.Visible = true;
            TotalTimeLabel.Text = "Total Time Taken: "+TimeTaken+" seconds";
            TotalTimeLabel.Visible = true;
            RequestsDroppedLabel.Text = "Total Requests Dropped By Server: "+RequestsDropped;
            RequestsDroppedLabel.Visible = true;
            TotalDataLabel.Text = $"Total Data Recieved: {(TotalBytesRecieved/1048576.0):0.##} MB";
            TotalDataLabel.Visible = true;
            AverageSpeedLabel.Text = $"Average Speed of Transmission: {((TotalBytesRecieved / 1048576.0)/TimeTaken):0.##} MB/s";
            AverageSpeedLabel.Visible = true;
            AverageRequestsLabel.Text = $"Average Requests sent per second: {(TotalRequestsSent / TimeTaken):0.##}";
            AverageRequestsLabel.Visible = true;
            ResetButton.Visible = true;
            ResetButton.Enabled = true;
            EndStressTestButton.Visible = true;
            EndStressTestButton.Enabled = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            //Because background threads keep running
            Application.Restart();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}
