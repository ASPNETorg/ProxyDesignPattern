using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks.Contracts;

namespace S11.ProxyDesignPattern.Sample01.ApplicationServices.Contracts
{
    public interface IService<TPost,TGet, TGetAll>
    {
        Task<IResponse<TGetAll>> GetAll();

        Task<IResponse<TGet>> Get(TGet dto);
        Task<IResponse<TPost>> Post(TPost dto);

    }
}
