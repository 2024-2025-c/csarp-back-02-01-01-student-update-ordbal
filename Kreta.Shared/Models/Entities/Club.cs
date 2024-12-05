

namespace Kreta.Shared.Models.Entities
{
    public class Club
    {
        public Club(Guid id, string clubName, DateTime alapitas, string edzo)
        {
            Id = id;
            ClubName = clubName;
            Alapitas = alapitas;
            Edzo = edzo;

        }
        public Club()
        {
            Id = new Guid();
            ClubName = string.Empty;
            Alapitas = new DateTime();
            Edzo = string.Empty;
        }

        public Guid Id { get; set; }
        public string ClubName { get; set; }
        public DateTime Alapitas { get; set; }
        public string Edzo { get; set; }
        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{ClubName} ({Edzo}), Szül: ({string.Format("{0:yyyy.MM.dd.}", Alapitas)})";
        }
    }
}
