namespace AnimalHierarchy
{
    using System;

    public class Animal : ISound
    {
        private string name;
        private int age;
        private SexEnum sex;

        public Animal()
        { 
        }

        public Animal(int age)
        {
            this.Age = age;
        }

        public Animal(string name, int age, SexEnum sex) : this(age)
        {
            this.Name = name;           
            this.Sex = sex;
        }

        public enum SexEnum 
        {
            Male, Female
        }

        public SexEnum Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }
        
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual void Talk()
        {
            Console.WriteLine("I'm an animal, I'm a little animal and I don't know what to saaaayyyy.. ooo-oh");
        }              
    }
}
