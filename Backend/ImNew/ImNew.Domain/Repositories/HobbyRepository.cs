using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;

namespace ImNew.Domain.Repositories
{
    public class HobbyRepository : IRepository<Hobby>
    {
        public ImNewContext DbContext { get; }

        public HobbyRepository(ImNewContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(Hobby item)
        {
            DbContext.Hobbies.Add(item);
            Save();
        }

        public void Edit(Hobby item)
        {
            DbContext.Entry(item).State = EntityState.Modified;
            Save();
        }

        public IEnumerable<Hobby> GetAll()
        {
            return DbContext.Hobbies;
        }

        public Hobby GetSingle(int id)
        {
            return DbContext.Hobbies.FirstOrDefault(x => x.Id == id);
        }
        private void Save()
        {
            DbContext.SaveChanges();
        }

    }
}
