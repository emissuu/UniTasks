using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TeamService
    {
        private readonly TeamRepository _repo;
        public TeamService(TeamRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Team> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public IEnumerable<string> GetAllNames()
        {
            return _repo.GetAll().Select(t => t.Name).ToList();
        }
        public void Add(Data.Models.Team teamModel)
        {
            _repo.Add(teamModel);
            _repo.Save();
        }
        public void Update(Data.Models.Team teamModel)
        {
            _repo.Update(teamModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
