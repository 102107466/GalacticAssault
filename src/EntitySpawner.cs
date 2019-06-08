using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public class EntitySpawner : Entity
    {
        public void Update(EntityManager entities)
        {
            SpawnEnemies(entities);
        }

        public void Render()
        {
        
        }

        private void SpawnEnemies(EntityManager entities)
        {
            if (Utilities.Random(1,400) == 1)
            {
                entities.Add(new Drone());
            }
        }
    }
}
