using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;

namespace Kreta.Shared.Assamblers
{
    public static class PlayerAssambler
    {
        public static Player ToModel(this PlayerDto playerDto)
        {
            return new Player
            {
                Id = playerDto.Id,
                FirstName = playerDto.FirstName,
                LastName = playerDto.LastName,
                BirthsDay = playerDto.BirthsDay,
                Club = playerDto.Club,
            };
        }

        public static PlayerDto ToDto(this Player player)
        {
            return new PlayerDto
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                BirthsDay = player.BirthsDay,
                Club = player.Club,
            };
        }
    }
}
