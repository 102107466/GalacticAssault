using GameFramework;
using SwinGameSDK;
namespace GalacticAssault
{
	public class LoadingScene:Scene
	{
		public override void Update()
		{
			base.Update();
			Game.PushScene(new GameScene());
		}
	}
}