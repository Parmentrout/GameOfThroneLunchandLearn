using GameOfThrones.Models;
using GameOfThrones.Repository;
using GameOfThrones.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameOfThrones.App_Start;

namespace GameOfThrones.Controllers
{
    [Log]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View();
        }

        public ActionResult Read()
        {
            ViewBag.Message = "GOT Houses";

            var context = new GotContext();
            IQueryable<House> query = context.Houses;

            ViewBag.Houses = query.ToList();

            return View();
        }

        //Without Repository Pattern
        public ActionResult Edit()
        {
            var viewModel = new EditViewModel();
            List<Person> people;
            using (var context = new GotContext())
            {
                people = context.People.AsNoTracking().ToList();
            }
            viewModel.People = people.Select(p => new SelectListItem() { Text = p.Name, Value = p.PersonId.ToString() });

            return View(viewModel);
        }

        public ActionResult SaveEdit(EditViewModel viewModel)
        {
            //Save data
            using (var context = new GotContext())
            {
                var person = context.People.Find(viewModel.SelectedPerson);

                if (person != null)
                {
                    var animal = new Pet()
                    {
                        Name = viewModel.PetName,
                        PersonId = person.PersonId,
                        PetType = (PetType) Enum.Parse(typeof(PetType), viewModel.SelectedPetType)
                    };

                    person.Pets.Add(animal);
                }

                context.SaveChanges();
            }

            return View("Edit", viewModel);
        }
    }
}