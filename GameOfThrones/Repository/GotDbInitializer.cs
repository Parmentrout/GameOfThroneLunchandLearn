using GameOfThrones.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameOfThrones.Repository
{
    public class GotDbInitializer : CreateDatabaseIfNotExists<GotContext>
    {
        protected override void Seed(GotContext context)
        {
            List<House> houses = new List<House>()
            {
                new House() {HouseName = "Targaryen", Location = "Dragon Stone",
                    People = new List<Person>() {
                        new Person() { Name = "Danearys Targaryen", IsAlive = true},
                        new Person() { Name = "Mad King", IsAlive = false}
                    }},
                new House() {HouseName = "Lannister", Location = "Casterly Rock",
                     People = new List<Person>() {
                            new Person() { Name = "Cersei Lannister", IsAlive = true},
                            new Person() { Name = "Jaime Lannister", IsAlive = true},
                            new Person() { Name = "Joffrey Lannister", IsAlive = false}
                        }},
                new House() {HouseName = "Stark", Location = "North",  People = new List<Person>() {
                            new Person() { Name = "Ned Stark", IsAlive = false},
                            new Person() { Name = "John Snow", IsAlive = true},
                            new Person() { Name = "Arya Stark", IsAlive = true},
                            new Person() { Name = "Rob Stark", IsAlive = false},
                            new Person() { Name = "Catlyn Stark", IsAlive = false}
                        }},
            };

            foreach (var house in houses)
            {
                context.Houses.Add(house);
            }

            base.Seed(context);
        }
    }
}