using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public interface IUserRepo
    {
        Task<List<User>> GetAll();
        Task<User?> GetBy(Guid id);
        Task<ControllerResponse> UpdateUserAsync(User user);
    }
}
