namespace GeoLite2Import
{
    public class ValidateNameSpaceCommand<T> : ICommand<bool> where T : new()
    {
        public string CsvSchema { get; }

        public ValidateNameSpaceCommand(string csvSchema)
        {
            CsvSchema = csvSchema;
        }

        public bool Execute()
        {
            return CsvSchemaValidator.IsSchemaValid<T>(CsvSchema);
        }
    }
}