using GameFramework;
using SwinGameSDK;

namespace GalacticAssault
{
    class GameScene : Scene
    {
        public GameScene() 
        {
            Entities.Add(new ScrollingBackground());
            Entities.Add(new EntitySpawner());
            Entities.Add(new Player());
            SwinGame.PlayMusic("GameMusic");//Play Game Music
        }

        protected override void Update()
        {
            base.Update();
            if (SwinGame.KeyTyped(KeyCode.vk_p)) Game.PushScene(new PauseScene());
        }
    }
}
