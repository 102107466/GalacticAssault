namespace GameFramework
{
	public class Scene
	{
		/*============*/
		/* Properties */
		/*============*/

		protected EntityManager Entities { get; } = new EntityManager();

		/*=========*/
		/* Methods */
		/*=========*/

		protected internal virtual void Update() => Entities.Update();
		protected internal virtual void Render() => Entities.Render();
	}
}
