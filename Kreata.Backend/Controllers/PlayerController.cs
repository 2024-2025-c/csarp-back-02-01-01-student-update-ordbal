﻿using Kreta.Shared.Dtos;
using Kreata.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;

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
                    return Ok(entity.ToDto());
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
                List<PlayerDto> playerDto = users.Select(u => u.ToDto()).ToList();
                return Ok(playerDto);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePlayerAsync(PlayerDto entity)
        {
            ControllerResponse response = new();
            if (_playerRepo is not null)
            {
                response = await _playerRepo.UpdatePlayerAsync(entity.ToModel());
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
