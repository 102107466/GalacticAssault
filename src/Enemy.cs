using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public abstract class Enemy : Ship
    {
        private const int HEALTH_BAR_WIDTH = 128;
        private const int HEALTH_BAR_HEIGHT = 16;

        public int HealthRenderOffset { get; protected set; } = 32;

        public Enemy(float x, float y, int width, int height, float maxHealth)
            : base(x, y, width, height, maxHealth) {}

        public override void Render()
        {
            float centerX = X + Width / 2.0f;
            float centerY = (Y + Height / 2.0f) - HealthRenderOffset;
            int width = HEALTH_BAR_WIDTH;
            int height = HEALTH_BAR_HEIGHT;
            float healthPercentage = 1.0f;

            //Healthbar Background
            SwinGame.FillRectangle(Color.Black, centerX - width / 2.0f, centerY - height / 2.0f, width, height);

            // HealthBar Health 
            healthPercentage = Utilities.Clamp(Health / MaxHealth, 0.0f, 1.0f);
            width = (int)(HEALTH_BAR_WIDTH * healthPercentage);
            if (width == 0) return;
            SwinGame.FillRectangle(Color.White, centerX - width / 2.0f, centerY - height / 2.0f, width, height);

            // HealthBar Predicted Health
            healthPercentage = Utilities.Clamp((Health - DamageBuffer) / MaxHealth, 0.0f, 1.0f);
            width = (int)(HEALTH_BAR_WIDTH * healthPercentage);
            if (width == 0) return;
            SwinGame.FillRectangle(Color.Red, centerX - width / 2.0f, centerY - height / 2.0f, width, height);
        }
    }
}
