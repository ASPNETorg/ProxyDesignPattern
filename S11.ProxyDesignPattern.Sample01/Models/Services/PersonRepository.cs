using S11.ProxyDesignPattern.Sample01.Models.DomainModels;
using S11.ProxyDesignPattern.Sample01.Models.Frameworks.Contracts;

namespace S11.ProxyDesignPattern.Sample01.Models.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _dbContext;
        public PersonRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region [- Insert() -]
        public async Task Insert(Person person)
        {
            using (_dbContext)
            {
                try
                {
                    var p = new Person()
                    {
                        Id = Guid.NewGuid(),
                        FName = person.FName,
                        LName = person.LName,
                    };

                    _dbContext.Person.Add(p);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_dbContext.Person != null) _dbContext.Dispose();
                }
            }
        }
        #endregion

    }
}

