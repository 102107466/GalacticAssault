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
        }
    }
}
