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

        public IEnumerable<Techonology> GetAllTechnology()
        {
            return Repository.GetAll().Select(technology => new Techonology
            {
                Id = technology.Id,
                Name = technology.Name,
            });
        }

        public Techonology GetTechnology(int id)
        {
            var technology = Repository.GetSingle(id);
            return new Techonology
            {
                Id = technology.Id,
                Name = technology.Name,
            };
        }
    }
}
