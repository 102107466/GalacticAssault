using GameFramework;

namespace GalacticAssault
{
    public class MainMenu : Scene
    {
        public MainMenu() 
        {    
            Menu menu = new Menu("Main Menu");
            menu.AddItem("Play", Play);
            menu.AddItem("Options", Options);
            menu.AddItem("Quit", Quit);

            Entities.Add(menu);
        }

        private void Play() => Game.SetScene(new GameScene());
        private void Options() => Game.PushScene(new OptionsScene());
        private void Quit() => System.Environment.Exit(1);
    }
}
