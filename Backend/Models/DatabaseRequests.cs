namespace MeGeneAPI.Models
{
    public class ConnectionRequest
    {
        public string? ConnectionString { get; set; }
    }

    public class DatabaseRequest : ConnectionRequest
    {
        public string? Database { get; set; }
    }

    public class SchemaRequest : DatabaseRequest
    {
        public string? Schema { get; set; }
    }

    public class TableRequest : SchemaRequest
    {
        public string? Table { get; set; }
    }
}
