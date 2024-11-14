using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;

namespace Kreata.Backend.Repos
{
    public interface ITeacherRepo
    {
        Task<List<Teacher>> GetAll();
        Task<Teacher?> GetBy(Guid id);
        Task<ControllerResponse> UpdateTeacherAsync(Teacher entity);
    }
}