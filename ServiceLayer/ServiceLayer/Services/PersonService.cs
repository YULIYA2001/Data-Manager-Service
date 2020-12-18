using System.Collections.Generic;
using ServiceLayer.DTO;
using ServiceLayer.Interfaces;
using ServiceLayer.Infrastructure;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using System.IO;

namespace ServiceLayer.Services
{
    public class PersonService : IPersonService
    {
        public PersonDTO GetPerson(string connectionString, int id)
        {
            Person person = new Person();
            List<Person> personList = new PersonRepository().GetDataFromDB(connectionString);
            if (personList.Count < id)
                throw new ValidationException("Человек не найден", "");
            else
                person = personList[id-1];
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                PhoneNumberType = person.PhoneNumberType,
                Address = person.Address,
                City = person.City,
                Province = person.Province,
                Country = person.Country
            };
        }
    }
}
