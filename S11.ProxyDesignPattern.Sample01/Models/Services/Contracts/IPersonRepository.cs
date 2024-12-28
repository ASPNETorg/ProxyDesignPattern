using S11.ProxyDesignPattern.Sample01.Models.DomainModels;

namespace S11.ProxyDesignPattern.Sample01.Models.Services.Contracts
{
    public interface IPersonRepository: IRepository<Person, IEnumerable<Person>>
    {
       
    }
}
