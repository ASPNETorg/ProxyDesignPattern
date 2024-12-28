using Microsoft.AspNetCore.Mvc;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Contracts;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Services.Contracts;

namespace S11.ProxyDesignPattern.Sample01.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        #region [- Ctor -]
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        #endregion

        #region [- Index() -]
        public IActionResult Index()
        {
            return View();
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

        #region [- Post() -]
        [HttpPost]
        //public async Task<IActionResult> Post([FromBody] PostPersonServiceDto dto)
        //{
        //    Guard_PersonService();
        //    var postedDto = new GetPersonServiceDto() { Email = dto.Email };
            //var getResponse = await _personService.Get(postedDto);

        //    if (ModelState.IsValid && getResponse.Value is null)
        //    {
        //        //var postResponse = await _personService.Post(dto);
        //        return postResponse.IsSuccessful ? Ok() : BadRequest();
        //    }
        //    else if (ModelState.IsValid && getResponse.Value is not null)
        //    {
        //        return Conflict(dto);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
       
        #endregion

        #region [- PersonServiceGuard() -]
        private ObjectResult Guard_PersonService()
        {
            if (_personService is null)
            {
                return Problem($" {nameof(_personService)} is null.");
            }

            return null;
        }
        #endregion
    }
}
