using Microsoft.EntityFrameworkCore.Metadata.Internal;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Convertor.Frameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Frameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Frameworks.Contracts;

namespace S11.ProxyDesignPattern.Sample01.ApplicationServices.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        #region [- Ctor -]
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion
        private readonly IConvertor<PostPersonDto, Person> _personConvertor;

        public PersonService(IConvertor<PostPersonDto, Person> personConverter)
        {
            _personConvertor = personConverter;
        }

        //private static Person DtoConvertor(PostPersonDto dto)
        //{
        //    Models.DomainModels.Person model = new Models.DomainModels.Person
        //    {
        //        FName = dto.FName,
        //        LName = dto.LName
        //    };
        //    return model;

        //}
        public Task Post(PostPersonDto model)
        {
            //var p = _personRepository.Insert(PersonService.DtoConvertor(model));
            //return p;
            var p = _personRepository.Insert(_personConvertor.Convert(model));
            return p;
        }


    }
}
