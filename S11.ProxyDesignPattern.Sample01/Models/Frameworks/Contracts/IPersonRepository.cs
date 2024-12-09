using S11.ProxyDesignPattern.Sample01.Models.DomainModels;

namespace S11.ProxyDesignPattern.Sample01.Models.Frameworks.Contracts
{
    public interface IPersonRepository
    {
        Task Insert(Person person);
    }
}
