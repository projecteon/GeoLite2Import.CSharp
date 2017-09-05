using System;

namespace GeoLite2Import.Business.Models
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