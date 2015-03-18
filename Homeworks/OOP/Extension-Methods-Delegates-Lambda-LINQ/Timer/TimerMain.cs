//Problem 7. Timer

//Using delegates write a class Timer that can execute certain method at each t seconds.
namespace Timer
{
    using System;
    using System.Diagnostics;

    public class TimerMain
    {
        private static Stopwatch stop = new Stopwatch();
        static void Main(string[] args)
        {
            stop.Start();
            var timer = new Timer(4);
            timer.ExecuteMethods = TestTimer;
            timer.Run();
        }

        public static void TestTimer()
        {
            Console.WriteLine("Passed: {0,-3} seconds ", stop.ElapsedMilliseconds / 1000);
        }
    }
}
