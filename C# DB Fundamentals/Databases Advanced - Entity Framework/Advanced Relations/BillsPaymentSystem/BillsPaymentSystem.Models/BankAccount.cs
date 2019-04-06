using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public BankAccount() { }

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SWIFT = swiftCode;
        }

        public int BankAccountId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Balance { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string SWIFT { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0 || amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"-- ID: {this.BankAccountId}" + Environment.NewLine +
                $"--- Balance: {this.Balance:f2}" + Environment.NewLine +
                $"--- Bank: {this.BankName}" + Environment.NewLine +
                $"--- SWIFT: {this.SWIFT}";
        }
    }
}
