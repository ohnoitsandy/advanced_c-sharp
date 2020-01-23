﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using CoreSchool.Entities;
using CoreSchool.Utilities;
using static System.Console;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
           var engine = new SchoolEngine();
           engine.Initialize();
           Printer.DrawTitle("School courses for the jan - jun semester");
           PrintSchoolCourses(engine.School);
           var objectList = engine.GetBaseSchoolObjects();
           var iPlaceList = from baseObject in objectList
               where baseObject is IPlace
               select (IPlace) baseObject; 
           engine.School.CleanAddress();
        }

        private static void PrintSchoolCourses(School school)
        {
            
            if (school?.Courses == null) return;
            foreach (var course in school.Courses)
            {
                WriteLine($"Name: {course.Name}, ID: {course.Id}, Turn: {course.Turn}");
                Printer.DrawLine();
            }
        }
    }
}
