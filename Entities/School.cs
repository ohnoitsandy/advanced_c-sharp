using System;
using System.Collections.Generic;
using CoreSchool.Utilities;

namespace CoreSchool.Entities
{
    public class School: BaseSchoolObject, IPlace
    {
        private int FoundationYear { get; set; }

        private string Country { get; set; }

        private string City { get; set; }
        
        public string Address { get; set; }

        private SchoolTypes SchoolTypes { get; set; }

        public List<Course> Courses { get; set; }
        
        public School(string name, int foundationYear) => (this.Name, this.FoundationYear) = (name, foundationYear);
        
        

        public School(string name, int foundationYear, SchoolTypes schoolTypes, string country = "", string city = "") =>
            (this.Name, this.FoundationYear, this.SchoolTypes, this.Country, this.City) =
            (name, foundationYear, schoolTypes, country, city);

        public override string ToString()
        {
            return
                $"Name: {Name}, Type: {SchoolTypes}, Foundation year: {FoundationYear} \n Country: {Country}, City: {City}";
        }

        public void CleanAddress()
        {
            Printer.DrawLine();
            Console.WriteLine("Cleaning place ... ");
            foreach (var course in Courses)
            {
                course.CleanAddress();
            }
            Console.WriteLine($"{Name} has been cleaned");
        }

    }
}