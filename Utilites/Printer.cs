using System.Runtime.InteropServices;
using static System.Console;

namespace CoreSchool.Utilities
{
    public static class Printer
    {
        public static void DrawLine(int size = 10)
        {
            var line = "".PadLeft(size, '-');
            WriteLine($"+{line}+");
            //WriteLine("SCHOOL COURSES FOR THE JAN - JUN SEMESTER");
        }

        public static void DrawTitle(string title)
        {
            var fixedSize = title.Length + 18;
            DrawLine(fixedSize);
            WriteLine($"-------- {title.ToUpper()} ----------");
            DrawLine(fixedSize);
        }
        
    }
}