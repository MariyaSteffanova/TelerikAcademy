namespace StudentsAndWorkers
{
    using System.Text;

    public class Human
    {
        private string firstName;
        private string lastName;

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0,-20}", this.firstName + " " + this.LastName));

            return sb.ToString();
        }
    }
}
