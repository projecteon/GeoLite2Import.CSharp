namespace GeoLite2Import.Business.Models
{
    public class WorldCity
    {
        [CsvColumn(0)]
        public string Country { get; set; }
        [CsvColumn(1)]
        public string City { get; set; }
        [CsvColumn(2)]
        public string AccentCity { get; set; }
        [CsvColumn(3)]
        public string Region { get; set; }
        [CsvColumn(4)]
        public string Population { get; set; }
        [CsvColumn(5)]
        public string Latitude { get; set; }
        [CsvColumn(6)]
        public string Longitude { get; set; }
    }
}