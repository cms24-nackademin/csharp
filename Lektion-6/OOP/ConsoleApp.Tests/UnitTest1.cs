using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Net;

namespace ConsoleApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddContactToList__Should_AddContactPersonToList__ReturnTrue()
        {
            // arrange
            var contactService = new ContactService();
            var contactPerson = new ContactPerson
            {
                FirstName = "Hans",
                LastName = "Mattin-Lassei",
                Email = "hans@domain.com",
                PhoneNumber = "+46 73 123 45 67",

                PostalAddress = new Address
                {
                    StreetName = "Nordkapsvägen 1",
                    PostalCode = "136 57",
                    City = "Vega"
                }
            };


            // act
            var result = contactService.AddContactToList(contactPerson);

            // assert
            Assert.True(result.Succeeded);

        }


        [Fact]
        public void AddDuplicateContactPersons__Should_NotAddContactPersonToList__ReturnFalse()
        {
            // arrange
            var contactService = new ContactService();
            var contactPerson = new ContactPerson
            {
                Email = "hans@domain.com",
            };
            contactService.AddContactToList(contactPerson);

            // act
            var result = contactService.AddContactToList(contactPerson);


            // assert
            Assert.False(result.Succeeded);
            Assert.Equal("A contact person with the same email already exists.", result.Message);

        }
    }
}