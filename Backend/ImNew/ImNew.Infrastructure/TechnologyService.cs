using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Infrastructure
{
    public class TechnologyService
    {
        public IRepository<Techonology> Repository { get; }

        public TechnologyService(IRepository<Techonology> technologyRepository)
        {
            Repository = technologyRepository;
        }

        public IEnumerable<DtoTechnology> GetAllTechnology()
        {
            return Repository.GetAll().Select(technology => new DtoTechnology()
            {
                Id = technology.Id,
                Name = technology.Name,
            });
        }

        public DtoTechnology GetTechnology(int id)
        {
            var technology = Repository.GetSingle(id);
            return new DtoTechnology()
            {
                Id = technology.Id,
                Name = technology.Name,
            };
        }
    }
}
