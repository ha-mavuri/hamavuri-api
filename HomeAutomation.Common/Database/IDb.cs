using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomation.Common.Database
{
    public interface IDb<T> where T : class
    {
        T Instance
        {
            get;
        }
        bool CheckIfDBExists(string dbName);
    }
}
