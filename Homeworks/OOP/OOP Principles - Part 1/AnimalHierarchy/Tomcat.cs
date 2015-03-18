namespace AnimalHierarchy
{
    public class Tomcat : Cat
    {
        private SexEnum sex;

        public Tomcat()
        {
            this.Sex = SexEnum.Male;
        }

        public Tomcat(int age) : this()
        {
            this.Age = age;           
        }

        public Tomcat(string name, int age)
            : this(age)
        {
            this.Name = name;
        }      

        public SexEnum Sex
        {
            get { return this.sex; }
            private set { this.sex = SexEnum.Male; }
        }
    }
}
