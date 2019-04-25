using SwinGameSDK;
using GameFramework;
using System;

namespace GalacticAssault
{
    public class Bullet : Actor
    {
        /*===========*/
        /* Constants */
        /*===========*/

        private const int SPEED = 5;

        public float Direction { get; protected set; }

        public Bullet(float x, float y, float dir) : base(x - 4, y - 8, 8, 16)
        {
            Direction = dir;
        }

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            float xDir = (float)Math.Cos(Direction * (Math.PI * 180));
            float yDir = (float)Math.Sin(Direction * (Math.PI * 180)); 
            X += xDir * SPEED;
            Y += yDir * SPEED;
            float screenMargin = 100;
            bool onScreen = SwinGame.PointInRect(
            X,
            Y,
            -screenMargin,
            -screenMargin,
            SwinGame.ScreenWidth() + screenMargin * 2,
            SwinGame.ScreenHeight() + screenMargin * 2
            );
            if (!onScreen) entities.Remove(this);

            Y -= SPEED;
            if (Y < -100) entities.Remove(this); // delete when bullet is off-screen
        }

        public override void Render()
		{
			SwinGame.FillRectangle(Color.Yellow, X, Y, Width, Height);
		}
	}
}
