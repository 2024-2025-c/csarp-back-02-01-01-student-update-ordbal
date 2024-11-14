

namespace Kreta.Shared.Models.Entities
{
    public class Player
    {
        public Player(Guid id, string firstName, string lastName, DateTime birthsDay, string club)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            Club = club;
        }
        public Player()
        {
            Id = new Guid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            Club = string.Empty;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Club { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName} ({Club}), Szül: ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)})";
        }
    }
}
