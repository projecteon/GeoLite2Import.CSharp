using GeoLite2Import.Models;
using Xunit;

namespace GeoLite2Import.Tests.Unit
{
    public class CsvSchemaValidatorTests
    {
        private static string fakeSchema = "city,country";

        private class FakeOkSchemaMap 
        {
            [CsvColumn(0)]
            public string city { get; set; }

            [CsvColumn(1)]
            public string country { get; set; }
        }

        private class FakeWrongOrderSchemaMap 
        {
            [CsvColumn(1)]
            public string city { get; set; }

            [CsvColumn(0)]
            public string country { get; set; }
        }

        private class FakeWrongMissingSchemaMap 
        {
            [CsvColumn(0)]
            public string city { get; set; }
        }

        private class FakeWrongExtraSchemaMap 
        {
            [CsvColumn(0)]
            public string city { get; set; }

            [CsvColumn(1)]
            public string country { get; set; }

            [CsvColumn(2)]
            public string network { get; set; }
        }

        [Fact]
        public void WhenSchemaAttributeMapMatchesSchema_TrueIsReturned()
        {
            Assert.True(CsvSchemaValidator.IsSchemaValid<FakeOkSchemaMap>(fakeSchema));
        }

        [Fact]
        public void WhenSchemaAttributeMapHasWrongOrder_FalseIsReturned()
        {
            Assert.False(CsvSchemaValidator.IsSchemaValid<FakeWrongOrderSchemaMap>(fakeSchema));
        }

        [Fact]
        public void WhenSchemaAttributeMapHasMissingProperty_FalseIsReturned()
        {
            Assert.False(CsvSchemaValidator.IsSchemaValid<FakeWrongMissingSchemaMap>(fakeSchema));
        }

        [Fact]
        public void WhenSchemaAttributeMapHasExtraProperty_FalseIsReturned()
        {
            Assert.False(CsvSchemaValidator.IsSchemaValid<FakeWrongExtraSchemaMap>(fakeSchema));
        }
    }
}
