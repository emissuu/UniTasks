using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Models.Entities;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;

namespace DataProcessingRestored.ChartHandling
{
    public static class ChartHandler
    {
        public enum ChartType
        {
            ArtistAlbumCount,
            GenrePopularity,
            AlbumsPerYear,
            ScoreDistribution
        }

        public static PlotModel GenerateChart(ChartType chartType, string title)
        {
            return chartType switch
            {
                ChartType.ArtistAlbumCount => GenerateArtistAlbumCountChart(title),
                ChartType.GenrePopularity => GenerateGenrePopularityChart(title),
                ChartType.AlbumsPerYear => GenerateSongsPerYearChart(title),
                ChartType.ScoreDistribution => GenerateScoreDistributionChart(title)
            };
        }

        public static void GeneratePngChart(ChartType chartType, string title, string filePath)
        {
            var model = GenerateChart(chartType, title);
            model.Background = OxyColors.White;
            var pngExporter = new PngExporter { Width = 800, Height = 600 };
            using (var stream = File.Create(filePath))
            {
                pngExporter.Export(model, stream);
            }
        }

        // Generating charts

        private static PlotModel GenerateArtistAlbumCountChart(string title)
        {
            var model = new PlotModel { Title = title == "" ? "Top 12 Artists by Album Count" : title};

            var artistSongCounts = CurrentSession.Data.Albums
                .GroupBy(s => s.Artist_Id)
                .Select(g => new { ArtistId = g.Key, Count = g.Count() })
                .Join(CurrentSession.Data.Artists, sc => sc.ArtistId, a => a.Id, (sc, a) => new { ArtistName = a.Name, sc.Count })
                .OrderByDescending(x => x.Count)
                .Take(12)
                .OrderBy(x => x.Count)
                .ToList();

            model.Axes.Add(new CategoryAxis { Position = AxisPosition.Left, ItemsSource = artistSongCounts.Select(a => a.ArtistName).Reverse() });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, AbsoluteMinimum = 0 });

            var barSeries = new BarSeries();
            foreach (var item in artistSongCounts)
            {
                barSeries.Items.Add(new BarItem { Value = item.Count });
            }
            model.Series.Add(barSeries);
            return model;
        }

        private static PlotModel GenerateGenrePopularityChart(string title)
        {
            var model = new PlotModel { Title = title == "" ? "Top Genres by Album Count" : title};

            var genreCounts = CurrentSession.Data.Albums
            .SelectMany(s => s.Genre_Ids)
            .GroupBy(genreId => genreId)
            .Select(g => new { GenreId = g.Key, Count = g.Count() })
            .Join(CurrentSession.Data.Genres, gc => gc.GenreId, g => g.Id, (gc, g) => new { GenreName = g.Name, gc.Count })
            .OrderByDescending(x => x.Count)
            .Take(24)
            .ToList();

            var pieSeries = new PieSeries
            {
                StrokeThickness = 1.0,
                InsideLabelPosition = 0.8,
                AreInsideLabelsAngled = true,
                AngleSpan = 360,
                StartAngle = 0,
                TickRadialLength = 3,
                TickHorizontalLength = 4,
                TickDistance = 0,
                FontSize = 10,
            };

            foreach (var item in genreCounts)
            {
                pieSeries.Slices.Add(new PieSlice(item.GenreName, item.Count) { IsExploded = false });
            }

            model.Series.Add(pieSeries);
            return model;
        }


        private static PlotModel GenerateSongsPerYearChart(string title)
        {
            var model = new PlotModel { Title = title == "" ? "Albums Released Per Year" : title};

            var songsPerYear = CurrentSession.Data.Albums
                .GroupBy(s => s.Released_At.Year)
                .Select(g => new { Year = g.Key, Count = g.Count() })
                .OrderBy(x => x.Year)
                .ToList();

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, StringFormat = "0", Title = "Year" });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0.1, AbsoluteMinimum = 0, Title = "Number of Songs" });

            var lineSeries = new LineSeries { MarkerType = MarkerType.Circle };
            foreach (var item in songsPerYear)
            {
                lineSeries.Points.Add(new DataPoint(item.Year, item.Count));
            }

            model.Series.Add(lineSeries);
            return model;
        }

        private static PlotModel GenerateScoreDistributionChart(string title)
        {
            var model = new PlotModel { Title = title == "" ? "Distribution of User Scores" : title};

            var scoreBrackets = CurrentSession.Data.Albums
                .Select(s => (s.User_Score / 10) * 10)
                .GroupBy(bracket => bracket)
                .Select(g => new { ScoreBracket = g.Key, Count = g.Count() })
                .OrderBy(x => x.ScoreBracket)
                .ToList();

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Score Range",
                ItemsSource = scoreBrackets.Select(b => $"{b.ScoreBracket}-{b.ScoreBracket + 9}")
            };

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                AbsoluteMinimum = 0,
                Title = "Number of Songs"
            };

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            var barSeries = new BarSeries();
            foreach (var bracket in scoreBrackets)
            {
                barSeries.Items.Add(new BarItem { Value = bracket.Count });
            }

            model.Series.Add(barSeries);
            return model;
        }
    }
}
