using GameFramework;
using SwinGameSDK;

namespace GalacticAssault
{
    public class OptionsScene : Scene
    {
        /*=============*/
        /* Constructor */
        /*=============*/

        public OptionsScene() 
        {
            Menu menu = new Menu("Options");
            menu.AddItem("Fullscreen", Fullscreen);
            menu.AddItem("Back", Back);

            Entities.Add(menu);
        }

        /*=========*/
        /* Methods */
        /*=========*/

        private void Fullscreen() => SwinGame.ToggleFullScreen();
        private void Back() => Game.PopScene();
    }
}
