using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace Bakaleya
{
    public class PrintDataToExcel
    {
        public Excel.Application excelapp;//переменная для управл приложением
        public Excel.Sheets excelsheets;
        public Excel.Worksheet excelworksheet;
        public Excel.Range excelcells;//ячейки


        public void Open(bool f, string filename)
        {

            excelapp = new Excel.Application();
            excelapp.Visible = f;
            excelsheets = excelapp.Workbooks.Open(filename,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing).Worksheets;
        
        }
        public void add_data_in_cells(List<Product> prod, List<int> m, int sheet, string name_sheet)
        {
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(sheet);
                excelworksheet.Name = name_sheet;
                for (int i = 0; i < 30; i++)
                    for (int j = 0; j < 6; j++)
                    {
                        excelcells = (Excel.Range)excelworksheet.Cells[i + 1, j + 1];//получаем диапазон ячеек
                        switch (j)
                        {
                            case 0: excelcells.Value2 = ""; break;
                            case 1: excelcells.Value2 = ""; break;
                            case 2: excelcells.Value2 = ""; break;
                            case 3: excelcells.Value2 = ""; break;
                            case 4: excelcells.Value2 = ""; break;
                            case 5: excelcells.Value2 = ""; break;
                        }
                    }
                for (int i = 0; i<m.Count; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        excelcells = (Excel.Range)excelworksheet.Cells[i + 1, j + 1];

                        switch (j)
                        {
                            case 0: excelcells.Value2 = prod[m[i]].NAME; excelcells.ColumnWidth = 20; break;
                            case 1: excelcells.Value2 = prod[m[i]].PLACE; excelcells.ColumnWidth = 5; break;
                            case 2: excelcells.Value2 = prod[m[i]].VALUE; excelcells.ColumnWidth = 10; break;
                            case 3: excelcells.Value2 = prod[m[i]].post.NAME_FIRM; excelcells.ColumnWidth = 15; break;
                            case 4: excelcells.Value2 = prod[m[i]].post.ADDRES; excelcells.ColumnWidth = 20; break;
                            case 5: excelcells.Value2 = prod[m[i]].post.TELEPH; excelcells.ColumnWidth = 10; break;
                        }

                    }
                }
            
        }
        public void Save()
        {
            excelapp.Workbooks[1].Save();

        }
        public void Quit()
        {
            excelapp.Quit();
        }
    }
    
}
