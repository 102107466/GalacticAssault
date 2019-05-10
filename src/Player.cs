using SwinGameSDK;
using System.Collections.Generic;
using GameFramework;

namespace GalacticAssault
{
    public class Player : Ship
    {
        /*===========*/
        /* Constants */
        /*===========*/

        private const float SPEED = 1.5f;

        /*==============*/
        /* Constructors */
        /*==============*/
 

        public Player() : base (((float)SwinGame.ScreenWidth()) / 2f - 16f, ((float)SwinGame.ScreenHeight()) / 1.5f, 32, 32, 100f)
        {

        }    

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            float lastX = X;
            float lastY = Y;
            // movement
            if (SwinGame.KeyDown(KeyCode.vk_UP)) Y -= SPEED;
            if (SwinGame.KeyDown(KeyCode.vk_RIGHT)) X += SPEED * 2;
            if (SwinGame.KeyDown(KeyCode.vk_DOWN)) Y += SPEED;
            if (SwinGame.KeyDown(KeyCode.vk_LEFT)) X -= SPEED * 2;
            if(lastX != X || lastY != Y)//If ship moves play sound effect
            {
                SwinGame.PlaySoundEffect("ShipFlyingSound");
            }

            // shooting
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
            {
                entities.Add(new Bullet(X + Width/2.0f, Y, 270));
            }
        }

        public override void Render()
        {
            SwinGame.FillRectangle(Color.Green, X, Y, Width, Height);
            //SwinGame.DrawBitmap("PlayerShip", X, Y);//Draw player ship
        }
    }
}
