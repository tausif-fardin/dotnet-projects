using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LINQ
{
    internal class Program
    {
        static void PrintArray(List<Student> students)
        {
            foreach(var s in students)
            {
                s.Show();
            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 10, 21, 33, 44, 55, 66, 75, 86, 97, 102 };
           
            foreach(int i in arr)
            {
                if (i > 20)
                {
                    Console.WriteLine(i);
                }
            }
            //Using LINQ
            var filtered = from i in arr where i > 20 select i; //will return a ienumerable interface object
            var filtered1 = (from i in arr where i > 20 select i).ToArray(); //will return a ienumerable interface object as an array

            List<Student> students = new List<Student>();
            Random rand = new Random();
            for(int i = 0; i < 150; i++)
            {
                Student s= new Student();
                s.Name = "Student" +(i+1);
                s.Id = (i + 1);
                s.Cgpa = rand.NextDouble() * (4.00 - 2.00) + 2.00;
                students.Add(s);
            }
            //PrintArray(students);

            var filteredStudent = (from s in students 
                                   where s.Cgpa>=3.75 &&
                                   s.Id>=1 && s.Id<=100
                                   select s).ToList();
            PrintArray(filteredStudent);
        }
    }
}
