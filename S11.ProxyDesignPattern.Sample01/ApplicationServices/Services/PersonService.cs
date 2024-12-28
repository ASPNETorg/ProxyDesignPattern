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
        public Task<IResponse<GetPersonServiceDto>> Get(GetPersonServiceDto dto)
        {
            throw new NotImplementedException();
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
        public Task Post(PostPersonServiceDto model)
        {
            var p = _personRepository.Insert(PersonService.DtoConvertor(model));
            return p;
        } 
        #endregion

        Task<IResponse<PostPersonServiceDto>> IService<PostPersonServiceDto, GetPersonServiceDto, GetAllPersonServiceDto>.Post(PostPersonServiceDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
