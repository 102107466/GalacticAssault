using GameFramework;
using SwinGameSDK;

namespace GalacticAssault
{
    public class PauseScene : Scene
    {
        /*=============*/
        /* Constructor */
        /*=============*/

        public PauseScene() 
        {
            SwinGame.PlaySoundEffect("Select2");

            Menu menu = new Menu("Pause");
            menu.AddItem("Continue", Continue);
            menu.AddItem("Options", Options);
            menu.AddItem("Main Menu", MainMenu);
            menu.AddItem("Quit", Quit);

            Entities.Add(menu);
        }

        /*=========*/
        /* Methods */
        /*=========*/

        private void Continue() => Game.PopScene();
        private void Options() => Game.PushScene(new OptionsScene());
        private void MainMenu() => Game.SetScene(new MainMenu());
        private void Quit() => System.Environment.Exit(1);
    }
}
