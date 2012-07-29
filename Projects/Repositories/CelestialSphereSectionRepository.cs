using Interfaces.Collections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Repositories
{
    public class CelestialSphereSectionRepository : ICelestialSphereSectionRepository
    {
        private static MongoDatabase _database;
        private readonly MongoServer _server;
        private MongoCollection<CelestialSphereCollection> _collection;

        public CelestialSphereSectionRepository()
        {
            _server = MongoServer.Create("mongodb://localhost");
            _database = _server.GetDatabase("WorkingSet");
            _collection = _database.GetCollection<CelestialSphereCollection>("Rows");
        }

        public void Insert(CelestialSphereCollection collection)
        {
            collection.CollectionName = "Rows";

            foreach (var item in collection)
            {
                _collection.Insert(item);
            }
        }
    }
}
