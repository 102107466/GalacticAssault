using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public static class MainClass
    {
        public static void Main(string[] args)
        {
            SwinGame.OpenGraphicsWindow("Game", 800, 600);
            Game.PushScene(new GameScene());
            Game.Start();
        }
    }
}
