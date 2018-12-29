using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomAPI.DAL;
using RoomAPI.Models;

namespace RoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly PlayerService _playerService = new PlayerService();
        private readonly TableService _tableService = new TableService();

        [HttpPost]
        [Route("join")]
        public async Task<ActionResult> JoinTable(string playerName, string tableName, double buyIn)
        {
            var player = await _playerService.GetAsync(playerName);
            var table = await _tableService.GetAsync(tableName);

            ValidateJoinRequest(player, table, buyIn);

            table.CurrentPlayers.Add(playerName, buyIn);
            await _tableService.UpdatePlayers(tableName, table.CurrentPlayers);
            await _playerService.UpdateBalance(playerName, player.AvailableFunds - buyIn);

            return Ok();
        }

        [HttpPost]
        [Route("leave")]
        public async Task<ActionResult> LeaveTable(string playerName, string tableName)
        {
            var player = await _playerService.GetAsync(playerName);
            var table = await _tableService.GetAsync(tableName);

            ValidateLeaveRequest(player, table);

            double cashOut = table.CurrentPlayers[playerName];
            table.CurrentPlayers.Remove(playerName);

            await _tableService.UpdatePlayers(tableName, table.CurrentPlayers);
            await _playerService.UpdateBalance(playerName, player.AvailableFunds + cashOut);

            return Ok();
        }


        private void ValidateJoinRequest(Player player, Table table, double buyIn)
        {
            if (table.MaxPlayers == table.CurrentPlayers.Count)
            {
                throw new InvalidOperationException();
            }
            if (table.CurrentPlayers.ContainsKey(player.Name))
            {
                throw new ArgumentException(nameof(player));
            }
            if (table.MinBuyIn > buyIn)
            {
                throw new ArgumentException(nameof(buyIn));
            }
            if (player.AvailableFunds < buyIn)
            {
                throw new ArgumentException(nameof(buyIn));
            }
        }

        private void ValidateLeaveRequest(Player player, Table table)
        {
            if (!table.CurrentPlayers.ContainsKey(player.Name))
            {
                throw new ArgumentException(nameof(player));
            }
        }
    }
}