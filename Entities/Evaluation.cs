using System;

namespace CoreSchool.Entities
{
    public class Evaluation: BaseSchoolObject
    {
        
        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public double Grade { get; set; }
        
    }
}