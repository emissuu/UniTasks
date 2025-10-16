using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DataProcessingRestored.ChartHandling;

namespace DataProcessing.Data.Reports
{
    public class DocxReportService : IReportable
    {
        public void GenerateReport(string path)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new();
                EnsureListStyle(mainPart);
                Body body = mainPart.Document.AppendChild(new Body());
                AddParagraph(body, "MusicStore report", 48, true);
                AddParagraph(body, "As of " + DateTime.UtcNow + " UTC", 36);
                AddParagraph(body, "");
                AddParagraph(body, $"Dataset {CurrentSession.Data.Name} contains data about music albums. The data primarly focuses on basic information about the album and has link to each one of them.");
                AddParagraph(body, "Fields:", 36);

                
                foreach (var item in new string[]
                {
                    "Id: Unique identifier for each album",
                    "Title: The name of the album",
                    "Artist: The name of performing artist",
                    "Release_date: The date the album was released",
                    "Genres: A list of genres associated with the album",
                    "User_score: Rating given by user from 0 to 100",
                    "Rating_count: The number of ratings given",
                    "Album_link: Url pointing to the album source"
                })
                {
                    AddListItem(body, item);
                }
                AddParagraph(body, "");
                AddParagraph(body, "Summary of size of the dataset:", 36);
                foreach (var item in new string[]
                {
                    $"Total unique albums: {CurrentSession.Data.Albums.Count}",
                    $"Total unique artists: {CurrentSession.Data.Artists.Count}",
                    $"Total unique genres: {CurrentSession.Data.Genres.Count}"
                })
                {
                    AddListItem(body, item);
                }
                AddParagraph(body, "");
                AddParagraph(body, "Data-based charts:", 36);
                AddImageToBody(doc, ChartHandler.ChartType.ArtistAlbumCount);
                AddParagraph(body, "Reveals the most prolific artists in the collection, indicating biases or focus areas of the dataset towards specific creators.");
                AddImageToBody(doc, ChartHandler.ChartType.GenrePopularity);
                AddParagraph(body, "Shows the distribution of albums across genres, highlighting which genres are most frequently met through the dataset.");
                AddImageToBody(doc, ChartHandler.ChartType.AlbumsPerYear);
                AddParagraph(body, "Provides a time analysis, showing the number of albums released per year. This chart highlights peaks of artist's activity.");
            }
        }

        private void AddParagraph(Body body, string text, int fontSize = 24, bool bold = false)
        {
            body.AppendChild(new Paragraph())
                .AppendChild(new Run(
                    new RunProperties(
                        new FontSize() { Val = fontSize.ToString() },
                        new Bold() { Val = bold },
                        new Languages() { Val = "en-US"}
                        ),
                    new Text(text)
                    ));
        }
        private void AddListItem(Body body, string text)
        {
            Paragraph para = body.AppendChild(new Paragraph());
            ParagraphProperties pp = new ParagraphProperties();
            NumberingProperties np = new NumberingProperties(
                new NumberingLevelReference() { Val = 0 },
                new NumberingId() { Val = 1 });
            pp.Append(np);
            para.Append(pp);
            Run run = para.AppendChild(new Run(
                    new RunProperties(
                            new Languages() { Val = "en-US" }
                        )
                ));
            run.AppendChild(new Text(text));
        }
        private void AddImageToBody(WordprocessingDocument wordDoc, ChartHandler.ChartType chartType)
        {
            string imagePath = chartType switch
            {
                ChartHandler.ChartType.ArtistAlbumCount => ".\\TempResources\\ArtistAlbumCountChart.png",
                ChartHandler.ChartType.GenrePopularity => ".\\TempResources\\GenrePopularityChart.png",
                ChartHandler.ChartType.AlbumsPerYear => ".\\TempResources\\AlbumsPerYearChart.png"
            };
            ChartHandler.GeneratePngChart(chartType, "", imagePath);

            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);

            using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            AddImageToParagraph(mainPart.Document.Body, mainPart.GetIdOfPart(imagePart));
        }
        private static void AddImageToParagraph(Body body, string imagePartId)
        {
            long imageWidth = 5486400L;
            long imageHeight = 4114800L;

            var element = new Drawing(
                new DW.Inline(
                    new DW.Extent() { Cx = imageWidth, Cy = imageHeight },
                    new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                    new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
                    new DW.NonVisualGraphicFrameDrawingProperties(
                        new A.GraphicFrameLocks() { NoChangeAspect = true }),
                    new A.Graphic(
                        new A.GraphicData(
                            new PIC.Picture(
                                new PIC.NonVisualPictureProperties(
                                    new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)0U, Name = "New Picture" },
                                    new PIC.NonVisualPictureDrawingProperties()),
                                new PIC.BlipFill(
                                    new A.Blip(new A.BlipExtensionList(new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" }))
                                    {
                                        Embed = imagePartId,
                                        CompressionState = A.BlipCompressionValues.Print
                                    },
                                    new A.Stretch(new A.FillRectangle())),
                                new PIC.ShapeProperties(
                                    new A.Transform2D(
                                        new A.Offset() { X = 0L, Y = 0L },
                                        new A.Extents() { Cx = imageWidth, Cy = imageHeight }),
                                    new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })))
                        { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                )
                {
                    DistanceFromTop = (UInt32Value)0U,
                    DistanceFromBottom = (UInt32Value)0U,
                    DistanceFromLeft = (UInt32Value)0U,
                    DistanceFromRight = (UInt32Value)0U,
                    EditId = "50D07946"
                });

            body.AppendChild(new Paragraph(new Run(element)));
        }

        private void EnsureListStyle(MainDocumentPart mainPart)
        {
            NumberingDefinitionsPart numberingPart;
            if (mainPart.NumberingDefinitionsPart == null)
            {
                numberingPart = mainPart.AddNewPart<NumberingDefinitionsPart>();
                Numbering numbering = new Numbering(
                    new AbstractNum(
                        new Level(
                            new NumberingFormat() { Val = NumberFormatValues.Bullet },
                            new LevelText() { Val = "•" }
                        )
                        { LevelIndex = 0 }
                    )
                    { AbstractNumberId = 1 },
                    new NumberingInstance(
                        new AbstractNumId() { Val = 1 }
                    )
                    { NumberID = 1 }
                );
                numbering.Save(numberingPart);
            }
            else
            {
                numberingPart = mainPart.NumberingDefinitionsPart;
            }
        } 
    }
}
