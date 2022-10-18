using Microsoft.EntityFrameworkCore;
using UnitofWork_Implemention.Models;

namespace UnitofWork_Implemention.Controllers.Data
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }
    }
}
