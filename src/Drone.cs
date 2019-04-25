using SwinGameSDK;
using GameFramework;
using System;

namespace GalacticAssault
{
    public class Drone : Enemy
    {

        /*==============*/
        /* Constructors */
        /*==============*/

        public Drone() : base(Utilities.Random(100, SwinGame.ScreenWidth() - 100), -100, 32, 32, 100)
        {
        }

        public override void Update(EntityManager entities)
        {
            base.Update(entities);
            // Drone movement
            float speed = 6 - (float)Math.Pow(1.02, Y - 100);
            speed = (float)Math.Min(speed, 0.1);
            Y += speed;
            // Drone Shoot

            if (Utilities.Random(1, 120) == 1)
            {
                float bulletsToShoot = 6;
                for (int i = 0; i < bulletsToShoot; i++)
                {
                    float centerX = X + Width / 2;
                    float centerY = Y + Height / 2;
                    float direction = (360 / bulletsToShoot -1 ) * i;
                    entities.Add(new Bullet(centerX, centerY, direction));
                }
            }
        }

        public override void Render()
        {
            base.Render();
            SwinGame.FillRectangle(Color.Orange, X, Y, Width, Height);
        }

    }
}