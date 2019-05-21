using GameFramework;

namespace GalacticAssault
{
    class GameScene : Scene
    {
        public GameScene() 
        {
            Entities.Add(new ScrollingBackground());
            Entities.Add(new EntitySpawner());
            Entities.Add(new Player());
        }
    }
}
