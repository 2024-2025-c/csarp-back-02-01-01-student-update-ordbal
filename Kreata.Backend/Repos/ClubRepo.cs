using Kreata.Backend.Context;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public class ClubRepo : IClubRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public ClubRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Club?> GetBy(Guid id)
        {
            return await _dbContext.Clubs.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Club>> GetAll()
        {
            return await _dbContext.Clubs.ToListAsync();
        }

        public async Task<ControllerResponse> UpdateClubAsync(Club club)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(club).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(ClubRepo)} osztály, {nameof(UpdateClubAsync)} metódusban hiba keletkezett.");
                response.AppendNewError($"{club} frissítése nem sikerült!");
            }
            return response;
        }
    }
}
