using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GameOfThrones.Repository.Models;

namespace GameOfThrones.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private GotContext _context;

        public UnitOfWork(GotContext context)
        {
            _context = context;
        }

        public IQueryable<House> GetHouses()
        {
            return _context.Houses;
        }

        public IQueryable<Person> GetPeople()
        {
            return _context.People;
        }

        public Person FindPersonById(int id)
        {
            return _context.People.Find(id);
        }

        public void UpdatePerson(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}