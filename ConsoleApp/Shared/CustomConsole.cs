using System;

namespace ConsoleApp.Shared
{
    internal static class CustomConsole
    {
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }

        public static string Read()
        {
           return Console.ReadLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}