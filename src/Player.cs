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

        private const float SPEED = 2.5f;
        private const int UI_PADDING = 32;
        private const int HEALTH_BAR_HEIGHT = 32;

        /*============*/
        /* Properties */
        /*============*/

        public int Score { get; set; } = 0;

        /*==============*/
        /* Constructors */
        /*==============*/

        public Player()
            : base (((float)SwinGame.ScreenWidth()) / 2f - 16f,
                    ((float)SwinGame.ScreenHeight()) / 1.5f,
                    64, 64, 500f) {}    

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            base.Update(entities);

            float lastX = X;
            float lastY = Y;
            // movement
            if (SwinGame.KeyDown(KeyCode.vk_UP)) Y -= SPEED;
            if (SwinGame.KeyDown(KeyCode.vk_RIGHT)) X += SPEED * 2;
            if (SwinGame.KeyDown(KeyCode.vk_DOWN)) Y += SPEED;
            if (SwinGame.KeyDown(KeyCode.vk_LEFT)) X -= SPEED * 2;

            if(SwinGame.KeyTyped(KeyCode.vk_UP) || SwinGame.KeyTyped(KeyCode.vk_RIGHT) || SwinGame.KeyTyped(KeyCode.vk_DOWN) || SwinGame.KeyTyped(KeyCode.vk_LEFT))
            {
                SwinGame.PlaySoundEffect("ShipFlyingSound");
            }

            // shooting
            if (SwinGame.KeyTyped(KeyCode.vk_SPACE))
            {
                entities.Add(new Bullet<Enemy>(X + Width/2.0f, Y, 270));
                SwinGame.PlaySoundEffect("BulletShoot");
            }
        }

        public override void Render()
        {
            SwinGame.DrawBitmap("PlayerShip", X, Y);
            RenderHealthBar();
            RenderScore();
        }

        private void RenderHealthBar()
        {
            int healthBarWidth = SwinGame.ScreenWidth() / 4;
            int width = healthBarWidth;
            int height = HEALTH_BAR_HEIGHT;
            float x = UI_PADDING;
            float y = SwinGame.ScreenHeight() - UI_PADDING - height;
            float healthPercentage = 1.0f;

            SwinGame.FillRectangle(SwinGame.RGBColor(32,32,32), x, y, width, height);

            healthPercentage = Utilities.Clamp(Health / MaxHealth, 0.0f, 1.0f);
            width = (int)(healthBarWidth * healthPercentage);
            if (width == 0) return;
            SwinGame.FillRectangle(Color.White, x, y, width, height);

            healthPercentage = Utilities.Clamp((Health - DamageBuffer) / MaxHealth, 0.0f, 1.0f);
            width = (int)(healthBarWidth * healthPercentage);
            if (width == 0) return;
            SwinGame.FillRectangle(Color.Red, x, y, width, height);
        }

        private void RenderScore()
        {
            string score = $"Score: {Score}";
            Font scoreFont = SwinGame.FontNamed("GameFont");
            float x = UI_PADDING;
            float y = SwinGame.ScreenHeight()
                    - UI_PADDING
                    - HEALTH_BAR_HEIGHT
                    - SwinGame.TextHeight(scoreFont, score);

            SwinGame.DrawText(score, Color.White, scoreFont, x, y);
        }

        protected override void Destroy(EntityManager entities)
        {
            Game.SetScene(new GameOver(Score));
        }
    }
}
