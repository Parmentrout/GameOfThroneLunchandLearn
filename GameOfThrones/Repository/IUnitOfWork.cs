using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameOfThrones.Repository.Models;

namespace GameOfThrones.Repository
{
    public interface IUnitOfWork
    {
        IQueryable<House> GetHouses();

        IQueryable<Person> GetPeople();

        Person FindPersonById(int id);

        void UpdatePerson(Person person);

        void Save();
    }
}