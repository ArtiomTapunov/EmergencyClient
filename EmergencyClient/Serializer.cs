using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.XWPF.UserModel;

namespace EmergencyClient
{
    class Serializer
    {
        private List<EmergencyInfo> data;

        public Serializer(List<EmergencyInfo> list)
        {
            data = list;
        }

        public void ExcelSerialization(string path, List<string> headersList)
        {
            int row = 1;
            int column = 1;
            IRow excelRow;
            NPOI.SS.UserModel.ICell excelCell;

            try
            {
                IWorkbook workBook;
                ISheet sheet;
                string filename = Path.GetFileName(path);
                var fileExt = Path.GetExtension(filename);

                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    if (fileExt == ".xls")
                    {
                        workBook = new HSSFWorkbook();
                        sheet = workBook.CreateSheet();
                    }
                    else
                    {
                        workBook = new XSSFWorkbook();
                        sheet = workBook.CreateSheet();
                    }

                    excelRow = sheet.CreateRow(row);
                    foreach (string header in headersList)
                    {                       
                        excelCell = excelRow.CreateCell(column);
                        excelCell.SetCellValue(header);
                        column++;
                    }
                    row++;

                    foreach (EmergencyInfo emInfo in data)
                    {
                        excelRow = sheet.CreateRow(row);
                        for (int i = 0; i < headersList.Count; i++)
                        {
                            if (headersList[i] == "Номер пользователя")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.userName);
                            }
                            if (headersList[i] == "Статус готовности")
                            {
                                if (emInfo.status == "1")
                                {
                                    excelCell = excelRow.CreateCell(i + 1);
                                    excelCell.SetCellValue("Готов");
                                }
                                else if (emInfo.status == "0")
                                {
                                    excelCell = excelRow.CreateCell(i + 1);
                                    excelCell.SetCellValue("Не готов");
                                }
                            }
                            if (headersList[i] == "Подразделение")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.department);
                            }
                            if (headersList[i] == "Группа пользователя")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.userGroup);
                            }
                            if (headersList[i] == "Долгота")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.longitude);
                            }
                            if (headersList[i] == "Широта")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.latitude);
                            }
                            if (headersList[i] == "E-mail")
                            {
                                excelCell = excelRow.CreateCell(i + 1);
                                excelCell.SetCellValue(emInfo.email);
                            }
                        }
                        row++;
                    }

                    workBook.Write(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void WordSerialization(string path, List<string> headersList)
        {
            int nrrow = 0;
            int nrcolumn = 0;

            try
            {
                XWPFDocument doc;
                string filename = Path.GetFileName(path);
                var fileExt = Path.GetExtension(filename);

                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    doc = new XWPFDocument();
                    XWPFTable table = doc.CreateTable(data.Count + 1, headersList.Count);

                    foreach (string header in headersList)
                    {
                        table.GetRow(nrrow).GetCell(nrcolumn).SetText(header);
                        nrcolumn++;
                    }
                    nrrow++;

                    foreach (EmergencyInfo emInfo in data)
                    {
                        for (int i = 0; i < headersList.Count; i++)
                        {
                            if (headersList[i] == "Номер пользователя" && emInfo.userName != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.userName);
                            if (headersList[i] == "Статус готовности")
                            {
                                if (emInfo.status == "1")
                                    table.GetRow(nrrow).GetCell(i).SetText("Готов");
                                else if (emInfo.status == "0")
                                    table.GetRow(nrrow).GetCell(i).SetText("Не готов");
                            }
                            if (headersList[i] == "Подразделение" && emInfo.department != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.department);
                            if (headersList[i] == "Группа пользователя" && emInfo.userGroup != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.userGroup);
                            if (headersList[i] == "Долгота" && emInfo.longitude != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.longitude);
                            if (headersList[i] == "Широта" && emInfo.latitude != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.latitude);
                            if (headersList[i] == "E-mail" && emInfo.email != null)
                                table.GetRow(nrrow).GetCell(i).SetText(emInfo.email);
                        }
                        nrrow++;
                    }

                    doc.Write(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
