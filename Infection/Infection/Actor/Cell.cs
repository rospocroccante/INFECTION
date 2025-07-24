using Aiv.Fast2D;
using Infection;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    internal class Cell : GameObject
    {
        protected Vector2 velocity;
        private Vector2 direction;
        protected float infectionRadius = 100f; //Every cell has this value since it is used in both the NearInfected and Infected state
        public Cell infected { get; protected set; } //Used during the NearInfected state to see if i can still be infected
        public StateMachine fsm;
        public Cell(string textureName = "cell") : base(textureName)
        {
            body = new RigidBody(this);
           
            body.collider = ColliderFactory.CreateCircleFor(this);
            direction = new Vector2(RandomGenerator.GetRandomIntF(-1, 1), RandomGenerator.GetRandomIntF(-1, 1)); //Uses a ranomnumbergenerator to generate a random direction for the Cell
            direction.Normalize();
            float posX = RandomGenerator.GetRandomFloat() * Game.win.Width; //Generate a random X that is within the window limits
            float posY = RandomGenerator.GetRandomFloat() * Game.win.Height;//Generate a random Y that is within the window limits
            sprite.position = new Vector2(posX,posY); //Use the 2 random numbers to set the position of this Cell
            velocity = speed * direction;
            fsm = new StateMachine();
            IsActive = true;
            // Add States
            fsm.AddState(StateEnum.SANE, new Sane(this));
            fsm.AddState(StateEnum.NEARINFECTED, new NearInfected(this));
            fsm.AddState(StateEnum.INFECTED, new Infected(this));
            fsm.GoTo(StateEnum.SANE);

            UpdateMngr.AddItem(this);
            DrawMngr.AddItem(this);
        }

        public override void Update()
        {
            if (Position.X + HalfWidth > Game.win.Width)
            {
                direction.X *= -1;
                X = Game.win.Width - HalfWidth;
            }
            else if (Position.X - HalfWidth < 0)
            {
                direction.X *= -1;
                X = HalfWidth;
            }
            if (Position.Y + HalfHeight > Game.win.Height)
            {
                direction.Y *= -1 ;
                Y = Game.win.Height - HalfHeight; 
            }
            else if (Position.Y - HalfHeight < 0)
            {
                direction.Y *= -1;
                Y = HalfHeight;
            }
            
            fsm.Update();
            Position += direction * velocity * Game.DeltaTime;
        }

        public override void OnCollide(GameObject other)
        {
            float dist = (Position - other.Position).Length; //Distance from the center of the two objects
            float sumOfRadius = other.body.collider.Radius * 2; //Sum of the radius of the two colliders 
            float minReposition = sumOfRadius - dist; //Calculate the min distance that the object has to use to not collide anymore
            //Checks used to set the direction that the object has after colliding
            //if (X > other.X)
            //{
            //    if (Y >= other.Y)
            //    {
            //        direction.Y *= -1;
            //    }
            //    else
            //    {
            //        direction.X *= -1;
            //    }
            //}
            //else if (X <= other.X)
            //{
            //    if (Y >= other.Y)
            //    {
            //        direction.Y *= -1;
            //    }
            //    else
            //    {
            //        direction.X *= -1;
            //    }
            //}
            direction *= -1;
            Position += direction * minReposition * velocity * Game.DeltaTime;
        }



        public void InfectVisibleCells() //Method used by an infected cell to infect anyother cell that is not already infected
        {
            List<Cell> cells = ((PlayScene)Game.CurrentScene).Cells;
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].fsm.Current is Sane)
                {
                    if (CanInfectCells(cells[i]))
                    {
                        cells[i].fsm.GoTo(StateEnum.NEARINFECTED);
                        cells[i].infected = this;
                    }
                }
            }
        }

        public bool CanInfectCells(Cell other) //Method used to return a bool, returns true if the cell is inside its infection radius 
        {
            Vector2 dist = Position - other.Position;
            return dist.LengthSquared < infectionRadius * infectionRadius;
        }


        public void SetColor(Vector4 color) //Method used to set the color of the cell everytime it changes state
        {
            sprite.SetAdditiveTint(color);
        }
    }
}
