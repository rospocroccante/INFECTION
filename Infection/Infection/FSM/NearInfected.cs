using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    internal class NearInfected : State
    {
        private float timer = 1f;
        private Cell owner;

        public NearInfected(Cell owner)
        {
            this.owner = owner;
        }

        public override void OnEnter()
        {
            timer = 1f; //Set the timer used to check the amount of time left before the cell becomes infected
            owner.SetColor(new OpenTK.Vector4(1.0f, 1.0f, 0.0f,0.0f));//Set the color of the Cell to yellow
        }

        public override void Update()
        {
            timer -= Game.DeltaTime; //Decrease the timer every time the Update is called
            if (timer <= 0)//If timer reaches 0 the cell becomes infected
            {
                owner.fsm.GoTo(StateEnum.INFECTED);
            }
            else if (!owner.CanInfectCells(owner.infected)) //if the cell can no longer be infected by the infected cell it will return to the Sane state
            {
                owner.fsm.GoTo(StateEnum.SANE);
            }
        }
    }
}
