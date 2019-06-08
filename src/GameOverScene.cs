using GameFramework;

namespace GalacticAssault
{
    public class GameOver : Scene
    {
        public GameOver(int score) 
        {    
            Menu menu = new Menu("Game Over");
            menu.AddItem("Score: " + score, ()=>{});
            menu.AddItem("Play Again", Play);
            menu.AddItem("Main Menu", MainMenu);
            menu.AddItem("Quit", Quit);

            Entities.Add(menu);
        }

        private void Play() => Game.SetScene(new GameScene());
        private void MainMenu() => Game.SetScene(new MainMenu());
        private void Quit() => System.Environment.Exit(1);
    }
}
