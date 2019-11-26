using MilitaryElit.Contracts;
using MilitaryElit.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElit.Models
{
    public class Mission : IMission
    {
        private string codeName;
        private State state;

        public Mission(string codename, State state)
        {
            this.CodeName = codename;
            this.State = state;
        }

        public string CodeName { get => codeName; private set => codeName = value; }
        public State State { get => state; private   set => state = value; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
