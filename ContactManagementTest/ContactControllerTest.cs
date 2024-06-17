using ContactManagementAPI.Controllers;
using ContactManagementAPI.Model;
using ContactManagementAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace ContactManagementTest
{
    [TestFixture]
    public class ContactControllerTest
    {
        private ContactsController _controller;
        private Mock<ContactService> _mockContactService;

        [SetUp]
        public void Setup()
        {
            _mockContactService = new Mock<ContactService>();
        }

        [Test]
        public void GetContactByIdTest_Success()
        {
            // Arrange
            int Id = 1;
            var expectedContact = new ContactModel { ID = Id, FirstName = "Tejashree", LastName = "Egade", Email = "tejuegade@gamil.com" };
       
            _mockContactService.Setup(service => service.GetContactById(1)).Returns(expectedContact);

            // Act
            var result = _controller.GetContactById(Id);

            // Assert
            NUnit.Framework.Assert.Equals(expectedContact, result);
        }

        [Test]
        public void GetContactByIdTest_Error()
        {
            // Arrange
            int id = 999;
            _mockContactService.Setup(service => service.GetContactById(id)).Returns(new ContactModel { ID = 0 });

            // Act
            var result = _controller.GetContactById(id);

            // Assert
            NUnit.Framework.Assert.Equals(typeof(NoContentResult), result);
        }

        [Test]
        public void GetAllContacts_ReturnsOkResultWithData()
        {
            // Arrange
            var expectedData = new List<ContactModel>
            {
                new ContactModel { ID = 1, FirstName = "John", LastName="Doe", Email = "john@example.com" },
                new ContactModel { ID = 2, FirstName = "Jane", LastName = "Smith", Email= "jane@example.com" }
            };
            _mockContactService.Setup(service => service.GetAllContacts()).Returns(expectedData);

            // Act
            var result = _controller.GetAllContacts();

            // Assert
            NUnit.Framework.Assert.Equals(expectedData, result);
           
        }

        [Test]
        public void GetAllContacts_ReturnsNoContent()
        {
            // Arrange
            List<ContactModel> nullData = null;
            _mockContactService.Setup(service => service.GetAllContacts()).Returns(nullData);

            // Act
            var result = _controller.GetAllContacts();

            // Assert
            NUnit.Framework.Assert.Equals(nullData, result);
        }


        [Test]
        public void CreateContact_Test()
        {
            // Arrange
            var newContact = new ContactModel { FirstName = "Tejashree", LastName = "Egade", Email = "teja@example.com" };

            // Act
            var result = _controller.CreateContact(newContact);

            // Assert
            NUnit.Framework.Assert.Equals(newContact, result);
        }

        [Test]
        public void UpdateContact_Test()
        {
            // Arrange
            var existingContact = new ContactModel { ID = 1, FirstName = "Teja", LastName = "Egade1", Email = "egadeTeja@example.com" };

            // Act
            var result = _controller.Update(existingContact);

            // Assert
            NUnit.Framework.Assert.Equals(existingContact, result);
        }

        [Test]
        public void DeleteContact_Test()
        {
            // Arrange
            int existingId = 1;

            // Act
            _controller.Delete(existingId);

            // Assert
            _mockContactService.Verify(service => service.DeleteContact(existingId), Times.Once);
        }

    }
}