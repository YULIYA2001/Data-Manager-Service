using System;
using System.Collections.Generic;
using ServiceLayer.DTO;

namespace ServiceLayer.Interfaces
{
    public interface IPersonService
    {
        PersonDTO GetPerson(string connectionString, int id);
    }
}
