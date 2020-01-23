using System;

namespace CoreSchool.Entities
{
    public abstract class BaseSchoolObject
    {
        public string Id { get; private set; }
        
        public string Name { get; set; }

        protected BaseSchoolObject() => Id = Guid.NewGuid().ToString();

        public override string ToString()
        {
            return $"{Name},{Id}";
        }
    }
    
}