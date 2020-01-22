using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class School
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        
        public int FundationYear { get; set; }
        
        public string Country { get; set; }
        
        public string City { get; set; }

        public SchoolTypes SchoolTypes { get; set; }

        public List<Course> Courses { get; set; }

        public School() => this.Id = Guid.NewGuid().ToString();
        
        public School(string name, int fundationYear) => (this.Name, this.FundationYear) = (name, fundationYear);
        
        

        public School(string name, int fundationYear, SchoolTypes schoolTypes, string country = "", string city = "") =>
            (this.Name, this.FundationYear, this.SchoolTypes, this.Country, this.City) =
            (name, fundationYear, schoolTypes, country, city);

        public override string ToString()
        {
            return
                $"Name: {Name}, Type: {SchoolTypes}, Fundation year: {FundationYear} \n Country: {Country}, City: {City}";
        }
    }
}