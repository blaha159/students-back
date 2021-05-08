using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace students_back.Controllers
{
    [Route("api/[controller]/predmet")]
    public class PredmetController : ControllerBase
    {
        public PredmetController(AppDb db)
        {
            Db = db;
        }

        // GET api/predmet
        [HttpGet("~/getAll")]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new PredmetQuery(Db);
            var result = await query.FindAllAsync();
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // GET api/predmet/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new PredmetQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/predmet
        [HttpPost]
        public async Task<IActionResult> Predmet([FromBody]Predmet body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/predmet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody]Predmet body)
        {
            await Db.Connection.OpenAsync();
            var query = new PredmetQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.nazev = body.nazev;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/predmet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new PredmetQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/predmet
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new PredmetQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }
    }
}