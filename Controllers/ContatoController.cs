using Azure.Data.Tables;
using AzureTableWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureTableWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public ContatoController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("SAConnectionString");
            _tableName = configuration.GetValue<string>("AzureTableName");


        }

        private TableClient GetTableClient()
        {
            var serviceClient = new TableServiceClient(_connectionString);

            var tableClient = serviceClient.GetTableClient(_tableName);

            tableClient.CreateIfNotExists();

            return tableClient;
        }

        public IActionResult Criar(Contato contato)
        {
            var tableClient = GetTableClient();

            contato.RowKey = Guid.NewGuid().ToString();

            contato.PartitionKey = contato.RowKey;

            tableClient.UpsertEntity(contato);

            return Ok(contato);

        }

    }
}
