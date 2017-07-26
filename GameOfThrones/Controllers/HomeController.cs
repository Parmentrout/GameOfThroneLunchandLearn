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

        private IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new GotContext());
        }

        public ActionResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View();
        }

        public ActionResult Read()
        {
            ViewBag.Message = "GOT Houses";

            IQueryable<House> query = _unitOfWork.GetHouses();
            ViewBag.Houses = query.ToList();

            return View();
        }

        //Without Repository Pattern
        public ActionResult Edit()
        {
            var viewModel = new EditViewModel();
            List<Person> people = _unitOfWork.GetPeople().AsNoTracking().ToList();
          
            viewModel.People = people.Select(p => new SelectListItem() { Text = p.Name, Value = p.PersonId.ToString() });

            return View(viewModel);
        }

        public ActionResult SaveEdit(EditViewModel viewModel)
        {
           
            var person = _unitOfWork.FindPersonById(viewModel.SelectedPerson);

            if (person != null)
            {
                var animal = new Pet()
                {
                    Name = viewModel.PetName,
                    PersonId = person.PersonId,
                    PetType = (PetType) Enum.Parse(typeof(PetType), viewModel.SelectedPetType)
                };

                person.Pets.Add(animal);
                _unitOfWork.UpdatePerson(person);
            }

            _unitOfWork.Save();

            return View();
        }
    }
}