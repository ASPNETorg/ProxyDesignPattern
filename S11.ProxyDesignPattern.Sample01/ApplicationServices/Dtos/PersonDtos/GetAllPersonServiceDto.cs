using SinglePage.Sample01.ApplicationServices.Dtos.PersonDtos;

namespace S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person
{
    public class GetAllPersonServiceDto
    {
       public List<GetPersonServiceDto> GetPersonServiceDtos { get; set; }
    }
}
