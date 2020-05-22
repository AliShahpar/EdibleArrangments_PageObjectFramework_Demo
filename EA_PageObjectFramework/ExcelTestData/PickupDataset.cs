using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace EA_PageObjectFramework.ExcelTestData
{
    internal class ExcelConfig
    {
        Application app;
        Workbooks workbooks;
        Workbook workbook;

        public ExcelConfig()
        {
            app = new Application();
            workbooks = app.Workbooks;
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            workbook = workbooks.Open(projectPath + "\\" + "ExcelMobileSite" + ".xlsx");
            // workbook = workbooks.Open(@"F:\VS-SeleniumProjectDir\SeleniumTest1\SeleniumTest1\ExcelMobileSite.xlsx");
        }

        // this will read the data from the excel 
        internal object ReadSheatData(int _sheet, int _row, int _col)
        {
            Worksheet sheet = (Worksheet)workbook.Worksheets.get_Item(_sheet);
            try
            {
                //workbook.Sheets[_SheetName];
                Object rangObject = sheet.Cells[_row, _col];
                Range range = (Range)rangObject;
                Object rangeValue = range.Value2;
                workbook.Save();
                return rangeValue;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        // this will write the data in excel 
        internal bool WriteSheetData(int _sheet, int _row, int _col, String _value)
        {
            object misValue = System.Reflection.Missing.Value;
            Worksheet sheet = (Worksheet)workbook.Worksheets.get_Item(_sheet);

            try
            {
                int unicode = 64 + _col;
                char character = (char)unicode;
                string text = character.ToString();
                Range header_range = sheet.get_Range(text + _row);
                header_range.Value2 = _value;
                workbook.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        // this will close the excel sheet
        public void CloseExcel()
        {
            workbook.Close(true, Type.Missing, Type.Missing);
            app.Quit();
        }

    }

}
