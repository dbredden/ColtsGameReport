using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the Python script
            string pythonScriptPath = @"C:\Users\dredden\source\repos\ColtsGameReport\PythonScripts\test_data.py";

            // Create a new process to run the Python script
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = pythonScriptPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(start))
            {
                // Read the output from the Python script
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();

                    // Parse the JSON output
                    JObject data = JObject.Parse(result);

                    // Access the data
                    string name = data["name"].ToString();
                    int age = data["age"].ToObject<int>();
                    string email = data["email"].ToString();

                    // Output the data
                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Age: {age}");
                    Console.WriteLine($"Email: {email}");
                }
            }
        }
    }
}