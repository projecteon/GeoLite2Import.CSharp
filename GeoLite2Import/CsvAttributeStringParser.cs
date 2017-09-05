using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GeoLite2Import.Models;

namespace GeoLite2Import
{
    public class CsvAttributeStringParser
    {
        public static T Parse<T>(string csvString) where T: new()
        {
            var columns = csvString.Split(',');
            var newObject = new T();
            var props = newObject.GetType().GetProperties();
            foreach (var prop in props)
            {
                var csvColumnAttribute = prop.GetCustomAttributes(typeof(CsvColumnAttribute), true).FirstOrDefault() as CsvColumnAttribute;
                if (csvColumnAttribute != null)
                {
                    var index = csvColumnAttribute.ColumnIndex;
                    prop.SetValue(newObject, columns[index]);
                }
            }

            return newObject;
        }
    }
}