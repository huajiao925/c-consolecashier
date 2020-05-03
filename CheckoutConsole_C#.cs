using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SamplePaper
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input:");

            string moreItems = "";
            List<string> purchasedItems = new List<string> { };
            
            do
            {
                Console.Write("Enter Item Code: ");
                string itemCode = Console.ReadLine();
                Console.Write("Enter Qty: ");
                string Qty = Console.ReadLine();
                Console.Write("Enter Unit Price: ");
                string unitPrice = Console.ReadLine();
                Console.Write("To enter more items press Y; to end press N: ");
                moreItems = Console.ReadLine();
                Console.WriteLine();
                List<string> item = new List<string> { itemCode, Qty, unitPrice };
                purchasedItems.AddRange(item);
            }
            while (moreItems == "Y");

            Console.Write("The shopper a loyalty member?");
            string isMember = Console.ReadLine();
            if (isMember == "Y")
            {
                Console.WriteLine("Member No.: {0}", "KJ3525");
            }
            
            printReceipt(purchasedItems, isMember);
        }
        
        static void printReceipt(List<string> purchasedItems, string isMember)
        {
            var dayofWeek = DateTime.Today.DayOfWeek;
            var today = DateTime.Today;

            Console.WriteLine("\t\t" + "ABC STORE\n" + "\t\t" + "SINGAPORE\n\n" + "\t\t" + "INVOICE\n");
            Console.WriteLine("Date of Pruchase: {0}, {1}", today, dayofWeek);
            Console.WriteLine("".PadLeft(50,'-'));
            Console.WriteLine("SNo"+ "\t" + "Item Code"+ "\t" + "Qty" + "\t" + "U/Price" + "\t" + "Cost" + "\t" + "Discount" + "Net");
            Console.WriteLine("".PadLeft(50, '-'));



            double totalAmount = 0.0;
            int sNumber = 0;
            for (int i = 0; i < purchasedItems.Count(); i++) 
            {
                double midweekDiscount = 0.0;
                double cost = 0.0;

                if (i % 3 == 0)
                {
                    cost = Convert.ToDouble(purchasedItems[i + 1]) * Convert.ToDouble(purchasedItems[i + 2]);
                    sNumber++;


                    if (purchasedItems[i].ToString().Substring(0) == "F" && dayofWeek.ToString() == "Friday")
                {
                    midweekDiscount = 0.2 * cost;
                };
                
                double net = cost - midweekDiscount;
                Console.WriteLine(
                    "{0}" + "\t"+
                    "{1}" + "\t\t" +
                    "{2}" + "\t" +
                    "{3: 0.00}" + "\t" +
                    "{4:0.00}" + "\t" +
                    "{5: 0.00}" + "\t" +
                    "{6:0.00}",
                    sNumber, 
                    purchasedItems[i], 
                    purchasedItems[i+1],
                    purchasedItems[i+2], 
                    cost, 
                    midweekDiscount, 
                    net);

                 totalAmount += net;
                    
            };
            };
            Console.WriteLine("".PadLeft(50, '-'));
            double memberDiscount = 0.0;
            double netTotal = totalAmount - memberDiscount;


            Console.WriteLine("Gross Total:\t\t\t\t\t{0:0.00}", totalAmount);
            if (isMember == "Y")
            {
                memberDiscount = 0.1 * totalAmount;
                Console.WriteLine("Member Discount (Member No {0})\t\t\t\t\t-{1:c}", "KJ3525", memberDiscount);
            };            ;
            Console.WriteLine("GST @ 7%\t\t\t\t\t+ {0:0.00}", netTotal * .07);
            Console.WriteLine("\nPlease Pay:\t\t\t\t\t{0:c}", netTotal * 1.07);
            Console.ReadLine();
            return;
        }

    }
}
