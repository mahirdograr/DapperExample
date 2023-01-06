using Microsoft.AspNetCore.Mvc;
using productwebsitetest.Models;
using productwebsitetest.Repository;

namespace productwebsitetest.Controllers
{
    public class PersonelController : Controller
    {
        private readonly PersonelRepository personelRepository;

        public PersonelController()
        {
            personelRepository = new PersonelRepository();
        }


        [HttpGet]
        public List<Personel> GetAll()
        {
            return personelRepository.GetAll();
        }

        [HttpGet]
        public Personel GetById(int id)
        {
            return personelRepository.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody]Personel pers)
        {
            if (ModelState.IsValid)
            {
                personelRepository.Add(pers);
            }
        }

        [HttpPost]
        public void Add(int id,[FromBody] Personel pers)
        {
            pers.Id = id;
            if (ModelState.IsValid)
            {
                personelRepository.Add(pers);
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            personelRepository.Delete(id);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
