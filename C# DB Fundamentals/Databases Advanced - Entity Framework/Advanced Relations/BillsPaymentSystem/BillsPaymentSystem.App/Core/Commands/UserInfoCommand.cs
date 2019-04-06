using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users.Where(x => x.UserId == userId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            StringBuilder stringBuilder = new StringBuilder();

            var userInfo = user.Select(u => new
            {
                Name = $"{u.FirstName} {u.LastName}",
                BankAccounts = u.PaymentMethods
                              .Where(pm => pm.Type == PaymentType.BankAccount)
                              .Select(pm => pm.BankAccount)
                              .ToList(),
                CreditCards = u.PaymentMethods
                              .Where(pm => pm.Type == PaymentType.CreditCard)
                              .Select(pm => pm.CreditCard)
                              .ToList()})
                              .First();

            stringBuilder.AppendLine("User: " + userInfo.Name);
            stringBuilder.AppendLine("Bank Accounts:");
            stringBuilder.AppendLine(string.Join(Environment.NewLine, userInfo.BankAccounts));
            stringBuilder.AppendLine("Credit Cards:");
            stringBuilder.AppendLine(string.Join(Environment.NewLine, userInfo.CreditCards));

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
