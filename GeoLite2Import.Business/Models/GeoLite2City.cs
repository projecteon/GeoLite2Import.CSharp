namespace GeoLite2Import.Business.Models
{
    public class GeoLite2City
    {
        [CsvColumn(0)]
        public string network { get; set; }
        [CsvColumn(1)]
        public string geoname_id { get; set; }
        [CsvColumn(2)]
        public string registered_country_geoname_id { get; set; }
        [CsvColumn(3)]
        public string represented_country_geoname_id { get; set; }
        [CsvColumn(4)]
        public string is_anonymous_proxy { get; set; }
        [CsvColumn(5)]
        public string is_satellite_provider { get; set; }
        [CsvColumn(6)]
        public string postal_code { get; set; }
        [CsvColumn(7)]
        public string latitude { get; set; }
        [CsvColumn(8)]
        public string longitude { get; set; }
        [CsvColumn(9)]
        public string accuracy_radius { get; set; }
    }
}