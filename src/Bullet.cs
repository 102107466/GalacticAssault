using SwinGameSDK;
using GameFramework;

namespace GalacticAssault
{
	public class Bullet : Actor
	{
		/*===========*/
		/* Constants */
		/*===========*/

		private const int SPEED = 5;

		/*==============*/
		/* Constructors */
		/*==============*/

		public Bullet(float x, float y)
			: base(x-4, y-8, 8, 16) {}	

		/*=========*/
		/* Methods */
		/*=========*/

		public override void Update(EntityManager entities)
		{
			Y -= SPEED;
			if (Y < -100) entities.Remove(this); // delete when bullet is off-screen
		}

		public override void Render()
		{
			SwinGame.FillRectangle(Color.Yellow, X, Y, Width, Height);
		}
	}
}
