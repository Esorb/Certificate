using Esorb.Certificate.App.Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.App.Excel
{
    public class CertificateMasterLoader
    {
        private DbHelper DbHelper = new();
        public void UpdateCertificateTemplates(string filePath)
        {
            DbHelper.PrepareDatabaseForCertificateTemplateUpdate();
            LoadExcelFileIntoDatabase(filePath);
        }

        private void LoadExcelFileIntoDatabase(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(stream);

                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);

                    if (sheet.SheetName == "Zensuren")
                    {
                        Grades2Database(sheet);
                    }

                    if (sheet.SheetName.StartsWith("Jahrgang") || sheet.SheetName.Equals("LFE"))
                    {
                        Templates2Database(sheet);
                    }
                }
            }
        }

        private void Grades2Database(ISheet sheet)
        {
            for (int j = 1; j <= sheet.LastRowNum; j++)
            {
                IRow row = sheet.GetRow(j);
                GradeLimit gl = new();
                for (int k = 0; k < row.LastCellNum; k++)
                {
                    ICell cell = row.GetCell(k);
                    if (k == 0)
                    {
                        gl.PercentageLimit = cell.NumericCellValue;
                    }
                    if (k == 1)
                    {
                        gl.Grade = cell.StringCellValue;
                    }
                    if (k == 2)
                    {
                        gl.GradeNumeric = (int)cell.NumericCellValue;
                    }
                }
                gl.Save();
            }

        }

        private void Templates2Database(ISheet sheet)
        {
            CertificateTemplate ct = new();

            IRow row = sheet.GetRow(1);
            ICell cell = row.GetCell(1);
            ct.Yearlevel = (int)cell.NumericCellValue;

            row = sheet.GetRow(0);
            cell = row.GetCell(1);
            ct.AbbForFileName = cell.StringCellValue;

            row = sheet.GetRow(2);
            cell = row.GetCell(1);
            string Abb = cell.StringCellValue;

            if (Abb.Equals("Ja"))
            {
                ct.PupilTransferDecision = true;
            }
            else
            {
                ct.PupilTransferDecision = false;
            }

            if (sheet.SheetName.Contains("HJ 1"))
            {
                ct.HalfYear = 1;
                ct.IsFullYearReport = false;
            }

            else if (sheet.SheetName.Contains("HJ 2"))
            {
                ct.HalfYear = 2;
                ct.IsFullYearReport = false;
            }

            else
            {
                ct.HalfYear = 2;
                ct.IsFullYearReport = true;
            }

            if (sheet.SheetName.Equals("LFE"))
            {
                ct.PupilTransferDecision = false;
                ct.HalfYear = 0;
                ct.IsFullYearReport = false;
            }

            ct.Save();
            Content2Database(sheet, ct);
        }

        private void Content2Database(ISheet sheet, CertificateTemplate ct)
        {
            ICell cell;

            for (int j = 6; j <= sheet.LastRowNum; j++)
            {
                IRow row = sheet.GetRow(j);
                cell = row.GetCell(0);
                if (cell.CellType != CellType.Blank)
                {
                    Content con = new()
                    {
                        Position = j,
                        CertificateTemplateID = ct.ID!
                    };
                    for (int k = 0; k < row.LastCellNum; k++)
                    {
                        cell = row.GetCell(k);
                        if (cell != null)
                        {
                            if (k == 0)
                            {
                                con.Format = cell.StringCellValue;
                            }
                            if (k == 1)
                            {
                                con.Field = cell.StringCellValue;
                            }
                            if (k == 2)
                            {
                                con.Text = cell.StringCellValue;
                            }
                            if (k == 3 && cell.CellType != CellType.Blank)
                            {
                                con.Length = (int)cell.NumericCellValue;
                            }
                            if (k == 4 && cell.CellType != CellType.Blank)
                            {
                                con.WeightLevel1 = (int)cell.NumericCellValue;
                            }
                            if (k == 5 && cell.CellType != CellType.Blank)
                            {
                                con.WeightLevel2 = (int)cell.NumericCellValue;
                            }
                            if (k == 6 && cell.CellType != CellType.Blank)
                            {
                                con.RatingCalculation = cell.StringCellValue;
                            }
                            if (k == 7 && cell.CellType != CellType.Blank)
                            {
                                con.ElectiveSubjectGroup = (int)cell.NumericCellValue;
                            }
                            if (k == 8 && cell.CellType != CellType.Blank)
                            {
                                con.ElectiveSubject = cell.StringCellValue;
                            }
                        }
                    }
                    con.Save();
                }
            }
        }

    }
}
