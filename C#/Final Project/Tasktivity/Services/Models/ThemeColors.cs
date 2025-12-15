using Data.Models;
using Avalonia.Media;

namespace Services.Models
{
    public class ThemeColors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SolidColorBrush Accent { get; set; }
        public SolidColorBrush Foreground { get; set; }
        public SolidColorBrush SubForeground { get; set; }
        public SolidColorBrush SubSubForeground { get; set; }
        public SolidColorBrush Background { get; set; }
        public SolidColorBrush SubBackground { get; set; }
        public SolidColorBrush SubSubBackground { get; set; }
        public ThemeColors(Theme theme)
        {
            Id = theme.Id;
            Name = theme.Name;
            Accent = new SolidColorBrush(Color.Parse(theme.Accent));
            Foreground = new SolidColorBrush(Color.Parse(theme.Foreground));
            SubForeground = new SolidColorBrush(Color.Parse(theme.SubForeground));
            SubSubForeground = new SolidColorBrush(Color.Parse(theme.SubSubForeground));
            Background = new SolidColorBrush(Color.Parse(theme.Background));
            SubBackground = new SolidColorBrush(Color.Parse(theme.SubBackground));
            SubSubBackground = new SolidColorBrush(Color.Parse(theme.SubSubBackground));
        }
    }
}
