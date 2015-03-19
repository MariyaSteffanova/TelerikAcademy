namespace RangeExceptions
{
    using System;
    public class InvalidRangeException<T> : ApplicationException
    {
        private const int startRangeInt = 1;
        private const int endRangeInt = 100;
        private readonly DateTime startRangeDate = DateTime.Parse("1.1.1980");
        private readonly DateTime endRangeDate = DateTime.Parse("31.12.2013");

        private string message;

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }


        public InvalidRangeException(T param)
        {
            if (param.GetType() == typeof(Int32))
                this.Message = string.Format("The range should be between [{0}..{1}]", startRangeInt, endRangeInt);
            if (param.GetType() == typeof(DateTime))
                this.Message = string.Format("The range should be between [{0:dd.MM.yyyy}..{1:dd.MM.yyyy}]", startRangeDate, endRangeDate);
        }
    }
}
