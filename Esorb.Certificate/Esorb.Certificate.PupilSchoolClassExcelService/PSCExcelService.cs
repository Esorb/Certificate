using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace Esorb.Certificate.PupilSchoolClassExcelService
{
    public class PSCExcelService
    {
        private readonly string pupilFileName;
        private DataTable dataTable = new();
        private List<string> rows = new();

        public PSCExcelService(string pupilFileName)
        {
            this.pupilFileName = pupilFileName;
        }

        public DataTable DataTable
        {
            get { return dataTable; }
        }


        public void Prepare()
        {
            dataTable.Clear();
            rows.Clear();
            using (FileStream fStream = new(pupilFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                fStream.Position = 0;
                XSSFWorkbook ExcelWorkbook = new(fStream);
                ISheet ExcelWorksheet = ExcelWorkbook.GetSheetAt(0);
                IRow ExcelHeader = ExcelWorksheet.GetRow(0);
                int CountCells = ExcelHeader.LastCellNum;

                for (int j = 0; j < CountCells; j++)
                {
                    ICell ExcelCell = ExcelHeader.GetCell(j);
                    if (ExcelCell is null || string.IsNullOrWhiteSpace(ExcelCell.ToString())) continue;
                    {
                        dataTable.Columns.Add(ExcelCell.ToString());
                    }
                }

                for (int i = (ExcelWorksheet.FirstRowNum + 1); i <= ExcelWorksheet.LastRowNum; i++)
                {
                    IRow ExcelRow = ExcelWorksheet.GetRow(i);
                    if (ExcelRow is null) continue;
                    if (ExcelRow.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = ExcelRow.FirstCellNum; j < CountCells; j++)
                    {
                        if (ExcelRow.GetCell(j) is not null)
                        {
                            if (!string.IsNullOrEmpty(ExcelRow.GetCell(j).ToString()) &&
                                !string.IsNullOrWhiteSpace(ExcelRow.GetCell(j).ToString()))
                            {
                                rows.Add(ExcelRow.GetCell(j).ToString());
                            }
                        }
                    }
                }

                if (rows.Count > 0)
                {
                    dataTable.Rows.Add(rows.ToArray());
                }
                rows.Clear();
            }
        }
    }
}