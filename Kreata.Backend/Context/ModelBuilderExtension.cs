using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Enums;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Kreata.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    BirthsDay=new DateTime(2022,10,10),
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                    EducationLevel="érettségi"
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    BirthsDay=new DateTime(2021,4,4),
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                    EducationLevel="érettségi"
                }
            };

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Mery",
                    LastName="Matek",
                    BirthsDay=new DateTime(2020,2,2),
                    IsHeadTeacher=true,
                    IsWoomen=true,
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Feri",
                    LastName="Föci",
                    BirthsDay=new DateTime(2010,10,10),
                    IsHeadTeacher=false,
                    IsWoomen=false,
                }
            };

            List<Player> players = new List<Player>
            {
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Kylian",
                    LastName="Mbappe",
                    BirthsDay=new DateTime(1998,12,20),
                    Club="Real Madrid",
                },
                new Player
                {
                    Id=Guid.NewGuid(),
                    FirstName="Jude",
                    LastName="Bellingham",
                    BirthsDay=new DateTime(2003,6,29),
                    Club="Real Madrid",
                }
            };

            // Students
            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Teacher>().HasData(teachers);
            modelBuilder.Entity<Player>().HasData(players);
        }
    }
}
