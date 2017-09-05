using System.Linq;
using System.Reflection;
using GeoLite2Import.Models;

namespace GeoLite2Import
{
    public class CsvSchemaValidator
    {
        public static bool IsSchemaValid<T>(string schema) where T: new()
        {
            return schema == GetCsvColumnAttributeSchema<T>();
        }

        static string GetCsvColumnAttributeSchema<Q>() where Q: new()
        {
            var typeObject = new Q();
            return typeObject.GetType()
                              .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
                              .Select(p =>  new { Property = p, Attribute = p.GetCustomAttributes(typeof(CsvColumnAttribute), true) as CsvColumnAttribute[]})
                              .Where(o => o.Attribute.Any())
                              .OrderBy(o => o.Attribute.First().ColumnIndex)
                              .Select(p => p.Property.Name).Aggregate((current, next) => current + "," + next);
        }
    }
}