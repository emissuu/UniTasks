# Лабораторна робота №2  
**Тема:** Моделювання предметної області та створення реляційної бази даних у C# за допомогою EF Core (Code First)  
**Студент:** Луцюк Богдан Олександрович КН-213  
**Варіант:** 32 - Координатор подій, що організовує фестивалі  
**Дата:** 14.11.2025  
**Посилання на репозиторій:** https://github.com/emissuu/UniTasks/tree/main/C%23/Lab2

<!-- The dialog: https://kleban.notion.site/2-2a6c0ae924ac8074b50aced556a4c72f?p=2a6c0ae924ac8157ab24c1cc5d9226d1&pm=s -->

## 2. Мета роботи 
**Навчитися:**
- аналізувати предметну область і будувати концептуальну модель;
- створювати об’єктно-реляційну модель за допомогою **Entity Framework Core (Code First)**;
- поетапно розвивати структуру бази даних через **окремі міграції для кожної сутності**;
- ініціалізувати дані та виконувати базові запити LINQ.

## 3. Хід виконання
### 3.1. Аналіз предметної області (опис, таблиці, діаграма).
Після аналізу діалогу студента з закажчиком було винесено 15 сутностей:  
- Participants: *id, name, transport, arrives_at, hand_color, contact_number, notes.
- TeamMembers: *id, participant_id, name, role, contact_number.
- Accreditations: *id, team_member_id, valid_from, valid_to.

- Stages: *id, name, location, capacity.
- Performances: *id, participant_id, stage_id, starts_at, ends_at.
- TechnicalBreaks: *id, stage_id, starts_at, ends_at, notes.

- Volunteers: *id, name, contact_number, role.
- VolunteerShifts: *id, volunteer_id, zone_id, starts_at, ends_at.
  
- Partners: *id, name, contact_number.
- Zones: *id, name, type, location.
- ActivationZones: *id, partner_id, zone_id, required_power, notes.
- LogisticItems: *id, zone_id, name, quantity.

- Tickets: *id, qr_code, type, buyer_name, contact_number, entrance_date, status.
- Incidents: *id, zone_id, ticket_id, type, description, happened_at.
- DailyReports: *id, date, summary, contents.

З цих сутностей було побудовано схему:  

![Схема бази даних в LucidApp](ReadmeResources/EventOrganizerDB_LucidApp-scheme.png)
### 3.2. Створення класів сутностей та контексту бази даних.
Було створено клас C# для кожної сутності бази даних. Ось зразок одного з таких класів:

```cs
public class TeamMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Role { get; set; }
    public string? Contact_Number { get; set; }

    [Required]
    public int Participant_Id { get; set; }
    [ForeignKey(nameof(Participant_Id))]
    public Participant Participant { get; set; } = default!;

    public ICollection<Accreditation> Accreditations { get; set; } = new List<Accreditation>();
}
```

Фінальний код AppDbContext:

```cs
public class AppDbContext : DbContext
{
    public DbSet<Participant> Participants => Set<Participant>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Accreditation> Accreditations => Set<Accreditation>();
    public DbSet<Stage> Stages => Set<Stage>();
    public DbSet<Performance> Performances => Set<Performance>();
    public DbSet<TechnicalBreak> TechnicalBreaks => Set<TechnicalBreak>();
    public DbSet<Volunteer> Volunteers => Set<Volunteer>();
    public DbSet<Zone> Zones => Set<Zone>();
    public DbSet<VolunteerShift> VolunteersShifts => Set<VolunteerShift>();
    public DbSet<Partner> Partners => Set<Partner>();
    public DbSet<ActivationZone> ActivationZones => Set<ActivationZone>();
    public DbSet<LogisticItem> LogisticItems => Set<LogisticItem>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Incident> Incidents => Set<Incident>();
    public DbSet<DailyReport> DailyReports => Set<DailyReport>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EventOrganizerDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;Command Timeout=0");
        base.OnConfiguring(optionsBuilder);
    }
}
```

### 3.3. Послідовність створених міграцій (із коротким описом змін).
Я створював міграції відразу після написання сутностей і налаштування зв'язків між ними. Перші міграції також включали в себе виправлення помилок в минулих сутностях. Ось фінальна таблиця всіх міграцій зображена в DBeaver.  
![Міграції показані в DBeaver](ReadmeResources/Migrations_DBeaver.png)

### 3.4. Ініціалізація даних та приклади запитів LINQ.
Частина коду ініціалізації даних:
```cs
public static class DbInitializer
{
    public static void SeedTHEData(this ModelBuilder modelBuilder)
    {
        // ===== Participants =====
        modelBuilder.Entity<Participant>().HasData(
            new Participant { Id = 1, Name = "SuperCoolBand", Arrives_At = new DateTime(2024, 7, 10, 14, 0, 0), Contact_Number = "555-1234", Hand_Color = "Red", Notes = "Requires soundcheck at 3 PM" },
            new Participant { Id = 2, Name = "JazzMasters", Arrives_At = new DateTime(2024, 7, 11, 10, 0, 0), Contact_Number = "555-5678", Hand_Color = "Blue", Notes = "Bringing their own equipment" }
            );

        // ===== TeamMembers =====
        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, Name = "Alice", Role = "Vocalist", Participant_Id = 1, Contact_Number = "555-4128"},
            new TeamMember { Id = 2, Name = "Bob", Role = "Guitarist", Participant_Id = 1, Contact_Number = "555-4312" },
            new TeamMember { Id = 3, Name = "Charlie", Role = "Saxophonist", Participant_Id = 2, Contact_Number = "555-9412" },
            new TeamMember { Id = 4, Name = "Diana", Role = "Drummer", Participant_Id = 2, Contact_Number = "555-9481" },
            new TeamMember { Id = 5, Name = "Eve", Role = "Drummer", Participant_Id = 1, Contact_Number = "555-4144" }
            );
    }
}
```

Приклади запитів LINQ:
```cs
using (var context = new Main.Context.AppDbContext())
{
    // ===== Where =====
    Console.WriteLine("1. Where");
    List<Participant> participants = context.Participants
        .Where(a => a.Id == 1)
        .ToList();
    Console.WriteLine("Participants with Id = 1:");
    foreach (var participant in participants)
        Console.WriteLine($"Id {participant.Id}. Participant: {participant.Name}, Contact phone: {participant.Contact_Number}");

    // ===== FindOrDefault =====
    Console.WriteLine("\n2. FirstOrDefault");
    TeamMember teamMember = context.TeamMembers
        .FirstOrDefault(a => a.Id == 6);
    if (teamMember != null) Console.WriteLine($"Team Member with Id = 6: {teamMember.Name}");
    else Console.WriteLine("Team Member with Id = 6 not found.");

    // ===== Include =====
    Console.WriteLine("\n\n3. Include");
    List<TeamMember> teamMembers = context.TeamMembers
        .Include(a => a.Participant)
        .ToList();
    Console.WriteLine("Team Members with Participant included:");
    foreach (var member in teamMembers)
        Console.WriteLine($"Id {member.Id}. Team Member: {member.Name} is a member of {member.Participant.Name}");

    // ===== OrderBy =====
    Console.WriteLine("\n\n4. OrderBy");
    List<Accreditation> accreditations = context.Accreditations
        .OrderBy(a => a.Valid_To)
        .Include(a => a.Team_Member)
        .ToList();
    Console.WriteLine("Accreditations sorted by valid_to:");
    foreach (var accreditation in accreditations)
        Console.WriteLine($"Id {accreditation.Id}. Team Member: {accreditation.Team_Member.Name}, Valid To: {accreditation.Valid_To}");

    // ===== Average =====
    Console.WriteLine("\n\n5. Average");
    double? averagePerformances = context.Performances
        .Average(a => EF.Functions.DateDiffMinute(a.Starts_At, a.Ends_At));
    Console.WriteLine($"Average performance duration in minutes: {averagePerformances}");
}
```

Результати виконання LINQ запитів:  
![Результати LINQ запитів](ReadmeResources/LINQ_results.png)

LINQ запити є дуже потужним  та зручним інструментом для вибірки даних. Вони є невід'ємною частиною будь-якої програми, яка взаємодії з базами даних.

## 4. Результати роботи
Схема зв'язків зображена в DBeaver.
![Схема бази даних в DBeaver](ReadmeResources/EventOrganizerDB_DBeaver-scheme.png)

## 5. Висновки 
