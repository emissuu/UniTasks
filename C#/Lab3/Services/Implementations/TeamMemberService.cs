using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TeamMemberService
    {
        private readonly TeamMemberRepository _repo;
        public TeamMemberService(TeamMemberRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.TeamMember> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public void Add(Data.Models.TeamMember teamMemberModel)
        {
            _repo.Add(teamMemberModel);
            _repo.Save();
        }
        public void Update(Data.Models.TeamMember teamMemberModel)
        {
            _repo.Update(teamMemberModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
