namespace People
{
    using System;

    public class Person
    {
        public Person()
        {
        }

        public Person(string name, int age, Gender gender)
            : this()
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public Person GeneratePerson(int age)
        {
            Person person = new Person();
            person.Age = age;
            int remainderOfAge = age % 2;

            person.Name = ((Name)remainderOfAge).ToString();
            person.Gender = (Gender)remainderOfAge;

            return person;
        }
    }
}
