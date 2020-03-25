using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomation.Common.Database
{
    public interface IDbClient<T> where T: class
    {
        T Connection
        {
            get;
        }
    }
}