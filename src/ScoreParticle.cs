using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
    class ScoreParticle : Actor
    {

        /*===========*/
        /* Constants */
        /*===========*/

        private const int SPEED = 1;
        private const int MAX_LIFETIME = 100;

        /*========*/
        /* Fields */
        /*========*/

        private string _score;
        private Font _font = SwinGame.FontNamed("GameFont");
        private int _lifetime = MAX_LIFETIME;

        /*============*/
        /* Contructor */
        /*============*/

        public ScoreParticle(float x, float y, int score)
            : base(x, y, 0, 0)
        {
            _score = score.ToString("+0;-#");
            Width = SwinGame.TextWidth(_font, _score);
            Height = SwinGame.TextHeight(_font, _score);
        }

        /*=========*/
        /* Methods */
        /*=========*/

        public override void Update(EntityManager entities)
        {
            Y -= SPEED;
            if (_lifetime-- < 0) entities.Remove(this);
        }

        public override void Render()
        {
            float x = X - Width / 2;
            float y = Y - Height / 2;
            byte opacity = (byte)Utilities.Clamp((_lifetime / (float)MAX_LIFETIME)* 255 + 10, 0, 255);
            Color color = SwinGame.RGBColor(opacity, opacity, opacity);
            SwinGame.DrawText(_score, color, _font, x, y);
        }
    }
}
