using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;
using SinglePage.Sample01.ApplicationServices.Dtos.PersonDtos;

namespace S11.ProxyDesignPattern.Sample01.ApplicationServices.Contracts
{
    public interface IPersonService : 
        IService<PostPersonServiceDto, GetPersonServiceDto, GetAllPersonServiceDto>
    {
       
    }
}
