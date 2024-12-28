using Microsoft.EntityFrameworkCore;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Services.Contracts;
using System.Net;

namespace S11.ProxyDesignPattern.Sample01.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _dbContext;
        public PersonRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region [- Insert() -]
       public async Task<IResponse<Person>> Insert(Person model)
        {
             try
            {
                if (model is null)
                {
                    return new Response<Person>(false, HttpStatusCode.UnprocessableContent,"NullInput", null);
                }
                await _dbContext.AddAsync(model);
                var response = new Response<Person>(true, HttpStatusCode.OK,"SuccessfullOperation", model);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region [- SelectAll() -]
        public async Task<IResponse<IEnumerable<Person>>> SelectAll()
        {
            try
            {
                var persons = await _dbContext.Person.AsNoTracking().ToListAsync();
                return persons is null ? 
                    new Response<IEnumerable<Person>>(false, HttpStatusCode.UnprocessableContent, "NullInput", null) :
                    new Response<IEnumerable<Person>>(true, HttpStatusCode.OK, "SuccessfullOperation",persons);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}

