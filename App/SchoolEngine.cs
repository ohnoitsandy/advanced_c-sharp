using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreSchool.Entities;

namespace CoreSchool
{
    public class SchoolEngine
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
                                Grade = (float) (5 * randomGrade.NextDouble())
                            };
                            student.Evaluations.Add(evaluation);
                        }
                    }
                }
            }
        }
    }
}
