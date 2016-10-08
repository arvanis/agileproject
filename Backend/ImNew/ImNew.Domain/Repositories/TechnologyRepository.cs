using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;

namespace ImNew.Domain.Repositories
{
    public class TechnologyRepository : IRepository<Techonology>
    {
        public ImNewContext DbContext { get; }

        public TechnologyRepository(ImNewContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Add(Techonology item)
        {
            DbContext.Techonologies.Add(item);
            Save();
        }

        public void Edit(Techonology item)
        {
            DbContext.Entry(item).State = EntityState.Modified;
            Save();
        }

        public IEnumerable<Techonology> GetAll()
        {
            return DbContext.Techonologies;
        }

        public Techonology GetSingle(int id)
        {
            return DbContext.Techonologies.FirstOrDefault(x => x.Id == id);
        }
        private void Save()
        {
            DbContext.SaveChanges();
        }

    }



}
