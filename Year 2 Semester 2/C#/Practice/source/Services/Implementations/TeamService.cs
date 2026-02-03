using Data.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IAuditLogService _auditLogService;
        public TeamService(ITeamRepository teamRepository, IAuditLogService auditLogService)
        {
            _teamRepository = teamRepository;
            _auditLogService = auditLogService;
        }
        
        public IEnumerable<Team> GetAll()
        {
            return _teamRepository.GetAll();
        }

        public Team GetById(int id)
        {
            return _teamRepository.GetById(id);
        }

        public void Add(Team team)
        {
            _teamRepository.Add(team);
            _teamRepository.Save();
        }

        public void Update(Team team)
        {
            _teamRepository.Update(team);
            _teamRepository.Save();
        }

        public void Remove(int[] ids)
        {
            foreach (int id in ids)
            {
                _teamRepository.Delete(id);
            }
            _teamRepository.Save();
        }

        public void AddTeamUsers(List<TeamUser> teamUsers)
        {
            foreach (var teamUser in teamUsers)
            {
                _teamRepository.AddTeamUser(teamUser);
            }
            _teamRepository.Save();
        }

        public IEnumerable<TeamDetails> GetAllTeamDetails()
        {
            return _teamRepository.GetAll()
                .Select(t => new TeamDetails(
                    t.Id,
                    t.Name,
                    t.CreatedBy,
                    t.TeamUsers.ToList()
                    ));
        }
    }
}
