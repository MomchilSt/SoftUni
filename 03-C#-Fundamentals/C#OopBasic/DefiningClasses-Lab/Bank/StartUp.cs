using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            BankAccount acc = new BankAccount();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                var cmdArgs = command.Split();
                string cmdType = cmdArgs[0];

                switch (cmdType)
                {
                    case "Create":
                        Create(cmdArgs, accounts);
                        break;

                    case "Deposit":
                        Deposit(cmdArgs, accounts);
                        break;

                    case "Withdraw":
                        Withdraw(cmdArgs, accounts);
                        break;

                    case "Print":
                        Print(cmdArgs, accounts);
                        break;

                    default:
                        break;
                }
            }
        }

        private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);

            if (accounts.ContainsKey(id) == false)
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine($"Account ID{id}, balance {(accounts[id].Balance):f2}");
            }
        }

        private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = int.Parse(cmdArgs[2]);

            if (accounts.ContainsKey(id))
            {
                if (amount > accounts[id].Balance)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            var amount = int.Parse(cmdArgs[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(cmdArgs[1]);
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                var acc = new BankAccount();
                acc.Id = id;
                accounts.Add(id, acc);
            }
        }
    }
}
