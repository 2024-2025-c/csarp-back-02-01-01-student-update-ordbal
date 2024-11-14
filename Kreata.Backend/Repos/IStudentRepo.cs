
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;

namespace Kreata.Backend.Repos
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetBy(Guid id);
        Task<ControllerResponse> UpdateStudentAsync(Student student);
    }
}
