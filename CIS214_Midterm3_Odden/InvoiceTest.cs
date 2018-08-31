// InvoiceTest.cs
// Creates object from class Invoice and demonstrates its capabilities
using System;
using System.Collections.Generic;
using System.Text;

namespace CIS214_Midterm3_Odden
{
    class InvoiceTest
    {
        public static void Main(string[] args)
        {
            var invoices = new List<Invoice>(); // create data structure
            int i = 0; // incremented variable / counter
            // loop to create new Invoices
            while (true)
            {
                Console.Write("Press 1 to begin new Invoice (or -1 to quit): ");
                // check input
                int input1;
                if (!int.TryParse(Console.ReadLine(), out input1))
                    Console.WriteLine("Invalid input. Try again.");
                else if (input1 == 1)
                {
                    invoices.Add(new Invoice { Id = i + 1 }); // add invoice to List
                    Console.Write("Enter Part Number: "); // prompt
                    var input2 = Console.ReadLine(); // read user input
                    invoices[i].PartNumber = input2; // set PartNumber
                    Console.Write("Enter Part Description: "); // prompt
                    input2 = Console.ReadLine(); // read user input
                    invoices[i].PartDescription = input2; // set PartDescription
                    Console.Write("Enter Quantity: "); // prompt
                    int input3; // new input var for quantity
                    while (!int.TryParse(Console.ReadLine(), out input3)) // read input
                        Console.Write("Invalid input. Try again.\nEnter Quantity: "); // error message
                    if (input3 < 0) input3 = 0; // if quantity is negative, set to zero
                    invoices[i].Quantity = input3; // set Quantity
                    decimal input4; // new input var for price
                    Console.Write("Enter Price: "); // prompt
                    while (!Decimal.TryParse(Console.ReadLine(), out input4)) // read input
                        Console.Write("Invalid input. Try again.\nEnter Price: "); // error message
                    if (input4 < 0) input4 = 0; // if price is negative, set to zero
                    invoices[i].Price = input4; // set Price
                    i++; // increment count
                }
                else if (input1 == -1) // to quit loop and print invoices
                    break;
            }
            // print invoices
            foreach (var inv in invoices)
            {
                Console.WriteLine("\nId: {0}\nPart Number: {1}\nPart Description: {2}\nQuantity: {3}\nPrice: {4:C}",
                inv.Id, inv.PartNumber, inv.PartDescription, inv.Quantity, inv.Price);
                inv.GetInvoiceAmount();
            }
        }
    }
}
