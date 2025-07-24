using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infection
{
    static class Game
    {
        public static Window win;
        public static Scene CurrentScene { get; private set; }

        public static Vector2 ScreenCenter { get; private set; }
        public static float DeltaTime { get { return win.DeltaTime; } }
        public static float OptimalScreenHeight { get; private set; }
        public static float UnitSize { get; private set; }
        public static float OptimalUnitSize { get; private set; }

        public static float HalfDiagonalSquared { get { return ScreenCenter.LengthSquared; } }

        public static void Init()
        {
            win = new Window(1280, 720, "Infection");
            PlayScene playScene = new PlayScene();
            playScene.NextScene = null;
            CurrentScene = playScene;
        }

        public static void Play()
        {
            CurrentScene.Start();
            while (win.IsOpened)
            {
                if (win.GetKey(KeyCode.Esc))
                {
                    break;
                }
                CurrentScene.Update();
                CurrentScene.Draw();
                win.Update();
            }
        }
        public static float PixelsToUnits(float pixelsSize)
        {
            return pixelsSize / OptimalUnitSize;
        }

    }
}
