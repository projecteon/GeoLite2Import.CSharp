using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GeoLite2Import.Business;
using GeoLite2Import.Business.Models;

namespace GeoLite2Import
{
    class Program
    {
        static string Ipv4BCityBlocksImportFilePath = @"geolite2\GeoLite2-City-Blocks-IPv4-example.csv";
        static string Ipv4CityLocationsImportFilePath = @"geolite2\GeoLite2-City-Locations-en.csv";
        static string Ipv4CountryBlocksImportFilePath = @"geolite2\GeoLite2-Country-Blocks-IPv4-example.csv";
        static string Ipv4CountyLocationsImportFilePath = @"geolite2\GeoLite2-Country-Locations-en-example.csv";
        static string WorldCitiesPopImportFilePath = @"geolite2\worldcitiespop-example.csv";

        static void Main(string[] args)
        {
            LogImport<GeoLite2CityBlock>(Ipv4BCityBlocksImportFilePath);
            LogImport<GeoLite2CityLocation>(Ipv4CityLocationsImportFilePath);
            LogImport<GeoLite2CountryBlock>(Ipv4CountryBlocksImportFilePath);
            LogImport<GeoLite2CountryLocation>(Ipv4CountyLocationsImportFilePath);
            LogImport<WorldCity>(WorldCitiesPopImportFilePath);
            //LogMaxCityNameLength()
        }

        static void LogImport<T>(string filePath) where T: new()
        {            
            var result = Import<T>(filePath);
            foreach (var item in result.Take(10))
            {
                Console.WriteLine(item);
            }
        }

        static void LogMaxCityNameLength()
        {
            var cities = Import<GeoLite2CityLocation>(Ipv4CityLocationsImportFilePath);
            var maxLengthCityName = cities.Aggregate((agg, next) => next.city_name.Length > agg.city_name.Length ? next : agg);
            Console.WriteLine($"{maxLengthCityName.geoname_id}, {maxLengthCityName.city_name}, {maxLengthCityName.city_name.Length}");
            Console.ReadLine();
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
