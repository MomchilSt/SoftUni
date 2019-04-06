using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class PayBillsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public PayBillsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            try
                {
                Console.WriteLine("Bills Payment");
                Console.Write("Enter user ID: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Enter amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                var accounts = context.PaymentMethods
                    .Include(pm => pm.BankAccount)
                    .Where(pm => pm.UserId == userId && pm.Type == PaymentType.BankAccount)
                    .Select(pm => pm.BankAccount)
                    .ToList();

                var cards = context.PaymentMethods
                    .Include(pm => pm.CreditCard)
                    .Where(pm => pm.UserId == userId && pm.Type == PaymentType.CreditCard)
                    .Select(pm => pm.CreditCard)
                    .ToList();

                var moneyAvailable = accounts.Select(ba => ba.Balance).Sum() + cards.Select(cc => cc.LimitLeft).Sum();

                if (moneyAvailable < amount)
                {
                    return "Insufficient Funds";
                }

                foreach (var account in accounts)
                {
                    if (amount == 0 || account.Balance == 0)
                    {
                        continue;
                    }

                    decimal moneyInAccount = account.Balance;
                    if (moneyInAccount < amount)
                    {
                        account.Withdraw(moneyInAccount);
                        amount -= moneyInAccount;
                    }
                    else
                    {
                        account.Withdraw(amount);
                        amount -= amount;
                    }
                }


                foreach (var creditCard in cards)
                {
                    if (amount == 0 || creditCard.LimitLeft == 0)
                    {
                        continue;
                    }

                    decimal limitLeft = creditCard.LimitLeft;
                    if (limitLeft < amount)
                    {
                        creditCard.Withdraw(limitLeft);
                        amount -= limitLeft;
                    }
                    else
                    {
                        creditCard.Withdraw(amount);
                        amount -= amount;
                    }
                }

                context.SaveChanges();
                return "Bills paid!";
            }
                catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
