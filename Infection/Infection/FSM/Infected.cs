using Infection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Infection
{
    internal class Infected : State
    {
        private Cell owner;

        public Infected(Cell owner)
        {
            this.owner = owner;
        }


        public override void OnEnter()
        {
            ((PlayScene)Game.CurrentScene).SaneCells--; //Used for the Counter that can be seen while playing
            ((PlayScene)Game.CurrentScene).InfectedCells++;//Used for the Counter that can be seen while playing
            owner.SetColor(new Vector4(1.0f, 0.0f, 0.0f, 0.0f)); //Set the color of the cell to red
        }

        public override void Update()
        {
            owner.InfectVisibleCells(); //Call the method used to infect other cell
            //No other options, if a cell is infected it will stay infected for the rest of the duration of the program
        }
    }
}
