using System;

namespace GeoLite2Import.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CsvColumnAttribute : Attribute
    {
        public CsvColumnAttribute(int columnIndex)
        {
            ColumnIndex = columnIndex;
        }

        public int ColumnIndex { get; }
    }
}