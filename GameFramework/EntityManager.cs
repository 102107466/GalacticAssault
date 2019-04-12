using System.Collections.Generic;

namespace GameFramework
{
	public class EntityManager
	{
		/*========*/
		/* Fields */
		/*========*/

		private List<Entity> _entities = new List<Entity>();
		private List<Entity> _removeQueue = new List<Entity>();
		
		/*================*/
		/* Public Methods */
		/*================*/

		public void Add(Entity e) => _entities.Add(e);
		public void Remove(Entity e) => _removeQueue.Add(e);

		public List<T> GetEntitiesByType<T>() where T : Entity
		{
			return _entities
				.FindAll(e => e is T)
				.ConvertAll<T>(e => (T)e);
		}
		
		/*==================*/
		/* Internal Methods */
		/*==================*/

		internal void Update()
		{
			_entities.ForEach(e => e.Update(this));         // update all entities
			_removeQueue.ForEach(e => _entities.Remove(e)); // remove entities in remove queue
			_removeQueue.Clear();                           // empty remove queue
		}

		internal void Render()
		{
			_entities.ForEach(e => e.Render());
		}
	}
}
