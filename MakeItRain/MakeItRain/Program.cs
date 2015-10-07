using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeItRain.Classes
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Welcome to Make it Rain 1.0");

                Console.WriteLine("Enter the symbol of the company");

                string symbolInput = Console.ReadLine();

                if (symbolInput.Length == 0)
                {
                    break;
                }

                CompanyResult companyResult = CompanyService.GetStock(symbolInput);

                CompanyResult currentStock = null;

                CompanyResult previousStock = null;

                while (true)
                {
                    previousStock = currentStock;

                    currentStock = CompanyService.GetStock(symbolInput);
                    System.Threading.Thread.Sleep(2000);


                    if (previousStock != null)
                    {
                        if (previousStock.priceParse > currentStock.priceParse)
                        {
                            Console.WriteLine("{0}, the company {1} has a price of {2} which is lower than before BUY!", companyResult.symbol, companyResult.name, companyResult.lastPrice);
                        }
                        else if (previousStock.lastPrice == currentStock.lastPrice)
                        {
                            Console.WriteLine("{0}, the company {1} has a price of {2} which is the same", companyResult.symbol, companyResult.name, companyResult.lastPrice);
                        }
                        else
                        {
                            Console.WriteLine("{0}, the company {1} has a price of {2} which is lower than before BUY!", companyResult.symbol, companyResult.name, companyResult.lastPrice);
                        }
                    }
                }
            }
        }
    }
}
