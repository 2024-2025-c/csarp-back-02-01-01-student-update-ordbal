using Kreata.Backend.Context;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Repos
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public TeacherRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher?> GetBy(Guid id)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Teacher>> GetAll()
        {
            int count = _dbContext.Teachers.Count();
            return await _dbContext.Teachers.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateTeacherAsync(Teacher teacher)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(teacher).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(TeacherRepo)} osztály, {nameof(UpdateTeacherAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{teacher} frissítése nem sikerlûlt!");
            }
            return response;
        }
    }
}
