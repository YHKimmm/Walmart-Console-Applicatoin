using System;

namespace assignment
{
    public class StoreData
    {
        public int StoreNumber;
        public DateTime Date;
        public double WeeklySales;
        public bool HolidayFlag;

        public StoreData(string line)
        {
            string[] data = line.Split(',');
            var dates = data[1].Split('-');
            var currentDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]));

            this.StoreNumber = Convert.ToInt32(data[0]);
            this.Date = currentDate;
            this.WeeklySales = Convert.ToDouble(data[2]);
            this.HolidayFlag = data[3] == "0" ? false : true;
        }
    }
}
