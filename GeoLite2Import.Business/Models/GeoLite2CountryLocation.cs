namespace GeoLite2Import.Business.Models
{
    public class GeoLite2CountryLocation
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
    }
}