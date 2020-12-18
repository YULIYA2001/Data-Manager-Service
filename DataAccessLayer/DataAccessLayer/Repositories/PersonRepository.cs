using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        public List<Person> GetDataFromDB(string connectionString)
        {            
            List<Person> persons = new List<Person>();
            string sqlExpression = "sq_GetPersonInformation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Person person = new Person();
                        person.Id = reader.GetInt32(0);
                        person.FirstName = reader.GetString(1);
                        person.LastName = reader.GetString(2);
                        person.Email = reader.GetString(3);
                        person.PhoneNumber = reader.GetString(4);
                        person.PhoneNumberType = reader.GetString(5);
                        person.Address = reader.GetString(6);
                        person.City = reader.GetString(7);
                        person.Province = reader.GetString(8);
                        person.Country = reader.GetString(9);
                        persons.Add(person);
                    }
                }
                reader.Close();
            }
            return persons;
        }
    }
}
