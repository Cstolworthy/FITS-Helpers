using System;
using Core.Objects;
using MongoDB.Bson.Serialization;

namespace Core
{
    public class MongoClassMapper
    {
        public static void Map()
        {
            MapCelestialSphereSurvey();
            MapCelestialSphereSection();
        }

        private static void MapCelestialSphereSection()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(CelestialSphereSection)))
                return;
            BsonClassMap.RegisterClassMap<CelestialSphereSection>(cm =>
                                                                     {
                                                                         cm.AutoMap();
                                                                         cm.MapIdProperty(c => c.ObjectId);
                                                                     });
        }

        private static void MapCelestialSphereSurvey()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(CelestialSphereSurvey)))
                return;

            BsonClassMap.RegisterClassMap<CelestialSphereSurvey>(cm =>
                                                                     {
                                                                         cm.AutoMap();
                                                                         cm.MapIdProperty(c => c.ObjectId);
                                                                         cm.UnmapProperty(c => c.Sections);
                                                                     });
        }
    }
}