using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CoreSchool.Entities;
using CoreSchool.Utilities;

namespace CoreSchool
{
    public sealed class SchoolEngine
    {
        public School School { get; set; }

        public SchoolEngine()
        {

        }

        public void Initialize()
        {
            School = new School("LIFE HOMIE", 2020, SchoolTypes.HighSchool, "Santa catarina", "Babilonia");

            LoadCourses();
            LoadSubjects();
            LoadEvaluations();
        }

        public void PrintDictionary(Dictionary<DictionaryKey,
            IEnumerable<BaseSchoolObject>> dictionary, bool printEvaluations = true)
        {
            foreach (var dictionaryObject  in dictionary)
            {
                Console.WriteLine(dictionaryObject);
                
                foreach (var val in dictionaryObject.Value)
                {
                    switch (dictionaryObject.Key)
                    {
                        case DictionaryKey.Evaluation:
                            if (printEvaluations)
                                Console.WriteLine(val);
                            break;
                        case DictionaryKey.School:
                            if (val is School)
                                Console.WriteLine("School: " + val);
                            break;
                        case DictionaryKey.Student:
                            if (val is Student)
                                Console.WriteLine("Student: " + val);
                            break;
                        case DictionaryKey.Course:
                            var temp = val as Course;
                            if (temp != null)
                            {
                                var studentsCount = temp.Students.Count;
                                Console.WriteLine("Course: " + val.Name + " Amount of students: " + studentsCount); 
                            }
                            break;
                        case DictionaryKey.Subject:
                            break;
                        default:
                            Console.WriteLine(val);
                            break;
                    }
                }
            }
        }

        //THIS IS A NEW DICTIONARY, ITS SAVES BSC(BASE SCHOOL OBJECTS) WITH A IDENTIFIER
        public Dictionary<DictionaryKey, IEnumerable<BaseSchoolObject>> GetObjectDictionary()
        {
            var dictionary = new Dictionary<DictionaryKey, IEnumerable <BaseSchoolObject>>();
            
            dictionary.Add(DictionaryKey.School, new[] {School});
            // A NEW ARRAY MADE OUT OF A SINGLE SCHOOL IS STORED IN THE "SCHOOL" INDEX 
            dictionary.Add(DictionaryKey.Course, School.Courses.Cast<BaseSchoolObject>());
            dictionary[DictionaryKey.Course] = School.Courses.Cast<BaseSchoolObject>();
            
            /*THIS SECTION GOES TROUGH THE COURSES THAT ARE IN EACH SCHOOL
              AND ADDS THE SUBJECTS AND STUDENTS OF EACH TO THE DICTIONARY 
              PLUS ALL THE EVALUATIONS OF EACH STUDENT*/
            var temporaryListOfEvaluations = new List<Evaluation>();
            var temporaryListOfStudents = new List<Student>();
            var temporaryListOfSubjects = new List<Subject>();
            foreach (var course in School.Courses)
            {
                
                temporaryListOfStudents.AddRange(course.Students);
                temporaryListOfSubjects.AddRange(course.Subjects);
                
                foreach (var student in course.Students)
                {
                    temporaryListOfEvaluations.AddRange(student.Evaluations);
                }
                
            }
            dictionary.Add(DictionaryKey.Subject, temporaryListOfSubjects.Cast<BaseSchoolObject>());
            dictionary.Add(DictionaryKey.Student, temporaryListOfStudents.Cast<BaseSchoolObject>());
            dictionary.Add(DictionaryKey.Evaluation, temporaryListOfEvaluations.Cast<BaseSchoolObject>());
            return dictionary;
        }

        private static List<Student> GenerateStudents(int limit)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] secondName1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listOfStudents = from n1 in name1
                from n2 in name2
                from sn in secondName1
                select new Student {Name = $"{n1} {n2} {secondName1}"};

            return listOfStudents.OrderBy((student) => student.Id).Take(limit).ToList();

        }

        //LINES OF CODE HAVE BEEN REDUCED TROUGH POLYMORPHISM

        //OVERRIDE METHODS
        public IReadOnlyCollection <BaseSchoolObject> GetBaseSchoolObjects(
            bool bringEvaluations = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
        )
        {
            return GetBaseSchoolObjects(out var dummy);
        }
        
        public IReadOnlyCollection <BaseSchoolObject> GetBaseSchoolObjects(
            out int evaluationCount,
            bool bringEvaluations = true,
            bool bringStudents = true,
            bool bringSubjects = true,
            bool bringCourses = true
            )
        {
            evaluationCount = 0;
            var objectList = new List<BaseSchoolObject>();
            objectList.Add(School);
            if (bringCourses == true)
            {
                objectList.AddRange(School.Courses);
            }
            foreach (var course in School.Courses)
            {
                if (bringSubjects == true)
                {
                    objectList.AddRange(course.Subjects);
                }

                if (bringStudents == true)
                {
                    objectList.AddRange(course.Students);
                }

                if (bringEvaluations == true)
                {
                    foreach (var student in course.Students)
                    {
                        objectList.AddRange(student.Evaluations);
                        evaluationCount += student.Evaluations.Count;
                    }
                }
            }
            return objectList.AsReadOnly();
        }

        #region LoadResources

        private void LoadCourses()
        {
            School.Courses = new List<Course>()
            {
                new Course() {Name = "Fuckallthat", Turn = TurnTypes.Morning},
                new Course() {Name = "Fuckallthat Advanced", Turn = TurnTypes.Afternoon},
                new Course() {Name = "Fuckallthat with love", Turn = TurnTypes.Night},
                new Course() {Name = "How to unfuckallthat", Turn = TurnTypes.Morning},
                new Course() {Name = "Learning how to live fuckingallthat", Turn = TurnTypes.Afternoon},
                new Course() {Name = "Making peace with fuckingallthat", Turn = TurnTypes.Night},
            };
            var random = new Random();
            foreach (var course in School.Courses)
            {
                var randomAmount = random.Next(5, 20);
                course.Students = GenerateStudents(randomAmount);
            }
        }
        
        private void LoadSubjects()
        {
            foreach (var course in School.Courses)
            {
                var listOfSubjects = new List<Subject>()
                {
                    new Subject{Name= "Matemáticas"} ,
                    new Subject{Name= "Educación Física"},
                    new Subject{Name= "Castellano"},
                    new Subject{Name= "Ciencias Naturales"}
                };
                course.Subjects = listOfSubjects;
            }
        }
        
        private void LoadEvaluations()
        {
            foreach (var course in School.Courses)
            {
                foreach (var subject in course.Subjects)
                {
                    foreach (var student in course.Students)
                    {
                        var randomGrade = new Random();
                        for (int i = 0; i < 5; i++)
                        {

                            var evaluation = new Evaluation()
                            {
                                Name = $"{subject.Name} EV:#{i + 1}",
                                Student = student,
                                Subject = subject,
                                Grade = MathF.Round((float)(5 * randomGrade.NextDouble()), 2)
                            };
                            student.Evaluations.Add(evaluation);
                        }
                    }
                }
            }
        }
        
        #endregion
    }
}
