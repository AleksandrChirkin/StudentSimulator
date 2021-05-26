using System.Collections.Generic;
using System.Linq;

namespace StudentSimulator.Domain
{
    public class LocationBuilder
    {
        private List<GameObject> gameObjects;

        public LocationBuilder()
        {
            gameObjects = new List<GameObject>();
        }

        public LocationBuilder AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
            return this;
        }

        public Location Build() => new Location(gameObjects);
    }
}