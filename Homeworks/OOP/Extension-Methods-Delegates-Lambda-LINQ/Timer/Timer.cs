namespace Timer
{
    using System;
    using System.Threading;

    public delegate void TimerExe();

    public class Timer
    {
        private int interval;              

        public Timer(int seconds)
        {
            this.Interval = seconds;
        }

        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (value < 1) { throw new ArgumentException("Interval can not be less than 1 second"); }
                this.interval = value;
            }
        }

        public TimerExe ExecuteMethods { get; set; }

        public void Run()
        {
            while (true)
            {
                this.ExecuteMethods();
                Thread.Sleep(this.Interval * 1000); // because Thread works woth miliseconds
            }
        }
    }
}
