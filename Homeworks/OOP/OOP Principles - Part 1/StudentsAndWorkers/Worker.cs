namespace StudentsAndWorkers
{
    using System.Text;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker()
        { 
        }

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour;
            moneyPerHour = this.WeekSalary / (this.WorkHoursPerDay * 7);
            return moneyPerHour;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("Name : {0,-20}", this.FirstName + " " + this.LastName));
            sb.Append(string.Format(" | Money per hour : {0:F2}", this.MoneyPerHour()));
            return sb.ToString();
        }
    }
}
