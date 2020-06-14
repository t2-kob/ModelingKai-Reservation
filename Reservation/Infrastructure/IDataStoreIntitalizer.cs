using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure
{
    public interface IDataStoreIntitalizer
    {
        void CreateDataStore();
        void CleanUpDateStore();
    }
}
