using GameFramework;

namespace GalacticAssault
{
	class GameScene : Scene
	{
		public GameScene() 
		{
			Entities.Add(new Player());
            Entities.Add(new Drone());

        }
	}
}
