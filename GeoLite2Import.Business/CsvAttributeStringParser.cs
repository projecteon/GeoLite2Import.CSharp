using System.Linq;
using GeoLite2Import.Business.Models;

namespace GeoLite2Import.Business
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