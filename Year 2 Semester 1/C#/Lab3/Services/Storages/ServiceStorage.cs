using Microsoft.EntityFrameworkCore;
using Services.Implementations;

namespace Services.Storages
{
    public class ServiceStorage
    {
        public AdministratorService _adminServ;
        public EventBlockService _eventBlockServ;
        public EventService _eventServ;
        public IncidentService _incidentServ;
        public PartnerService _partnerServ;
        public PersonService _personServ;
        public TeamMemberService _teamMemberServ;
        public TeamService _teamServ;
        public TicketService _ticketServ;
        public WorkerService _workerServ;
        public WorkerShiftService _workerShiftServ;
        public ZoneActivationService _zoneActivationServ;
        public ZoneService _zoneServ;

        public ServiceStorage(RepositoryStorage repositoryStorage)
        {
            _adminServ = new AdministratorService(repositoryStorage._adminRepo);
            _eventBlockServ = new EventBlockService(repositoryStorage._eventBlockRepo);
            _eventServ = new EventService(repositoryStorage._eventRepo);
            _incidentServ = new IncidentService(repositoryStorage._incidentRepo);
            _partnerServ = new PartnerService(repositoryStorage._partnerRepo);
            _personServ = new PersonService(repositoryStorage._personRepo);
            _teamMemberServ = new TeamMemberService(repositoryStorage._teamMemberRepo);
            _teamServ = new TeamService(repositoryStorage._teamRepo);
            _ticketServ = new TicketService(repositoryStorage._ticketRepo);
            _workerServ = new WorkerService(repositoryStorage._workerRepo);
            _workerShiftServ = new WorkerShiftService(repositoryStorage._workerShiftRepo);
            _zoneActivationServ = new ZoneActivationService(repositoryStorage._zoneActivationRepo);
            _zoneServ = new ZoneService(repositoryStorage._zoneRepo);
        }
    }
}