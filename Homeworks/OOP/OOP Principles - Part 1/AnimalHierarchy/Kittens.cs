namespace AnimalHierarchy
{
    public class Kittens : Cat
    {
        private SexEnum sex;

        public Kittens()
        {
            this.Sex = SexEnum.Female;
        }
        public Kittens(int age)
            : this()
        {
            this.Age = age;
        }
        public Kittens(string name, int age)
            : this(age)
        {
            this.Name = name;
        }

        public SexEnum Sex
        {
            get { return this.sex; }
            protected set { this.sex = SexEnum.Female; }
        }

    }
}
