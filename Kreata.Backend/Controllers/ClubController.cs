using Kreata.Backend.Repos;
using Kreta.Shared.Assamblers;
using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Kreta.Shared.Responses;
using System.Numerics;

namespace Kreata.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubController : ControllerBase
    {
        private IClubRepo _clubRepo;

        public ClubController(IClubRepo clubRepo)
        {
            _clubRepo = clubRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(Guid id)
        {
            Club? entity = new();
            if (_clubRepo is not null)
            {
                entity = await _clubRepo.GetBy(id);
                if (entity != null)
                    return Ok(entity.ToDto());
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }

        [HttpGet]
        public async Task<IActionResult> SelectAllRecordToListAsync()
        {
            List<Club>? users = new();

            if (_clubRepo != null)
            {
                users = await _clubRepo.GetAll();
                List<ClubDto> clubDto = users.Select(u => u.ToDto()).ToList();
                return Ok(clubDto);
            }
            return BadRequest("Az adatok elérhetetlenek!");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClubAsync(ClubDto entity)
        {
            ControllerResponse response = new();
            if (_clubRepo is not null)
            {
                response = await _clubRepo.UpdateClubAsync(entity.ToModel());
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClubAsync(Guid id)
        {
            ControllerResponse response = new();
            if (_clubRepo is not null)
            {
                response = await _clubRepo.DeleteClubAsync(id);
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                    response.ClearAndAddError("A klub adatainak törlése nem sikerült!");
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok törlése nem lehetséges!");
            return BadRequest(response);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertClubAsync(ClubDto club)
        {
            ControllerResponse response = new();
            if (_clubRepo is not null)
            {
                response = await _clubRepo.InsertClubAsync(club.ToModel());
                if (response.HasError)
                {
                    Console.WriteLine(response.Error);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az új adatok mentése nem lehetséges!");
            return BadRequest(response);
        }
    }
}