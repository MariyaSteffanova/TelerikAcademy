using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
   public class GenericList<T>
    {
        const int DefaultCapacity = 4;

        private T[] elements;

        private int count;
        

        public GenericList(int capacity)
        {
            elements = new T[capacity];
        }
        public GenericList()
            : this(DefaultCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }
        // Add
        public void Add(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                Rezise();
            }
            this.elements[count] = element;
            this.count++;
        }
        private void Rezise()
        {
            var resized = new T[this.Count * 2];
            for (int el = 0; el < this.Count; el++) // Array.Copy(elements, resized, this.Count)
            {
                resized[el] = this.elements[el];
            }
            this.elements = resized;
        }
        // accessing element by index
        public T GetElement(int index)
        {
            if (index < 0 || index >= this.Count || this.Count == 0)
                throw new IndexOutOfRangeException("The index is out of range!");
            T element = this.elements[index];
            return element;
            
        }

        // Remove element by index
        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count || this.Count == 0)
                throw new IndexOutOfRangeException("The index is out of range!");

            for (int currentInd = index; currentInd < this.elements.Length - 1; currentInd++) // to check for in -1, > L
            {
                this.elements[currentInd] = this.elements[currentInd + 1];
            }
            this.count--;
        }
        // Inserting element at given position
        public void Insert(T value, int index)
        {
            if (index >= this.elements.Length)
                this.Rezise();

            for (int currentInd = this.elements.Length - 1; currentInd > index; currentInd--)
            {
                this.elements[currentInd] = this.elements[currentInd - 1];
            }
            this.count++;
            this.elements[index] = value;

        }
        // Clearing the list
        public void Clear()
        {
            this.count = 0;
        }

        // Finding element by its value 
        public int IndexOf(T value)
        {
            int index = new int();
            for (int currentInd = 0; currentInd < this.elements.Length; currentInd++)
            {
                if (this.elements[currentInd].Equals(value))
                {
                    index = currentInd;
                    break;
                }
                else
                {
                    index = -1;
                }
            }
            return index;
        }
        public int LastIndexOf(T value)
        {

            int index = -1;
            for (int currentInd = 0; currentInd < this.elements.Length; currentInd++)
            {
                if (this.elements[currentInd].Equals(value))
                {
                    index = currentInd;
                }
            }
            return index;
        }
       // Min
        public static T Min<T>(T first, T second) 
             where T: IComparable<T>
        {
            if (first.CompareTo(second) <= 0)
                return first;
            else
                return second;           
        }
       // Max
        public static T Max<T>(T first, T second)
             where T : IComparable<T>
        {
            if (first.CompareTo(second) > 0)
                return first;
            else
                return second;
        }
        // ToString().
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int currentInd = 0; currentInd < this.Count; currentInd++)
            {
                sb.Append(this.elements[currentInd] + " ");
            }
            return sb.ToString();
        }
        public void Print()
        {
            for (int currentInd = 0; currentInd < this.Count; currentInd++)
            {
                Console.Write(this.elements[currentInd] + " ");
            }
            Console.WriteLine();
        }
    }
}
