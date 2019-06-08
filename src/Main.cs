using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public static class MainClass
    {
        public static void Main(string[] args)
        {
            SwinGame.OpenGraphicsWindow("Game", 1280, 720);
            Game.SetScene(new LoadingScene()); 
            Game.Start(); 
            SwinGame.ReleaseAllResources(); 
        }
    }
}
