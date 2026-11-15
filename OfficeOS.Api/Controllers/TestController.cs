using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OfficeOS.Api.Configuration;
using OfficeOS.Api.Models;

namespace OfficeOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private IMongoCollection<TestDocument> _testCollection;

        public TestController(IOptions<MongoDbSettings> mongoSettings)
        {
            IMongoClient client = new MongoClient("mongodb+srv://rajdipchatterjee3000_db_user:AWMAZ3BZWvpJFt9i@personal-dev-m0.rjfklua.mongodb.net/");
            _testCollection = client.GetDatabase("TestDatabase").GetCollection<TestDocument>("TestCollection");

            string data = mongoSettings.Value.ConnectionString;
            Console.WriteLine($"data {data}");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string value)
        {
            var data = new TestDocument()
            {
                Name = "Rajdip"
            };

            try
            {
                await _testCollection.InsertOneAsync(data);
                //Console.WriteLine($" Inside Controller");
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return Ok(value);
        }
    }
}
