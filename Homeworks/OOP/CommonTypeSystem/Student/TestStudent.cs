namespace StudentClass
{
    using System;
    public class TestStudent
    {
        static void Main()
        {
            var stamat = new Student("Stamat", "Georgiev", "Petrov", 8547123569, "Bourgas, Aylyak str. 11", "+359 889 555 555", "stamat@abv.bg");

            var pesho = new Student(
                "Pesho", "Ivanov", "Goshov", 345678345678,
                "Sofia kv.Knyazdevo", "+359 887 564 456", "pesho@gmail.com", 2,
                Student.UniversityName.Technical_University_of_Varna,
                Student.FacultyName.Marine_Sciences_and_Ecology,
                Student.SpecialtyName.IM);

            Console.WriteLine("TESTING .ToString():");
            Console.WriteLine(stamat.ToString());
            Console.WriteLine(pesho.ToString());
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", "stamat.GetHashCode()", stamat.GetHashCode());
            Console.WriteLine("{0} = {1}", "pesho.GetHashCode()", pesho.GetHashCode());

            Console.WriteLine();
            Console.WriteLine("stamat.Equals(pesho) = {0}", stamat.Equals(pesho));
            Console.WriteLine("pesho.Equals(pesho) = {0}", pesho.Equals(pesho));

            Console.WriteLine();
            Console.WriteLine("stamat == pesho  : {0}", stamat == pesho);
            Console.WriteLine("stamat != pesho  : {0}", stamat != pesho);
            Console.WriteLine("pesho == pesho  : {0}", pesho == pesho);
            Console.WriteLine(Environment.NewLine + "Press ENTER to test the ICloneable and IComparable<Student> implementation." + Environment.NewLine);
            Console.Read();
            Console.Clear();
            Console.WriteLine(pesho.ToString());
            var peshoClone = pesho.Clone();
            Console.WriteLine(peshoClone.ToString());
            Console.WriteLine();
            Console.WriteLine("{0} = {1}", "pesho.GetHashCode()", pesho.GetHashCode());
            Console.WriteLine("{0} = {1}", "peshoClone.GetHashCode()", peshoClone.GetHashCode());
                        
            Console.WriteLine(Environment.NewLine+"pesho.CompareTo(stamat) = {0}", pesho.CompareTo(stamat));
            Console.WriteLine( "pesho.CompareTo(pesho) = {0}", pesho.CompareTo(pesho));
            
        }
    }
}
