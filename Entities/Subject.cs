using System;

namespace CoreSchool.Entities
{
    public class Subject
    {
        public string Id { get; private set; }
        
        public string Name { get; set; }

        public Subject() => Id = Guid.NewGuid().ToString();
    }
}