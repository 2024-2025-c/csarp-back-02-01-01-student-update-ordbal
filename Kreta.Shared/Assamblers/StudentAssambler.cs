using Kreta.Shared.Dtos;
using Kreta.Shared.Models.Entities;

namespace Kreta.Shared.Assamblers
{
    public static class StudentAssambler
    {
        public static Student ToModel(this StudentDto studentDto)
        {
            return new Student
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                BirthsDay = studentDto.BirthsDay,
                EducationLevel = studentDto.EducationLevel,
                IsWoman = studentDto.IsWoman,
                SchoolClass = studentDto.SchoolClass,
                SchoolYear = studentDto.SchoolYear,
            };
        }

        public static StudentDto ToDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthsDay = student.BirthsDay,
                EducationLevel = student.EducationLevel,
                IsWoman = student.IsWoman,
                SchoolClass = student.SchoolClass,
                SchoolYear = student.SchoolYear,
            };
        }
    }
}
