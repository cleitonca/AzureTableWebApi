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

    }
}
