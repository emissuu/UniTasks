using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    internal class Initializer
    {
        internal static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData
                (
                    new Role() { Id = 1, Name = "Administrator" },
                    new Role() { Id = 2, Name = "Manager" },
                    new Role() { Id = 3, Name = "Programmer" }
                );

            modelBuilder.Entity<Status>()
                .HasData
                (
                    new Status() { Id = 1, Name = "New" },
                    new Status() { Id = 2, Name = "In Progress" },
                    new Status() { Id = 3, Name = "Completed" },
                    new Status() { Id = 4, Name = "On Hold" },
                    new Status() { Id = 5, Name = "Canceled" }
                );
        }
    }
}
