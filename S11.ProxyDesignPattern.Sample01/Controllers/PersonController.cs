using Microsoft.AspNetCore.Mvc;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Frameworks.Contracts;

namespace S11.ProxyDesignPattern.Sample01.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        #region [- Ctor -]
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- Create Post -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FName,LName")] Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepository.Insert(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        #endregion
    }
}
