using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    class PlayScene : Scene
    {
        public List<Cell> Cells;
        public int InfectedCells;
        public int SaneCells;
        protected TextObject saneName;
        protected TextObject infectedName;
        protected TextObject saneCount;
        protected TextObject infectedCount;
        public int queueSize = 30;
        private float toClose = 1f;

        public override void Start()
        {
            base.Start();
            int randomIndex = RandomGenerator.GetRandomInt(0, queueSize);
            LoadAssets();
            Cells = new List<Cell>();
            for (int i = 0; i < queueSize; i++)
            {

                Cells.Add(new Cell());
                if (i == randomIndex)
                {
                    Cells[i].fsm.GoTo(StateEnum.INFECTED);
                }
                SaneCells++;
            }
            Vector2 sanePos = new Vector2(2, 2);
            saneName= new TextObject(sanePos, $"Sane Cells: ", FontMngr.GetFont(), 0);
            saneCount= new TextObject(new Vector2(sanePos.X + 220,sanePos.Y), "", FontMngr.GetFont(), 0);
            saneName.IsActive = true;
            saneCount.IsActive = true;

            Vector2 infectedPos = new Vector2(2, 20);
            infectedName = new TextObject(infectedPos, $"Infected Cells: ", FontMngr.GetFont(), 0);
            infectedCount = new TextObject(new Vector2(infectedPos.X + 300, infectedPos.Y), "", FontMngr.GetFont(), 0);
            infectedName.IsActive = true;
            infectedCount.IsActive = true;
            UpdateCount();
        }

        public override void Update()
        {
            UpdateCount();
            UpdateMngr.Update();
            CollisionMngr.CheckCollision();
            if (InfectedCells == queueSize)
            {
                toClose -= Game.DeltaTime;
                if (toClose <= 0)
                {
                    OnExit();
                }
            }
        }

        public override void Draw()
        {
            DrawMngr.Draw();
        }

        protected override void LoadAssets()
        {
            GfxMngr.AddTexture("cell", "Assets/grey_ball.png");
            FontMngr.AddFont("stdFont", "Assets/textSheet.png", 15, 32, 20, 20);
            FontMngr.AddFont("comics", "Assets/comics.png", 10, 32, 61, 65);
        }

        protected void UpdateCount()
        {
            saneCount.Text = SaneCells.ToString("00");
            infectedCount.Text = InfectedCells.ToString("00");
        }

    }
}
