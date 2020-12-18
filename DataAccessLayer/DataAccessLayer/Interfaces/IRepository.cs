using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetDataFromDB(string connectionString);
    }
}
