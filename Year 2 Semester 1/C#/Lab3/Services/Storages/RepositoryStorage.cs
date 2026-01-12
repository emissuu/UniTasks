using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Storages
{
    public class RepositoryStorage
    {
        public AdministratorRepository _adminRepo;
        public EventBlockRepository _eventBlockRepo;
        public EventRepository _eventRepo;
        public IncidentRepository _incidentRepo;
        public PartnerRepository _partnerRepo;
        public PersonRepository _personRepo;
        public TeamMemberRepository _teamMemberRepo;
        public TeamRepository _teamRepo;
        public TicketRepository _ticketRepo;
        public WorkerRepository _workerRepo;
        public WorkerShiftRepository _workerShiftRepo;
        public ZoneActivationRepository _zoneActivationRepo;
        public ZoneRepository _zoneRepo;

        public RepositoryStorage(DbContext context)
        {
            _adminRepo = new AdministratorRepository(context);
            _eventBlockRepo = new EventBlockRepository(context);
            _eventRepo = new EventRepository(context);
            _incidentRepo = new IncidentRepository(context);
            _partnerRepo = new PartnerRepository(context);
            _personRepo = new PersonRepository(context);
            _teamMemberRepo = new TeamMemberRepository(context);
            _teamRepo = new TeamRepository(context);
            _ticketRepo = new TicketRepository(context);
            _workerRepo = new WorkerRepository(context);
            _workerShiftRepo = new WorkerShiftRepository(context);
            _zoneActivationRepo = new ZoneActivationRepository(context);
            _zoneRepo = new ZoneRepository(context);
        }
    }
}