using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            HROfficer hROfficer = new HROfficer("Илья", "Иванов", "Петрович", "Заведующий по кадровому отделу");
            Sudent sudent1 = hROfficer.MakeSudent("Максим","Арчил","Гомиашвили", "13-В3");
            Sudent sudent2 = hROfficer.MakeSudent("Нет", "НЕТ", "ИИИ НЕТ!", "13-В3");
            sudent1.GetGroup();
            Group group = hROfficer.MakeGroup();
            group.SetName("14-B3");
            group.Add(sudent1);
            group.Add(sudent2);
            group.CountGroup();
            sudent2.Deduction(hROfficer);
            group.CountGroup();
        }
    }

    public interface Sudents
    {
        public string GetGroup();
        public void Deduction(HROfficer hr);
    }
    public interface Teachers
    {
        public void GetPost();
    }

    public class FIO
    {
        public string surname;
        public string name;
        public string middleName;
        public FIO(string surname, string name, string middleName)
        {
            this.surname = surname;
            this.name = name;
            this.middleName = middleName;
        }
    }
    public abstract class GenInf1
    {
        protected FIO fio;
    }

    public class Sudent : GenInf1, Sudents
    {
        public bool valid;
        public Group group;
        public Sudent(string surname, string name, string middleName, string group)
        {
            this.fio = new FIO(surname, name, middleName);
            this.group = new Group();
            this.group.name = group;

            this.valid = true;
        }
        public string GetGroup()
        {
            Console.WriteLine(this.group.name);
            return (this.group.name);
        }
        public void Deduction(HROfficer hr)
        {
            this.valid = false;
            hr.AppDataGroup(this.group,this);
        }
        public string GetFIO()
        {
            return(this.fio.name + " " + this.fio.middleName + " " + this.fio.surname);
        }
    }

    public abstract class GenInf2 : GenInf1 , Teachers
    {
        protected string post;
        public void GetPost()
        {
            Console.WriteLine(this.post);
        }
    }

    public class Teacher : GenInf2
    {
        public Teacher(string surname, string name, string middleName, string post)
        {
            this.fio = new FIO(surname, name, middleName);
            this.post = post;
        }
        public void ReadLecture(Group group)
        {
            if (group.lecture != 0) group.lecture--;
        }
    }
    public class HROfficer : GenInf2
    {
        public HROfficer(string surname, string name, string middleName, string post)
        {
            this.fio = new FIO(surname, name, middleName);
            this.post = post;
        }
        public Teacher MakeTeacher(string surname, string name, string middleName, string post)
        {
            return(new Teacher(surname, name, middleName, post));
        }
        public Sudent MakeSudent(string surname, string name, string middleName, string group)
        {
            return (new Sudent(surname, name, middleName, group));
        }
        public void AppDataGroup(Group group, Sudent sudent)
        {
            if (sudent.group == group) group.Remove();
        }
        public Group MakeGroup()
        {
            return(new Group());
        }
    }
    public class Group
    {
        private Teacher teacher;
        public string name;
        public int lecture;


        private List<Sudent> group = new List<Sudent>();
        public void Remove()
        {
            try
            {
                foreach (Sudent sudent2 in group)
                {
                    if (sudent2.valid == false)
                    {
                        sudent2.group = null;
                        group.Remove(sudent2);
                    }
                }
            }
            catch
            {
                foreach (Sudent sudent2 in group)
                {
                    if (sudent2.valid == false)
                    {
                        sudent2.group = null;
                        group.Remove(sudent2);
                    }
                }
            }
        }
        public void SetTeacher(Teacher teacher)
        {
            this.teacher = teacher;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void Add(Sudent sudent)
        {
            group.Add(sudent);
            sudent.group = this;
        }
        public void CountGroup()
        {
            foreach (Sudent sudent in group) Console.WriteLine(sudent.GetFIO() + " " + sudent.GetGroup());
        }
    }
}
