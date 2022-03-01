using System.Diagnostics;

namespace AoC2020
{
    public class PerformanceMonitoring
    {
        private static Stopwatch? _stopwatch;

        public static void StartStopwatch()
        {
            _stopwatch = new();
            _stopwatch.Start();
        }

        public static void StopStopwatch()
        {
            _stopwatch?.Stop();
            Console.WriteLine($"\t Elapsed time: {_stopwatch?.ElapsedMilliseconds}ms");
        }
    }
}
