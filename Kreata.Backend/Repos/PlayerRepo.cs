using Kreata.Backend.Context;
using Kreata.Backend.Datas.Entities;
using Kreata.Backend.Datas.Responses;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Kreata.Backend.Repos
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly KretaInMemoryContext _dbContext;

        public PlayerRepo(KretaInMemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Player?> GetBy(Guid id)
        {
            return await _dbContext.Players.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Player>> GetAll()
        {
            return await _dbContext.Players.ToListAsync();
        }

        public async Task<ControllerResponse> UpdatePlayer(Player player)
        {
            ControllerResponse response = new ControllerResponse();
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(player).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(PlayerRepo)} osztály, {nameof(UpdatePlayer)} metódusban hiba keletkezett.");
                response.AppendNewError($"{player} frissítése nem sikerült!");
            }
            return response;
        }
    }
}
