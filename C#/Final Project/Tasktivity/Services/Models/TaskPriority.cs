using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using Data.Models;

namespace Services.Models
{
    public class TaskPriority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
        public TaskSize Size { get; set; }
        public Category Category { get; set; }
        public DateTimeOffset WhenTo { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }

        public SolidColorBrush CategoryColor
        {
            get => new SolidColorBrush(Color.Parse(Category.Color));
            set => CategoryColor = value;
        }
        public int Priority
        { // sizeExp / hoursLeft
            get { return Size.Experience / HoursLeft; }
        }
        public int HoursLeft
        {
            get { return WhenTo.Hour - DateTimeOffset.Now.Hour; }
        }
        public string TimeLeft
        {
            get
            {
                TimeSpan timeLeft = WhenTo - DateTimeOffset.UtcNow;
                int hoursLeft = (int)Math.Floor(timeLeft.TotalHours);
                int minutesLeft = timeLeft.Minutes;
                //int minutesLeft = WhenTo.Minute - DateTimeOffset.Now.Minute;
                //int hoursLeft = WhenTo.Day WhenTo.Hour - DateTimeOffset.Now.Hour;
                if (hoursLeft < -48) return Math.Floor((double)Math.Abs(hoursLeft) / 24) + " days late";
                if (hoursLeft < -36) return "1 day late";
                else if (hoursLeft < -1) return Math.Abs(hoursLeft) + " hours late";
                else if (hoursLeft == -1) return Math.Abs(hoursLeft) + " hour late";
                else if (hoursLeft == 0 && minutesLeft < -1) return Math.Abs(minutesLeft) + " minutes late";
                else if (hoursLeft == 0 && minutesLeft == -1) return Math.Abs(minutesLeft) + " minute late";
                else if (hoursLeft == 0 && minutesLeft == 0) return '<' + minutesLeft + " minute left";
                else if (hoursLeft == 0 && minutesLeft == 1) return minutesLeft + " minute left";
                else if (hoursLeft == 0 && minutesLeft < 60) return minutesLeft + " minutes left";
                else if (hoursLeft == 1) return hoursLeft + " hour left";
                else if (hoursLeft < 36) return hoursLeft + " hours left";
                else if (hoursLeft < 48) return "1 day left";
                else return Math.Floor((double)hoursLeft / 24) + " days left";
            }
        }
        public bool IsCompleted
        {
            get => !(CompletedAt is null);
            set
            {
                if (value)
                    CompletedAt = DateTimeOffset.UtcNow;
                else
                    CompletedAt = null;
            }
        }
    }
}
