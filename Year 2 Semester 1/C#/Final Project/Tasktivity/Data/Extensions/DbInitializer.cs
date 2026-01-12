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
                new Category() { Id = 1, Name = "Uncategorized", Color = "#969696" },
                new Category() { Id = 2, Name = "Studying", Color = "#D69722" },
                new Category() { Id = 3, Name = "Personal", Color = "#2670D4" },
                new Category() { Id = 4, Name = "Health", Color = "#34C227" },
                new Category() { Id = 5, Name = "Chores", Color = "#995920" },
                new Category() { Id = 6, Name = "Work", Color = "#23219E" }
                );
            modelBuilder.Entity<Theme>().HasData(
                new Theme() { 
                    Id = 1, 
                    Name = "Grass", 
                    Accent = "#41BA4E", 
                    Foreground = "#071308", 
                    SubForeground = "#1E5724", 
                    SubSubForeground = "#2A7932",
                    Background = "#ECF8ED", 
                    SubBackground = "#CAECCE", 
                    SubSubBackground = "#86D58E"
                },
                new Theme()
                {
                    Id = 2,
                    Name = "Light",
                    Accent = "#765EFD",
                    Foreground = "#211F28",
                    SubForeground = "#4B485B",
                    SubSubForeground = "#75708F",
                    Background = "#F1F1F4",
                    SubBackground = "#D8D7E0",
                    SubSubBackground = "#BFBDCB"
                },
                new Theme()
                {
                    Id = 3,
                    Name = "Dark",
                    Accent = "#493C96",
                    Foreground = "#D8D7E0",
                    SubForeground = "#A7A4B7",
                    SubSubForeground = "#8E8AA3",
                    Background = "#0C0B0E",
                    SubBackground = "#211F28",
                    SubSubBackground = "#343240"
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, UserName = null, TotalExperience = 0, TasksCompleted = 0, CreatedAt = DateTime.Today, ActiveThemeId = 1}
                );
        }
    }
}
