namespace GeoLite2Import.Business.Models
{
    public class GeoLite2CountryBlock
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
    }
}