using HomeAutomation.Common.Database;
using HomeAutomation.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HomeAutomation.DAL
{
    public class ApplianceService : IDbService<Appliance>
    {
        private readonly IMongoCollection<Appliance> _appliances = null;
        public ApplianceService(IDb<IMongoDatabase> database)
        {
            IMongoDatabase databaseInstance = database.Instance;
            _appliances = databaseInstance.GetCollection<Appliance>("Devices");
        }

        public void Delete(Appliance applianceToRemove)
        {
            _appliances.DeleteOne(appliance => appliance.Id == applianceToRemove.Id);
        }

        public void Delete(string applianceIdToRemove)
        {
            _appliances.DeleteOne(appliance => appliance.Id == applianceIdToRemove);
        }

        public Appliance Get(string applianceId)
        {
            return _appliances.Find<Appliance>(appliance => appliance.Id == applianceId).FirstOrDefault();
        }

        public List<Appliance> GetAll()
        {
            return _appliances.Find(appliance => true).ToList();
        }

        public Appliance Insert(Appliance appliance)
        {
            _appliances.InsertOne(appliance);
            return appliance;
        }

        public bool Update(string applianceId, Appliance applianceToUpdate)
        {
            ReplaceOneResult updateResult = _appliances.ReplaceOne(appliance => appliance.Id == applianceId, applianceToUpdate);
            return updateResult.IsAcknowledged;
        }
    }
}
