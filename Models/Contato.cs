using Azure;
using Azure.Data.Tables;

namespace AzureTableWebApi.Models
{
    public class Contato : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
