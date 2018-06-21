using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConfigurationBuilderSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            // Only Environment Variables has been set
            Environment.SetEnvironmentVariable("SOME_PRIMARY_KEY", "EnvironmentVariablesKey");
            // Evirnoment Variables and appsettings has been set
            Environment.SetEnvironmentVariable("SOME_HOST_NAME", "EnvironmentVariablesHostName");
            // Only AppSettings set. SOME_SECRET

            var builder = new ConfigurationBuilder();

            const string APP_SETTINGS = "appsettings.jso";

            if (File.Exists(APP_SETTINGS))
            {
                builder.AddJsonFile(APP_SETTINGS);
            } else
            {
                Console.WriteLine("Warning: appsettings.json not found");
            }
            // the configuration is overriden if it has an entry which has the same name.
            builder.AddEnvironmentVariables();

            var configration = builder.Build();

            Console.WriteLine($"SOME_PRIMARY_KEY: {configration["SOME_PRIMARY_KEY"]}");
            Console.WriteLine($"SOME_HOST_NAME: {configration["SOME_HOST_NAME"]}");
            Console.WriteLine($"SOME_SECRET: {configration["SOME_SECRET"]}");

            Console.ReadLine();
        }
    }
}
