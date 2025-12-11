using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Extensions
{
    public static class DbInitializer
    {
        public static void BasicInitialization(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskSize>().HasData(
                new TaskSize() { Id = 1, Name = "Little (<2 hours)", Experience = 3 },
                new TaskSize() { Id = 2, Name = "Medium (<8 hours)", Experience = 10 },
                new TaskSize() { Id = 3, Name = "Great (<2 days)", Experience = 30 },
                new TaskSize() { Id = 4, Name = "Huge (>2 days)", Experience = 50 }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Uncategorized", Color = "#808080" }
                );
            modelBuilder.Entity<Theme>().HasData(
                new Theme() { Id = 1, Name = "Light Green", 
                    Accent = "#30AD11", Foreground = "#181818", SubForeground = "#616161",
                    Background = "#FFFFFF", SubBackground = "#D1E0D2"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User() { UserName = null, TotalExperience = 0, TasksCompleted = 0, CreatedAt = DateTime.Now, ActiveThemeId = 1}
                );
        }
    }
}
