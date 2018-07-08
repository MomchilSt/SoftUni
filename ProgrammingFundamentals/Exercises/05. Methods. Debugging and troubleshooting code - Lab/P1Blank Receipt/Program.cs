using System;

class P1Blank_Receipt
{
    static void Main()
    {
        PrintReceipt();
    }

    static void PrintReceipt()
    {
        PrintReceiptHeader();
        PrintReceiptBody();
        PrintReceiptFooter();
    }

    static void PrintReceiptHeader()
    {
        Console.WriteLine("CASH RECEIPT");
        Console.WriteLine("------------------------------");
    }

    static void PrintReceiptBody()
    {
        Console.WriteLine("Charged to____________________");
        Console.WriteLine("Received by___________________");
        
    }

    static void PrintReceiptFooter()
    {
        Console.WriteLine("------------------------------");
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("\u00a9 SoftUni");
    }
}
