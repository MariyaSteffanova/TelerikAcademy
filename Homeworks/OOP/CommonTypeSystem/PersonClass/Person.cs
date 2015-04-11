namespace PersonClass
{
    using System;
    using System.Text;
    public class Person
    {
        private string name;
        private int? age;
        public Person(string initialName)
        {
            this.Name = initialName;
        }
        public Person(string initialName, int initialAge)
            :this(initialName)
        {
            this.Age = initialAge;
        }

        public string Name
        {
            get
            {
                return this.name;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be null or empty!");
                this.name = value;
            }
        }
        public int? Age 
        {
            get 
            {
                return this.age ; 
            }

            set
            {
                if (value > 120)
                    throw new ArgumentException(string.Format("I truely belive {0} is not {1} years old! Person cannot be older than 120 years (except some tibetian lamas)",this.Name, value));
                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Name: {0} |", this.Name);
            sb.AppendFormat("Age: {0}", this.Age == null ? "Age is not specified" : this.Age.ToString());
            return sb.ToString();
        }
    }
}
