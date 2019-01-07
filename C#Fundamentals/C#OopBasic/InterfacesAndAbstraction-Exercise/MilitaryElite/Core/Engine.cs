using MilitaryElit.Contracts;
using MilitaryElit.Enums;
using MilitaryElit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElit.Core
{
    class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var args = input.Split();

                string type = args[0];
                var id = int.Parse(args[1]);
                var firstName = args[2];
                var lastname = args[3];
                if (type == "Private")
                {
                    var salary = decimal.Parse(args[4]);
                    soldier = GetPrivateSoldier(id, firstName, lastname, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(args[4]);
                    soldier = GetLeutenantGeneral(id, firstName, lastname, salary, args);
                }

                else if (type == "Engineer")
                {
                    var salary = decimal.Parse(args[4]);
                    soldier = GetEngineer(id, firstName, lastname, salary, args);
                }

                else if (type == "Commando")
                {
                    var salary = decimal.Parse(args[4]);
                    soldier = GetCommando(id, firstName, lastname, salary, args);
                }

                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(args[4]);
                    soldier = GetSpy(id, firstName, lastname, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastname, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastname, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastname, decimal salary, string[] args)
        {
            var corpsAsString = args[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastname, salary, corps);

            for (int i = 6; i < args.Length ; i+=2)
            {
                var codeName = args[i];
                var stateAsString = args[i + 1];

                if (!Enum.TryParse(stateAsString, out State state))
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                commando.Missions.Add(mission);
            }

            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastname, decimal salary, string[] args)
        {
            var corpsAsString = args[5];

            if (!Enum.TryParse(corpsAsString, out Corps corps))
            {
                return null;
            }

            IEngineer engineer = new Engineer(id, firstName, lastname, salary, corps);

            for (int i = 6; i < args.Length; i+=2)
            {
                string partName = args[i];
                int workHours = int.Parse(args[i + 1]);

                IRepair repair = new Repair(partName, workHours);

                engineer.Repairs.Add(repair);
            }
            return engineer;
        }

        private ISoldier GetLeutenantGeneral(int id, string firstName, string lastname, decimal salary, string[] args)
        {
            ILieutenantGeneral lieutenantGeneral = new LeutenantGeneral(id, firstName, lastname, salary);

            for (int i = 5; i < args.Length; i++)
            {
                int privateId = int.Parse(args[i]);
                IPrivate privateSoldier = (IPrivate)soldiers.FirstOrDefault(x => x.Id == privateId);

                lieutenantGeneral.Privates.Add(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastname, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastname, salary);

            return privateSoldier;
        }
    }
}
