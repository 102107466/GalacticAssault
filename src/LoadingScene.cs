using GameFramework;
using SwinGameSDK;
namespace GalacticAssault
{
    public class LoadingScene : Scene
    {
        protected override void Update()
        {
            base.Update();
            Game.PushScene(new GameScene());
            LoadBitmaps();
        }

        private void LoadBitmaps()
        {
            SwinGame.LoadBitmapNamed("Bullet", "Resources/images/Bullet.PNG");
            SwinGame.LoadBitmapNamed("DroneShip", "Resources/images/DroneShip.PNG");
            SwinGame.LoadBitmapNamed("PlayerShip", "Resources/images/PlayerShip.PNG");
            SwinGame.LoadBitmapNamed("Background", "Resources/images/Background.PNG");
        }
    }
}
