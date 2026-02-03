using Task = Data.Models.Task;

namespace Services.Models
{
    public class TaskDetails : Task
    {
        public int GetStatus
        {
            get
            {
                return StatusId - 1;
            }
        }

        public string GetDueTo
        {
            get
            {
                return DueDate.ToString("g");
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
