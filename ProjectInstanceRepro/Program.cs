using System;
using System.IO;
using Microsoft.Build.Execution;
using Microsoft.Build.Locator;

namespace ProjectInstanceRepro
{
    public class Program
    {
        public static void Main()
        {
            //  Environment.SetEnvironmentVariable("MSBuildSDKsPath", @"C:\Program Files\dotnet\sdk\5.0.300-preview.21180.15\Sdks");
            var instance = MSBuildLocator.RegisterDefaults();
            Console.WriteLine(instance.MSBuildPath);
            Console.WriteLine(instance.VisualStudioRootPath);
            Console.WriteLine(instance.Version);
            LoadTestProject();
        }

        public static void LoadTestProject()
        {
            var project = new ProjectInstance(Path.Combine(AppContext.BaseDirectory, "assets", "test.csproj"));
            Console.WriteLine($"Loaded {project.FullPath}");
        }
    }
}
