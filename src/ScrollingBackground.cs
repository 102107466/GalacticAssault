using System; 
using SwinGameSDK;
using GameFramework;
using System.Collections.Generic;
using System.Linq;

namespace GalacticAssault
{
    public class ScrollingBackground : Entity
    {
        private int SPEED = 1;
        private Bitmap _background = SwinGame.BitmapNamed("Background");
        private List<int> _backgrounds = new List<int>();
        private int _backgroundHeight;
        
        public ScrollingBackground()
        {
            _backgroundHeight = SwinGame.BitmapHeight(_background);
            int heightCoverage = SwinGame.ScreenHeight() + _backgroundHeight;
            int backgrounds = 1 + (int)Math.Ceiling((double)(heightCoverage / _backgroundHeight));
            for (int i=0; i<backgrounds; i++) 
            {
                _backgrounds.Add(i * _backgroundHeight);
            }
        }
        
        public void Update(EntityManager entities)
        {
            //_backgrounds.ForEach(bg => bg += SPEED);
            for (int i=0; i<_backgrounds.Count; i++) _backgrounds[i] += SPEED;
            for (int i = 0; i<_backgrounds.Count;i++)
            {
                if (_backgrounds[i]> SwinGame.ScreenHeight())
                {
                    _backgrounds[i] = _backgrounds.Min() - _backgroundHeight;
                }
            }
        }
        
        public void Render()
        {
            _backgrounds.ForEach(bg => SwinGame.DrawBitmap(_background, 0, bg));
        }
    }
}
