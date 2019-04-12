using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
	public abstract class Actor : Entity
	{
		/*============*/
		/* Properties */
		/*============*/
		
		public float X { get; set; }
		public float Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		/*=============*/
		/* Constructor */
		/*=============*/

		public Actor(float x, float y, int width, int height)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		/*=========*/
		/* Methods */
		/*=========*/

		public abstract void Update(EntityManager entities);
		public abstract void Render();
	}
}
