using System.Threading.Tasks;
using UnitofWork_Implemention.Core.IRepositories;

namespace UnitofWork_Implemention.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        Task CompleteAsync();
    }
}
