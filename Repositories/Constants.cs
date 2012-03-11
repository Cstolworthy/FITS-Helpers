using System;

namespace Repositories
{
    public static class Constants
    {
        public static string DatabaseName = "FITSData";
        public static string Id = "_id";
        public static class Data
        {
            public static string CollectionName = "Data";
            public static string LinkerKey = "ids";

            public static class Linker
            {
                public static string CollectionName = "DataMapping";
                public static string PrimaryDocumentDataKey = "data";
            }
            
        }
    }
}
