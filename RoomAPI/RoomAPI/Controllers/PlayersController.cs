using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomAPI.DAL;
using RoomAPI.Models;

namespace RoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService = new PlayerService();

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] Player player)
        {
            await _playerService.Create(player);

            return Ok();
        }

        [HttpGet]
        [Route("all")]
        public async Task<JsonResult> All()
        {
            var result = await _playerService.GetAllAsync();

            return new JsonResult(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<JsonResult> Get(string name)
        {
            var result = await _playerService.GetAsync(name);

            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(string name)
        {
            await _playerService.DeleteAsync(name);

            return Ok();
        }
    }
}