using SwinGameSDK;
using GameFramework;
using System;

namespace GalacticAssault
{
    public class Drone : Enemy
    {
        /*=============*/
        /* Constructor */
        /*=============*/

        public Drone()
            : base(Utilities.Random(100, SwinGame.ScreenWidth() - 100),
                   -100, 32, 32, 100) {}

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            base.Update(entities);

            // Drone movement
            float speed = 2 - (float)Math.Pow(1.01f, Y - 16);
            speed = (float)Math.Max(speed, 0.1f);
            Y += speed;

            // Drone Shoot
            if (Utilities.Random(1, 64) == 1)
            {
                float bulletsToShoot = 16;
                float angle = (360 / bulletsToShoot);
                float randomComponent = Utilities.Random(0, (int)angle);
                for (int i = 0; i < bulletsToShoot; i++)
                {
                    float centerX = X + Width / 2;
                    float centerY = Y + Height / 2;
                    float direction = (angle * i) + randomComponent;
                    entities.Add(new Bullet<Player>(centerX, centerY, direction));
                }
            	SwinGame.PlaySoundEffect("BulletShoot");
            }
        }

        public override void Render()
        {
            base.Render();
            SwinGame.FillRectangle(Color.Orange, X, Y, Width, Height);
        }
    }
}
