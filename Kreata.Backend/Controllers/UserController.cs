
using Kreata.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            User? entity = new();
            if (_userRepo is not null)
            {
                entity = await _userRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity.ToDto());
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<User>? users = new();

            if (_userRepo != null)
            {
                users = await _userRepo.GetAll();
                List<UserDto> userDto = users.Select(u => u.ToDto()).ToList();
                return Ok(userDto);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClubAsync(UserDto entity)
        {
            ControllerResponse response = new();
            if (_userRepo is not null)
            {
                response = await _userRepo.UpdateUserAsync(entity.ToModel());
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
