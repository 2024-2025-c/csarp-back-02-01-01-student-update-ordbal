

namespace Kreta.Shared.Models.Entities
{
    public class User
    {
        public User(Guid id, string userName, DateTime birthsDay, string email)
        {
            Id = id;
            UserName = userName;
            BirthsDay = birthsDay;
            Email = email;

        }
        public User()
        {
            Id = new Guid();
            UserName = string.Empty;
            BirthsDay = new DateTime();
            Email = string.Empty;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{UserName} ({Email}), Szül: ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)})";
        }
    }
}
