using System;
using System.Threading.Tasks;
using UnitofWork_Implemention.Models;

namespace UnitofWork_Implemention.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        //Task<string> GetFullName(Guid id);
    }
}
