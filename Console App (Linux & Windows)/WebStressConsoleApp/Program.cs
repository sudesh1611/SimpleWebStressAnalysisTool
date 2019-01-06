using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WebStressConsoleApp
{

    public class AttackWithEverything
    {
        public long RequestsPerSeconds { set; get; } = 0;
        public long RequestsDropped { set; get; } = 0;
        public long TotalRequestsSent { set; get; } = 0;
        public long TotalBytesRecieved { set; get; } = 0;
        public int NumberThreads { set; get; } = 1;
        public bool ShowFurther { set; get; } = true;
        public System.Timers.Timer aTimer;
        CancellationTokenSource cts = new CancellationTokenSource();
        ParallelOptions po = new ParallelOptions();
        public string Url { set; get; }

        public void Attack()
        {
            //Cancellation Token Config
            cts = new CancellationTokenSource();
            po = new ParallelOptions
            {
                CancellationToken = cts.Token
            };
            po.MaxDegreeOfParallelism = System.Environment.ProcessorCount * 2;

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
                Parallel.For(0, NumberThreads, async ctr =>
               {
                   while (true)
                   {
                       Task<bool> dwnld = ProcessUrl(client);
                       bool z = await dwnld;
                   }
               });
            }
            catch (OperationCanceledException e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                //cts.Dispose();
            }
        }

        private async Task<bool> ProcessUrl(HttpClient client)
        {
            try
            {
                RequestsPerSeconds++;
                TotalRequestsSent++;
                var xyz = await client.GetAsync(Url);
                if (xyz.IsSuccessStatusCode)
                {
                    var conten = await xyz.Content.ReadAsStringAsync();
                    TotalBytesRecieved += conten.Length;
                }
                else
                {
                    //Console.WriteLine("Status Code: " + xyz.StatusCode);
                    RequestsDropped++;
                }
                return true;
            }
            catch (Exception ex)
            {
                RequestsDropped++;
                return false;
            }
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (ShowFurther)
                Console.WriteLine("> {0} : Sent {1} requests", DateTime.Now.ToLongTimeString(), RequestsPerSeconds);
            RequestsPerSeconds = 0;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime StartTime;
            DateTime EndTime;
            double TimeTaken = 0;
            long TotalRequestsSent = 0;
            long RequestsDropped = 0;
            long TotalBytesRecieved = 0;

            if (TimeTaken == 0)
            {
                AttackWithEverything attackWithEverything = new AttackWithEverything();

                Console.WriteLine("\n......Welcome to the Web Stress Analysis Tool......\n");

                Console.Write("Enter complete url to analyze: ");
                string InputUrl = Console.ReadLine().ToLower();
                Regex.Replace(InputUrl, @"\s+", "");
                bool result = Uri.TryCreate(InputUrl, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                while (!result)
                {
                    Console.WriteLine("\nERROR: URL syntax is not valid!");
                    Console.WriteLine("URL syntax should be: http://FullDomainName or https://FullDomainName");
                    Console.Write("Enter complete url to analyze: ");
                    InputUrl = Console.ReadLine().ToLower();
                    Regex.Replace(InputUrl, @"\s+", "");
                    result = Uri.TryCreate(InputUrl, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
                }
                attackWithEverything.Url = InputUrl;

                Console.Write("\nEnter number of threads to use (1-500): ");
                result = int.TryParse(Console.ReadLine(), out int NumberThreads);
                while (!result || NumberThreads < 1 || NumberThreads > 500)
                {
                    Console.WriteLine("\nERROR: Number is not valid!");
                    Console.Write("Enter number of threads to use (1-500): ");
                    result = int.TryParse(Console.ReadLine(), out NumberThreads);
                }
                attackWithEverything.NumberThreads = NumberThreads;

                Console.WriteLine("\nPress Enter to start analysis and after starting press Enter to stop");

                Console.ReadKey();

                StartTime = DateTime.Now;
                attackWithEverything.Attack();

                Console.ReadKey();

                EndTime = DateTime.Now;
                TimeTaken = (EndTime.Subtract(StartTime)).TotalSeconds;
                TotalRequestsSent = attackWithEverything.TotalRequestsSent;
                RequestsDropped = attackWithEverything.RequestsDropped;
                TotalBytesRecieved = attackWithEverything.TotalBytesRecieved;
                attackWithEverything.ShowFurther = false;
            }

            Console.WriteLine("\n\nTest Results...");
            Console.WriteLine("Total Requests Sent: " + TotalRequestsSent);
            Console.WriteLine("Total Time Taken: " + $"{TimeTaken:0.#}" + " seconds");
            Console.WriteLine("Total Requests Dropped By Server: " + RequestsDropped);
            Console.WriteLine($"Total Data Recieved: {(TotalBytesRecieved / 1048576.0):0.##} MB");
            Console.WriteLine($"Average Speed of Transmission: {((TotalBytesRecieved / 1048576.0) / TimeTaken):0.##} MB/s");
            Console.WriteLine($"Average Requests sent per second: {(TotalRequestsSent / TimeTaken):0.##}\n\n");

            Console.Write("\nPress Any Key to Exit...");
            Console.ReadKey();
            return;
        }
    }
}
