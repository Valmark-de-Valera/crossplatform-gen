using System;
using DotNetTool.Laboratories;
using McMaster.Extensions.CommandLineUtils;

namespace SubcommandSample
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Lab Works",
                Description = "",
            };

            app.HelpOption(inherited: true);
            app.Command("run", configCmd =>
            {
                configCmd.OnExecute(() =>
                {
                    Console.WriteLine("Specify aplication:");
                    configCmd.ShowHelp();
                    return 1;
                });

                // ./DotNetTool run lab1 -I "dataIn.txt" -O "dataOut.txt"
                configCmd.Command("lab1", setCmd =>
                {
                    setCmd.Description = "Laboratory work 1";
                    var folder = getPathToFile();
                    var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                    input.DefaultValue = $"{folder}/dataIn.txt";
                    output.DefaultValue = $"{folder}/dataOut.txt";
                    setCmd.OnExecute(() =>
                    {
                        Console.WriteLine($"Set input file path: {input.Value()}");
                        Console.WriteLine($"Set output file path: {output.Value()}");
                        var app = new Lab1(new DotNetTool.Utils.FileRepository(input.Value(), output.Value()));
                        app.Main();
                    });
                });

                // ./DotNetTool run lab2 -I "dataIn.txt" -O "dataOut.txt"
                configCmd.Command("lab2", setCmd =>
                {
                    setCmd.Description = "Laboratory work 2";
                    var folder = getPathToFile();
                    var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                    input.DefaultValue = $"{folder}/dataIn.txt";
                    output.DefaultValue = $"{folder}/dataOut.txt";
                    setCmd.OnExecute(() =>
                    {
                        Console.WriteLine($"Set input file path: {input.Value()}");
                        Console.WriteLine($"Set output file path: {output.Value()}");
                        var app = new Lab2(new DotNetTool.Utils.FileRepository(input.Value(), output.Value()));
                        app.Main();
                    });
                });

                // ./DotNetTool run lab3 -I "dataIn.txt" -O "dataOut.txt"
                configCmd.Command("lab3", setCmd =>
                {
                    setCmd.Description = "Laboratory work 3";
                    var folder = getPathToFile();
                    var input = setCmd.Option("-I|--input <INPUT>", "Input file path", CommandOptionType.SingleValue);
                    var output = setCmd.Option("-O|--output <OUTPUT>", "Output file path", CommandOptionType.SingleValue);
                    input.DefaultValue = $"{folder}/dataIn.txt";
                    output.DefaultValue = $"{folder}/dataOut.txt";
                    setCmd.OnExecute(() =>
                    {
                        Console.WriteLine($"Set input file path: {input.Value()}");
                        Console.WriteLine($"Set output file path: {output.Value()}");
                        var app = new Lab3(new DotNetTool.Utils.FileRepository(input.Value(), output.Value()));
                        TmpLab.Main();
                        app.Main();
                    });
                });
            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Specify a lab work");
                app.ShowHelp();
                return 1;
            });

            return app.Execute(args);
        }
        private static string getPathToFile()
        {
            string labPath = Environment.GetEnvironmentVariable("LAB_PATH") ?? "";
            if (labPath.Length > 0) return labPath;
            else return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}