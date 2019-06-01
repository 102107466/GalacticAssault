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
            base.Update();
            Game.PushScene(new GameScene());
            LoadBitmaps();
        }

        //Loding game images
        private void LoadBitmaps()
        {
            SwinGame.LoadBitmapNamed("Bullet", "Resources/images/Bullet.PNG");
            SwinGame.LoadBitmapNamed("DroneShip", "Resources/images/DroneShip.PNG");
            SwinGame.LoadBitmapNamed("PlayerShip", "Resources/images/PlayerShip.PNG");
            SwinGame.LoadBitmapNamed("Background", "Resources/images/Background.PNG");
        }

        //Loading game sound effects
        private void LoadSoundEffects()
        {
            SwinGame.LoadSoundEffectNamed("BulletShoot", "Resources/sounds/BulletShoot.WAV");
            SwinGame.LoadSoundEffectNamed("BulletHitSound", "Resources/sounds/BulletHitSound.WAV");
            SwinGame.LoadSoundEffectNamed("ExplosionSound", "Resources/sounds/ExplosionSound.WAV");
            SwinGame.LoadSoundEffectNamed("ShipFlyingSound", "Resources/sounds/ShipFlyingSound.WAV");
        }

        //Loading game Music
        private void LoadMusic()
        {
            SwinGame.LoadMusicNamed("MainMenuMusic", "Resources/sounds/MainMenuMusic.MP3");
            SwinGame.LoadMusicNamed("GameMusic", "Resources/sounds/GameMusic.MP3");
        }
    }
}
