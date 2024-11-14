using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Assamblers
{
    public static class TeacherAssambler
    {
        public static Teacher ToModel(this TeacherDto teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                BirthsDay = teacherDto.BirthsDay,
                IsWoman = teacherDto.IsWoman,
                IsHeadTeacher = teacherDto.IsHeadTeacher,
            };
        }

        public static TeacherDto ToDto(this Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthsDay = teacher.BirthsDay,
                IsWoman = teacher.IsWoman,
                IsHeadTeacher = teacher.IsHeadTeacher,
            };
        }
    }
}
