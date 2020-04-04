﻿using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkbookFactoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream= File.OpenRead("multisheets.xlsx"))
            {
                IWorkbook workbook = WorkbookFactory.Create(stream, ImportOption.SheetContentOnly);
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    Console.WriteLine(sheet.SheetName);
                }
                Console.ReadLine();
            }
        }
    }
}
