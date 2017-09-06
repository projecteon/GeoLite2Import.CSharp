namespace GeoLite2Import.Business.Models
{
    public class GeoLite2CityLocation
    {
        [CsvColumn(0)]
        public string geoname_id { get; set; }
        [CsvColumn(1)]
        public string locale_code { get; set; }
        [CsvColumn(2)]
        public string continent_code { get; set; }
        [CsvColumn(3)]
        public string continent_name { get; set; }
        [CsvColumn(4)]
        public string country_iso_code { get; set; }
        [CsvColumn(5)]
        public string country_name { get; set; }
        [CsvColumn(6)]
        public string subdivision_1_iso_code { get; set; }
        [CsvColumn(7)]
        public string subdivision_1_name { get; set; }
        [CsvColumn(8)]
        public string subdivision_2_iso_code { get; set; }
        [CsvColumn(9)]
        public string subdivision_2_name { get; set; }
        [CsvColumn(10)]
        public string city_name { get; set; }
        [CsvColumn(11)]
        public string metro_code { get; set; }
        [CsvColumn(12)]
        public string time_zone { get; set; }
    }
}