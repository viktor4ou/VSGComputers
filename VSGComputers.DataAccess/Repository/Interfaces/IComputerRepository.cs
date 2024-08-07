using VSGComputers.Models;

namespace VSGComputers.DataAccess.Repository.Interfaces
{
    public interface IComputerRepository : IRepository<Computer>
    {
        void Update(Computer entity);
        void Save();
    }
}
