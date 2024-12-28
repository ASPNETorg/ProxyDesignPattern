using Microsoft.EntityFrameworkCore;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks;
using S11.ProxyDesignPattern.Sample01.Frameworks.ResponseFrameworks.Contracts;
using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Services.Contracts;
using System;
using System.Net;

namespace S11.ProxyDesignPattern.Sample01.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _dbContext;
        #region [- Ctor -]
        public PersonRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        #endregion

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
                var person = await _dbContext.Person.AsNoTracking().ToListAsync();
                return person is null ? 
                    new Response<IEnumerable<Person>>(false, HttpStatusCode.UnprocessableContent, "NullInput", null) :
                    new Response<IEnumerable<Person>>(true, HttpStatusCode.OK, "SuccessfullOperation",person);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region [- Select() -]
        public async Task<IResponse<Person>> Select(Person model)
        {
            try
            {
                var responseValue = new Person();
                if (model.Id.ToString() != "")
                {
                    //responseValue = await _projectDbContext.Person.FindAsync(person.Email);
                    responseValue = await _dbContext.Person.Where(c => c.Email == model.Email).SingleOrDefaultAsync();
                }
                else
                {
                    responseValue = await _dbContext.Person.FindAsync(model.Id);
                }
                return responseValue is null ?
                     new Response<Person>(false, HttpStatusCode.UnprocessableContent, "NullInput", null) :
                     new Response<Person>(true, HttpStatusCode.OK, "SuccessfullOperation", responseValue);
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion
    }
}

