using SwinGameSDK;
using GameFramework;
using System;
using System.Collections.Generic;

namespace GalacticAssault
{
    public class Bullet<T> : Actor where T :Ship
    {
        /*===========*/
        /* Constants */
        /*===========*/

        private int SPEED = 5;
        private int DAMAGE = 25;

        public float Direction { get; protected set; }

        public Bullet(float x, float y, float dir) : base(x - 4, y - 4, 8, 8)
        {
            Direction = dir;
        }

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            float xDir = (float)Math.Cos(Direction * (Math.PI / 180));
            float yDir = (float)Math.Sin(Direction * (Math.PI / 180)); 
            X += xDir * SPEED;
            Y += yDir * SPEED;
            //get shot targets
            List<T> shotTargets = entities
                .GetEntitiesByType<T>()
                .FindAll(target => CheckCollision(this, target));
            
            //if any targets were shot
            if(shotTargets.Count>0)
            {
                shotTargets.ForEach(target=>target.Damage(DAMAGE));//damage the targets
                entities.Remove(this);//destroy this bullet
            }
            
            float screenMargin = 100;
            bool onScreen = SwinGame.PointInRect(
                X,
                Y,
                -screenMargin,
                -screenMargin,
                SwinGame.ScreenWidth() + screenMargin * 2,
                SwinGame.ScreenHeight() + screenMargin * 2
            );
            SwinGame.DrawBitmap("Bullet", X, Y);//Draw bullet

            if (!onScreen) entities.Remove(this);
        }

        public override void Render()
        {
            SwinGame.DrawBitmap("Bullet", X, Y);
        }
    }
}

