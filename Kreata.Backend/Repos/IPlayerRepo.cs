
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public interface IPlayerRepo
    {
        Task<List<Player>> GetAll();
        Task<Player?> GetBy(Guid id);
        Task<ControllerResponse> UpdatePlayerAsync(Player player);
    }
}
