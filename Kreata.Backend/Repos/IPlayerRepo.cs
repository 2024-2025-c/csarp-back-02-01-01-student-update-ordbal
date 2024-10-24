using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public interface IPlayerRepo
    {
        Task<List<Player>> GetAll();
        Task<Player?> GetBy(Guid id);
        Task<ControllerResponse> UpdatePlayer(Player player);
    }
}
