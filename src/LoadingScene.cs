using GameFramework;
using SwinGameSDK;
namespace GalacticAssault
{
    public class LoadingScene : Scene
    {
        protected override void Update()
        {
            LoadBitmaps();
            LoadSoundEffects();
            LoadMusic();
            LoadFonts();

            base.Update();
            Game.SetScene(new MainMenu());
        }

        // Loding game images
        private void LoadBitmaps()
        {
            SwinGame.LoadBitmapNamed("Bullet", "Bullet.png");
            SwinGame.LoadBitmapNamed("DroneShip", "DroneShip.png");
            SwinGame.LoadBitmapNamed("PlayerShip", "PlayerShip.png");
            SwinGame.LoadBitmapNamed("Background", "Background.png");
        }

        // loading game sound effects
        private void LoadSoundEffects()
        {
            SwinGame.LoadSoundEffectNamed("BulletShoot", "BulletShoot.wav");
            SwinGame.LoadSoundEffectNamed("BulletHitSound", "BulletHitSound.wav");
            SwinGame.LoadSoundEffectNamed("ExplosionSound", "ExplosionSound.wav");
            SwinGame.LoadSoundEffectNamed("ShipFlyingSound", "ShipFlyingSound.wav");
            SwinGame.LoadSoundEffectNamed("Select1", "Select1.wav");
            SwinGame.LoadSoundEffectNamed("Select2", "Select2.wav");
        }

        // loading game music
        private void LoadMusic()
        {
            SwinGame.LoadMusicNamed("MainMenuMusic", "MainMenuMusic.mp3");
            SwinGame.LoadMusicNamed("GameMusic", "GameMusic.mp3");
        }

        // loading game fonts
        private void LoadFonts()
        {
            SwinGame.LoadFontNamed("MenuFont", "ModernDOS4378x8.ttf", 24);
            SwinGame.LoadFontNamed("GameFont", "ModernDOS4378x8.ttf", 12);
        }
    }
}
