using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace Services.Models
{
    public class TaskPriority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
        public int TaskSizeId { get; set; }
        public string TaskSizeName { get; set; }
        public int TaskSizeExp { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public SolidColorBrush CategoryColor { get; set; }
        public DateTimeOffset WhenTo { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
        
        public int Priority
        { // sizeExp / hoursLeft
            get { return TaskSizeExp / HoursLeft; }
        }
        public int HoursLeft
        {
            get { return WhenTo.Hour - DateTimeOffset.Now.Hour; }
        }
        public string TimeLeft
        {
            get
            {
                int minutesLeft = WhenTo.Minute - DateTimeOffset.Now.Minute;
                int hoursLeft = WhenTo.Hour - DateTimeOffset.Now.Hour;
                if (hoursLeft < -36) return Math.Round((double)hoursLeft / 24) + " days late";
                else if (hoursLeft < -1) return hoursLeft + " hours late";
                else if (hoursLeft == -1) return hoursLeft + " hour late";
                else if (minutesLeft < -1) return minutesLeft + " minutes late";
                else if (minutesLeft == -1) return minutesLeft + " minute late";
                else if (minutesLeft == 0) return '<' + minutesLeft + " minute left";
                else if (minutesLeft == 1) return minutesLeft + " minute left";
                else if (minutesLeft < 60) return minutesLeft + " minutes left";
                else if (hoursLeft == 1) return hoursLeft + " hour left";
                else if (hoursLeft < 36) return hoursLeft + " hours left";
                else return Math.Round((double)hoursLeft / 24) + " days left";
            }
        }
    }
}
