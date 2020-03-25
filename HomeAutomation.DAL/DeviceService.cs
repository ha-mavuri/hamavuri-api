using HomeAutomation.Common.Database;
using HomeAutomation.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace HomeAutomation.DAL
{
    public class DeviceService: IDbService<Device>
    {
        private IMongoCollection<Device> _devices = null;
        public DeviceService(IDb<IMongoDatabase> database)
        {
            IMongoDatabase databaseInstance = database.Instance;
            _devices = databaseInstance.GetCollection<Device>("Devices");
        }

        public void Delete(Device deviceToRemove)
        {
            _devices.DeleteOne(device => device.Id == deviceToRemove.Id);
        }

        public void Delete(string deviceIdToRemove)
        {
            _devices.DeleteOne(device => device.Id == deviceIdToRemove);
        }

        public Device Get(string deviceId)
        {
            return _devices.Find<Device>(device => device.Id == deviceId).FirstOrDefault();
        }

        public List<Device> GetAll()
        {
            return _devices.Find(device => true).ToList();
        }

        public Device Insert(Device device)
        {
            _devices.InsertOne(device);
            return device;
        }

        public bool Update(string deviceId, Device deviceToUpdate)
        {
            ReplaceOneResult updateResult = _devices.ReplaceOne(device => device.Id == deviceId, deviceToUpdate);
            return updateResult.IsAcknowledged;
        }
    }
}
