using System.Drawing;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Esorb.Certificate.Output
{
    public class WordVersuche
    {
        public static void FirstTest()
        {
            using var document = DocX.Load(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Vorlage.docx");
            document.SaveAs(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis.docx");
        }
        public static void SecondTest()
        {
            using Document document = DocX.Load(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Anfang.docx");
            document.InsertParagraph();
            Paragraph p = document.InsertParagraph("Zeugnis").FontSize(18).Bold();
            p.Alignment = Alignment.center;
            p = document.InsertParagraph("für").FontSize(11);
            p.Alignment = Alignment.center;
            p = document.InsertParagraph("Lieschen Müller").FontSize(14).Bold();
            p.Alignment = Alignment.center;
            document.InsertParagraph();
            p = document.InsertParagraph("geboren am 20.12.2012").FontSize(11);
            p.Alignment = Alignment.center;
            document.InsertParagraph();
            p = document.InsertParagraph("Klasse 3a               Schuljahr 2022/2023               . Halbjahr").FontSize(11);
            p.Alignment = Alignment.center;
            p.InsertHorizontalLine(HorizontalBorderPosition.top, BorderStyle.Tcbs_single);
            p = document.InsertParagraph("versäumte Stunden 0, davon unentschuldigt 0 Stunde(n)").FontSize(10);
            p.Alignment = Alignment.center;
            p.InsertHorizontalLine(HorizontalBorderPosition.bottom, BorderStyle.Tcbs_single);
            p = document.InsertParagraph();
            p = document.InsertParagraph();
            p = document.InsertParagraph("Aussagen zum Arbeits- und Sozialverhalten").FontSize(14).Bold();
            p.Alignment = Alignment.center;

            p = document.InsertParagraph();
            Table t = document.AddTable(1, 5);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            Xceed.Document.NET.Font Wingdings = new("Wingdings");

            t.Rows[0].Cells[0].Paragraphs[0].Append("Arbeitszeitverhalten").FontSize(12).Bold();
            t.Rows[0].Cells[1].Paragraphs[0].Append("nnnn").Font(Wingdings).FontSize(11).Color(Color.Gray).Alignment = Alignment.center;
            t.Rows[0].Cells[2].Paragraphs[0].Append("nnn").Font(Wingdings).FontSize(11).Color(Color.Gray).Alignment = Alignment.center;
            t.Rows[0].Cells[3].Paragraphs[0].Append("nn").Font(Wingdings).FontSize(11).Color(Color.Gray).Alignment = Alignment.center;
            t.Rows[0].Cells[4].Paragraphs[0].Append("n").Font(Wingdings).FontSize(11).Color(Color.Gray).Alignment = Alignment.center;

            t.SetWidths(new float[] { 342f, 46f, 46f, 46f, 46f });
            p.InsertTableAfterSelf(t);

            p = document.InsertParagraph();
            t = document.AddTable(1, 6);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            Xceed.Document.NET.Font Wingdings2 = new("Wingdings 2");

            t.Rows[0].Cells[0].Paragraphs[0].Append("—").Font(Wingdings2).FontSize(11);
            t.Rows[0].Cells[1].Paragraphs[0].Append("beteiligte sich mit sachbezogenen Beiträgen am Unterricht\t").FontSize(10);
            t.Rows[0].Cells[1].Paragraphs[0].InsertTabStopPosition(Alignment.left, 312f, TabStopPositionLeader.dot);
            t.Rows[0].Cells[2].Paragraphs[0].Append("S").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            t.Rows[0].Cells[2].VerticalAlignment = VerticalAlignment.Bottom;
            t.Rows[0].Cells[3].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            t.Rows[0].Cells[3].VerticalAlignment = VerticalAlignment.Bottom;
            t.Rows[0].Cells[4].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            t.Rows[0].Cells[4].VerticalAlignment = VerticalAlignment.Bottom;
            t.Rows[0].Cells[5].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            t.Rows[0].Cells[5].VerticalAlignment = VerticalAlignment.Bottom;

            t.SetWidths(new float[] { 10f, 332f, 46f, 46f, 46f, 46f });

            var r = t.InsertRow();
            r.Cells[0].Paragraphs[0].Append("—").Font(Wingdings2).FontSize(11);
            r.Cells[1].Paragraphs[0].Append("liest und schreibt Wörter und einfache Sätze aus bekannten Wortfeldern\t").FontSize(10);
            r.Cells[1].Paragraphs[0].InsertTabStopPosition(Alignment.left, 312f, TabStopPositionLeader.dot);
            r.Cells[2].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            r.Cells[2].VerticalAlignment = VerticalAlignment.Bottom;
            r.Cells[3].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            r.Cells[3].VerticalAlignment = VerticalAlignment.Bottom;
            r.Cells[4].Paragraphs[0].Append("£").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            r.Cells[4].VerticalAlignment = VerticalAlignment.Bottom;
            r.Cells[5].Paragraphs[0].Append("S").Font(Wingdings2).FontSize(11).Alignment = Alignment.center;
            r.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;

            p.InsertTableAfterSelf(t);

            p = document.InsertParagraph().FontSize(3);
            t = document.AddTable(1, 2);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            t.SetWidths(new float[] { 342f, 184f });
            t.Rows[0].Cells[0].Paragraphs[0].Append("Note:").FontSize(12).Bold().Alignment = Alignment.right;
            t.Rows[0].Cells[1].Paragraphs[0].Append("befriedigend").FontSize(12).Bold().Alignment = Alignment.center;

            p.InsertTableAfterSelf(t);

            p = document.InsertParagraph().FontSize(3);
            t = document.AddTable(1, 2);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            t.SetWidths(new float[] { 342f, 184f });
            t.Rows[0].Cells[0].Paragraphs[0].Append("Gesamtnote Deutsch:").FontSize(12).Bold().Alignment = Alignment.right;
            t.Rows[0].Cells[1].Paragraphs[0].Append("ungenügend").FontSize(12).Bold().Alignment = Alignment.center;

            p.InsertTableAfterSelf(t);


            p = document.InsertParagraph();
            p = document.InsertParagraph("Bemerkungen:").FontSize(12).Bold();
            p = document.InsertParagraph("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no s");
            p = document.InsertParagraph();
            p = document.InsertParagraph("Lieschen Müller wird in Klasse 4 versetzt.").FontSize(12).Bold();
            p = document.InsertParagraph();

            t = document.AddTable(1, 2);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            t.SetWidths(new float[] { 263f, 263f });
            t.Rows[0].Cells[0].Paragraphs[0].Append("Konferenzbeschluss vom ").FontSize(11);
            t.Rows[0].Cells[1].Paragraphs[0].Append("Rösrath, den 01.02.2023").FontSize(11).Alignment = Alignment.right;

            p.InsertTableAfterSelf(t);
            p = document.InsertParagraph().FontSize(3);

            t = document.AddTable(2, 3);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            t.SetWidths(new float[] { 196f, 133f, 196f });
            t.Rows[0].Cells[0].Paragraphs[0].Append("").FontSize(11);
            t.Rows[0].Cells[0].InsertParagraph();
            t.Rows[0].Cells[0].InsertParagraph();
            var pp = t.Rows[0].Cells[0].InsertParagraph();
            pp.InsertHorizontalLine(HorizontalBorderPosition.bottom, BorderStyle.Tcbs_single);


            t.Rows[0].Cells[1].Paragraphs[0].Append("(Siegel der Schule)").FontSize(8).Alignment = Alignment.center;

            t.Rows[0].Cells[2].Paragraphs[0].Append("").FontSize(11);
            t.Rows[0].Cells[2].InsertParagraph();
            t.Rows[0].Cells[2].InsertParagraph();
            pp = t.Rows[0].Cells[2].InsertParagraph();
            pp.InsertHorizontalLine(HorizontalBorderPosition.bottom, BorderStyle.Tcbs_single);

            t.Rows[1].Cells[0].Paragraphs[0].Append("Klassenlehrer").FontSize(11).Alignment = Alignment.center;
            t.Rows[1].Cells[2].Paragraphs[0].Append("Schulleiter").FontSize(11).Alignment = Alignment.center;

            p.InsertTableAfterSelf(t);

            p = document.InsertParagraph().FontSize(3);
            p = document.InsertParagraph("Hinweise zum Zeugnis").FontSize(11).Bold();
            p.Alignment = Alignment.center;
            p.InsertHorizontalLine(HorizontalBorderPosition.top, BorderStyle.Tcbs_single);

            p = document.InsertParagraph("Legende:").FontSize(8).Bold();
            p = document.InsertParagraph("nnnn").Font(Wingdings).FontSize(8).Color(Color.Gray);
            p.Alignment = Alignment.center;
            p.Append(" = oberer Bereich, ").FontSize(8).Bold();
            p.Append("nnn").Font(Wingdings).FontSize(8).Color(Color.Gray);
            p.Append(" = mittlerer Bereich Tendenz nach oben, ").FontSize(8).Bold();
            p.Append("nn").Font(Wingdings).FontSize(8).Color(Color.Gray);
            p.Append(" = mittlerer Bereich Tendenz nach unten, ").FontSize(8).Bold();
            p.Append("n").Font(Wingdings).FontSize(8).Color(Color.Gray);
            p.Append(" = unterer Bereich").FontSize(8).Bold();
            document.SaveAs(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis1.docx");
        }
    }
}