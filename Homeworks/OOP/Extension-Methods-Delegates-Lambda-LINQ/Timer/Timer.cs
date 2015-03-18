//Problem 7. Timer

//Using delegates write a class Timer that can execute certain method at each t seconds.
namespace Timer
{
    using System;
    using System.Diagnostics;

    public delegate void TimeInterval(long param);
    public class Timer
    {
        static void Main(string[] args)
        {
            var stop = new Stopwatch();
            stop.Start();
            var printStop = new Stopwatch();
            printStop.Start();

            TimeInterval d = new TimeInterval(TestTimer);// delegate 

            while (true)
            {
                if (stop.ElapsedMilliseconds == 250)
                {
                    d(printStop.ElapsedMilliseconds);
                    stop.Restart();
                }
            }
        }
        public static void TestTimer(long param)
        {

            Console.WriteLine("Passed: {0}seconds | {1} miliseconds ",param / 1000, param);
        }
    }
}
