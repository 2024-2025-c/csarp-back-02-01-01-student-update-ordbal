using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;

namespace Kreta.Shared.Assamblers
{
    public static class ClubAssambler
    {
        public static Club ToModel(this ClubDto clubDto)
        {
            return new Club
            {
                Id = clubDto.Id,
                ClubName = clubDto.ClubName,
                Alapitas = clubDto.Alapitas,
                Edzo = clubDto.Edzo,
            };
        }

        public static ClubDto ToDto(this Club club)
        {
            return new ClubDto
            {
                Id = club.Id,
                ClubName = club.ClubName,
                Alapitas = club.Alapitas,
                Edzo = club.Edzo,
            };
        }
    }
}
