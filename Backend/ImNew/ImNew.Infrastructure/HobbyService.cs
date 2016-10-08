using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Infrastructure
{
    public class HobbyService
    {
        public IRepository<Hobby> Repository { get; }

        public HobbyService(IRepository<Hobby> HobbyRepository)
        {
            Repository = HobbyRepository;
        }

        public IEnumerable<DtoHobby> GetAllHobby()
        {
            return Repository.GetAll().Select(hobby => new DtoHobby()
            {
                Id = hobby.Id,
                Name = hobby.Name,
            });
        }

        public DtoHobby GetHobby(int id)
        {
            var hobby = Repository.GetSingle(id);
            return new DtoHobby()
            {
                Id = hobby.Id,
                Name = hobby.Name,
            };
        }

        public void AddNew(string name)
        {
            Repository.Add(new Hobby() { Name = name });
        }
    }

}
