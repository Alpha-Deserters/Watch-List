using System;
using System.IO;

namespace Watch_List.Classes
{
    public static class LocalPath
    {
        public static string ProjectPath { get; } = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\"));
        public static string JsonPath { get; } = $"{ProjectPath}Content\\JSON\\";
        public static string ImagePath { get; } = $"{ProjectPath}Content\\Image\\";
    }
}
