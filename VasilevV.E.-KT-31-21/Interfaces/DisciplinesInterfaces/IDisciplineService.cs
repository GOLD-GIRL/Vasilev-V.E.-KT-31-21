using Microsoft.EntityFrameworkCore;
using VasilevV.E._KT_31_21.Models;
using VasilevV.E._KT_31_21.Database;
using VasilevV.E._KT_31_21.Filters.DisciplineFilters;
using NLog.Filters;
using System.Threading;


namespace VasilevV.E._KT_31_21.Interfaces.DisciplinesInterfaces
{
    public interface IDisciplineService
    {
        public Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken);
        public Task<Discipline[]> GetDisciplinesByDeletedAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken);

    }
    public class DisciplineService : IDisciplineService
    {
        private readonly StudentDbContext _dbContext;
        public DisciplineService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineDirectionFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _dbContext.Set<Discipline>().Where(w => w.Direction == filter.Direction).ToArrayAsync(cancellationToken);
            return disciplines;
        }
        public async Task<Discipline[]> GetDisciplinesByDeletedAsync(DisciplineDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var disciplines = await _dbContext.Set<Discipline>().Where(w => w.IsDeleted == filter.IsDeleted).ToArrayAsync(cancellationToken);
            return disciplines;
        }
    }

}
