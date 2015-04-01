using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDataTransformations
{
    //Set up properties for students and teachers
    class Student
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public List<int> Scores;
    }

    class Teacher
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main()
        {
            //Create the first data source
            List<Student> students = new List<Student>()
            {
                new Student 
                {
                    ID=1,
                    First="Sylvia",
                    Last="Spear",                    
                    Street="111 Main Street",
                    City = "Neenah",
                    Scores = new List<int> {100,99,98,97}
                },
                new Student 
                {
                    ID=2,
                    First="Calvin",
                    Last = "Spear",
                    Street = "222 Elm Street",
                    City="Appleton",
                    Scores = new List<int> {100,99,98,97}
                },
                new Student
                {
                    ID=3,
                    First = "Holden",
                    Last = "Floyd",
                    Street = "333 Lyndale Ave.",
                    City="St. Louis Park",
                    Scores = new List<int>{54,67,78,89}
                },
            };

            //Create the second data source
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher 
                {
                    ID = 1,
                    First = "Nicolette",
                    Last = "Spear",
                    City="Neenah"
                },
                new Teacher
                {
                    ID = 2,
                    First = "Heather",
                    Last = "Floyd",
                    City = "St. Louis Park"
                },
            };

            //Create the query
            var peopleInNeenah = (
                from student in students
                where student.City == "Neenah"
                select student.First)
                .Concat(from teacher in teachers
                        where teacher.City == "Neenah"
                        select teacher.First);

            Console.WriteLine("The following students and teachers live in Neenah:");

            //Execute the query
            foreach (var person in peopleInNeenah)
            {
                Console.WriteLine(person);
            }
            Console.Read();

        }
    }
}

