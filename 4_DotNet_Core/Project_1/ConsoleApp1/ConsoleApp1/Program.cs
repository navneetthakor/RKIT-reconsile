//using System;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    private static readonly HttpClient _httpClient = new HttpClient();
//    private static readonly string _url = "https://rkitsoftware.com/"; // Replace with your IP or URL
//    private static readonly TimeSpan _interval = TimeSpan.FromSeconds(20);

//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Starting HTTP Request Tester...");
//        Console.WriteLine($"Target URL: {_url}");
//        Console.WriteLine($"Interval: {_interval.TotalMinutes} minute(s)");

//        using Timer timer = new Timer(async _ => await MakeHttpRequest(), null, TimeSpan.Zero, _interval);

//        Console.WriteLine("Press Enter to stop the application...");
//        Console.ReadLine();
//    }

//    private static async Task MakeHttpRequest()
//    {
//        try
//        {
//            Console.WriteLine($"[{DateTime.Now}] Sending request to {_url}...");

//            // Send the HTTP GET request
//            var response = await _httpClient.GetAsync(_url);

//            // Log the response status
//            Console.WriteLine($"[{DateTime.Now}] Response: {(int)response.StatusCode} {response.ReasonPhrase}");
//        }
//        catch (Exception ex)
//        {
//            // Log any exceptions
//            Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
//        }
//    }
//}

//-------------------------------------------------
//-------------------------------------------------
//using System;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    private static readonly HttpClient _httpClient = new HttpClient();
//    private static readonly string _url = "http://example.com"; // Replace with your IP or URL
//    private static readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Starting HTTP Request Tester with Metrics...");
//        Console.WriteLine($"Target URL: {_url}");
//        Console.WriteLine($"Interval: {_interval.TotalMinutes} minute(s)");

//        using Timer timer = new Timer(async _ => await MakeHttpRequest(), null, TimeSpan.Zero, _interval);

//        Console.WriteLine("Press Enter to stop the application...");
//        Console.ReadLine();
//    }

//    private static async Task MakeHttpRequest()
//    {
//        try
//        {
//            Console.WriteLine($"[{DateTime.Now}] Sending request to {_url}...");

//            // Measure latency and response time
//            var stopwatch = Stopwatch.StartNew();

//            // Measure connection latency
//            var latencyWatch = Stopwatch.StartNew();
//            using var request = new HttpRequestMessage(HttpMethod.Get, _url);
//            var connectionResponse = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
//            latencyWatch.Stop();

//            // Measure full response time
//            var response = await connectionResponse.Content.ReadAsStringAsync();
//            stopwatch.Stop();

//            // Capture metrics
//            var latency = latencyWatch.ElapsedMilliseconds; // Time to establish connection
//            var responseTime = stopwatch.ElapsedMilliseconds; // Total time to receive response
//            var statusCode = (int)connectionResponse.StatusCode; // HTTP status code
//            var contentLength = response.Length; // Response content length in bytes

//            // Display metrics
//            Console.WriteLine($"[{DateTime.Now}] Metrics:");
//            Console.WriteLine($"  - Status Code: {statusCode}");
//            Console.WriteLine($"  - Latency: {latency} ms");
//            Console.WriteLine($"  - Response Time: {responseTime} ms");
//            Console.WriteLine($"  - Content Length: {contentLength} bytes");
//        }
//        catch (Exception ex)
//        {
//            // Log any exceptions
//            Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
//        }
//    }
//}


using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private static readonly string _url = "https://www.notion.com/"; // Replace with your IP or URL
    private static readonly TimeSpan _interval = TimeSpan.FromSeconds(3);
    private static Timer _timer;

    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting HTTP Request Tester with Metrics...");
        Console.WriteLine($"Target URL: {_url}");
        Console.WriteLine($"Interval: {_interval.TotalMinutes} minute(s)");

        // Start the timer
        _timer = new Timer(async _ => await MakeHttpRequest(), null, TimeSpan.Zero, _interval);

        Console.WriteLine("Press Enter to stop the application...");
        Console.ReadLine();

        // Dispose of the timer and HttpClient on exit
        _timer?.Dispose();
        _httpClient?.Dispose();
    }

    private static async Task MakeHttpRequest()
    {
        try
        {
            Console.WriteLine($"[{DateTime.Now}] Sending request to {_url}...");

            // Measure latency and response time
            var stopwatch = Stopwatch.StartNew();

            // Measure connection latency
            var latencyWatch = Stopwatch.StartNew();
            using var request = new HttpRequestMessage(HttpMethod.Get, _url);
            var connectionResponse = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            latencyWatch.Stop();

            // Measure full response time
            var response = await connectionResponse.Content.ReadAsStringAsync();
            stopwatch.Stop();

            // Capture metrics
            var latency = latencyWatch.ElapsedMilliseconds; // Time to establish connection
            var responseTime = stopwatch.ElapsedMilliseconds; // Total time to receive response
            var statusCode = (int)connectionResponse.StatusCode; // HTTP status code
            var contentLength = response.Length; // Response content length in bytes

            // Display metrics
            Console.WriteLine($"[{DateTime.Now}] Metrics:");
            Console.WriteLine($"  - Status Code: {statusCode}");
            Console.WriteLine($"  - Latency: {latency} ms");
            Console.WriteLine($"  - Response Time: {responseTime} ms");
            Console.WriteLine($"  - Content Length: {contentLength} bytes");
        }
        catch (Exception ex)
        {
            // Log any exceptions and ensure they don't stop the timer
            Console.WriteLine($"[{DateTime.Now}] Error: {ex.Message}");
        }
    }
}
