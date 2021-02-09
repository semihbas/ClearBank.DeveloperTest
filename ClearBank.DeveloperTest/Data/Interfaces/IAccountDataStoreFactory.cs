using System;
namespace ClearBank.DeveloperTest.Data.Interfaces
{
    public interface IAccountDataStoreFactory
    {
        IAccountDataStore GetInstance();
    }
}
