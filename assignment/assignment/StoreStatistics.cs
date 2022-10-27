using System;

namespace assignment
{
    public class StoreStatistics
    {
        public string[] CsvLines;

        public StoreStatistics()
        {
            CsvLines = System.IO.File.ReadAllLines(@"C:\Users\kim\source\repos\assignment\assignment\Walmart_Store_Data.csv");
        }

        public double GetTotalSales(int storeNum)
        {
            var totalSale = 0d;

            for(int i = 1; i < CsvLines.Length; i++)
            {
                StoreData storeData = new StoreData(CsvLines[i]);

                if (storeData.StoreNumber == storeNum || storeNum == 0)
                {
                    totalSale += storeData.WeeklySales;
                }
            }
            return totalSale;
        }

        public double GetTotalMonthlySales(int storeNum, DateTime firstDayOfUserInput)
        {
            var totalSales = 0d;

            var lastDayOfMonth = firstDayOfUserInput.AddMonths(1).AddDays(-1);

            for (int i = 1; i < CsvLines.Length; i++)
            {
                StoreData storeData = new StoreData(CsvLines[i]);

                if ((storeData.StoreNumber == storeNum || storeNum == 0) && storeData.Date >= firstDayOfUserInput && storeData.Date <= lastDayOfMonth)
                {
                    totalSales += storeData.WeeklySales;                  
                }
            }
            return totalSales;
        }

        public double GetTotalHolidaySales(int storeNum)
        {
            var totalSales = 0d;

            for (int i = 1; i < CsvLines.Length; i++)
            {
                StoreData storeData = new StoreData(CsvLines[i]);

                if ((storeData.StoreNumber == storeNum || storeNum == 0) && storeData.HolidayFlag)
                {
                    totalSales += storeData.WeeklySales;
                }
            }
            return totalSales;
        }
    }
}
