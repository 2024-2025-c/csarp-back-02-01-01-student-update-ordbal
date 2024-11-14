using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Assamblers
{
    public static class UserAssambler
    {
        public static User ToModel(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                BirthsDay = userDto.BirthsDay,
                Email = userDto.Email,
            };
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                BirthsDay = user.BirthsDay,
                Email = user.Email,
            };
        }
    }
}
