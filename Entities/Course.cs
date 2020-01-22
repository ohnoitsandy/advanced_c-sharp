using System;
using System.Collections.Generic;

namespace CoreSchool.Entities
{
    public class Course: BaseSchoolObject
    {
        public TurnTypes Turn { get; set; }
        
        public List<Subject> Subjects { get; set; }
        
        public List<Student> Students { get; set; }
        
        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}";
        }
    }
}