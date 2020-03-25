using MongoDB.Driver;

namespace HomeAutomation.Common.Database
{
    public class MongoDbClient : IDbClient<IMongoClient>
    {
        private string _connectionString;
        public MongoDbClient(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IMongoClient Connection
        {
            get
            {
                return new MongoClient(_connectionString);
            }
        }
    }
}
