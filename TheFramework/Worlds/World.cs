using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Design_Patterns;
using TheFramework.Model.Creature;

namespace TheFramework.Worlds
{
    /// <summary>
    /// This is supposed to represent a world, where everything, creatures, weapons and more, will resolve in
    /// </summary>
    public class World
    {
        /// <summary>
        /// This is the maximum width of the world
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// This is the maximum height of the world
        /// </summary>
        public int MaxY { get; set; }


        /// <summary>
        /// This is a List of objects that will be inside the world
        /// </summary>
        private List<WorldObject> _worldObjects;
        /// <summary>
        /// This is a List of creatures that will be inside the world
        /// </summary>
        private List<Creature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        public World()
        {
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        private List<IWorldObjectObserver> _observers = new List<IWorldObjectObserver>();

        public void AddObserver(IWorldObjectObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IWorldObjectObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers(WorldObject worldObject)
        {
            foreach (var observer in _observers)
            {
                observer.OnWorldObjectCreated(worldObject);
            }
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            _worldObjects.Add(worldObject);
            Console.WriteLine($"{worldObject.Name} added to the world.");
            NotifyObservers(worldObject);
        }

    }
}
