using Data.Models;
using Task = Data.Models.Task;

namespace Services.Models
{
    public class TaskDetails
    {
        public Task task;

        public int Id { get { return task.Id; }  }
        public string Name { get { return task.Name; } }
        public string Details { get { return task.Details; } }
        public Project Project { get { return task.Project; } }
        public User CreatedBy { get { return task.CreatedBy; } }
        public User AssignedTo { get { return task.AssignedTo; } }
        public Status Status { get { return task.Status; } }
        public DateTime CreatedAt { get { return task.CreatedAt; } }
        public DateTime UpdatedAt { get { return task.UpdatedAt; } }
        public DateTime DueDate { get { return task.DueDate; }  }

        public int GetStatus
        {
            get
            {
                return task.StatusId - 1;
            }
            set
            {
                task.StatusId = value + 1; 
            }
        }

        public string GetDueTo
        {
            get
            {
                return task.DueDate.ToString("g");
            }
        }

        public override string ToString()
        {
            return task.Name;
        }
    }
}
