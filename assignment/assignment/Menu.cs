using System;

namespace assignment
{
    public class Menu
    {
        // Method for fixed text align at console window
        public static void centerTextLine(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
        public static void centerText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.Write(text);
        }

        public static void textAlignLine(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth) / 3));
            Console.WriteLine(text);
        }

        public static void textAlign(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth) / 3));
            Console.Write(text);
        }

        // Walmart logo at the center of top 
        public void DisplayWalmart()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            string star = "***************************************";
            centerTextLine(star);
            centerTextLine("*        WALMART SALES MANAGER        *");
            centerTextLine(star);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        public void MainMenu()
        {
            string selection = "";
            while (selection != "3")
            {
                DisplayWalmart();
                textAlignLine("MAIN MENU");
                Console.WriteLine();
                textAlignLine("1. Individual Store Statistics");
                textAlignLine("2. All Stores Combined Statistics.");
                textAlignLine("3. Quit.");
                Console.WriteLine();
                textAlign("Please enter your selection: ");

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        EnterStoreNumber();
                        break;
                    case "2":
                        DisplayStatisticsMenu(0);
                        break;
                    case "3":
                        break;
                    default:
                        DisplayMessage("Your selection was invalid. Please try again: ",1,0);
                        break;
                }
            }
        }
        public void DisplaySalesOption()
        {
            Console.WriteLine();
            textAlignLine("1. Get total sales");
            textAlignLine("2. Get total monthly sales");
            textAlignLine("3. Get holiday sales");
            textAlignLine("4. Return to main menu");
            Console.WriteLine();
            textAlign("Please enter your selection: ");
        }
        public void EnterStoreNumber()
        {
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    DisplayWalmart();
                    textAlign("Please enter store number (1-45): ");
                    int storeNum = Convert.ToInt32(Console.ReadLine());

                    if (storeNum < 1 || storeNum > 45)
                    {
                        DisplayMessage("Your selection was invalid. Please try again: ",1,1);
                    }
                    else
                    {
                        DisplayStatisticsMenu(storeNum);
                        isValid = true;
                    }
                }
                catch
                {
                    DisplayMessage("Your selection was invalid. Please try again: ", 1,1);
                }
            }
        }
        public void DisplayStatisticsMenu(int storeNum)
        {
            string selection = "";
            const int TOTALALLSTORESALES = 0;
            while (selection != "4")
            {
                DisplayWalmart();
                if (storeNum == 0)
                {
                    textAlignLine("ALL STORES");
                }
                else
                {
                    textAlignLine($"STORE NUMBER {storeNum}");
                }
                DisplaySalesOption();
                StoreStatistics storeStat = new StoreStatistics();
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        if (storeNum == 0)
                        {
                            DisplayMessage($"Total Sales All Store Sales: {storeStat.GetTotalSales(TOTALALLSTORESALES):C}",2,1);
                        }
                        else
                        {
                            DisplayMessage($"Total Sales at Store #{storeNum}: {storeStat.GetTotalSales(storeNum):C}",2,1);
                        }
                        break;
                    case "2":
                        GetMonthAndYear(storeNum);
                        break;
                    case "3":
                        if (storeNum == 0)
                        {
                            DisplayMessage($"All Store Total Holiday Sales: {storeStat.GetTotalHolidaySales(TOTALALLSTORESALES):C}",2,1);
                        }
                        else
                        {
                            DisplayMessage($"Total Holiday Sales at Store #{storeNum}: {storeStat.GetTotalHolidaySales(storeNum):C}",2,1);
                        }
                        break;
                    case "4":
                        break;
                    default:
                        DisplayMessage("Your selection was invalid. Please try again: ",1,0);
                        break;
                }
            }
        }
        public void GetMonthAndYear(int storeNum)
        {
            const int TOTALALLSTORESALES = 0;
            bool isValid = false;
            while (!isValid)
            {
                DisplayWalmart();
                textAlign("Please enter the month and year in the format MM-YYYY: ");
                StoreStatistics storeStat = new StoreStatistics();
                string monthAndYear = Console.ReadLine();
                DateTime dt;
                if (!DateTime.TryParseExact(monthAndYear, "MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    DisplayMessage("The date you entered is invalid:", 1,1);
                }
                else
                {
                    if (storeNum == 0)
                    {
                        DisplayMessage($"{monthAndYear} Total All Store Sales: {storeStat.GetTotalMonthlySales(TOTALALLSTORESALES, dt):C}",1,1);
                    }
                    else
                    {
                        DisplayMessage($"{monthAndYear} Total Sales at Store #{storeNum}: {storeStat.GetTotalMonthlySales(storeNum, dt):C}",1,1);
                    }
                    isValid = true;
                }
            }
        }
        public void DisplayMessage(string message, int LineSpace1, int LineSpace2)
        {
            for (int i = 0; i < LineSpace1; i++)
            {
                Console.WriteLine();
            }
            textAlignLine($"{message}");
            for (int i = 0; i < LineSpace2; i++)
            {
                Console.WriteLine();
            }
            textAlign("Press enter to continue.");
            Console.ReadLine();
        }
    }
}
