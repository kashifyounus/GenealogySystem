using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FamilyTreeSystem.Models;
using FamilyTreeSystem;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyTreeSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FTSContext Context;
        private readonly IMapper Mapper;

        public HomeController(ILogger<HomeController> logger, 
                              FTSContext context,
                              IMapper mapper)
        {
            _logger = logger;
            Context = context;
            Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPerson()
        {
            var vm = new PersonVM();
            vm.Parents = new List<SelectListItem>();
            var parentList = Context.MartialRelations.Include(x=>x.Husband).Include(x=>x.Wife).ToList();
            foreach (var p in parentList)
            {
                vm.Parents.Add(new SelectListItem() 
                { 
                    Text = p.Husband.FullName + "<--->" + p.Wife.FullName,
                    Value = p.Id.ToString()
                });
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddPerson(PersonVM vm)
        {
            var person = new Person();
            person.FirstName = vm.FirstName;
            person.LastName = vm.LastName;
            person.DOB = vm.DOB;
            person.Age = vm.Age;
            person.City = vm.City;
            person.Profession = vm.Profession;
            person.Reference = vm.Reference;
            person.Town = vm.Town;
            Context.Persons.Add(person);
            Context.SaveChanges();
            if (vm.ParentId > 0)
            {
                var couple = Context.MartialRelations.Find(vm.ParentId);
                if (couple != null)
                {
                    var family = new FamilyTree
                    {
                        PersonId = person.Id
                    };
                    Context.FamilyTrees.Add(family);
                    Context.SaveChanges();
                }              
            }
            
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
