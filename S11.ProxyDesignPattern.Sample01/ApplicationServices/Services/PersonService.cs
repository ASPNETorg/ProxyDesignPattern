using S11.ProxyDesignPattern.Sample01.ApplicationServices.Contracts;
using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Services.Contracts;
using SinglePage.Sample01.ApplicationServices.Dtos.PersonDtos;
using System.Net;

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

        #region [- Convertor -]
        public static Person DtoConvertor(PostPersonServiceDto dto)
        {
            Models.DomainModels.Person model = new()
            {
                FName = dto.Firstname,
                LName = dto.Lastname,
                Email = dto.Email,
            };
            return model;

        }
        #endregion

        #region [- Get -]
        public async Task<IResponse<GetPersonServiceDto>> Get(GetPersonServiceDto dto)
        {
           var preson = new Person()
           {
               Id = dto.Id,
               FName = dto.Firstname,
               LName = dto.Lastname,
               Email = dto.Email,
           };
           var selectResponse = await _personRepository.Select(preson);
             var getPersonServiceDto = new GetPersonServiceDto()
            {
                Id = selectResponse.Value.Id,
                Firstname = selectResponse.Value.FName,
                Lastname = selectResponse.Value.LName,
                Email = selectResponse.Value.Email
            };
            var response = new Response<GetPersonServiceDto>(true, HttpStatusCode.OK,"SuccessfullOperation", getPersonServiceDto);
            return response;
        } 
        #endregion

        #region [- GetAll -]
        public async Task<IResponse<GetAllPersonServiceDto>> GetAll()
        {
            var selectAllResponse = await _personRepository.SelectAll();
            if (selectAllResponse is null)
            {
                return new Response<GetAllPersonServiceDto>(false, HttpStatusCode.UnprocessableContent, "NullInput", null);
            }

            if (!selectAllResponse.IsSuccessful)
            {
                return new Response<GetAllPersonServiceDto>(false, HttpStatusCode.UnprocessableContent, "Error", null);
            }
            var getAllPersonDto = new GetAllPersonServiceDto() { GetPersonServiceDtos = new List<GetPersonServiceDto>() };
            foreach (var item in selectAllResponse.Value)
            {
                var personDto = new GetPersonServiceDto()
                {
                    Id = (Guid)item.Id,
                    Firstname = item.FName,
                    Lastname = item.LName,
                    Email = item.Email
                };
                getAllPersonDto.GetPersonServiceDtos.Add(personDto);
            }

            var response = new Response<GetAllPersonServiceDto>(true, HttpStatusCode.OK, "SuccessfullOperation", getAllPersonDto);
            return response;
        }
        #endregion

        #region [- Post -]
        public async Task<IResponse<PostPersonServiceDto>> Post(PostPersonServiceDto model)
        {
            //var p = _personRepository.Insert(PersonService.DtoConvertor(model));
            //return p;
            var PostedpPerson = new Person()
            {
                Id = new Guid(),
                FName = model.Firstname,
                LName = model.Lastname,
                Email = model.Email,
            };
            var insrtedPerson = await _personRepository.Insert(PostedpPerson);
            var response = new Response<PostPersonServiceDto>(true, HttpStatusCode.OK, "SuccessfullOperation", model);
            return response;
        }
        #endregion

        #region [- IService() -]
        Task<IResponse<PostPersonServiceDto>> IService<PostPersonServiceDto, GetPersonServiceDto, GetAllPersonServiceDto>.Post(PostPersonServiceDto dto)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
