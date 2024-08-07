using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSGComputers.Data;
using VSGComputers.DataAccess.Repository.Interfaces;
using VSGComputers.Models;

namespace VSGComputers.DataAccess.Repository
{
    public class ComputerRepository : Repository<Computer>, IComputerRepository
    {
        private readonly ComputersDbContext db;
        public ComputerRepository(ComputersDbContext db) : base(db)
        {
            this.db = db;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Computer entity)
        {
            db.Computers.Update(entity);
        }
    }
}
