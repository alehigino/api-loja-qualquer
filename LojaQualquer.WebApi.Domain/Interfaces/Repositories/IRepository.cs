using LojaQualquer.WebApi.Domain.Entities;
using System.Threading.Tasks;

namespace LojaQualquer.WebApi.Domain.Interfaces.Repositories
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAsync(TEntity entity);
        Task SaveChangesAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}