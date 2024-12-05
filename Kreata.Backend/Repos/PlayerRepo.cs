using Kreata.Backend.Context;
using Kreta.Shared.Models.Entities;
using Kreta.Shared.Models.Responses;
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

        public async Task<ControllerResponse> UpdatePlayerAsync(Player player)
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
                response.AppendNewError($"{nameof(PlayerRepo)} osztály, {nameof(UpdatePlayerAsync)} metódusban hiba keletkezett.");
                response.AppendNewError($"{player} frissítése nem sikerült!");
            }
            return response;
        }
        public async Task<ControllerResponse> DeletePlayerAsync(Guid id)
        {
            ControllerResponse response = new ControllerResponse();
            Player? playerToDelete = await GetBy(id);
            if (playerToDelete == null || playerToDelete == default)
            {
                response.AppendNewError($"{id} idével rendelkező játékos nem található!");
                response.AppendNewError("A játékos törlése nem sikerült!");
            }
            else
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Entry(playerToDelete).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            return response;
        }
        public async Task<ControllerResponse> InsertPlayerAsync(Player player)
        {
            if (player.HasId)
            {
                return await UpdatePlayerAsync(player);
            }
            else
            {
                return await InsertNewItemAsync(player);
            }
        }
        private async Task<ControllerResponse> InsertNewItemAsync(Player player)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                _dbContext.Players.Add(player);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                response.AppendNewError(e.Message);
                response.AppendNewError($"{nameof(PlayerRepo)} osztály, {nameof(InsertNewItemAsync)} metódusban hiba keletkezett");
                response.AppendNewError($"{player} osztály hozzáadása az adatbázishoz nem sikerült!");
            }
            return response;
        }

    }
}
