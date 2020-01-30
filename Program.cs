using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using CoreSchool.App;
using CoreSchool.Entities;
using CoreSchool.Utilities;
using static System.Console;

namespace CoreSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += ActionEvent;
           var engine = new SchoolEngine();
           engine.Initialize();
           Printer.DrawTitle("School courses for the jan - jun semester");
           var reporter = new Reporter(engine.GetObjectDictionary());
        }

        private static void ActionEvent(object? sender, EventArgs e)
        {
            Printer.DrawTitle("PROCESS FAILED SUCCESSFULLY");
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
