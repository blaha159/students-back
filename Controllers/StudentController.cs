using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace students_back.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        public StudentController(AppDb db)
        {
            Db = db;
        }

        // GET api/predmet
        /*[HttpGet("~/getAll")]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
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
            var query = new StudentQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/predmet
        [HttpPost]
        public async Task<IActionResult> Student([FromBody]Student body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/predmet/5
        [HttpPut]
        public async Task<IActionResult> PutOne([FromBody]Student body)
        {
            await Db.Connection.OpenAsync();
            var query = new StudentQuery(Db);
            var result = await query.FindOneAsync(body.id);
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
            var query = new StudentQuery(Db);
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
            var query = new StudentQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }*/

        public AppDb Db { get; }
    }
}