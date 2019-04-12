using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace GameFramework
{
	public static class Game
	{
		/*========*/
		/* Fields */
		/*========*/

		private static Stack<Scene> _scenes = new Stack<Scene>();
		private static bool _started = false;

		/*================*/
		/* Public Methods */
		/*================*/

		public static void Start()
		{
			if (_started) throw new InvalidOperationException("Game has been started more than once");
			_started = true;
			while (!SwinGame.WindowCloseRequested()) Loop();
		}

		public static void SetScene(Scene scene)
		{
			_scenes.Clear();
			PushScene(scene);
		}

		public static void PushScene(Scene scene)
		{
			_scenes.Push(scene);
		}

		public static Scene PopScene()
		{
			return _scenes.Pop();
		}

		/*=================*/
		/* Private Methods */
		/*=================*/

		private static void Loop()
		{
			Scene activeScene = _scenes.Peek(); // get active scene
			SwinGame.ProcessEvents();           // process SwinGame events
			activeScene.Update();               // update active scene
			SwinGame.ClearScreen(Color.Black);  // clear the screen
			activeScene.Render();               // draw the active scene
			SwinGame.DrawFramerate(0, 0);       // draw the framerate
			SwinGame.RefreshScreen(60);         // refresh the screen
		}
	}
}
