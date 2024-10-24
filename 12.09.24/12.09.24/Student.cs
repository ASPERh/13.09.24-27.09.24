using System;
using System.Collections.Generic;

namespace HW.Student;

class Student : ICloneable
{
    internal string name;
    internal string surname;
    internal string papaname;
    internal string adress;
    internal long number;
    internal static Random random = new Random();
    internal DateTime birthday;
    internal List<int> homeworks = new List<int>();
    internal List<int> courseWorks = new List<int>();
    public List<int> exams = new List<int>();

    public List<int> GetExams()
    {
        return exams;
    }

    public void GenericHomeworks()
    {
        for (int i = 0; i <= 12; i++)
        {
            int randomHomework = random.Next(1, 13);
            homeworks.Add(randomHomework);
        }
    }

    public void GenericCoursWorks()
    {
        for (int i = 0; i <= 3; i++)
        {
            int randomCoursWork = random.Next(1, 13);
            courseWorks.Add(randomCoursWork);
        }
    }

    public void GenericExams()
    {
        for (int i = 0; i <= 1; i++)
        {
            int randomExams = random.Next(1, 13);
            exams.Add(randomExams);
        }
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }
    public void SetSurname(string surname)
    {
        this.surname = surname;
    }

    public string GetSurname()
    {
        return surname;
    }
    public void SetPapaname(string papaname)
    {
        this.papaname = papaname;
    }

    public string GetPapaname()
    {
        return papaname;
    }

    public void SetAdress(string adress)
    {
        this.adress = adress;
    }

    public string GetAdress()
    {
        return adress;
    }
    public void SetNumber(long number)
    {
        this.number = number;
    }

    public long GetNumber()
    {
        return number;
    }
    public DateTime GetDateTime()
    {
        return birthday;
    }

    public Student()
    {

    }

    public Student(string _name, string _surname, string _papaname, string _adress, long _number)
    {
        birthday = GenerateRandomDate(1980, 2015);
        SetName(_name);
        SetSurname(_surname);
        SetPapaname(_papaname);
        SetAdress(_adress);
        SetNumber(_number);
    }

    public Student(Student student)
    {
    }

    private DateTime GenerateRandomDate(int startYear, int endYear)
    {
        int year = random.Next(startYear, endYear + 1);
        int month = random.Next(1, 13);
        int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
        return new DateTime(year, month, day);
    }

    public static bool operator true(Student student)
    {
        foreach (int mark in student.exams)
        {
            if (mark >= 6)
            {
                return true;
            }
        }
        return false;
    }


    public static bool operator false(Student student)
    {
        foreach (int mark in student.exams)
        {
            if (mark >= 6)
            {
                return false;
            }
        }
        return true;
    }

    public static bool operator ==(Student a, Student b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

        return a.surname == b.surname && a.name == b.name;
    }

    public static bool operator !=(Student a, Student b)
    {
        return !(a == b);
    }


    public double GetAverageMark()
    {
        double totalCount = ((GetExams().Sum() / 2) + (homeworks.Sum() / 13) + (courseWorks.Sum() / 4)) / 3;

        return totalCount;
    }


    public static bool operator >(Student a, Student b)
    {

        return a.GetAverageMark() > b.GetAverageMark();
    }

    public static bool operator <(Student a, Student b)
    {
        return a.GetAverageMark() < b.GetAverageMark();
    }
    public class CompareByName : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return string.Compare(x.name, y.name);
        }
    }
    public class CompareByAverageScore : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            double averageX = (x.exams.Sum() + x.homeworks.Sum() + x.courseWorks.Sum()) / (x.exams.Count + x.homeworks.Count + x.courseWorks.Count);
            double averageY = (y.exams.Sum() + y.homeworks.Sum() + y.courseWorks.Sum()) / (y.exams.Count + y.homeworks.Count + y.courseWorks.Count);
            return averageX.CompareTo(averageY);
        }
    }


    public object Clone()
    {
        return new Student(this.name, this.surname, this.papaname, this.adress, this.number)
        {
            homeworks = new List<int>(this.homeworks),
            courseWorks = new List<int>(this.courseWorks),
            exams = new List<int>(this.exams)
        };
    }
}
