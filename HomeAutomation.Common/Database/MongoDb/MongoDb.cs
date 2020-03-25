using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomation.Common.Database
{
    public class MongoDb : IDb<IMongoDatabase>
    {
        private IMongoClient _mongoDbClient = null;
        private string _dbName = null;
        public MongoDb(IDbClient<IMongoClient> mongoDbClient, string dbName)
        {
            _mongoDbClient = mongoDbClient.Connection;
            _dbName = dbName;
        }

        public IMongoDatabase Instance
        {
            get
            {
                return _mongoDbClient.GetDatabase(_dbName);
            }
        }

        public bool CheckIfDBExists(string dbName)
        {
            List<string> dbNames = _mongoDbClient.ListDatabaseNames().ToList();
            if(dbNames != null && dbNames.Count > 0 && dbNames.Where(x=>x.ToLower() == dbName.ToLower()).Any())
            {
                return true;
            }
            return false;
        }
    }
}
