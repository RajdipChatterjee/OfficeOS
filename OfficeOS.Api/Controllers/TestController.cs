using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using OfficeOS.Api.Models;

namespace OfficeOS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMongoCollection<TestDocument> _testCollection;

        public TestController(IMongoDatabase mongoDatabase)
        {
            _testCollection = mongoDatabase.GetCollection<TestDocument>("TestCollection");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TestDocument value)
        {
            await _testCollection.InsertOneAsync(value);
            return Ok(value);
        }
    }
}
