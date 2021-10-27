using System;
using System.Collections.Generic;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonnelOfficer personnelOfficer = new PersonnelOfficer();
            Student stud1 = personnelOfficer.MakeStudent("Илья", "Васильевич", "Дробышевский");
            Student stud2 = personnelOfficer.MakeStudent();
            Student stud3 = personnelOfficer.MakeStudent();
            Teacher teacher = personnelOfficer.MakeTeacher("Илья1", "Васильевич1", "Дробышевский1");

            Group group = personnelOfficer.MakeGroup();
            group.SetTeacher(teacher);
            teacher.Lecture = 23;
            teacher.Lectured();
            group.NameGroup = "1-2П9";
            group.AddStudent(stud1);
            group.AddStudent(stud2);
            group.AddStudent(stud3);

            Console.WriteLine(stud1.GetAllFIO());
            Console.WriteLine(stud2.GetGroup());
            Console.WriteLine(group.GetNumber());
            stud1.Deducted();
            Console.WriteLine(group.GetNumber());
            Console.WriteLine(teacher.Lecture);
            Console.WriteLine(teacher.GetAllFIO());

            teacher.Post = "Математик";
            teacher.Post = "Физик";
            Console.WriteLine(teacher.Post);
        }
    }
    public class Group
    {
        private string namegroup;
        private Teacher teacher;
        private List<Student> students = new List<Student>();

        public void SetTeacher(Teacher teacher)
        {
            teacher.SetGroup(this);
            this.teacher = teacher;
        }
        public void AddStudent(Student student)
        {
            this.students.Add(student);
            student.group = this;
        }

        public string NameGroup
        {
            get
            {
                return (namegroup);
            }
            set
            {
                this.namegroup = value;
                foreach (Student student in students) student.group = this;
            }
        }
        public int GetNumber()
        {
            return (this.students.Count);
        }
        public void UpData()
        {
            try
            {
                foreach (Student student in students)
                {
                    if (student.studies == false) students.Remove(student);
                }
            }
            catch { }
        }
        public List<Student> GroupList()
        {
            return (this.students);
        }
    }

    public abstract class Human
    {
        private string name;
        private string middlename;
        private string surname;

        public Human(string name = null, string middlename = null, string surname = null)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
        }
        public string GetAllFIO()
        {
            string[] fio = new string[] {this.middlename, this.surname};
            string allfio = name;
            foreach(string i in fio)
            {
                if (i != null)
                {
                    allfio = allfio+" "+ i;
                }
            }
            return (allfio);
        }
    }
    public abstract class Worker : Human
    {
        public Worker(string name = null, string middlename = null, string surname = null) : base(name, middlename, surname) { }
        private string post;

        public string Post
        {
            get
            {
                return (post);
            }
            set
            {
                if (this.post == null) this.post = value;
            }
        }
    }

    public class PersonnelOfficer : Worker
    {
        public void AddStudent(Group group, Student student)
        {
            group.AddStudent(student);
        }
        public Student MakeStudent(string name = null, string middlename = null, string surname = null)
        {
            return (new Student(name, middlename, surname));
        }
        public Teacher MakeTeacher(string name = null, string middlename = null, string surname = null)
        {
            return (new Teacher(name, middlename, surname));
        }
        public Group MakeGroup()
        {
            return(new Group());
        }
    }

    public class Teacher : Worker
    {
        public Teacher(string name = null, string middlename = null, string surname = null) : base (name, middlename, surname) { }
        private int lecture;
        private Group group = null;
        public int Lecture
        {
            set
            {
                if(group != null) this.lecture = value;
            }
            get
            {
                return (this.lecture);
            }
        }
        public void Lectured()
        {
            this.lecture--;
        }
        public void SetGroup(Group group)
        {
            this.group = group;
        }
    }
    public class Student : Human
    {
        public Student(string name = null, string middlename = null, string surname = null) : base(name, middlename, surname) { }
        public Group group;
        public bool studies = true;

        public string GetGroup()
        {
            return (this.group.NameGroup);
        }
        public void Deducted()
        {
            this.studies = false;
            group.UpData();
        }
    }
}
