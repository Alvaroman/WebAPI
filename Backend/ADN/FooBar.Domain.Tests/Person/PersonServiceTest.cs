using FooBar.Domain.Exception;
using FooBar.Domain.Ports;
using FooBar.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading.Tasks;

namespace FooBar.Domain.Tests.Person
{
    [TestClass]
    public class PersonServiceTest
    {

        IGenericRepository<FooBar.Domain.Entities.Person> _personRepository = default!;
        PersonService _personService = default!;

        [TestInitialize]
        public void Init(){
            _personRepository = Substitute.For<IGenericRepository<FooBar.Domain.Entities.Person>>();
            _personService = new PersonService(_personRepository);
        }

        [TestMethod]
        public async Task FailToRegisterAnUnderagePerson()
        {
            try
            {
                Domain.Entities.Person newborn = new()
                {
                    FirstName = "john",
                    LastName = "doe",
                    Email = "johndoe@foo.bar",
                    DateOfBirth = System.DateTime.Now
                };
                await _personService.RegisterPersonAsync(newborn);
            }catch(System.Exception ex){
                Assert.IsTrue(ex is UnderAgeException);
            }
        }

        [TestMethod]
        public async Task SuccessToRegisterPerson()
        {
            FooBar.Domain.Entities.Person older = new()
            {
                FirstName = "john",
                LastName = "doe",
                Email = "johndoe@foo.bar",
                DateOfBirth = System.DateTime.Now.AddYears(-20)
            };

            _personRepository.AddAsync(Arg.Any<FooBar.Domain.Entities.Person>()).Returns(Task.FromResult(
                new PersonDataBuilder()
                    .WithName(older.FirstName)
                    .WithLastName(older.LastName)
                    .WithEmail(older.Email)
                    .WithDateOfBirth(older.DateOfBirth).Build()
            ));

            var result = await _personService.RegisterPersonAsync(older);

            Assert.IsTrue(result is FooBar.Domain.Entities.Person && result?.Id is not null);
        }
    }
}
