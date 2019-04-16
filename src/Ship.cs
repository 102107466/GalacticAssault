using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public abstract class Ship : Actor
    {
        public float Health { get; protected set; } // Ship health
        public float DamageBuffer { get; protected set; } = 0f; // DamageBuffer keeps track of Damage ship takes
        public float MaxHealth { get; protected set; } // MaxHealth set the max health of the ship

        public Ship(float x, float y, int width, int height, float maxHealth) : base(x, y, width, height)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
        }

        // Update method will updathe the ship health and damge status.
        // If ship healt less than or equal 0 remove the ship(tell the Ship to destroy itself)

        public override void Update(EntityManager entities)
        {
            if (DamageBuffer > 0)
            {
                DamageBuffer--;
                Health--;
                
                if (Health <= 0)
                {
                    entities.Remove(this);
                }
            }
        }

        public virtual void Damage(int damage)
        {
            DamageBuffer += damage;
        }
    }
}
