using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure
{
    public interface IDataStoreInitializer
    {
        void CreateDataStore();
        void CleanUpDateStore();
    }
}
