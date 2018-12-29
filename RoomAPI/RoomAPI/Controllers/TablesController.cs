using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomAPI.DAL;
using RoomAPI.Models;

namespace RoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly TableService _tableService = new TableService();

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] Table table)
        {
            await _tableService.Create(table);

            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> All()
        {
            var result = await _tableService.GetAllAsync();

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<JsonResult> Get(string name)
        {
            var result = await _tableService.GetAsync(name);

            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(string name)
        {
            await _tableService.DeleteAsync(name);

            return Ok();
        }
    }
}
