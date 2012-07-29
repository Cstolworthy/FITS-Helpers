using Interfaces;
using Interfaces.Collections;
using MongoDB.Driver;

namespace Repositories
{
    public class CelestialSphereSurveyRepository
    {
        private readonly ICelestialSphereSectionRepository _celestialSphereSectionRepository;
        private static MongoDatabase _database;
        private readonly MongoServer _server;
        private MongoCollection<CelestialSphereCollection> _collection;

        public CelestialSphereSurveyRepository(ICelestialSphereSectionRepository celestialSphereSectionRepository)
        {
            _celestialSphereSectionRepository = celestialSphereSectionRepository;
            _server = MongoServer.Create("mongodb://localhost");
            _database = _server.GetDatabase("WorkingSet");
            _collection = _database.GetCollection<CelestialSphereCollection>("CelestialSurveys");
        }

        public void Insert(ICelestialSphereSurvey survey)
        {
            _celestialSphereSectionRepository.Insert(survey.Sections);
            survey.SectionsCollectionName = survey.Sections.CollectionName;
            _collection.Insert(survey);
        }
    }
}