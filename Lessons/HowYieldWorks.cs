using System;
using System.Collections.Generic;

namespace leetcode.Lessons
{
    public class HowYieldWorks
    {
        public HowYieldWorks()
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("Start of Yield demo");
            Console.WriteLine("\n");

            var people = DataAccess.GetPeople();

            foreach(var p in people)
            {
                Console.WriteLine($"Read {p.FirstName} {p.LastName}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("End of Yield demo");
        }
    }

    // Simulate database
    public class DataAccess
    {
        public static IEnumerable<PersonModel> GetPeople()
        {
            List<PersonModel> output = new();

            output.Add(new PersonModel("Tim", "Corney"));
            output.Add(new PersonModel("Sue", "Storm"));
            output.Add(new PersonModel("Jane", "Smith"));

            return output;
        }
    }

    // Simulate DTO model
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Console.WriteLine($"Initialized user { FirstName } { LastName }");
        }
    }
}
