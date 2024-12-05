using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public interface IClubRepo
    {
        Task<List<Club>> GetAll();
        Task<Club?> GetBy(Guid id);
        Task<ControllerResponse> UpdateClubAsync(Club club);
        Task<ControllerResponse> DeleteClubAsync(Guid id);
        Task<ControllerResponse> InsertClubAsync(Club club);
    }
}
