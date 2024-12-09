using S11.ProxyDesignPattern.Sample01.ApplicationServices.Dtos.Person;

namespace S11.ProxyDesignPattern.Sample01.ApplicationServices.Frameworks.Contracts
{
    public interface IPersonService
    {
        Task Post(PostPersonDto model);
    }
}
