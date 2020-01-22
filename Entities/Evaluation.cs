using System;

namespace CoreSchool.Entities
{
    public class Evaluation
    {
        public string Id { get; private set; }
        
        public string Name { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public double Grade { get; set; }
        
        public Evaluation() => Id = Guid.NewGuid().ToString();
    }
}