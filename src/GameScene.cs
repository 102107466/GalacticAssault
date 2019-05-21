using GameFramework;
using SwinGameSDK;

namespace GalacticAssault
{
    class GameScene : Scene
    {
        public GameScene() 
        {
            Entities.Add(new Player());
            Entities.Add(new Drone());
            SwinGame.PlayMusic("GameMusic");//Play Game Music
        }
    }
}
