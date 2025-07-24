using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Infection
{
    internal class Sane : State
    {
        private Cell owner;

        public Sane(Cell owner)
        {
            this.owner = owner;
        }

        public override void OnEnter()
        {
            owner.SetColor(new Vector4(0.0f,1.0f,1.0f,0.0f)); //Set the color of the cell to Blue
        }

        public override void Update()
        {
            //A sane cell has only generic methods that are shared by every other state
        }
    }
}
