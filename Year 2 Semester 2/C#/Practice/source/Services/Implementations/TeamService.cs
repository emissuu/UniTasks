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

        public void Add(Team team, int userId)
        {
            _teamRepository.Add(team);
            _teamRepository.Save();
            var newTeam = _teamRepository.GetByName(team.Name);
            _auditLogService.Log(userId, "Team", newTeam.Id, "CREATE", null, newTeam);
        }

        public void Update(Team team, int userId)
        {
            var oldTeam = _teamRepository.GetByIdSimple(team.Id);
            _teamRepository.Update(team);
            _teamRepository.Save();
            var newTeam = _teamRepository.GetByIdSimple(team.Id);
            _auditLogService.Log(userId, "Team", newTeam.Id, "UPDATE", oldTeam, newTeam);
        }

        public void Remove(int[] ids, int userId)
        {
            foreach (int id in ids)
            {
                var oldValue = _teamRepository.GetByIdSimple(id);
                _teamRepository.Delete(id);
                _auditLogService.Log(userId, "Team", id, "REMOVE", oldValue, null);
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
