using GameFramework;
using SwinGameSDK;
namespace GalacticAssault
{
    public class LoadingScene : Scene
    {
		
        protected override void Update()
        {
			LoadBitmaps();
            base.Update();
            Game.PushScene(new GameScene());
        }
		
		private void LoadBitmaps()
		{
			SwinGame.LoadBitmapNamed("Background","Resources/images/Background.png");
		}
    }
}
