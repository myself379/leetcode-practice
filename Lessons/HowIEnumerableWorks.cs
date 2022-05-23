using System;
using System.Collections;
using System.Collections.Generic;

namespace leetcode.Lessons;

public class HowIEnumerableWorks
{
    public HowIEnumerableWorks()
    {
        Console.WriteLine(GetType().Name + "\n");

        Console.WriteLine("Foreach loop: \n");
        this.Run();
        Console.WriteLine("\n");

        Console.WriteLine("Manual get: \n");
        this.ManualList();
        Console.WriteLine("\n");

        Console.WriteLine("While loop get: \n");
        this.WhileLoop();
        Console.WriteLine("\n");

        Console.WriteLine("Class implement IEnumerator: \n");
        StudentList studentList = new StudentList();

        foreach(Student s in studentList)
        {
            Console.WriteLine($"{s.Name} \t {s.Age}");
        }
        Console.WriteLine("\n");
    }

    public void Run()
    {
        var lstName = new List<string>();

        lstName.Add("John");
        lstName.Add("Martin");
        lstName.Add("Tom");


        foreach(var name in lstName)
        {
            Console.WriteLine(name);
        }
    }

    public void ManualList()
    {
        var lstName = new List<string>();

        lstName.Add("John");
        lstName.Add("Martin");
        lstName.Add("Tom");

        // Note that using var, c# will return IEnumerator<T> without Reset() implementation
        // var numerator = lstName.GetEnumerator();
        IEnumerator numerator = lstName.GetEnumerator();

        Console.WriteLine("Invoke MoveNext(), result: " + numerator.MoveNext());
        Console.WriteLine(numerator.Current);
        Console.WriteLine("Invoke MoveNext(), result: " + numerator.MoveNext());
        Console.WriteLine(numerator.Current);
        Console.WriteLine("Invoke MoveNext(), result: " + numerator.MoveNext());
        Console.WriteLine(numerator.Current);

        Console.WriteLine("This will return false: " + numerator.MoveNext());

        numerator.Reset();
        Console.WriteLine("Invoke MoveNext(), result: " + numerator.MoveNext());
        Console.WriteLine(numerator.Current);
    }

    public void WhileLoop()
    {
        var lstName = new List<string>();

        lstName.Add("John");
        lstName.Add("Martin");
        lstName.Add("Tom");

        var enumerator = lstName.GetEnumerator();
        while(enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class StudentList : IEnumerable, IEnumerator
    {
        private Student[] _studentList;

        public StudentList()
        {
            _studentList = new Student[6]
            {
                new Student("John",15),
                new Student("Wiliam",24),
                new Student("Chris",17),
                new Student("Mark",16),
                new Student("Steve",15),
                new Student("Sam",19),
            };
        }

        private int _position = -1;
        public object Current
        {
            get { return _studentList[_position]; }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _studentList.Length);
        }

        public void Reset()
        {
            _position = 0;
        }
    }
}
