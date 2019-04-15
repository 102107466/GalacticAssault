using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    public abstract class Enemy : Ship
    {
        private const float HEALTH_BAR_WIDTH = 16f;
        private const float HEALTH_BAR_HEIGHT = 128f;

        public float HealthRenderOffset { get; protected set; } = 32f;

        public Enemy(float x, float y, int width, int height, float maxHealth) : base(x, y, width, height, maxHealth)
        {

        }

        public override void Render()
        {
            float centerX = X + Width / 2.0f;
            float centerY = (Y + Height / 2.0f) - HealthRenderOffset;
            float width = HEALTH_BAR_WIDTH;
            float height = HEALTH_BAR_HEIGHT;
            float healthPercentage = 1.0f;

            //Healthbar Background
            SwinGame.FillRectangle(Color.Black, centerX - width / 2.0f, centerY - height / 2.0f, (int)width, (int)height);

            // HealthBar Health 
            healthPercentage = Utilities.Clamp(Health / MaxHealth, 0.0f, 1.0f);
            width = HEALTH_BAR_WIDTH * healthPercentage;

            SwinGame.FillRectangle(Color.White, centerX - width / 2.0f, centerY - height / 2.0f, (int)width, (int)height);

            // HealthBar Predicted Health
            healthPercentage = Utilities.Clamp((Health - DamageBuffer) / MaxHealth, 0.0f, 1.0f);
            width = HEALTH_BAR_WIDTH * healthPercentage;
            SwinGame.FillRectangle(Color.Red, centerX - (float)width / 2.0f, centerY - (float)height / 2.0f, (int)width, (int)height);


        }
    }
}