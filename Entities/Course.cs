using System;
using System.Collections.Generic;
using CoreSchool.Utilities;

namespace CoreSchool.Entities
{
    public class Course: BaseSchoolObject, IPlace
    {
        public TurnTypes Turn { get; set; }
        
        public List<Subject> Subjects { get; set; }
        
        public List<Student> Students { get; set; }
        
        public string Address { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
        public void CleanAddress()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning place ... ");
            Console.WriteLine($"Course: {Name} has been cleaned");
        }
    }
}