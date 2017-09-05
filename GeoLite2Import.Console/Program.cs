using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeoLite2Import.Business.Models;

namespace GeoLite2Import
{
    class Program
    {
        static string Ipv4CititesImportFilePath = @"geolite2\GeoLite2-City-Blocks-IPv4-example.csv";
        static string Ipv4CountriesImportFilePath = @"geolite2\GeoLite2-Country-Blocks-IPv4-example.csv";
        static string WorldCitiesPopImportFilePath = @"geolite2\worldcitiespop-example.csv";

        static void Main(string[] args)
        {
            LogImport<GeoLite2City>(Ipv4CititesImportFilePath);
            LogImport<GeoLite2Country>(Ipv4CountriesImportFilePath);
            LogImport<WorldCity>(WorldCitiesPopImportFilePath);
        }

        static void LogImport<T>(string filePath) where T: new()
        {            
            var result = Import<T>(filePath);
            foreach (var item in result.Take(10))
            {
                Console.WriteLine(item);
            }
        }

        static IEnumerable<T> Import<T>(string filePath) where T: new()
        {
            var csvLines = File.ReadAllLines(filePath);
            var importSchemaValidatorCommand = new ValidateNameSpaceCommand<T>(csvLines.First());
            if(importSchemaValidatorCommand.Execute() == false) 
            {
                Console.WriteLine($"Schema validation failed for {(new T()).GetType()} and {filePath}");
                return new List<T>();
            } 
            
            var importCommand = new ImportCommand<T>(csvLines.Skip(1));
            return importCommand.Execute();
        }
    }
}
