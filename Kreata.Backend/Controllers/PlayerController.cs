using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Kreata.Backend.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private IPlayerRepo _playerRepo;

        public PlayerController(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Player? entity = new();
            if (_playerRepo is not null)
            {
                entity = await _playerRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Player>? users = new();

            if (_playerRepo != null)
            {
                users = await _playerRepo.GetAll();
                return Ok(users);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePlayerAsync(Player entity)
        {
            ControllerResponse response = new();
            if (_playerRepo is not null)
            {
                response = await _playerRepo.UpdatePlayer(entity);
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }
    }
}
